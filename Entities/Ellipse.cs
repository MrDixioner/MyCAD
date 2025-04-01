using System;
using System.Collections.Generic;

namespace MyCAD.Entities {
	public class Ellipse:EntityObject {
		private Vector3 center;
		private double majorAxis;
		private double minorAxis;
		private double rotation;
		private double startAngle;
		private double endAngle;
		private double thickness;

		public Ellipse() : this(Vector3.Zero, 1.0, 0.5) { }

		public Ellipse(Vector3 center,double majoraxis,double minoraxis):base(EntityType.Ellipse) {
			Center = center;
			MajorAxis = majoraxis;
			MinorAxis = minoraxis;
			startAngle = 0.0;
			endAngle = 360.0;
			Rotation = 0.0;
			Thickness = 0.0;
		}

		public double Thickness {
			get { return thickness; }
			set { thickness = value; }
		}

		public double EndAngle {
			get { return endAngle; }
			set { endAngle = value; }
		}

		public double StartAngle {
			get { return startAngle; }
			set { startAngle = value; }
		}

		public double Rotation {
			get { return rotation; }
			set { rotation = value; }
		}

		public double MinorAxis {
			get { return minorAxis; }
			set { minorAxis = value; }
		}

		public double  MajorAxis {
			get { return majorAxis; }
			set { majorAxis = value; }
		}

		public Vector3 Center {
			get { return center; }
			set { center = value; }
		}

		public bool IsFullEllipse {
			get { return HelperClass.IsEqual(startAngle, endAngle, HelperClass.Epsilon); }
		}

		public Vector3 MajorPoint {
			get {
				double x = majorAxis * Math.Cos(rotation * Math.PI / 180.0) + center.X;
				double y = majorAxis * Math.Sin(rotation * Math.PI / 180.0) + center.Y;

				return new Vector3(x, y);
			}
		}

		public Vector3 MinorPoint {
			get {
				double x = minorAxis * Math.Cos((rotation + 90.0) * Math.PI / 180.0) + center.X;
				double y = minorAxis * Math.Sin((rotation + 90.0) * Math.PI / 180.0) + center.Y;
		  
				return new Vector3(x, y);
			}
		}

		public Vector3 StartPoint {
			get {
				double a = majorAxis;
				double b = minorAxis;
				double cos = Math.Cos(startAngle * Math.PI / 180.0);
				double sin = Math.Sin(startAngle * Math.PI / 180.0);
				double radius = a * b / Math.Sqrt(b * b * cos * cos + a * a * sin * sin);
				Vector3 c = center.Transfer2D(radius, startAngle);

				return c.Rotate2D(center, rotation);
			}
		}

		public Vector3 EndPoint {
			get {
				double a = majorAxis;
				double b = minorAxis;
				double cos = Math.Cos((startAngle + endAngle) * Math.PI / 180.0);
				double sin = Math.Sin((startAngle + endAngle) * Math.PI / 180.0);
				double radius = a * b / Math.Sqrt(b * b * cos * cos + a * a * sin * sin);
				Vector3 c = center.Transfer2D(radius, startAngle + endAngle);

				return c.Rotate2D(center, rotation);
			}
		}

		public Vector3 FocalPoint1 {
			get {
				double e = Math.Sqrt(majorAxis * majorAxis - minorAxis * minorAxis);
				double x = e * Math.Cos(rotation * HelperClass.DegToRad) + center.X;
				double y = e * Math.Sin(rotation * HelperClass.DegToRad) + center.Y;

				return new Vector3(x, y);
			}
		}

		public Vector3 FocalPoint2 {
			get {
				double e = Math.Sqrt(majorAxis * majorAxis - minorAxis * minorAxis);
				double x = e * Math.Cos((rotation-180.0) * HelperClass.DegToRad) + center.X;
				double y = e * Math.Sin((rotation-180.0) * HelperClass.DegToRad) + center.Y;

				return new Vector3(x, y);
			}
		}

