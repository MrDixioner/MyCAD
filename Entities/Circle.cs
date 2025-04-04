using System.Collections.Generic;
using System.Net;

namespace MyCAD.Entities {
	public class Circle:EntityObject {
		private Vector3 center;
		private double radius;
		private double thickness;

		public Circle():this(Vector3.Zero, 1.0) {
		}
		
		public Circle(Vector3 center, double radius):base(EntityType.Circle) {
			Center = center;
			Radius = radius;
			Thickness = 0.0;
		}

		public double Thickness {
			get { return thickness; }
			set { thickness = value; }
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
			get { return Radius * 2.0; }
		}

		public LwPolyline Rectangle {
			get {
				int direction;
				Vector3 first = new Vector3(center.X - radius, center.Y - radius);
				Vector3 second = new Vector3(center.X + radius, center.Y + radius);

				return Method.PointToRect(first, second, out direction);
			}
		}

		public List<Vector3> Quadrant() {
			List<Vector3> result = new List<Vector3>();
			for (int i = 0; i < 360; i += 90) {
				result.Add(center.Transfer2D(radius, i));
			}
			return result;
		}

		public override object CopyOrMove(Vector3 fromPoint, Vector3 toPoint) {
			Vector3 c = center.CopyOrMove(fromPoint, toPoint);

			return new Circle {
				Center = c,
				Radius = radius,                
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object Rotate2D(Vector3 basePoint, Vector3 targetPoint) {
			Vector3 c = center.Rotate2D(basePoint, targetPoint);

			return new Circle {
				Center = c,
				Radius = radius,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object Rotate2D(Vector3 basePoint, double angle) {
			Vector3 c = center.Rotate2D(basePoint, angle);

			return new Circle {
				Center = c,
				Radius = radius,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object Mirror2D(Vector3 basePoint, Vector3 targetPoint) {
			Vector3 c = center.Mirror2D(basePoint, targetPoint);

			return new Circle {
				Center = c,
				Radius = radius,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object Scale(Vector3 basePoint, double value) {
			Vector3 c = center.Scale(basePoint, value);
			double r = radius * value;

			return new Circle {
				Center = c,
				Radius = r,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object LinearArray2D(int horizontalQty, int verticalQty, double horizontalDistance, double verticalDistance, int direction) {
			Circle[] circles = new Circle[horizontalQty * verticalQty];
			int counter = 0;
			HelperClass.Direction(direction, out int h, out int v);

			double y = center.Y;
			EntityObject circle = this;

			for (int i = 0; i < horizontalQty; i++) {
				double x = center.X;
				for (int j = 0; j < verticalQty; j++) {
					Vector3 c = new Vector3(x, y);
					circles[counter] = circle.CopyOrMove(center, c) as Circle;
					x += horizontalDistance * h;
					counter++;
				}
				y += verticalDistance * v;
			}
			return circles;
		}

		public override object CircularArray2D(Vector3 basePoint, double fillAngle, int items, bool isRotatedItems) {
			Circle[] circles = new Circle[items - 1];

			if (fillAngle < 360)
				fillAngle /= (items - 1);
			else
				fillAngle /= items;

			Circle circle = this;

			for (int i = 0; i < items - 1; i++) {
				circles[i] = new Circle(circle.Center.Rotate2D(basePoint, fillAngle), radius);
				circle = circles[i];
			}
			return circles;
		}

		public override object Offset(Vector3 insertPoint, double offsetValue) {
			bool flg = HelperClass.DeterminePointOfCircle(this, insertPoint);
			double r = (flg) ? radius - offsetValue : radius + offsetValue;

			if (r > 0) {
				return new Circle {
					Center = center,
					Radius = r,
					IsVisible = isVisible
				};
			} else
				return null;		
		}

		public override object Clone() {
			return new Circle {
				Center = center,
				Radius = Radius,
				Thickness = Thickness,
				// EntityObject properties
				IsVisible = isVisible
			};
		}
	}
}
