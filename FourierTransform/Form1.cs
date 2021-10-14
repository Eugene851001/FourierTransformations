using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FourierTransform
{
    public partial class tbN : Form
    {

        Chart chTimeSpecter;
        Chart chAmplitudeSpecter;
        Chart chPhaseSpecter;

        const int OriginX = 10;
        const int OriginY = 10;

        const double WidthPart = 0.75;
        const double HeightPart = 0.3;

        private Chart[] charts;

        private int n = 128;

        private int garmonicRate = 2;
        private int polygarmonicRate = 128 / 2;

        private FourierTransfomator transfomator;

        private double[] amplitudes = { 1, 3, 5, 8, 10, 12, 16 };
        private double[] phases = { Math.PI / 6, Math.PI / 4, Math.PI / 3, Math.PI / 2, 3 * Math.PI / 4, Math.PI};

        public tbN()
        {
            InitializeComponent();
            chTimeSpecter = new Chart();
            chAmplitudeSpecter = new Chart();
            chPhaseSpecter = new Chart();

            this.charts = new Chart[] { chTimeSpecter, chAmplitudeSpecter, chPhaseSpecter };

            SetScalePos(this.charts);

            for (int i = 0; i < 3; i++)
            {
                var chartArea = new ChartArea();
                chartArea.Name = "Sinus";

                charts[i].ChartAreas.Add(chartArea);
                charts[i].Legends.Add(new Legend());
            }


            
            this.Controls.AddRange(charts);

            this.transfomator = new FourierTransfomator(n);
        }

        private void SetScalePos(Chart[] charts)
        {
            int height = (int)(HeightPart * this.Height);

            for (int i = 0; i < 3; i++)
            {
                charts[i].Location = new Point(OriginX, OriginY + (height + 10) * i);
                charts[i].Width = (int)(WidthPart * this.Width);
                charts[i].Height = height;
            }

            int width = this.pnControls.Width;
            this.pnControls.Location = new Point(this.Width - width, 0);
        }

        private void btRun_Click(object sender, EventArgs e)
        {
            HelpRun();
        }

        private void HelpRun(Func<int, bool> filter = null)
        {
            if (rbGarmonic.Checked)
            {
                double[] signal = SignalGenerator.GenerateGarmonic(n);
                FindSpecters(signal, 2, filter);
            }
            else
            {
                double[] signal = SignalGenerator.GeneratePolygarmonic(amplitudes, phases, n);
                FindSpecters(signal, n / 2, filter);
            }
        }

        private void FindSpecters(double[] signal, int frequency, Func<int, bool> filter = null)
        {
            this.chTimeSpecter.Series.Clear(); 
            this.chPhaseSpecter.Series.Clear();
            this.chAmplitudeSpecter.Series.Clear();

            this.chTimeSpecter.ResetAutoValues();

            if (filter == null)
            {
                if (this.chFFT.Checked)
                {
                    this.transfomator.CalculateFast(signal, frequency, filter);
                }
                else
                {
                    this.transfomator.Calculate(signal, frequency);
                }
            } 
            else
            {
                if (this.chFFT.Checked)
                {
                    this.transfomator.CalculateFast(signal, frequency, filter);
                }
                else
                {
                    this.transfomator.HelpCalculate(signal, frequency, filter);
                }
            }

            double[] restored = this.transfomator.RecoverSignal(frequency, true);
            double[] restoredNoPhase = this.transfomator.RecoverSignal(frequency, false);

            var originalSeries = new Series();
            originalSeries.Name = "Original";
            originalSeries.ChartType = SeriesChartType.Spline;
            originalSeries.Color = Color.Red;


            var restoredSeries = new Series();
            restoredSeries.Name = "Restored";
            restoredSeries.ChartType = SeriesChartType.Spline;
            restoredSeries.Color = Color.Blue;

            var restoredNoPhaseSeries = new Series();
            restoredNoPhaseSeries.Name = "Restored With No Phase";
            restoredNoPhaseSeries.ChartType = SeriesChartType.Spline;
            restoredNoPhaseSeries.Color = Color.Green;

            for (int i = 0; i < signal.Length; i++)
            {
                originalSeries.Points.AddXY(2 * Math.PI * i / n, signal[i]);
                restoredSeries.Points.AddXY(2 * Math.PI * i / n, restored[i]);
                restoredNoPhaseSeries.Points.AddXY(2 * Math.PI * i / n, restoredNoPhase[i]);
            }

            this.chTimeSpecter.Series.Add(originalSeries);
            this.chTimeSpecter.Series.Add(restoredSeries);
            this.chTimeSpecter.Series.Add(restoredNoPhaseSeries);

            var phaseSeries = new Series();
            phaseSeries.Name = "Phase";
            phaseSeries.ChartType = SeriesChartType.Candlestick;
            phaseSeries.Color = Color.Red;
            for (int i = 1; i < frequency; i++)
            {
                phaseSeries.Points.AddXY(i, this.transfomator.Phases[i]);
            }

            this.chPhaseSpecter.Series.Add(phaseSeries);

            var amplitudeSeries = new Series();
            amplitudeSeries.Name = "Amplitude";
            amplitudeSeries.ChartType = SeriesChartType.Candlestick;
            amplitudeSeries.Color = Color.Red;

            for (int i = 1; i < frequency; i++)
            {
                amplitudeSeries.Points.AddXY(i, this.transfomator.Amplitudes[i]);
            }

            this.chAmplitudeSpecter.Series.Add(amplitudeSeries);
        }

        private void btLFFilter_Click(object sender, EventArgs e)
        {
            int filterFrequency = int.Parse(this.tbFilterFrequency.Text);

            HelpRun((i) => i < filterFrequency);
        }

        private void btHFFilter_Click(object sender, EventArgs e)
        {
            int filterFrequency = int.Parse(this.tbFilterFrequency.Text);

            HelpRun((i) => i > filterFrequency);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            SetScalePos(this.charts);
        }

        private void btSetN_Click(object sender, EventArgs e)
        {
            this.n = int.Parse(this.tbFrequency.Text);
            this.transfomator = new FourierTransfomator(this.n);
        }

        private void tbN_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