		public List<Vector3> BoundingPoints() {
			List<Vector3> result = new List<Vector3>();
			List<double> t_list = new List<double>();
			double a = majorAxis;
			double b = minorAxis;
			double angle = rotation * HelperClass.DegToRad;
			double cos = Math.Cos(angle);
			double sin = Math.Sin(angle);
			double tan = Math.Tan(angle);
			double cot = 1 / tan;

			t_list.Add(Math.Atan(-b / a * tan));
			t_list.Add(Math.PI + Math.Atan(-b / a * tan));
			t_list.Add(Math.Atan(b / a * cot));
			t_list.Add(Math.PI + Math.Atan(b / a * cot));

			foreach (double t in t_list) {
				double x = a * Math.Cos(t) * cos - b * Math.Sin(t) * sin + center.X;
				double y = a * Math.Cos(t) * sin + b * Math.Sin(t) * cos + center.Y;
				result.Add(new Vector3(x, y));
			}
			return result;
		}

		public LwPolyline Rectangle {
			get {
				double a = majorAxis;
				double b = minorAxis;
				double angle = rotation * HelperClass.DegToRad;
				double cos = Math.Cos(angle);
				double sin = Math.Sin(angle);
				List<LwPolylineVertex> vertexes = new List<LwPolylineVertex>();

				double A = a * a * cos * cos + b * b * sin * sin;
				double B = a * a * sin * sin + b * b * cos * cos;

				double x1 = Math.Sqrt(A) + center.X;
				double x2 = -Math.Sqrt(A) + center.X;
				double y1 = Math.Sqrt(B) + center.Y;
				double y2 = -Math.Sqrt(B) + center.Y;

				vertexes.Add(new LwPolylineVertex(Math.Min(x1, x2), Math.Min(y1, y2)));
				vertexes.Add(new LwPolylineVertex(Math.Max(x1, x2), Math.Min(y1, y2)));
				vertexes.Add(new LwPolylineVertex(Math.Max(x1, x2), Math.Max(y1, y2)));
				vertexes.Add(new LwPolylineVertex(Math.Min(x1, x2), Math.Max(y1, y2)));

				return new LwPolyline(vertexes, true);
			}
		}

		public LwPolyline FitRectangle {
			get {
				List<Vector3> pointlist = new List<Vector3>(new Vector3[] { StartPoint, EndPoint });
				int direction;

				foreach (Vector3 v in BoundingPoints()) {
					if (Methods.Method.IsPointOnEllipse(this, v))
						pointlist.Add(v);
				}

				double x1 = StartPoint.X;
				double y1 = StartPoint.Y;
				double x2 = StartPoint.X;
				double y2 = StartPoint.Y;

				foreach (Vector3 p in pointlist) {
					x1 = Math.Min(p.X, x1);
					y1 = Math.Min(p.Y, y1);
					x2 = Math.Max(p.X, x2);
					y2 = Math.Max(p.Y, y2);
				}

				Vector3 start = new Vector3(x1, y1);
				Vector3 end = new Vector3(x2, y2);

				return Methods.Method.PointToRect(start, end, out direction);
			}
		}

		public void GetGeneralParameters(out double A,out double B,out double C,out double D,out double E,out double F) {
			double a = majorAxis;
			double b = minorAxis;
			double sin = Math.Sin(rotation * HelperClass.DegToRad);
			double cos = Math.Cos(rotation * HelperClass.DegToRad);
			double x = center.X;
			double y = center.Y;

			A = a * a * sin * sin + b * b * cos * cos;
			B = 2 * (b * b - a * a) * sin * cos;
			C = a * a * cos * cos + b * b * sin * sin;
			D = -2 * A * x - B * y;
			E = -B * x - 2 * C * y;
			F = A * x * x + B * x * y + C * y * y - a * a * b * b;
		}

