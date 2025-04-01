namespace MyCAD.Entities {
	public class Point:EntityObject {
		private Vector3 position;
		private double thickness;

		public Point() : this(Vector3.Zero) { }
				
		public Point(Vector3 position):base(EntityType.Point) {
			Position = position;
			Thickness = 0.0;
		}

		public double Thickness {
			get { return thickness; }
			set { thickness = value; }
		}

		public Vector3 Position {
			get { return position; }
			set { position = value; }
		}

		public override object CopyOrMove(Vector3 fromPoint, Vector3 toPoint) {
			Vector3 p = position.CopyOrMove(fromPoint, toPoint);

			return new Entities.Point {
				Position = p,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object Rotate2D(Vector3 basePoint, Vector3 targetPoint) {
			Vector3 p = position.Rotate2D(basePoint, targetPoint);

			return new Entities.Point {
				Position = p,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object Rotate2D(Vector3 basePoint, double angle) {
			Vector3 p = position.Rotate2D(basePoint, angle);

			return new Entities.Point {
				Position = p,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object Mirror2D(Vector3 basePoint, Vector3 targetPoint) {
			Vector3 p = position.Mirror2D(basePoint, targetPoint);

			return new Entities.Point {
				Position = p,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object Scale(Vector3 basePoint, double value) {
			Vector3 p = position.Scale(basePoint, value);

			return new Entities.Point {
				Position = p,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object LinearArray2D(int horizontalQty, int verticalQty, double horizontalDistance, double verticalDistance, int direction) {
			Point[] points = new Point[horizontalQty * verticalQty];
			int counter = 0;
			HelperClass.Direction(direction, out int h, out int v);

			double y = position.Y;
			EntityObject point = this;

			for (int i = 0; i < horizontalQty; i++) {
				double x = position.X;
				for (int j = 0; j < verticalQty; j++) {
					Vector3 c = new Vector3(x, y);
					points[counter] = point.CopyOrMove(position, c) as Point;
					x += horizontalDistance * h;
					counter++;
				}
				y += verticalDistance * v;
			}
			return points;
		}

		public override object CircularArray2D(Vector3 basePoint, double fillAngle, int items, bool isRotatedItems) {
			Point[] points = new Point[items - 1];

			if (fillAngle < 360)
				fillAngle /= (items - 1);
			else
				fillAngle /= items;

			Point point = this;

			for (int i = 0; i < items - 1; i++) {
				points[i] = point.Rotate2D(basePoint, fillAngle) as Point;
				point = points[i];
			}
			return points; ;
		}

		public override object Clone() {
			return new Point {
				Position=position,
				Thickness=thickness,
				// EntityObject properties
				IsVisible = isVisible
			};
		}
	}
}
