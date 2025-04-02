using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using MyCAD.Tables;

namespace MyCAD.Entities {
	public class Text:EntityObject {
		private Vector3 position;
		private string text;
		private TextAlignment alignment;
		private TextStyle style;
		private double height;
		private double rotation;

		public Text(string text) : this(text, Vector3.Zero) { }
		public Text(string name,double height) : this(name, Vector3.Zero, height, TextStyle.Default) { }

		public Text(string text,Vector3 position) : this(text, position, 2.50, TextStyle.Default) { }
		
		public Text(string text,Vector3 position,double height,TextStyle style) : base(EntityType.Text) {
			this.text = text;
			this.position = position;
			alignment = TextAlignment.BottomLeft;
			this.height = height;
			this.style = style;
			rotation = 0.0;
		}

		public double Rotation {
			get { return rotation; }
			set { rotation = value; }
		}

		public double Height {
			get { return height; }
			set {
				if (height<0)
					throw new ArgumentOutOfRangeException(nameof(value),value.ToString(Thread.CurrentThread.CurrentCulture));
				height = value;
			}
		}

		public TextStyle Style {
			get { return style; }
			set { style = value; }
		}

		public Vector3 Position {
			get { return position; }
			set { position = value; }
		}

		public string Value {
			get { return text; }
			set { text = value; }
		}

		public TextAlignment Alignment {
			get { return alignment; }
			set { alignment = value; }
		}

		public SizeF Size {
			get {
				Bitmap bmp = new Bitmap(100, 100);
				SizeF size = new SizeF();

				using (Graphics g = Graphics.FromImage(bmp)) {
					g.PageUnit = GraphicsUnit.Millimeter;
					size = g.MeasureString(text, Font);
				}
				return size;
			}
		}

		public Font Font {
			get { return new Font(style.FontFamilyName, (float)height, style.FontStyle, GraphicsUnit.Millimeter); }
		}

		public LwPolyline Rectangle {
			get {
				List<LwPolylineVertex> vertexes = new List<LwPolylineVertex>();
				float rotate;
				double x = position.X;
				double y = position.Y;
				float width = Size.Width * HelperClass.Sign(style.IsBackward) * (float)style.WidthFactor;
				float height = Size.Height * HelperClass.Sign(style.IsUpsideDown);

				double[] _x = { x, x - width / 2.0, x - width };
				double[] _y = { y, y + height / 2.0, y + height };

				int i = (int)alignment % 3;
				int j = (int)Math.Truncate((int)alignment / 3.0);

				vertexes.Add(new LwPolylineVertex(_x[i],_y[j]));
				vertexes.Add(new LwPolylineVertex(_x[i] + width, _y[j]));
				vertexes.Add(new LwPolylineVertex(_x[i] + width, _y[j] - height));
				vertexes.Add(new LwPolylineVertex(_x[i], _y[j] - height));

				LwPolyline result = new LwPolyline(vertexes, true);

				rotate = (float)(rotation % 360);

				return result.Rotate2D(position, rotate) as LwPolyline;
			}
		}

		public PointF[] RectangleF {
			get {
				PointF[] result = new PointF[Rectangle.Vertexes.Count];

				for (int i = 0; i < Rectangle.Vertexes.Count; i++) {
					result[i] = Rectangle.Vertexes[i].Position.ToPointF;
				}
				return result;
			}
		}

		private Vector3 AlignmentCoordinate(LwPolyline rect, TextAlignment alignment, out double rotate) {
			Vector3 result = new Vector3();

			double angle = rect.Vertexes[0].Position.AngleWith(rect.Vertexes[1].Position);
			double width = Size.Width;
			double height = Size.Height;
			double radius = Math.Sqrt(width * width + height * height) / 2;
			double a = Math.Acos((2 * radius * radius - height * height) / 2 / radius / radius) * HelperClass.RadToDeg / 2;
			double b = Math.Acos((2 * radius * radius - width * width) / 2 / radius / radius) * HelperClass.RadToDeg / 2;

			rotate = (angle + 180) % 360;

			switch (alignment) {
				case TextAlignment.TopLeft:
					result = rect.Center.Transfer2D(radius, angle + 180 + a + 2 * b);
					break;
				case TextAlignment.TopCenter:
					result = rect.Center.Transfer2D(height / 2, angle + 180 + a + b);
					break;
				case TextAlignment.TopRight:
					result = rect.Center.Transfer2D(radius, angle + 180 + a);
					break;
				case TextAlignment.MiddleLeft:
					result = rect.Center.Transfer2D(width / 2, angle);
					break;
				case TextAlignment.MiddleCenter:
					result = rect.Center;
					break;
				case TextAlignment.MiddleRight:
					result = rect.Center.Transfer2D(width, angle + 2 * a + 2 * b);
					break;
				case TextAlignment.BottomLeft:
					result = rect.Center.Transfer2D(radius, angle + a);
					break;
				case TextAlignment.BottomCenter:
					result = rect.Center.Transfer2D(-height / 2, angle - a - b);
					break;
				case TextAlignment.BottomRight:
					result = rect.Center.Transfer2D(radius, angle + a + 2 * b);
					break;
			}
			return result;
		}

