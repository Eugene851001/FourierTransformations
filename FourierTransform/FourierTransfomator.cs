using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Linq;

namespace FourierTransform
{
    class FourierTransfomator
    {
        private double phase;
        private double amplitude;

        private double[] sinTable;
        private int samplingRate;

        private double[] cosAmplitudes;
        private double[] sinAmplitudes;
        private double[] amplitudes;
        private double[] phases;

        public double[] CosAmplitudes { get => cosAmplitudes; }
        public double[] SinAmplitudes { get => sinAmplitudes; }
        public double[] Amplitudes { get => amplitudes; }
        public double[] Phases { get => phases; }

        public FourierTransfomator(int samplingRate)
        {
            this.samplingRate = samplingRate;
            this.sinTable = new double[samplingRate];
            for (int i = 0; i < sinTable.Length; i++)
            {
                sinTable[i] = Math.Sin(2 * Math.PI * i  / samplingRate);
            }
        }

        public void CalculateHFFilter(double[] signal, int maxFequency, int filterFrequency) =>
            HelpCalculate(signal, maxFequency, (i) => i > filterFrequency);

        public void CalculateLFFilter(double[] signal, int maxFrequency, int filterFrequency) =>
            HelpCalculate(signal, maxFrequency, (i) => i < filterFrequency);

        public void Calculate(double[] signal, int maxFrequency) => 
            HelpCalculate(signal, maxFrequency, (_) => true);

        public void HelpCalculate(double[] signal, int maxFrequency, Func<int, bool> filter)
        {
            if (maxFrequency * 2 > this.samplingRate)
            {
                throw new ArgumentOutOfRangeException(nameof(maxFrequency));
            }

            this.sinAmplitudes = new double[maxFrequency];
            this.cosAmplitudes = new double[maxFrequency];
            this.amplitudes = new double[maxFrequency];
            this.phases = new double[maxFrequency];

            for (int i = 0; i < maxFrequency; i++)
            {
                if (!filter(i))
                {
                    continue;
                }

                var (aCos, aSin) = this.GetAmplitude(signal, i);
                this.sinAmplitudes[i] = aSin;
                this.cosAmplitudes[i] = aCos;
                this.amplitudes[i] = Math.Sqrt(aSin * aSin + aCos * aCos);
                this.phases[i] = Math.Atan2(aCos, aSin);
            }
        }

        public void CalculateFast(double[] signal, int maxFrequency, Func<int, bool> filter = null)
        {
            Complex[] result = FastFourierTransformator
                .FFT(signal.Select(value => new Complex(value, 0)).ToArray());

            this.phases = new double[maxFrequency];
            this.amplitudes = new double[maxFrequency];
            this.cosAmplitudes = new double[maxFrequency];
            this.sinAmplitudes = new double[maxFrequency];

            for (int i = 0; i < maxFrequency; i++)
            {
                if (filter != null && !filter(i))
                {
                    continue;
                }

                this.phases[i] = -result[i].Phase;
                this.amplitudes[i] = result[i].Magnitude * 2 / signal.Length;
                this.cosAmplitudes[i] = result[i].Real * 2 / signal.Length;
                this.sinAmplitudes[i] = result[i].Imaginary * 2 / signal.Length;
            }
        }

        public (double re, double im) GetAmplitude(double[] signal, int j)
        {
            double im = 0;
            double re = 0;
            for (int i = 0; i < samplingRate; i++)
            {
                re += signal[i] * this.sinTable[(j * i) % this.samplingRate];
                im += signal[i] * this.sinTable[(j * i + this.samplingRate / 4) % this.samplingRate];
            }

            return (re * 2 / this.samplingRate, im * 2 / this.samplingRate);
        }

        public double[] RecoverGarmonicSignal() => RecoverSignal(2, true);

        public double[] RecoverPolygarmonicSignal() => RecoverSignal(this.samplingRate / 2, true);


        public double[] RecoverSignal(int maxFrequency, bool withPhase)
        {
            int k = withPhase ? 1 : 0;
            var result = new double[this.samplingRate];

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < maxFrequency; j++)
                {
                    result[i] += this.amplitudes[j] * Math.Cos(2 * Math.PI * i * j / this.samplingRate - this.phases[j] * k);
                }
            }

            return result;
        }
    }
}
