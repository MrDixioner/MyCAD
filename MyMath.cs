using System;
using System.Collections.Generic;
using System.Numerics;

namespace MyCAD {
	public static class MyMath {
		public static bool IsZero(this Complex arg) {
			return arg.Real == 0 && arg.Imaginary == 0;
		}

		public static Complex Round(this Complex arg, int n) {
			return new Complex(Math.Round(arg.Real, 12), Math.Round(arg.Imaginary, 12));
		}

		// Решение кубического уравнения
		public static List<Complex> SolvingQubicEquation(double a, double b,double c,double d) {
			List<Complex> result = new List<Complex>();

			double f = (3 * c / a - b * b / a / a) / 3;
			double g = (2 * b * b * b / a / a / a - 9 * b * c / a / a + 27 * d / a) / 27;
			double h = g * g / 4 + f * f * f / 27;
			double p = -b / 3 / a;
			double i = Math.Sqrt(g * g / 4 - h);

			if (h > 0.0) {
				double R = -g / 2 + Math.Sqrt(h);
				double S = HelperClass.NthRoot(R, 3);
				double T = -g / 2 - Math.Sqrt(h);
				double U = HelperClass.NthRoot(T, 3);

				result.Add(new Complex(S + U + p, 0));
				result.Add(new Complex(-(S + U) / 2 + p, (S - U) * Math.Sqrt(3) / 2));
				result.Add(new Complex(-(S + U) / 2 + p, -(S - U) * Math.Sqrt(3) / 2));
			} else {
				if (f == 0 && g == 0) {
					result.Add(new Complex(-HelperClass.NthRoot(d / a, 3), 0));
					result.Add(new Complex(-HelperClass.NthRoot(d / a, 3), 0));
					result.Add(new Complex(-HelperClass.NthRoot(d / a, 3), 0));
				} else {
					double j = HelperClass.NthRoot(i, 3);
					double k = Math.Acos(-g / 2 / i);
					double M = Math.Cos(k / 3);
					double N = Math.Sqrt(3) * Math.Sin(k / 3);

					result.Add(new Complex(Math.Round(2 * j * M + p, 12), 0));
					result.Add(new Complex(Math.Round(-j * (M + N) + p, 12), 0));
					result.Add(new Complex(Math.Round(-j * (M - N) + p, 12), 0));
				}
			}
			return result;
		}

		// Решение квадратного уравнения
		public static List<Complex> SolvingQuadraticEquation(double a,double b,double c,double d,double e) {
			List<Complex> result = new List<Complex>();

			double m = a;
			a /= m;
			b /= m;
			c /= m;
			d /= m;
			e /= m;

			double f = c - 3 * b * b / 8;
			double g = d + b * b * b / 8 - b * c / 2;
			double h = e - 3 * b * b * b * b / 256 + b * b * c / 16 - b * d / 4;

			double b1 = f / 2;
			double c1 = (f * f - 4 * h) / 16;
			double d1 = -g * g / 64;

			List<Complex> cubic = SolvingQubicEquation(a, b1, c1, d1);

			Complex y1 = cubic[0];
			Complex y2 = cubic[1];

			if (y1.IsZero())
				y1 = cubic[2];
			if (y2.IsZero())
				y2 = cubic[2];

			Complex p = Complex.Sqrt(y1);
			Complex q = Complex.Sqrt(y2);
			Complex r = -g / 8 / p / q;
			Complex s = new Complex(b / 4 / a, 0);

			result.Add((p + q + r - s).Round(12));
			result.Add((p - q - r - s).Round(12));
			result.Add((-p + q - r - s).Round(12));
			result.Add((-p - q + r - s).Round(12));

			return result;
		}
	}
}
