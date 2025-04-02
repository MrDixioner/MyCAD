using System;

namespace MyCAD {
	public static class HelperClass {
		public static double DegToRad = Math.PI / 180.0;
		public static double RadToDeg = 180.0 / Math.PI;
		public static double Epsilon = 1e-12;

		public static void Direction(int index, out int horizontal, out int vertical) { 
			switch (index) {
				case 1:
					horizontal = 1;vertical = 1;
					break;
				case 2:
					horizontal = -1; vertical = -1;
					break;
				case 3:
					horizontal = -1; vertical = 1;
					break;
				default:
					horizontal = 1; vertical = -1;
					break;
			}
		}

		public static bool IsEqual(double d1, double d2) {
			return IsEqual(d1, d2, Epsilon);
		}

		public static bool IsEqual(double d1, double d2, double epsilon) {
			return IsZero(d1 - d2, Epsilon);
		}

		public static bool IsZero(double d) {
			return IsZero(d, Epsilon);
		}

		public static bool IsZero(double d, double epsilon) {
			return d >= -epsilon && d <= epsilon;
		}

		public static double CopySign(double a, double b) {
			return a * Math.Sign(b);
		}

		public static double NthRoot(double a,int n) {
			double r = a;
			double k = a / n;
			while (Math.Abs(r - k) > Epsilon) {
				k = r;
				r = (1 / n) * ((n - 1) * k + a / Math.Pow(k, n - 1));
			}
			return r;
		}

		public static int Sign(bool flg) {
			switch (flg) {
				case true:
					return -1;
				default:
					return 1;
			}
		}

		private static float DPI() {
			System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(1, 1);
			using(var g = System.Drawing.Graphics.FromImage(bmp)) {
				return g.DpiX;
			}
		}
		
		// Convert pixels to millimeters
		public static float PixelToMillimeters(float pixel) {
			return pixel * 25.4f / DPI();
		}
	}
}
