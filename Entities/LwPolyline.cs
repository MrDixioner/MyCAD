using System;
using System.Collections.Generic;

namespace MyCAD.Entities {
	public class LwPolyline:EntityObject {
		private List<LwPolylineVertex> vertexes;
		private PolylineTypeFlags flags;
		private double thickness;

		public LwPolyline():this(new List<LwPolylineVertex>(), false) { }

		public LwPolyline(List<LwPolylineVertex> vertexes, bool IsClosed):base(EntityType.LwPolyline) {
			if (vertexes==null)
				throw new ArgumentNullException(nameof(vertexes));
			this.vertexes = vertexes;
			flags = IsClosed ? PolylineTypeFlags.CloseLwPolyline : PolylineTypeFlags.OpenLwPolyline;
			thickness = 0.0;
		}

		public List<LwPolylineVertex> Vertexes {
			get { return vertexes; }
			set {
				if (value == null)
					throw new ArgumentNullException(nameof(vertexes));
				vertexes = value;
			}
		}

		internal PolylineTypeFlags Flags {
			get { return flags; }
			set {  flags = value; }
		}

		public bool IsClosed {
			get { return (flags & PolylineTypeFlags.CloseLwPolyline) == PolylineTypeFlags.CloseLwPolyline; }
			set { flags = value ? PolylineTypeFlags.CloseLwPolyline : PolylineTypeFlags.OpenLwPolyline; }
		}

		public double  Thickness {
			get { return thickness; }
			set { thickness = value; }
		}

		public List<EntityObject> Explode() {
			List<EntityObject> entities = new List<EntityObject>();
			int index = 0;
			foreach (LwPolylineVertex vertex in vertexes) {
				double bulge = vertex.Bulge;
				Vector2 p1, p2;

				if (index == vertexes.Count - 1) {
					if (!IsClosed) {
						break;
					}
					p1 = new Vector2(vertex.Position.X, vertex.Position.Y);
					p2 = new Vector2(vertexes[0].Position.X, vertexes[0].Position.Y);
				} else {
					p1 = new Vector2(vertex.Position.X, vertex.Position.Y);
					p2 = new Vector2(vertexes[index+1].Position.X, vertexes[index+1].Position.Y);
				}

				if (HelperClass.IsZero(bulge)) {
					entities.Add(new Line {
						StartPoint = new Vector3(p1.X, p1.Y),
						EndPoint = new Vector3(p2.X, p2.Y),
						Thickness = thickness
					});
				} else {
					double theta = 4 * Math.Atan(Math.Abs(bulge));
					double c = p1.DistanceFrom(p2);
					double r = c / 2 / Math.Sin(theta / 2);

					if (HelperClass.IsZero(r))
						entities.Add(new Line {
							StartPoint = new Vector3(p1.X, p1.Y),
							EndPoint = new Vector3(p2.X, p2.Y),
							Thickness = thickness
						});
					else {
						double gamma = (Math.PI - theta) / 2;
						double phi = p1.AngleWith(p2) + Math.Sign(bulge) * gamma;
						Vector2 center = new Vector2(p1.X + r * Math.Cos(phi), p1.Y + r * Math.Sin(phi));
						double startAngle, endAngle;

						if (bulge > 0) {
							startAngle = Vector2.Angle(p1 - center) * HelperClass.DegToRad;
							endAngle = startAngle + theta * HelperClass.DegToRad;
						} else {
							endAngle = Vector2.Angle(p1 - center) * HelperClass.DegToRad;
							startAngle = endAngle - theta * HelperClass.DegToRad;
						}

						entities.Add(new Arc {
							Center = new Vector3(center.X, center.Y),
							Radius = r,
							StartAngle = startAngle,
							EndAngle = endAngle,
							Thickness = thickness
						});
					}
				}
				index++;
			}
			return entities;
		}

