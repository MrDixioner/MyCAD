using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using MyCAD.Entities;

namespace MyCAD {
	public static class GraphicsExtension {
		private static float Height;
		private static float XScroll;
		private static float YScroll;
		private static float ScaleFactor;
		private static Pen extpen = new Pen(Color.Gray, 0);

		public static void SetParameters(this Graphics g,
			float xscroll, float yscroll, float scalefactor, float height) {
			XScroll= xscroll;
			YScroll= yscroll;
			ScaleFactor = scalefactor;
			Height = height;
			extpen.DashPattern = new float[] { 1.5f / scalefactor, 2.0f / scalefactor };
		}

		public static void SetTransform(this Graphics g) {
			g.PageUnit = GraphicsUnit.Millimeter;
			g.TranslateTransform(0, Height);
			g.ScaleTransform(ScaleFactor, -ScaleFactor);
			g.TranslateTransform(-XScroll / ScaleFactor, YScroll / ScaleFactor);
		}

		public static void DrawPoint(this Graphics g, Pen pen,Entities.Point point) {
			g.SetTransform();
			PointF p = point.Position.ToPointF;
			if (!point.IsSelected)
				g.DrawEllipse(pen, p.X - 1, p.Y - 1, 2, 2);
			else
				g.DrawEllipse(extpen, p.X - 1, p.Y - 1, 2, 2);
			g.ResetTransform();
		}

		public static void DrawLine(this Graphics g, Pen pen, Line line) {
			g.SetTransform();
			if (!line.IsSelected)
				g.DrawLine(pen, line.StartPoint.ToPointF, line.EndPoint.ToPointF);
			else
				g.DrawLine(extpen, line.StartPoint.ToPointF, line.EndPoint.ToPointF);
			g.ResetTransform();
		}

		public static void DrawCircle(this Graphics g, Pen pen, Circle circle) {
			float x = (float)(circle.Center.X - circle.Radius);
			float y = (float)(circle.Center.Y - circle.Radius);
			float d = (float)circle.Diameter;			

			g.SetTransform();
			if (!circle.IsSelected)
				g.DrawEllipse(pen, x, y, d, d);
			else
				g.DrawEllipse(extpen, x, y, d, d);
			g.ResetTransform();
		}

		public static void DrawEllipse(this Graphics g,Pen pen, Ellipse ellipse) {
			// tests
			
			//
			SetTransform(g);
			g.TranslateTransform(ellipse.Center.ToPointF.X, ellipse.Center.ToPointF.Y);
			g.RotateTransform((float)ellipse.Rotation);
			if (!ellipse.IsSelected)
				g.DrawEllipse(pen,-(float)ellipse.MajorAxis,-(float)ellipse.MinorAxis,(float)ellipse.MajorAxis*2, (float)ellipse.MinorAxis*2);
			else
				g.DrawEllipse(extpen, -(float)ellipse.MajorAxis, -(float)ellipse.MinorAxis, (float)ellipse.MajorAxis * 2, (float)ellipse.MinorAxis * 2);
			g.ResetTransform();
		}

		public static void DrawEllipticalArc(this Graphics g, Pen pen, Ellipse ellipse) {
			try {
				SetTransform(g);
				g.TranslateTransform(ellipse.Center.ToPointF.X, ellipse.Center.ToPointF.Y);
				g.RotateTransform((float)ellipse.Rotation);
				RectangleF rect = new RectangleF(-(float)ellipse.MajorAxis, -(float)ellipse.MinorAxis, (float)ellipse.MajorAxis * 2, (float)ellipse.MinorAxis * 2);
				if (!ellipse.IsSelected)
					g.DrawArc(pen, rect, (float)ellipse.StartAngle, (float)ellipse.EndAngle);
				else
					g.DrawArc(extpen, rect, (float)ellipse.StartAngle, (float)ellipse.EndAngle);
				g.ResetTransform();
			} catch { }			
		}
		
