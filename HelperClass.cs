using MyCAD.Entities;
using System;
using System.Collections.Generic;

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

		public static double DeterminePointOfLine(Line line, Vector3 v) {
			return (v.X - line.StartPoint.X) * (line.EndPoint.Y - line.StartPoint.Y) - (v.Y - line.StartPoint.Y) * (line.EndPoint.X - line.StartPoint.X);
		}

		public static bool DeterminePointOfArc(Arc arc, Vector3 point) {
			double a1 = arc.StartPoint.AngleWith(arc.Center) + 90;
			double a2 = arc.EndPoint.AngleWith(arc.Center) - 90;

			Vector3 v1 = arc.StartPoint.Transfer2D(50, a1);
			Vector3 v2 = arc.EndPoint.Transfer2D(50, a2);

			Entities.Line l1 = new Entities.Line(v1, arc.StartPoint);
			Entities.Line l2 = new Entities.Line(arc.EndPoint, v2);
			Entities.Line l3 = new Entities.Line(arc.StartPoint, arc.EndPoint);

			bool flg = Method.IsPointInsidePie(arc, point);
			double d1 = DeterminePointOfLine(l1, point);
			double d2 = DeterminePointOfLine(l2, point);
			double d3 = DeterminePointOfLine(l3, point);

			bool flg1 = (d1 > 0) ? false : true;
			bool flg2 = (d2 > 0) ? false : true;
			bool flg3 = (d3 > 0) ? false : true;

			if (flg || (flg1 && flg2 && flg3))
				return true;

			return false;
		}

		public static bool DeterminePointOfCircle(Circle circle,Vector3 point) {
			double d = circle.Center.DistanceFrom(point);
			return d <= circle.Radius;
		}

		public static bool DeterminePointOfEllipse(Ellipse ellipse, Vector3 point) {
			double a = point.DistanceFrom(ellipse.FocalPoint1);
			double b = point.DistanceFrom(ellipse.FocalPoint2);
			double c = Math.Max(ellipse.MajorAxis, ellipse.MinorAxis) * 2;

			return a + b > c;
		}

		public static bool DeterminePointOfPolyline(LwPolyline polyline,Vector3 point) {
			List<EntityObject> entities = polyline.Explode();

			Method.DistancePointToLwPolyline(polyline, point, out Vector3 v, out int index);

			if (entities[index] is Line) {
				double d = DeterminePointOfLine(entities[index] as Line, point);
				if (d > 0)
					return true;
			} else
				return DeterminePointOfArc(entities[index] as Arc, point);

			return false;
		}
	}
}