		public List<Vector2> PolygonalVertexes(int num) {
			List<Vector2> tempVertexes = new List<Vector2>();
			int counter = 0;

			foreach (LwPolylineVertex vertex in vertexes) {
				double bulge = vertex.Bulge;
				Vector2 p1, p2;

				if (counter == vertexes.Count - 1) {
					p1 = new Vector2(vertex.Position.X, vertex.Position.Y);
					if (!IsClosed) {
						tempVertexes.Add(p1);
						continue;
					}
					p2 = new Vector2(vertexes[0].Position.X, vertexes[0].Position.Y);
				} else {
					p1 = new Vector2(vertex.Position.X, vertex.Position.Y);
					p2 = new Vector2(vertexes[counter + 1].Position.X, vertexes[counter + 1].Position.Y);
				}

				if (!p1.Equals(p2)) {
					if (HelperClass.IsZero(bulge) || num == 0) {
						tempVertexes.Add(p1);
					} else {
						double c = p1.DistanceFrom(p2);
						if (c >= 0.001) {
							double s = (c / 2) * Math.Abs(bulge);
							double r = ((c / 2) * (c / 2) + s * s) / (2 * s);
							double theta = 4 * Math.Atan(Math.Abs(bulge));
							double gamma = (Math.PI - theta) / 2;
							double phi = Vector2.Angle(p1, p2) + Math.Sign(bulge) * gamma;
							Vector2 center = new Vector2(p1.X + r * Math.Cos(phi), p1.Y + r * Math.Sin(phi));
							Vector2 a1 = p1 - center;
							double angle = Math.Sign(bulge) * theta / (num + 1);
							tempVertexes.Add(p1);
							Vector2 pPoint = p1;
							for (int i = 0; i <= num; i++) {
								Vector2 cPoint = new Vector2();
								cPoint.X = center.X + Math.Cos(i * angle) * a1.X - Math.Sin(i * angle) * a1.Y;
								cPoint.Y = center.Y + Math.Sin(i * angle) * a1.X + Math.Cos(i * angle) * a1.Y;

								if (!cPoint.Equals(pPoint) && !cPoint.Equals(p2)) {
									tempVertexes.Add(cPoint);
									pPoint = cPoint;
								}
							}
						} else {
							tempVertexes.Add(p1);
						}
					}
				}
				counter++;
			}
			return tempVertexes;
		}

		public double Area {
			get {
				int length = PolygonalVertexes(3).Count;
				Vector2[] points = new Vector2[length + 1];
				PolygonalVertexes(3).CopyTo(points, 0);
				points[length] = points[0];

				double result = 0;

				for (int i = 0; i < length; i++) {
					result += (points[i + 1].X - points[i].X) * (points[i + 1].Y + points[i].Y) / 2;
				}

				return Math.Abs(result);
			}			
		}

		public Vector3 Center {
			get {
				int length = PolygonalVertexes(3).Count;
				Vector2[] points = new Vector2[length + 1];
				PolygonalVertexes(3).CopyTo(points, 0);
				points[length] = points[0];
				double X = 0, Y = 0, factor;

				for (int i = 0; i < length; i++) {
					factor = points[i].X * points[i + 1].Y - points[i].Y * points[i + 1].X;
					X += (points[i].X + points[i + 1].X) * factor;
					Y += (points[i].Y + points[i + 1].Y) * factor;
				}

				X /= (6 * Area);
				Y /= (6 * Area);

				if (X < 0) {
					X = -X;
					Y = -Y;
				}

				return new Vector3(X, Y);
			}
		}