		public static void DrawArc(this Graphics g, Pen pen, Arc arc) {
			float x = (float)(arc.Center.X - arc.Radius);
			float y = (float)(arc.Center.Y - arc.Radius);
			float d = (float)arc.Diameter;

			RectangleF rect = new RectangleF(x, y, d, d);

			g.SetTransform();
			try {
				if (!arc.IsSelected)
					g.DrawArc(pen, rect, (float)arc.StartAngle, (float)arc.EndAngle);
				else
					g.DrawArc(extpen, rect, (float)arc.StartAngle, (float)arc.EndAngle);
			}
			catch { }
			g.ResetTransform();
		}

		public static void DrawLwPolyline(this Graphics g, Pen pen, LwPolyline polyline) {
			foreach (EntityObject entity in polyline.Explode()) {
				g.DrawPoint(new Pen(Color.Red, 0), new Entities.Point(polyline.Center));
				if (!polyline.IsSelected)
					g.DrawEntity(pen, entity);
				else
					g.DrawEntity(extpen, entity);
			}
			//PointF[] vertexes = new PointF[polyline.Vertexes.Count];

			//if (polyline.IsClosed) {
			//	vertexes = new PointF[polyline.Vertexes.Count + 1];
			//	vertexes[polyline.Vertexes.Count] = polyline.Vertexes[0].Position.ToPointF;
			//}

			//for (int i = 0; i < polyline.Vertexes.Count; i++)
			//	vertexes[i] = polyline.Vertexes[i].Position.ToPointF;

			//g.SetTransform();
			//g.DrawLines(pen, vertexes);
			//g.ResetTransform();
		}

		public static void DrawEntity(this Graphics g,Pen pen,EntityObject entity) {
			try {
				switch (entity.Type) {
					case EntityType.Arc:
						g.DrawArc(pen, entity as Arc);
						break;
					case EntityType.Ellipse:
						if ((entity as Ellipse).IsFullEllipse)
							g.DrawEllipse(pen, entity as Ellipse);
						else
							g.DrawEllipticalArc(pen, entity as Ellipse);
							break;
					case EntityType.Circle:
						g.DrawCircle(pen, entity as Circle);
						break;
					case EntityType.Line:
						g.DrawLine(pen, entity as Line);
						break;
					case EntityType.LwPolyline:
						g.DrawLwPolyline(pen, entity as LwPolyline);
						break;
					case EntityType.Point:
						g.DrawPoint(pen, entity as Entities.Point);
						break;
					case EntityType.Text:
						g.DrawText(pen, entity as Text);
						break;
				}
			} catch { }
		}

		public static void FillLwPolyline(this Graphics g,SolidBrush brush,LwPolyline polyline) {
			List<PointF> list = new List<PointF>();

			foreach (LwPolylineVertex lpw in polyline.Vertexes)
				list.Add(lpw.Position.ToPointF);

			g.SetTransform();
			g.FillPolygon(brush, list.ToArray());
			g.ResetTransform();
		}

		public static void ExtendedOfModify(this Graphics g, Pen pen, int modifyIndex, List<EntityObject> entities, Vector3 fromPoint, Vector3 toPoint) {
			g.DrawLine(pen, new Line(fromPoint, toPoint));

			for (int i = 0; i < entities.Count; i++) {
				if (entities[i].IsSelected) {
					switch (modifyIndex) {
						case 0: // Copy
						case 1: // Move
							g.DrawEntity(pen, entities[i].CopyOrMove(fromPoint, toPoint) as EntityObject);
							break;
						case 3: // Rotate
							g.DrawEntity(pen, entities[i].Rotate2D(fromPoint, fromPoint.AngleWith(toPoint)) as EntityObject);
							break;
						case 4: // Mirror
							g.DrawEntity(pen, entities[i].Mirror2D(fromPoint, toPoint) as EntityObject);
							break;
						case 5: // Scale
							g.DrawEntity(pen, entities[i].Scale(fromPoint, fromPoint.DistanceFrom(toPoint)) as EntityObject);
							break;
					}

				}
			}
		}

