using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourierTransform
{
    public static class SignalGenerator
    {
        public static double[] GenerateGarmonic(int n)
        {
            var result = new double[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = 10 * Math.Cos(2 * Math.PI * i / n);
            }

            return result;
        }

        public static double[] GeneratePolygarmonic(double[] amplitudes, double[] phases, int n)
        {
            var result = new double[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    result[i] += amplitudes[j % amplitudes.Length] * Math.Cos(2 * Math.PI * i * j / n - phases[j % phases.Length]);
                }
            }

            return result;
        }
    }
}
