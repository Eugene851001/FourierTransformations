using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FourierTransform
{
    class FastFourierTransformator
    {
        private static Complex WPow(int i, int N)
        {
            if (i % N == 0) return 1;
            double arg = -2 * Math.PI * i / N;
            return new Complex(Math.Cos(arg), Math.Sin(arg));
        }
       
        public static Complex[] FFT(Complex[] x)
        {
            Complex[] X;
            int N = x.Length;
            if (N == 2)
            {
                X = new Complex[2];
                X[0] = x[0] + x[1];
                X[1] = x[0] - x[1];
            }
            else
            {
                Complex[] xEven = new Complex[N / 2];
                Complex[] xOdd = new Complex[N / 2];
                for (int i = 0; i < N / 2; i++)
                {
                    xEven[i] = x[2 * i];
                    xOdd[i] = x[2 * i + 1];
                }

                Complex[] XEvenProcessed = FFT(xEven);
                Complex[] XOddProcessed = FFT(xOdd);
                X = new Complex[N];
                for (int i = 0; i < N / 2; i++)
                {
                    X[i] = XEvenProcessed[i] + WPow(i, N) * XOddProcessed[i];
                    X[i + N / 2] = XEvenProcessed[i] - WPow(i, N) * XOddProcessed[i];
                }
            }

            return X;
        }
    }
}