		public override object CopyOrMove(Vector3 fromPoint, Vector3 toPoint) {
			List<LwPolylineVertex> vertex = new List<LwPolylineVertex>();

			foreach (LwPolylineVertex lw in vertexes) {
				LwPolylineVertex lv = new LwPolylineVertex {
					Position = lw.Position.CopyOrMove(fromPoint.ToVector2, toPoint.ToVector2),
					Bulge = lw.Bulge
				};
				vertex.Add(lv);
			}

			return new LwPolyline {
				Vertexes=vertex,
				Flags=flags,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object Rotate2D(Vector3 basePoint, Vector3 targetPoint) {
			List<LwPolylineVertex> vertex = new List<LwPolylineVertex>();

			foreach (LwPolylineVertex lw in vertexes) {
				LwPolylineVertex lv = new LwPolylineVertex {
					Position = lw.Position.Rotate2D(basePoint, targetPoint),
					Bulge = lw.Bulge
				};
				vertex.Add(lv);
			}

			return new LwPolyline {
				Vertexes = vertex,
				Flags = flags,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object Rotate2D(Vector3 basePoint, double angle) {
			List<LwPolylineVertex> vertex = new List<LwPolylineVertex>();

			foreach (LwPolylineVertex lw in vertexes) {
				LwPolylineVertex lv = new LwPolylineVertex {
					Position = lw.Position.Rotate2D(basePoint, angle),
					Bulge = lw.Bulge
				};
				vertex.Add(lv);
			}

			return new LwPolyline {
				Vertexes = vertex,
				Flags = flags,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object Mirror2D(Vector3 basePoint, Vector3 targetPoint) {
			List<LwPolylineVertex> vertex = new List<LwPolylineVertex>();

			foreach (LwPolylineVertex lw in vertexes) {
				LwPolylineVertex lv = new LwPolylineVertex {
					Position = lw.Position.Mirror2D(basePoint, targetPoint),
					Bulge = lw.Bulge
				};
				vertex.Add(lv);
			}

			return new LwPolyline {
				Vertexes = vertex,
				Flags = flags,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object Scale(Vector3 basePoint, double value) {
			List<LwPolylineVertex> vertex = new List<LwPolylineVertex>();

			foreach (LwPolylineVertex lw in vertexes) {
				LwPolylineVertex lv = new LwPolylineVertex {
					Position = lw.Position.Scale(basePoint, value),
					Bulge = lw.Bulge
				};
				vertex.Add(lv);
			}

			return new LwPolyline {
				Vertexes = vertex,
				Flags = flags,
				Thickness = thickness,
				IsVisible = isVisible
			};
		}

		public override object LinearArray2D(int horizontalQty, int verticalQty, double horizontalDistance, double verticalDistance, int direction) {
			LwPolyline[] polylines = new LwPolyline[horizontalQty * verticalQty];
			int counter = 0;
			HelperClass.Direction(direction, out int h, out int v);

			double y = vertexes[0].Position.Y;
			EntityObject polyline = this;

			for (int i = 0; i < horizontalQty; i++) {
				double x = vertexes[0].Position.X;
				for (int j = 0; j < verticalQty; j++) {
					Vector3 v0 = vertexes[0].Position.ToVector3;
					Vector3 c = new Vector3(x, y);
					polylines[counter] = polyline.CopyOrMove(v0, c) as LwPolyline;
					x += horizontalDistance * h;
					counter++;
				}
				y += verticalDistance * v;
			}
			return polylines;
		}

		public override object CircularArray2D(Vector3 basePoint, double fillAngle, int items, bool isRotatedItems) {
			LwPolyline[] polylines = new LwPolyline[items - 1];

			if (fillAngle < 360)
				fillAngle /= (items - 1);
			else
				fillAngle /= items;

			LwPolyline polyline = this;

			for (int i = 0; i < items - 1; i++) {
				if (isRotatedItems)
					polylines[i] = polyline.Rotate2D(basePoint, fillAngle) as LwPolyline;
				else {
					Vector3 p = polyline.Center.Rotate2D(basePoint, fillAngle);
					polylines[i] = (LwPolyline)polyline.CopyOrMove(polyline.Center, p);
				}
				polyline = polylines[i];
			}
			return polylines;
		}

		public override object Offset(Vector3 insertPoint, double offsetValue) {
			List<LwPolylineVertex> vertex = new List<LwPolylineVertex>();
			List<Line> lines = new List<Line>();
			bool flg = HelperClass.DeterminePointOfPolyline(this, insertPoint);
			double angle;

			for (int i = 0; i < vertexes.Count; i++) {
				int next = (i == 0) ? vertexes.Count - 1 : i - 1;
				Line l1=new Line(vertexes[i].Position, vertexes[next].Position);
				angle = l1.Angle;
				angle = flg ? angle + 90 : angle - 90;
				Vector3 start = l1.StartPoint.Transfer2D(offsetValue, angle);
				Vector3 end = l1.EndPoint.Transfer2D(offsetValue, angle);
				lines.Add(new Line(start, end));
			}

			for (int j = 0; j < lines.Count; j++) {
				int next = (j == vertexes.Count - 1) ? 0 : j + 1;
				Vector3 intersection = Method.LineLineIntersection(lines[j], lines[next], true);
				Vector2 v = intersection.ToVector2;

				vertex.Add(new LwPolylineVertex(v, vertexes[j].Bulge));
			}

			if (!IsClosed) {
				vertex[0].Position = lines[1].EndPoint.ToVector2;
				vertex[lines.Count - 1].Position = lines[lines.Count - 1].StartPoint.ToVector2;

			}

			return new LwPolyline {
				Vertexes = vertex,
				Flags = flags,
				Thickness = thickness,
				IsClosed = IsClosed,
				IsVisible = isVisible
			};
		}

		public override object Clone() {
			List<LwPolylineVertex> vertexs_copy = new List<LwPolylineVertex>();
			foreach (LwPolylineVertex vertex in vertexes)
				vertexs_copy.Add((LwPolylineVertex)vertex.Clone());
			return new LwPolyline {
				Vertexes = vertexs_copy,
				Flags = flags,
				Thickness = thickness,
				// EntityObject properties
				IsVisible = isVisible
			};
		}
	}
}