		public static void DrawExtendedOfLinearArray2D(this Graphics g,Pen pen,
			List<EntityObject> entities,
			int horizontalQty,
			int verticalQty,
			double horizontalDist,
			double verticalDist,
			int direction) {
			for (int i = 0; i < entities.Count; i++) {
				if (entities[i].IsSelected) {
					EntityObject[] array = entities[i].LinearArray2D(horizontalQty, verticalQty,horizontalDist,verticalDist,direction) as EntityObject[];
					for (int j = 1; j < array.Length; j++)
						g.DrawEntity(pen, array[j]);
				}
			}
		}

		public static void DrawExtendedOfCircularArray2D(this Graphics g, Pen pen,
			List<EntityObject> entities,
			Vector3 basePoint,
			double fillAngle,
			int items,
			bool isRotatedItems) {
			try {
				for (int i = 0; i < entities.Count; i++) {
					if (entities[i].IsSelected) {
						EntityObject[] entity = entities[i].CircularArray2D(basePoint, fillAngle, items, isRotatedItems) as EntityObject[];
						foreach (EntityObject entity1 in entity)
							g.DrawEntity(pen, entity1);
					}
				}
			} catch { }			
		}

		public static void DrawText(this Graphics g,Pen pen,Text text) {
			try {
				SolidBrush brush = new SolidBrush(pen.Color);
				SolidBrush brush1 = new SolidBrush(extpen.Color);
				//g.DrawLwPolyline(new Pen(Color.Red, 0), text.Rectangle);

				float rotate = -(float)(text.Rotation % 360);
				Vector3 p = text.Position * ScaleFactor;

				g.PageUnit = GraphicsUnit.Millimeter;
				g.ScaleTransform(ScaleFactor * (float)text.Style.WidthFactor * HelperClass.Sign(text.Style.IsBackward),
					ScaleFactor * HelperClass.Sign(text.Style.IsUpsideDown));
				g.RotateTransform(rotate);
				g.TranslateTransform((float)p.X - XScroll, Height - (float)p.Y - YScroll, System.Drawing.Drawing2D.MatrixOrder.Append);

				float[] _x = { 0, -text.Size.Width / 2, -text.Size.Width };
				float[] _y = { 0, -text.Size.Height / 2, -text.Size.Height };

				int i = (int)text.Alignment % 3;
				int j = (int)Math.Truncate((int)text.Alignment / 3.0);

				if (!text.IsSelected)
					g.DrawString(text.Value, text.Font, brush, _x[i], _y[j]);
				else
					g.DrawString(text.Value, text.Font, brush1, _x[i], _y[j]);
			} catch { }
		}

		#region Extended of Offset
		private static bool Direction(EntityObject entity,Vector3 insertPoint) {
			switch (entity.Type) {
				case EntityType.Arc:
					return HelperClass.DeterminePointOfArc(entity as Arc, insertPoint);
				case EntityType.Circle:
					return HelperClass.DeterminePointOfCircle(entity as Circle, insertPoint);
				case EntityType.Ellipse:
					return HelperClass.DeterminePointOfEllipse(entity as Ellipse, insertPoint);
				case EntityType.Line:
					double d = HelperClass.DeterminePointOfLine(entity as Line, insertPoint);
					return (d < 0) ? false : true;
				case EntityType.LwPolyline:
					return HelperClass.DeterminePointOfPolyline(entity as LwPolyline, insertPoint);
				case EntityType.Point:
				case EntityType.Text:
					break;
				default:
					return false;
			}
			return false;
		}

		public static void DrawExtendedOffset(this Graphics g,Pen pen,List<EntityObject> entities, Vector3 insertPoint, double offsetValue, out bool direction) {
			bool flg = false;
			for (int i = 0; i < entities.Count; i++) {
				if (entities[i].IsSelected) {
					EntityObject entity = entities[i].Offset(insertPoint, offsetValue) as EntityObject;
					g.DrawEntity(pen, entity);
					flg = Direction(entities[i], insertPoint);
				}
			}
			direction = flg;
		}
		#endregion
	}
}
