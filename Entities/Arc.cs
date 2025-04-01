using System;
using System.Collections.Generic;

namespace MyCAD.Entities {
	public class Arc:EntityObject {
		private Vector3 center;
		private double radius;
		private double startAngle;
		private double endAngle;
		private double thickness;

		public Arc() : this(Vector3.Zero, 1.0, 0.0, 180.0) { }

		public Arc(Vector3 center,double radius,double start,double end):base(EntityType.Arc) {
			Center = center;
			Radius = radius;
			StartAngle = start;
			EndAngle = end;
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

		public double Radius {
			get { return radius; }
			set { radius = value; }
		}

		public Vector3 Center {
			get { return center; }
			set { center = value; }
		}

		public double Diameter {
			get { return Radius * 2; }
		}

		public Vector3 StartPoint {
			get {
				double x = radius * Math.Cos(startAngle * HelperClass.DegToRad);
				double y = radius * Math.Sin(startAngle * HelperClass.DegToRad);
				return new Vector3(center.X + x, center.Y + y);
			}
		}

		public Vector3 EndPoint {
			get {
				double x = radius * Math.Cos((startAngle+endAngle) * HelperClass.DegToRad);
				double y = radius * Math.Sin((startAngle+endAngle) * HelperClass.DegToRad);
				return new Vector3(center.X + x, center.Y + y);
			}
		}

		public List<Vector3> Quadrant() {
			List<Vector3> result = new List<Vector3>();
			for (int i = 0; i < 360; i += 90) {
				Vector3 v = center.Transfer2D(radius, i);
				if (Methods.Method.IsPointOnArc(this, v))
					result.Add(v);
			}
			return result;
		}

		public LwPolyline FitRectangle {
			get {
				int direction;
				List<Vector3> pointlist = Quadrant();
				pointlist.Add(StartPoint);
				pointlist.Add(EndPoint);
				
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

		public override object CopyOrMove(Vector3 fromPoint, Vector3 toPoint) {
			Vector3 c = center.CopyOrMove(fromPoint, toPoint);

			return new Arc {
				Center = c,
				Radius = radius,
				StartAngle = startAngle,
				EndAngle = endAngle,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object Rotate2D(Vector3 basePoint, Vector3 targetPoint) {
			Vector3 c = center.Rotate2D(basePoint, targetPoint);
			Vector3 startpoint = StartPoint.Rotate2D(basePoint, targetPoint);
			Vector3 endpoint = EndPoint.Rotate2D(basePoint, targetPoint);

			double start = c.AngleWith(startpoint);
			double end = c.AngleWith(endpoint);

			if (end > start)
				end -= start;
			else
				end += 360.0 - start;

			return new Arc {
				Center = c,
				Radius = radius,
				StartAngle = start,
				EndAngle = end,
				Thickness = thickness,
				IsVisible = IsVisible
			};
		}

		public override object Rotate2D(Vector3 basePoint, double angle) {
			Vector3 c = center.Rotate2D(basePoint, angle);
			Vector3 startpoint = StartPoint.Rotate2D(basePoint, angle);
			Vector3 endpoint = EndPoint.Rotate2D(basePoint, angle);

			double start = c.AngleWith(startpoint);
			double end = c.AngleWith(endpoint);

			end = (end > start) ? end - start : end - start + 360.0;

			return new Arc {
				Center = c,
				Radius = radius,
				StartAngle = start,
				EndAngle = end,
				Thickness = thickness,
				IsVisible = IsVisible
			};
		}

		public override object Mirror2D(Vector3 basePoint, Vector3 targetPoint) {
			Vector3 c = center.Mirror2D(basePoint, targetPoint);
			Vector3 startpoint = StartPoint.Mirror2D(basePoint, targetPoint);
			Vector3 endpoint = EndPoint.Mirror2D(basePoint, targetPoint);

			double start = c.AngleWith(endpoint);
			double end = c.AngleWith(startpoint);

			end = (end > start) ? end - start : end - start + 360.0;

			return new Arc {
				Center = c,
				Radius = radius,
				StartAngle = start,
				EndAngle = end,
				Thickness = thickness,
				IsVisible = IsVisible
			};
		}

		public override object Scale(Vector3 basePoint, double value) {
			Vector3 c = center.Scale(basePoint, value);
			double r = radius * value;
			
			return new Arc {
				Center = c,
				Radius = r,
				StartAngle = startAngle,
				EndAngle = endAngle,
				Thickness = thickness,
				IsVisible = IsVisible
			};
		}

		public override object LinearArray2D(int horizontalQty, int verticalQty, double horizontalDistance, double verticalDistance, int direction) {
			Arc[] arcs = new Arc[horizontalQty * verticalQty];
			int counter = 0;
			HelperClass.Direction(direction, out int h, out int v);

			double y = center.Y;
			EntityObject arc = this;

			for (int i = 0; i < horizontalQty; i++) {
				double x = center.X;
				for (int j = 0; j < verticalQty; j++) {
					Vector3 c = new Vector3(x, y);
					arcs[counter] = arc.CopyOrMove(center, c) as Arc;
					x += horizontalDistance * h;
					counter++;
				}
				y += verticalDistance * v;
			}
			return arcs;
		}

		public override object CircularArray2D(Vector3 basePoint, double fillAngle, int items, bool isRotatedItems) {
			Arc[] arcs = new Arc[items - 1];

			if (fillAngle < 360)
				fillAngle /= (items - 1);
			else
				fillAngle /= items;

			Arc arc = this;

			for (int i = 0; i < items - 1; i++) {
				if (isRotatedItems)
					arcs[i] = arc.Rotate2D(basePoint, fillAngle) as Arc;
				else {
					Vector3 p = arc.Center.Rotate2D(basePoint, fillAngle);
					arcs[9] = (Arc)arc.CopyOrMove(arc.Center, p);
				}
				arc = arcs[i];
			}
			return arcs;
		}

		public override object Clone() {
			return new Arc {
				Center = center,
				Radius = radius,
				StartAngle = startAngle,
				EndAngle = endAngle,
				Thickness = thickness,
				// EntityObject properties
				IsVisible = isVisible
			};
		}
	}
}