		public override object CopyOrMove(Vector3 fromPoint, Vector3 toPoint) {
			Vector3 c = center.CopyOrMove(fromPoint, toPoint);

			return new Ellipse {
				Center = c,
				MajorAxis=majorAxis,
				MinorAxis=minorAxis,
				Rotation=rotation,
				StartAngle = startAngle,
				EndAngle = endAngle,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object Rotate2D(Vector3 basePoint, Vector3 targetPoint) {
			Vector3 c = center.Rotate2D(basePoint, targetPoint);
			double angle = basePoint.AngleWith(targetPoint) + Rotation;

			return new Ellipse {
				Center = c,
				MajorAxis = majorAxis,
				MinorAxis = minorAxis,
				Rotation = angle,
				StartAngle = startAngle,
				EndAngle = endAngle,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object Rotate2D(Vector3 basePoint, double angle) {
			Vector3 c = center.Rotate2D(basePoint, angle);
			angle += rotation;

			return new Ellipse {
				Center = c,
				MajorAxis = majorAxis,
				MinorAxis = minorAxis,
				Rotation = angle,
				StartAngle = startAngle,
				EndAngle = endAngle,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object Mirror2D(Vector3 basePoint, Vector3 targetPoint) {
			Vector3 c = center.Mirror2D(basePoint, targetPoint);
			Vector3 minorpoint = MinorPoint.Mirror2D(basePoint, targetPoint);
			Vector3 startpoint = StartPoint.Mirror2D(basePoint, targetPoint);
			Vector3 endpoint = EndPoint.Mirror2D(basePoint, targetPoint);
			double angle = c.AngleWith(minorpoint) + 90.0;

			double start = c.AngleWith(endpoint);
			double end = c.AngleWith(startpoint);

			end = (end > start) ? end - start : end - start + 360.0;
			start -= angle;

			return new Ellipse {
				Center = c,
				MajorAxis = majorAxis,
				MinorAxis = minorAxis,
				Rotation = angle,
				StartAngle = start,
				EndAngle = end,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object Scale(Vector3 basePoint, double value) {
			Vector3 c = center.Scale(basePoint, value);
			double major = majorAxis * value;
			double minor = minorAxis * value;

			return new Ellipse {
				Center = c,
				MajorAxis = major,
				MinorAxis = minor,
				Rotation = rotation,
				StartAngle = startAngle,
				EndAngle = endAngle,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object LinearArray2D(int horizontalQty, int verticalQty, double horizontalDistance, double verticalDistance, int direction) {
			Ellipse[] ellipses = new Ellipse[horizontalQty * verticalQty];
			int counter = 0;
			HelperClass.Direction(direction, out int h, out int v);

			double y = center.Y;
			EntityObject ellipse = this;

			for (int i = 0; i < horizontalQty; i++) {
				double x = center.X;
				for (int j = 0; j < verticalQty; j++) {
					Vector3 c = new Vector3(x, y);
					ellipses[counter] = ellipse.CopyOrMove(center, c) as Ellipse;
					x += horizontalDistance * h;
					counter++;
				}
				y += verticalDistance * v;
			}
			return ellipses;
		}

		public override object CircularArray2D(Vector3 basePoint, double fillAngle, int items, bool isRotatedItems) {
			Ellipse[] ellipses = new Ellipse[items - 1];
			
			if (fillAngle < 360)
				fillAngle /= (items - 1);
			else
				fillAngle /= items;

			Ellipse ellipse = this;

			for (int i = 0; i < items - 1; i++) {
				if (isRotatedItems)
					ellipses[i] = (Ellipse)ellipse.Rotate2D(basePoint, fillAngle);
				else {
					Vector3 c = ellipse.Center.Rotate2D(basePoint, fillAngle);
					ellipses[i] = (Ellipse)ellipse.CopyOrMove(ellipse.Center, c);
				}
				ellipse = ellipses[i];
			}
			return ellipses;
		}

		public override object Clone() {
			return new Ellipse {
				Center = center,
				MajorAxis = majorAxis,
				MinorAxis = minorAxis,
				Rotation = rotation,
				StartAngle = startAngle,
				EndAngle = endAngle,
				Thickness = thickness,
				// EntityObject properties
				IsVisible = isVisible
			};
		}
	}
}
