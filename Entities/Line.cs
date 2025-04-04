using System;
using System.Net;

namespace MyCAD.Entities {
	public class Line:EntityObject {
		private Vector3 startPoint;
		private Vector3 endPoint;
		private double thickness;

		public Line():this(Vector3.Zero, Vector3.Zero) { }

		public Line(Vector2 start,Vector2 end) : this(start.ToVector3, end.ToVector3) { }

		public Line(Vector3 start, Vector3 end):base(EntityType.Line) {
			StartPoint=start;
			EndPoint=end;
			Thickness = 0.0;
		}

		public Vector3 StartPoint {
			get { return startPoint;; }
			set { startPoint = value; }
		}

		public Vector3 EndPoint {
			get { return endPoint; }
			set { endPoint = value; }
		}

		public Vector3 MidPoint {
			get {
				return new Vector3((startPoint.X + endPoint.X) * 0.5, (startPoint.Y + endPoint.Y) * 0.5);
			}
		}

		public double  Thickness {
			get { return thickness; }
			set { thickness = value; }
		}

		public double Length {
			get {
				double dx = endPoint.X - startPoint.X;
				double dy = endPoint.Y - startPoint.Y;
				double dz = endPoint.Z - startPoint.Z;

				return Math.Sqrt(dx * dx + dy * dy + dz * dz);
			}
		}

		public double Angle {
			get {
				double angle = Math.Atan2((endPoint.Y - startPoint.Y), (endPoint.X - startPoint.X)) * 180.0 / Math.PI;
				if (angle < 0)
					angle += 360.0;
				return angle;
			}
		}

		public double AngleWith(Line line) {
			double m1 = (endPoint.Y - startPoint.Y) / (endPoint.X - startPoint.X);
			double m2 = (line.EndPoint.Y - line.StartPoint.Y) / (line.EndPoint.X - line.StartPoint.X);

			double t = (m2 - m1) / (1 + m1 * m2);

			return Math.Atan(t) * 180 / Math.PI;
		}		

		public override object CopyOrMove(Vector3 fromPoint, Vector3 toPoint) {
			Vector3 startpoint = startPoint.CopyOrMove(fromPoint, toPoint);
			Vector3 endpoint = endPoint.CopyOrMove(fromPoint, toPoint);

			return new Line {
				StartPoint = startpoint,
				EndPoint = endpoint,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object Rotate2D(Vector3 basePoint, Vector3 targetPoint) {
			Vector3 startpoint = startPoint.Rotate2D(basePoint,targetPoint);
			Vector3 endpoint = endPoint.Rotate2D(basePoint, targetPoint);

			return new Line {
				StartPoint = startpoint,
				EndPoint = endpoint,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object Rotate2D(Vector3 basePoint, double angle) {
			Vector3 startpoint = startPoint.Rotate2D(basePoint, angle);
			Vector3 endpoint = endPoint.Rotate2D(basePoint, angle);

			return new Line {
				StartPoint = startpoint,
				EndPoint = endpoint,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object Mirror2D(Vector3 basePoint, Vector3 targetPoint) {
			Vector3 startpoint = startPoint.Mirror2D(basePoint, targetPoint);
			Vector3 endpoint = endPoint.Mirror2D(basePoint, targetPoint);

			return new Line {
				StartPoint = startpoint,
				EndPoint = endpoint,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object Scale(Vector3 basePoint, double value) {
			Vector3 startpoint = startPoint.Scale(basePoint, value);
			Vector3 endpoint = endPoint.Scale(basePoint, value);

			return new Line {
				StartPoint = startpoint,
				EndPoint = endpoint,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object LinearArray2D(int horizontalQty, int verticalQty, double horizontalDistance, double verticalDistance, int direction) {
			Line[] lines = new Line[horizontalQty * verticalQty];
			int counter = 0;
			HelperClass.Direction(direction, out int h, out int v);

			double y = startPoint.Y;
			EntityObject line = this;

			for (int i = 0; i < horizontalQty; i++) {
				double x = startPoint.X;
				for (int j = 0; j < verticalQty; j++) {
					Vector3 start = new Vector3(x, y);
					lines[counter] = line.CopyOrMove(startPoint, start) as Line;
					x += horizontalDistance * h;
					counter++;
				}
				y += verticalDistance * v;
			}
			return lines;
		}

		public override object CircularArray2D(Vector3 basePoint, double fillAngle, int items, bool isRotatedItems) {
			Line[] lines = new Line[items - 1];

			if (fillAngle < 360)
				fillAngle /= (items - 1);
			else
				fillAngle /= items;

			Line line = this;

			for (int i = 0; i < items - 1; i++) {
				if (isRotatedItems)
					lines[i] = (Line)line.Rotate2D(basePoint, fillAngle);
				else {
					Vector3 p = line.MidPoint.Rotate2D(basePoint, fillAngle);
					lines[i] = (Line)line.CopyOrMove(line.MidPoint, p);
				}
				line = lines[i];
			}
			return lines;
		}

		public override object Offset(Vector3 insertPoint, double offsetValue) {
			double d = HelperClass.DeterminePointOfLine(this, insertPoint);
			double angle = (d < 0) ? Angle + 90 : (d > 0) ? Angle - 90 : Angle;

			return new Line {
				StartPoint=startPoint.Transfer2D(offsetValue,angle),
				EndPoint=endPoint.Transfer2D(offsetValue,angle),
				IsVisible=isVisible,
				Thickness=thickness
			};
		}

		public override object Clone() {
			return new Line {
				StartPoint = startPoint,
				EndPoint = endPoint,
				Thickness = thickness,
				// EntityObject properties
				IsVisible = isVisible
			};
		}
	}
}