		public override object CopyOrMove(Vector3 fromPoint, Vector3 toPoint) {
			Vector3 p = position.CopyOrMove(fromPoint, toPoint);

			return new Text(text) {
				Position = p,
				Alignment = alignment,
				Height = height,
				Style = style,
				Rotation = rotation,
				isVisible = isVisible
			};
		}

		public override object Rotate2D(Vector3 basePoint, double angle) {
			Vector3 p = position.Rotate2D(basePoint, angle);
			double rotate = rotation + angle;

			return new Text(text) {
				Position = p,
				Alignment = alignment,
				Height = height,
				Style = style,
				Rotation = rotate,
				isVisible = isVisible
			};
		}

		public override object Rotate2D(Vector3 basePoint, Vector3 targetPoint) {
			Vector3 p = position.Rotate2D(basePoint, targetPoint);
			double rotate = rotation + basePoint.AngleWith(targetPoint);

			return new Text(text) {
				Position = p,
				Alignment = alignment,
				Height = height,
				Style = style,
				Rotation = rotate,
				isVisible = isVisible
			};
		}

		public override object Mirror2D(Vector3 basePoint, Vector3 targetPoint) {
			LwPolyline rect = Rectangle.Mirror2D(basePoint, targetPoint) as LwPolyline;
			double rotate;

			Text newText = new Text(text) {
				Position = AlignmentCoordinate(rect,alignment, out rotate),
				Alignment = alignment,
				Height = height,
				Style = style,
				Rotation = rotate,
				isVisible = isVisible
			};

			if (rotate > 90 && rotate < 270)
				return newText.Rotate2D(rect.Center, 180);
			else
				return newText;
		}

		public override object LinearArray2D(int horizontalQty, int verticalQty, double horizontalDistance, double verticalDistance, int direction) {
			Text[] texts = new Text[horizontalQty * verticalQty];

			int counter = 0;
			int v, h;

			HelperClass.Direction(direction, out h, out v);
			double y = position.Y;
			Text txt = this;

			for (int i = 0; i < horizontalQty; i++) {
				double x = position.X;
				for (int j = 0; j < verticalQty; j++) {
					Vector3 vector = new Vector3(x, y);

					if (!position.Equals(vector))
						texts[counter] = txt.CopyOrMove(position, vector) as Text;

					x += horizontalDistance * h;
					counter++;
				}
				y += verticalDistance * v;
			}
			return texts;
		}

		public override object CircularArray2D(Vector3 basePoint, double fillAngle, int items, bool isRotatedItems) {
			Text[] texts = new Text[items - 1];

			if (fillAngle < 360)
				fillAngle /= (items - 1);
			else
				fillAngle /= items;

			Text txt = this;

			for (int i = 0; i < items - 1; i++) {
				texts[i] = txt.Rotate2D(basePoint, fillAngle) as Text;
				if (isRotatedItems)
					texts[i] = texts[i].Rotate2D(texts[i].Rectangle.Center, -fillAngle) as Text;
				txt = (Text)texts[i].Clone();
			}
			return texts;
		}

		public override object Scale(Vector3 basePoint, double value) {
			Vector3 p = position.Scale(basePoint, value);
			double h = height * value;

			return new Text(text) {
				Position = p,
				Alignment = alignment,
				Height = h,
				Style = style,
				Rotation = rotation,
				isVisible = isVisible
			};
		}

		public override object Clone() {
			return new Text(text) {
				Position = position,
				Alignment = alignment,
				Height = height,
				Style = style,
				Rotation = rotation,
				isVisible = isVisible
			};
		}
	}
}
