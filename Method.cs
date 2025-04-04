using MyCAD.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;

namespace MyCAD {
	public static class Method {
		public static double LineAngle(Vector3 start, Vector3 end) {
			double angle = Math.Atan2((end.Y - start.Y), (end.X - start.X)) * 180.0 / Math.PI;
			if (angle < 0.0)
				angle += 360;
			return angle;
		}

		#region --- Intersection ---
		public static Vector3 LineLineIntersection(Line line1,Line line2,bool extended = false) {
			Vector3 result;
			Vector3 p1 = line1.StartPoint;
			Vector3 p2 = line1.EndPoint;
			Vector3 p3 = line2.StartPoint;
			Vector3 p4 = line2.EndPoint;

			double dx12 = p2.X - p1.X;
			double dy12 = p2.Y - p1.Y;
			double dx34 = p4.X - p3.X;
			double dy34 = p4.Y - p3.Y;

			double denominator = (dy12 * dx34 - dx12 * dy34);
			double k1 = ((p1.X - p3.X) * dy34 + (p3.Y - p1.Y) * dx34) / denominator;

			if (double.IsInfinity(k1))
				return new Vector3(double.NaN, double.NaN);

			result = new Vector3(p1.X + dx12 * k1, p1.Y + dy12 * k1);

			if (extended)
				return result;
			else {
				if (IsPointOnLine(line1, result) && IsPointOnLine(line1, result))
					return result;
				else
					return new Vector3(double.NaN, double.NaN);
			}
		}
				
		public static List<Vector3> LineEllipseIntersection(Line line, Ellipse ellipse) {
			double x1 = line.StartPoint.X;
			double y1 = line.StartPoint.Y;
			double x2 = line.EndPoint.X;
			double y2 = line.EndPoint.Y;

			double xc = ellipse.Center.X;
			double yc = ellipse.Center.Y;

			double a = ellipse.MajorAxis;
			double b = ellipse.MinorAxis;

			double angle = ellipse.Rotation * HelperClass.DegToRad;

			double X, Y;
			List<Vector3> result=new List<Vector3>();

			double x21 = x2 - x1;
			double y21 = y2 - y1;

			x1 -= xc;
			y1 -= yc;

			double sin = Math.Sin(angle);
			double cos = Math.Cos(angle);

			double A1 = b * b * cos * cos + a * a * sin * sin;			
			double B1 = a * a * cos * cos + b * b * sin * sin;
			double C1 = 2 * (b * b - a * a) * sin * cos;

			double A = A1 * x21 * x21 + B1 * y21 * y21 + C1 * x21 * y21;
			double B = 2 * A1 * x1 * x21 + 2 * B1 * y1 * y21 + C1 * x1 * y21 + C1 * x21 * y1;
			double C = A1 * x1 * x1 + B1 * y1 * y1 + C1 * x1 * y1 - a * a * b * b;

			double Delta = B * B - 4 * A * C;

			List<double> t_value = new List<double>();

			if (Delta == 0)
				t_value.Add(-B / 2 / A);
			else if (Delta > 0) {
				t_value.Add((-B + Math.Sqrt(Delta)) / 2 / A);
				t_value.Add((-B - Math.Sqrt(Delta)) / 2 / A);
			}

			foreach (double t in t_value) {
				if ((t >= 0.0) && (t <= 1.0)) {
					X = x1 + x21 * t + xc;
					Y = y1 + y21 * t + yc;
					result.Add(new Vector3(X, Y));
				}
			}

			return result;
		}
				
		public static List<Vector3> LineCircleIntersection(Line line,Circle circle) {
			List<Vector3> result = new List<Vector3>();
			double x1 = line.StartPoint.X;
			double y1 = line.StartPoint.Y;
			double x2 = line.EndPoint.X;
			double y2 = line.EndPoint.Y;

			double xc = circle.Center.X;
			double yc = circle.Center.Y;
			double r = circle.Radius;

			double dx = x2 - x1;
			double dy = y2 - y1;

			x1 -= xc;
			y1 -= yc;

			double A = dx * dx + dy * dy;
			double B = 2 * (x1 * dx + y1 * dy);
			double C = x1 * x1 + y1 * y1 - r * r;

			double Delta = B * B - 4 * A * C;

			List<double> t_value = new List<double>();

			if (Delta == 0)
				t_value.Add(-B / 2 / A);
			else if (Delta > 0) {
				t_value.Add((-B + Math.Sqrt(Delta)) / 2 / A);
				t_value.Add((-B - Math.Sqrt(Delta)) / 2 / A);
			}

			foreach (double t in t_value) {
				if ((t >= 0.0) && (t <= 1.0)) {
					double X = x1 + dx * t + xc;
					double Y = y1 + dy * t + yc;
					result.Add(new Vector3(X, Y));
				}
			}

			return result;
		}
				
		public static List<Vector3> LineArcIntersection(Line line, Arc arc) {
			List<Vector3> result = new List<Vector3>();
			List<Vector3> list = LineCircleIntersection(line, new Circle(arc.Center, arc.Radius));
			foreach (Vector3 v in list) {
				if (IsPointOnArc(arc,v))
					result.Add(v);
			}
			return result;
		}

		public static List<Vector3> LinePolylineIntersection(Line line,LwPolyline polyline) {
			List<Vector3> result = new List<Vector3>();

			foreach (EntityObject entity in polyline.Explode()) {
				switch (entity.Type) {
					case EntityType.Arc:
						List<Vector3> list = LineArcIntersection(line, entity as Arc);
						foreach(Vector3 v in list) {
							if (IsVector(v))
								result.Add(v);
						}
						break;
					case EntityType.Line:
						Vector3 intersect=LineLineIntersection(line, entity as Line, false);
						if (IsVector(intersect))
							result.Add(intersect);
						break;
				}
			}
			return result;
		}

		public static List<Vector3> CircleCircleIntersection(Circle circle1,Circle circle2) {
			List<Vector3> result = new List<Vector3>();

			double r1 = circle1.Radius;
			double r2 = circle2.Radius;
			double cx1 = circle1.Center.X;
			double cy1 = circle1.Center.Y;
			double cx2 = circle2.Center.X;
			double cy2 = circle2.Center.Y;

			double length = circle1.Center.DistanceFrom(circle2.Center);

			if (length > r1 + r2)
				return result;
			else if (length < Math.Abs(r1 - r2))
				return result;
			else if (HelperClass.IsZero(length))
				return result;
			else {
				double a = (r1 * r1 - r2 * r2 + length * length) / 2 / length;
				double h = Math.Sqrt(r1 * r1 - a * a);
				double kx = cx1 + a * (cx2 - cx1) / length;
				double ky = cy1 + a * (cy2 - cy1) / length;

				result.Add(new Vector3(kx + h * (cy2 - cy1) / length, ky - h * (cx2 - cx1) / length));
				result.Add(new Vector3(kx - h * (cy2 - cy1) / length, ky + h * (cx2 - cx1) / length));
			}
			return result;
		}

		public static List<Vector3> ArcCircleIntersection(Arc arc,Circle circle) {
			List<Vector3> result = new List<Vector3>();

			Circle circle1 = new Circle(arc.Center, arc.Radius);
			List<Vector3> list = CircleCircleIntersection(circle, circle1);
			if (list.Count > 0) {
				foreach(Vector3 v in list) {
					if (IsPointOnArc(arc, v))
						result.Add(v);
				}
			}
			return result;
		}

		public static List<Vector3> CircleEllipseIntersection(Circle circle,Ellipse ellipse) {
			List<Vector3> result = new List<Vector3>();
			ellipse.GetGeneralParameters(out double A, out double B, out double C, out double D, out double E, out double F);

			double xc = circle.Center.X;
			double yc = circle.Center.Y;
			double r = circle.Radius;
			double xe = ellipse.Center.X;
			double ye = ellipse.Center.Y;

			double A1 = A * xc * xc - 2 * A * xc * r + A * r * r + B * xc * yc - B * yc * r + C * yc * yc + D * xc - D * r + E * yc + F;
			double B1 = 2 * B * xc * r - 2 * B * r * r + 4 * C * yc * r + 2 * E * r;
			double C1 = 2 * A * (xc * xc - r * r) + 2 * B * xc * yc + 2 * C * yc * yc + 4 * C * r * r + 2 * D * xc + 2 * E * yc + 2 * F;
			double D1 = 2 * B * xc * r + 2 * B * r * r + 4 * C * yc * r + 2 * E * r;
			double E1 = A * xc * xc + 2 * A * xc * r + A * r * r + B * xc * yc + B * yc * r + C * yc * yc + D * xc + D * r + E * yc + F;

			double X, Y;
			List<System.Numerics.Complex> list = MyMath.SolvingQuadraticEquation(A1, B1, C1, D1, E1);

			foreach(System.Numerics.Complex c in list) {
				double t = c.Real;
				X = xc + r * (1 - t * t) / (1 + t * t);
				Y = yc + 2 * r * t / (1 + t * t);
				Vector3 v = new Vector3(X, Y);

				if (IsPointOnEllipse(ellipse, v))
					result.Add(v);
			}
			return result;
		}

		public static List<Vector3> CirclePolylineIntersection(Circle circle,LwPolyline polyline) {
			List<Vector3> result = new List<Vector3>();

			foreach (EntityObject entity in polyline.Explode()) {
				switch (entity.Type) {
					case EntityType.Arc:
						result.AddRange(ArcCircleIntersection(entity as Arc, circle));
						break;
					case EntityType.Line:
						result.AddRange(LineCircleIntersection(entity as Line, circle));
						break;
				}
			}
			return result;
		}

		public static List<Vector3> ArcArcIntersection(Arc arc1, Arc arc2) {
			List<Vector3> result = new List<Vector3>();

			try {
				Circle c1 = new Circle(arc1.Center, arc1.Radius);
				Circle c2 = new Circle(arc2.Center, arc2.Radius);

				List<Vector3> list = CircleCircleIntersection(c1, c2);

				if (list.Count > 0) {
					foreach (Vector3 v in list) {
						if (IsPointOnArc(arc1, v) && IsPointOnArc(arc2, v)) {
							result.Add(v);
						}
					}
				}
			} catch { }
			return result;
		}

		public static List<Vector3> ArcPolylineIntersection(Arc arc, LwPolyline polyline) {
			List<Vector3> result = new List<Vector3>();

			foreach (EntityObject entity in polyline.Explode()) {
				switch (entity.Type) {
					case EntityType.Arc:
						result.AddRange(ArcArcIntersection(entity as Arc, arc));
						break;
					case EntityType.Line:
						result.AddRange(LineArcIntersection(entity as Line, arc));
						break;
				}
			}
			return result;
		}

		public static List<Vector3> ArcEllipseIntersection(Arc arc, Ellipse ellipse) {
			List<Vector3> result = new List<Vector3>();

			Circle c = new Circle(arc.Center, arc.Radius);

			List<Vector3> list = CircleEllipseIntersection(c, ellipse);

			if (list.Count > 0) {
				foreach (Vector3 v in list) {
					if (IsPointOnArc(arc, v)) {
						result.Add(v);
					}
				}
			}
			return result;
		}

		public static List<Vector3> PolylineEllipseIntersection(LwPolyline polyline, Ellipse ellipse) {
			List<Vector3> result = new List<Vector3>();

			foreach (EntityObject entity in polyline.Explode()) {
				switch (entity.Type) {
					case EntityType.Arc:
						result.AddRange(ArcEllipseIntersection(entity as Arc, ellipse));
						break;
					case EntityType.Line:
						result.AddRange(LineEllipseIntersection(entity as Line, ellipse));
						break;
				}
			}
			return result;
		}

		public static List<Vector3> PolylinePolylineIntersection(LwPolyline polyline1,LwPolyline polyline2) {
			List<Vector3> result = new List<Vector3>();

			foreach (EntityObject entity in polyline1.Explode()) {
				switch (entity.Type) {
					case EntityType.Arc:
						result.AddRange(ArcPolylineIntersection(entity as Arc, polyline2));
						break;
					case EntityType.Line:
						result.AddRange(LinePolylineIntersection(entity as Line, polyline2));
						break;
				}
			}
			return result;
		}
		#endregion

		#region --- Is ---
		private static bool IsPointInPolyline(PointF[] rect, Vector3 point) {
			System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
			path.AddPolygon(rect);

			return path.IsVisible(point.ToPointF);
		}

		private static bool IsPointInPolyline(PointF[] rect, Vector2 point) {
			System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
			path.AddPolygon(rect);

			return path.IsVisible(point.ToPointF);
		}

		public static bool IsPointOnArc(Arc arc, Vector3 v) {
			Line line = new Line(arc.Center, v);

			double angle = line.Angle;
			double start = arc.StartAngle;
			double end = (arc.EndAngle + arc.StartAngle) % 360.0;

			if ((start < end) && (start <= angle) && (angle <= end))
				return true;
			else if ((start > end) && (angle >= start) && (angle <= 360.0))
				return true;
			else if ((start > end) && (angle >= 0) && (angle <= end))
				return true;
			else
				return false;
		}

		public static bool IsPointOnLine(Line line1,Vector3 point) {
			return HelperClass.IsEqual(line1.Length,line1.StartPoint.DistanceFrom(point)+line1.EndPoint.DistanceFrom(point));
		}		

		public static bool IsPointOnEllipse(Ellipse ellipse,Vector3 point) {
			double fl1 = ellipse.FocalPoint1.DistanceFrom(point);
			double fl2 = ellipse.FocalPoint2.DistanceFrom(point);
			double a = ellipse.MajorAxis;
			double angle = ellipse.Center.AngleWith(point);
			double start = (ellipse.Rotation + ellipse.StartAngle) % 360;
			double end = start + ellipse.EndAngle;

			if (ellipse.IsFullEllipse) {
				return HelperClass.IsEqual(fl1 + fl2, 2 * a, 1e-10);
			}else if ((angle >= start) && (angle <= end)) {
				if (HelperClass.IsEqual(fl1 + fl2, 2 * a, 1e-10))
					return true;
				else
					return false;
			}
			return false;
		}

		public static bool IsPointOnCircle(Circle circle,Vector3 point) {
			double length=circle.Center.DistanceFrom(point);
			return HelperClass.IsEqual(circle.Radius, length);
		}

		public static bool IsPointOnPolyline(LwPolyline polyline,Vector3 point) {
			bool result = false;
			foreach (EntityObject entity in polyline.Explode()) {
				switch (entity.Type) {
					case EntityType.Arc:
						if (IsPointOnArc(entity as Arc, point)) {
							result = true;
							break;
						}
						break;
					case EntityType.Line:
						if (IsPointOnLine(entity as Line, point)) {
							result = true;
							break;
						}
						break;
				}
			}
			return result;
		}

		public static bool IsArcInsidePolyline(PointF[] rect,Arc arc) {
			bool result = true;
			foreach (LwPolylineVertex lw in arc.FitRectangle.Vertexes) {
				if (!IsPointInPolyline(rect, lw.Position)) {
					result = false;
					break;
				}
			}
			return result;
		}

		public static bool IsCircleInsidePolyline(PointF[] rect,Circle circle) {
			bool result = true;
			foreach (LwPolylineVertex lw in circle.Rectangle.Vertexes) {
				if (!IsPointInPolyline(rect, lw.Position)) {
					result = false;
					break;
				}
			}
			return result;
		}

		public static bool IsLineInsidePolyline(PointF[] rect,Line line) {
			return IsPointInPolyline(rect, line.StartPoint) && IsPointInPolyline(rect, line.EndPoint);
		}

		public static bool IsEllipseInsidePolyline(PointF[] rect,Ellipse ellipse) {
			bool result = true;
			foreach (LwPolylineVertex lw in ellipse.FitRectangle.Vertexes) {
				if (!IsPointInPolyline(rect, lw.Position)) {
					result = false;
					break;
				}
			}
			return result;
		}

		public static bool IsPolylineInsidePolyline(PointF[] rect,LwPolyline polyline) {
			bool result = true;
			foreach (LwPolylineVertex lw in polyline.Vertexes) {
				if (!IsPointInPolyline(rect, lw.Position)) {
					result = false;
					break;
				}
			}
			return result;
		}

		public static bool IsPointInsidePie(Arc pie,Vector3 point) {
			double length = pie.Center.DistanceFrom(point);
			double angle = pie.Center.AngleWith(point);
			double start = pie.StartAngle;
			double end = (pie.EndAngle + pie.StartAngle) % 360;

			if (HelperClass.IsEqual(pie.Radius, length) || (pie.Radius > length)) {
				if ((start < end) && (start <= angle) && (angle <= end))
					return true;
				else if ((start > end) && (angle >= start) && (angle <= 360))
					return true;
				else if ((start > end) && (angle >= 0) && (angle <= end))
					return true;
			}
			return false;
		}

		public static bool IsNumber(double number) {
			return !double.IsNaN(number) && !double.IsInfinity(number);
		}

		public static bool IsNumber(float number) {
			return !float.IsNaN(number) && !float.IsInfinity(number);
		}

		public static bool IsVector(Vector3 vector) {
			return IsNumber(vector.X) && IsNumber(vector.Y) && IsNumber(vector.Z);
		}

		public static bool IsVector(Vector2 vector) {
			return IsNumber(vector.X) && IsNumber(vector.Y);
		}
		#endregion

		#region Get functions
		public static Arc GetArcWith3Points(Vector3 p1,Vector3 p2,Vector3 p3) {
			double start, end;
			Arc result = new Arc();

			Circle c = GetCircleWith3Point(p1, p2, p3);

			if (c.Radius>0) {
				if (HelperClass.DeterminePointOfLine(new Line(p1, p3), p2) < 0) {
					start = LineAngle(c.Center, p3);
					end = LineAngle(c.Center, p1);
				} else {
					start = LineAngle(c.Center, p1);
					end = LineAngle(c.Center, p3);
				}
				if (end > start)
					end -= start;
				else
					end += 360.0 - start;

				result = new Arc(c.Center, c.Radius, start, end);
			}

			return result;
		}
		
		public static Arc GetArcWithCenterStartEnd(Vector3 center,Vector3 startPoint,Vector3 endPoint) {
			double start = LineAngle(center, startPoint);
			double end = LineAngle(center, endPoint);
			double radius = center.DistanceFrom(startPoint);

			if (end > start)
				end -= start;
			else
				end += 360.0 - start;

			return new Arc(center, radius, start, end);
		}

		public static Arc GetArcWithCenterStartAngle(Vector3 center,Vector3 startPoint,double angle) {
			double start = LineAngle(center, startPoint);
			double end = angle + start;
			double radius = center.DistanceFrom(startPoint);

			if (end > start)
				end -= start;
			else
				end += 360.0 - start;

			return new Arc(center, radius, start, end);
		}

		public static Arc GetArcWithCenterStartLength(Vector3 center,Vector3 startPoint,double length) {
			Arc arc = new Arc();
			double start = LineAngle(center, startPoint);
			double radius = center.DistanceFrom(startPoint);

			if (length <= radius * 2) {
				double a = (2 * radius * radius - length * length) / (2 * radius * radius);
				double end = Math.Acos(a) * 180.0 / Math.PI;
				arc = new Arc(center, radius, start, end);
			}
			return arc;
		}

		public static Arc GetArcWithStartEndAngle(Vector3 startPoint,Vector3 endPoint,double angle) {
			Arc arc = new Arc();

			double length = startPoint.DistanceFrom(endPoint);
			double radius = Math.Sqrt(length * length / (1 - Math.Cos(angle * Math.PI / 180.0)) / 2);

			if (length <= radius * 2) {
				double a = (180.0 - angle) / 2;
				a += LineAngle(startPoint, endPoint);

				double x = radius * Math.Cos(a * Math.PI / 180.0) + startPoint.X;
				double y = radius * Math.Sin(a * Math.PI / 180.0) + startPoint.Y;
				Vector3 center = new Vector3(x, y);

				double start = LineAngle(center, startPoint);
				double end = LineAngle(center, endPoint);

				if (end > start)
					end -= start;
				else
					end += 360.0 - start;

				arc=new Arc(center,radius, start, end);
			}
			return arc;
		}

		public static Arc GetArcWithStartEndRadius(Vector3 startPoint,Vector3 endPoint,double radius) {
			Arc arc = new Arc();
			double l = startPoint.DistanceFrom(endPoint);

			if (l <= radius * 2) {
				double a = (2 * radius * radius - l * l) / (2 * radius * radius);
				double angle = Math.Acos(a) * 180.0 / Math.PI;
				angle = (180.0 - angle) / 2;
				angle += LineAngle(startPoint, endPoint);

				double x = radius * Math.Cos(angle * Math.PI / 180.0) + startPoint.X;
				double y = radius * Math.Sin(angle * Math.PI / 180.0) + startPoint.Y;
				Vector3 center = new Vector3(x, y);

				double start = LineAngle(center, startPoint);
				double end = LineAngle(center, endPoint);

				if (end > start)
					end -= start;
				else
					end += 360.0 - start;

				arc = new Arc(center, radius, start, end);
			}
			return arc;
		}

		public static void GetArc(int index, Vector3 p1,Vector3 p2,Vector3 p3,out Arc ResultArc) {
			Arc arc = new Arc();

			Vector3 center = p1;
			double angle = center.AngleWith(p3);
			double start = arc.StartAngle;
			double end = angle;
			double radius = center.DistanceFrom(p2);
			double length = p1.DistanceFrom(p2);
			double d = HelperClass.DeterminePointOfLine(new Line(p1, p2), p3);

			switch (index) {
				case 10: // 3-Points
					radius = GetCircleWith3Point(p1, p2, p3).Radius;
					center = GetCircleWith3Point(p1, p2, p3).Center;
					start = center.AngleWith(p1);
					end = center.AngleWith(p3);

					if (HelperClass.DeterminePointOfLine(new Line(p1, p3), p2) < 0) {
						start = center.AngleWith(p3);
						end = center.AngleWith(p1);
					}
					break;
				case 11: // Start, Center, End
					center = p2;
					start = center.AngleWith(p1);
					radius = center.DistanceFrom(p1);
					end = center.AngleWith(p3);
					break;
				case 12: // Start, Center, Angle
					center = p2;
					start = center.AngleWith(p1);
					radius = p1.DistanceFrom(p2);
					end = center.AngleWith(p3);
					break;
				case 13: // Start, Center, Length
					center = p2;
					start = center.AngleWith(p1);
					radius = center.DistanceFrom(p1);
					end = p1.AngleWith(p3);

					if (length <= radius * 2) {
						double a = (2 * radius * radius - length * length) / (2 * radius * radius);
						end = Math.Acos(a) * 180 / Math.PI;
					} else {
						center = Vector3.Zero;
						radius = HelperClass.Epsilon;
						start = 0;
						end = HelperClass.Epsilon;
					}
					break;
				case 14: // Start, End, Angle
					radius = Math.Sqrt(length * length / (1 - Math.Cos(angle * HelperClass.DegToRad)) / 2);

					if (length <= radius * 2) {
						double a = (180.0 - angle) / 2;
						a += p1.AngleWith(p2);
						center = p1.Transfer2D(radius, a);
						start = center.AngleWith(p1);
						end = center.AngleWith(p2);
					}
					break;
				case 15: // Start, End, Direction
					Line l1 = new Line(p1, p2);
					Line l2 = new Line(p1, p3);

					angle = l1.AngleWith(l2) * 2;

					if (angle < 0.0)
						angle += 360.0;

					radius = Math.Sqrt(length * length / (1 - Math.Cos(angle * HelperClass.DegToRad)) / 2);

					if (length <= radius * 2) {
						double a = (angle / 180.0) / 2;
						a += p1.AngleWith(p2);

						center = p1.Transfer2D(radius, a);

						start = center.AngleWith(p1);
						end = center.AngleWith(p2);

						if (d < 0) {
							start = center.AngleWith(p1);
							end = center.AngleWith(p2);
						}
					}
					break;
				case 16: // Start, End, Radius
					radius = p2.DistanceFrom(p3);

					if (length <= radius * 2) {
						double a = (2 * radius * radius - length * length) / (2 * radius * radius);
						angle = Math.Acos(a) * HelperClass.RadToDeg;
						angle = (180.0 - angle) / 2;
						angle += p1.AngleWith(p2);

						center = p1.Transfer2D(radius, angle);

						start = center.AngleWith(p1);
						end = center.AngleWith(p2);
					} else {
						center = Vector3.Zero;
						radius = HelperClass.Epsilon;
						start = 0;
						end = HelperClass.Epsilon;
					}
					break;
				case 17: // Center, Start, End
					start = center.AngleWith(p2);
					end = center.AngleWith(p3);
					break;
				case 18: // Center, Start, Angle
					start = center.AngleWith(p2);
					end = angle + start;
					break;
				case 19: // Center, Start, Length
					start = center.AngleWith(p2);
					end = p2.DistanceFrom(p3);

					if (length <= radius * 2) {
						double a=(2*radius*radius-length*length) / (2 * radius*radius);
						end = Math.Acos(a) * HelperClass.RadToDeg;
					} else {
						center = Vector3.Zero;
						radius = HelperClass.Epsilon;
						start = 0;
						end = HelperClass.Epsilon;
					}
					break;
			}
			if (index != 13 && index != 19) {
				end = (end > start) ? end - start : end - start + 360;
			}

			if (radius > 0)
				arc = new Arc(center, radius, start, end);

			ResultArc = arc;
		}
				
		public static Circle GetCircle(Vector3 center,double radius) {
			return new Circle(center, radius);
		}
		
		public static Circle GetCircleWith2Point(Vector3 firstPoint,Vector3 secondPoint) {
			double radius = firstPoint.DistanceFrom(secondPoint) / 2;
			double x = (secondPoint.X + firstPoint.X) / 2;
			double y = (secondPoint.Y + firstPoint.Y) / 2;

			return new Circle(new Vector3(x, y), radius);
		}
		
		public static Circle GetCircleWith3Point(Vector3 p1,Vector3 p2,Vector3 p3) {
			double x1 = (p1.X + p2.X) / 2;
			double y1 = (p1.Y + p2.Y) / 2;
			double dx1 = p2.X - p1.X;
			double dy1 = p2.Y - p1.Y;

			double x2 = (p2.X + p3.X) / 2;
			double y2 = (p2.Y + p3.Y) / 2;
			double dx2 = p3.X - p2.X;
			double dy2 = p3.Y - p2.Y;

			Line line1 = new Line(new Vector3(x1, y1), new Vector3(x1 - dy1, y1 + dx1));
			Line line2 = new Line(new Vector3(x2, y2), new Vector3(x2 - dy2, y2 + dx2));

			Vector3 center = LineLineIntersection(line1, line2, true);

			double dx = center.X - p1.X;
			double dy = center.Y - p1.Y;

			double radius = Math.Sqrt(dx * dx + dy * dy);

			return new Circle(center, radius);
		}

		public static Ellipse GetEllipse(Vector3 center, Vector3 firstPoint, Vector3 secondPoint) {
			double major = center.DistanceFrom(firstPoint);
			double minor = center.DistanceFrom(secondPoint);
			double angle = LineAngle(center, firstPoint);
			Ellipse elp = new Ellipse(center, Math.Max(major, minor), Math.Min(major, minor));
			angle = (major > minor) ? angle : angle + 90;
			elp.Rotation = angle % 360;
			return elp;
		}

		public static Ellipse GetEllipticalArc(Vector3 center, Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4) {
			Ellipse elp = GetEllipse(center, p1, p2);
			double start = LineAngle(center, p3);
			double end = LineAngle(center, p4);

			end = (end > start) ? end - start : end - start + 360.0;
			start -= elp.Rotation;

			elp.StartAngle = start;
			elp.EndAngle = end;

			return elp;
		}
		#endregion

		#region --- Distance ---
		public static double DistanceFromLine(Line line,Vector3 point,out Vector3 closest,bool IsExtended = false) {
			double x1 = line.StartPoint.X;
			double y1 = line.StartPoint.Y;
			double x2 = line.EndPoint.X;
			double y2 = line.EndPoint.Y;

			double x = point.X;
			double y = point.Y;

			double dx = x2 - x1;
			double dy = y2 - y1;

			if ((dx==0) && (dy == 0)) {
				closest = line.StartPoint;
				dx = x - x1;
				dy = y - y1;
				return Math.Sqrt(dx * dx + dy * dy);
			}

			double k = ((x - x1) * dx + (y - y1) * dy) / (dx * dx + dy * dy);

			closest = new Vector3(x1 + k * dx, y1 + k * dy);
			dx = x - closest.X;
			dy = y - closest.Y;

			if (!IsExtended) {
				if (k < 0) {
					closest = new Vector3(x1, y1);
					dx = x - x1;
					dy = y - y1;
				} else if (k>1) {
					closest = new Vector3(x2, y2);
					dx = x - x2;
					dy = y - y2;
				}
			}

			return Math.Sqrt(dx * dx + dy * dy);
		}

		public static double DistancePointToEllipse(Ellipse ellipse,Vector3 point,out Vector3 PointOnEllipse) {
			double a = ellipse.MajorAxis;
			double b = ellipse.MinorAxis;
			double angle = ellipse.Rotation * HelperClass.DegToRad;
			double sin = Math.Sin(angle);
			double cos = Math.Cos(angle);
			double xc = ellipse.Center.X;
			double yc = ellipse.Center.Y;

			double x1 = point.X;
			double y1 = point.Y;

			x1 -= xc;
			y1 -= yc;

			double xr = cos * x1 + sin * y1;
			double yr = -sin * x1 + cos * y1;

			double xt = cos;
			double yt = sin;
			double x = 0, y = 0;

			foreach (int i in Enumerable.Range(0, 3)) {
				x = a * xt;
				y = b * yt;

				double ex = (a * a - b * b) * Math.Pow(xt, 3) / a;
				double ey = (b * b - a * a) * Math.Pow(yt, 3) / b;

				double xq = Math.Abs(xr) - ex;
				double yq = Math.Abs(yr) - ey;

				double nx = Math.Sqrt((x - ex) * (x - ex) + (y - ey) * (y - ey)) / Math.Sqrt(xq * xq + yq * yq);

				xt = (xq * nx + ex) / a;
				yt = (yq * nx + ey) / b;

				double nt = Math.Sqrt(xt * xt + yt * yt);
				xt /= nt;
				yt /= nt;
			}
			x = HelperClass.CopySign(x, xr);
			y = HelperClass.CopySign(y, yr);

			PointOnEllipse = new Vector3(cos * x - sin * y + xc, sin * x + cos * y + yc);

			return point.DistanceFrom(PointOnEllipse);
		}

		public static double DistancePointToCircle(Circle circle,Vector3 point,out Vector3 PointOnCircle) {
			double d = point.DistanceFrom(circle.Center) - circle.Radius;
			double angle = LineAngle(point, circle.Center);

			double x = d * Math.Cos(angle * HelperClass.DegToRad) + point.X;
			double y = d * Math.Sin(angle * HelperClass.DegToRad) + point.Y;

			PointOnCircle = new Vector3(x, y);

			return point.DistanceFrom(PointOnCircle);
		}

		public static double DistancePointToArc(Arc arc,Vector3 point,out Vector3 PointOnArc) {
			double d = point.DistanceFrom(arc.Center) - arc.Radius;
			double angle = LineAngle(point, arc.Center);

			double x = d * Math.Cos(angle * HelperClass.DegToRad) + point.X;
			double y = d * Math.Sin(angle * HelperClass.DegToRad) + point.Y;

			Vector3 result = new Vector3(x, y);
			
			if (IsPointOnArc(arc,result)) {
				PointOnArc = result;
			} else {
				double dist1 = arc.StartPoint.DistanceFrom(point);
				double dist2 = arc.EndPoint.DistanceFrom(point);

				if (dist1 < dist2) {
					d = dist1;
					PointOnArc = arc.StartPoint;
				} else {
					d = dist2;
					PointOnArc = arc.EndPoint;
				}
			}
			return Math.Abs(d);
		}

		public static double DistancePointToLwPolyline(LwPolyline polyline,Vector3 point,out Vector3 PointOnLwPolyline, out int INDEX) {
			double result = double.MaxValue;
			PointOnLwPolyline = new Vector3();
			List<EntityObject> entities = polyline.Explode();
			int index = -1;

			for (int i=0; i< entities.Count; i++) {
				switch (entities[i].Type) {
					case EntityType.Line:
						double d = DistanceFromLine(entities[i] as Line, point, out Vector3 v);
						if (d < result) {
							PointOnLwPolyline = v;
							result = d;
							index = i;
						}
						break;
					case EntityType.Arc:
						d = DistancePointToArc(entities[i] as Arc, point, out v);
						if (d < result) {
							PointOnLwPolyline = v;
							result = d;
							index = i;
						}
						break;
				}
			}
			INDEX = index;
			return result;
		}
		#endregion
		
		public static LwPolyline PointToRect(Vector3 firstCorner,Vector3 secondCorner, out int direction) {
			double x = Math.Min(firstCorner.X, secondCorner.X);
			double y = Math.Min(firstCorner.Y, secondCorner.Y);
			double width = Math.Abs(secondCorner.X - firstCorner.X);
			double height = Math.Abs(secondCorner.Y - firstCorner.Y);

			double dx = secondCorner.X - firstCorner.X;

			List<LwPolylineVertex> vertexes = new List<LwPolylineVertex>();
			vertexes.Add(new LwPolylineVertex(x, y));
			vertexes.Add(new LwPolylineVertex(x+width, y));
			vertexes.Add(new LwPolylineVertex(x+width, y+height));
			vertexes.Add(new LwPolylineVertex(x, y+height));

			if (dx > 0) direction = 1;
			else if (dx < 0) direction = 2;
			else direction = -1;

			return new LwPolyline(vertexes, true);
		}

		public static LwPolyline GetPolygon(Vector3 center, Vector3 secondPoint, int sidesQty, int inscribed) {
			List<LwPolylineVertex> vertexes = new List<LwPolylineVertex>();
			double sides_angle = 360.0 / sidesQty;
			double radius = center.DistanceFrom(secondPoint);
			double lineangle = LineAngle(center, secondPoint);

			if (inscribed == 1) {
				lineangle -= sides_angle / 2.0;
				radius /= Math.Cos(sides_angle / 180.0 * Math.PI / 2.0);
			}

			for (int i = 0; i < sidesQty; i++) {
				double x = center.X + radius * Math.Cos(lineangle / 180.0 * Math.PI);
				double y = center.Y + radius * Math.Sin(lineangle / 180.0 * Math.PI);

				vertexes.Add(new LwPolylineVertex(x, y));
				lineangle += sides_angle;
			}

			return new LwPolyline(vertexes, true);
		}

		public static Bitmap SetCursor(int index,float size,Color color) {
			Bitmap bmp = new Bitmap((int)size + 1, (int)size + 1);
			float cx = size / 2;
			float cy = size / 2;
			PointF[] points;

			using (Graphics gr = Graphics.FromImage(bmp)) {
				gr.Clear(Color.Transparent);
				switch (index) {
					case 0: // Default cursor
						break;
					case 1: // Drawing cursor
						points = new PointF[] {
							new PointF(cx,0),
							new PointF(2*cx,cy),
							new PointF(cx,2*cy),
							new PointF(0,cy)
						};
						gr.DrawLine(new Pen(color, 2.0f), points[0], points[2]);
						gr.DrawLine(new Pen(color, 2.0f), points[1], points[3]);
						break;
					case 2: // Editing cursor
						points = new PointF[] {
							new PointF(1,1),
							new PointF(2*cx-1,1),
							new PointF(2*cx-1,2*cy-1),
							new PointF(1,2*cy-1)
						};
						gr.DrawPolygon(new Pen(color, 2.0f), points);
						break;
				}
				return bmp;
			}
		}

		public static bool IsMouseOnEntity(List<EntityObject> entities, Vector3 mousePosition, PointF[] cursor_rect, out int index) {
			Vector3 poSegment = new Vector3();

			for (int i = 0; i < entities.Count; i++) {
				switch (entities[i].Type) {
					case EntityType.Arc:
						double d = DistancePointToArc(entities[i] as Arc,mousePosition,out poSegment);
						break;
					case EntityType.Circle:
						d = DistancePointToCircle(entities[i] as Circle, mousePosition, out poSegment);
						break;
					case EntityType.Ellipse:
						d = DistancePointToEllipse(entities[i] as Ellipse, mousePosition, out poSegment);
						break;
					case EntityType.Line:
						d = DistanceFromLine(entities[i] as Line, mousePosition, out poSegment);
						break;
					case EntityType.LwPolyline:
						d = DistancePointToLwPolyline(entities[i] as LwPolyline, mousePosition, out poSegment, out int INDEX);
						break;
					case EntityType.Point:
						poSegment = (entities[i] as Entities.Point).Position;
						break;
					case EntityType.Text:
						cursor_rect = (entities[i] as Text).RectangleF;
						poSegment = mousePosition;
						break;
				}
					if (IsPointInPolyline(cursor_rect, poSegment)) {
						index = i;	
						return true;
					}
				
			}
			index = -1;
			return false;
		}		

		public static void Modify1Selection(int modifyIndex, List<EntityObject> entities, Vector3 fromPoint, Vector3 toPoint, bool flags = false) {
			for (int i = 0; i < entities.Count; i++) {
				if (entities[i].IsSelected) {
					switch (modifyIndex) {
						case 0: // Copy
							entities.Add(entities[i].CopyOrMove(fromPoint, toPoint) as EntityObject);
							break;
						case 1: // Move
							entities[i] = entities[i].CopyOrMove(fromPoint,toPoint) as EntityObject;
							entities[i].DeSelect();
							break;
						case 3: // Rotate
							entities[i] = entities[i].Rotate2D(fromPoint, fromPoint.AngleWith(toPoint)) as EntityObject;
							entities[i].DeSelect();
							break;
						case 4: // Mirror
							EntityObject entity = entities[i].Mirror2D(fromPoint, toPoint) as EntityObject;
							
							if (flags) {
								entities[i] = (EntityObject)entity.Clone();
							} else {
								entities.Add(entity);
							}
							entities[i].DeSelect();
							break;
						case 5: // Scale
							entities[i] = entities[i].Scale(fromPoint, fromPoint.DistanceFrom(toPoint)) as EntityObject;
							entities[i].DeSelect();
							break;
					}
				}
			}
		}

		public static void LinearArray2D(List<EntityObject> entities,
			int horizontalQty, int verticalQty,
			double horizontalDist, double verticalDist,
			int direction) {
			for (int i = 0; i < entities.Count; i++) {
				if (entities[i].IsSelected) {
					EntityObject[] array = entities[i].LinearArray2D(horizontalQty, verticalQty, horizontalDist, verticalDist, direction) as EntityObject[];
					for (int j = 1; j < array.Length; j++)
						entities.Add(array[j]);
					entities[i].DeSelect();
				}
			}
		}

		public static void CircularArray2D(List<EntityObject> entities,Vector3 basePoint,double fillAngle,int items,bool isRotatedItems) {
			for (int i = 0; i < entities.Count; i++) {
				if (entities[i].IsSelected) {
					EntityObject[] entity = entities[i].CircularArray2D(basePoint,fillAngle,items,isRotatedItems) as EntityObject[];
					for (int j = 0; j < entity.Length; j++)
						entities.Add(entity[j]);
					entities[i].DeSelect();
				}
			}
		}

		public static void Offset(List<EntityObject> entities,Vector3 insertPoint,double offsetValue) {
			try {
				foreach (EntityObject entity in entities) {
					if (entity.IsSelected) {
						switch (entity.Type) {
							case EntityType.Arc:
								Arc arc = (entity as Arc).Offset(insertPoint, offsetValue) as Arc;
								if (arc != null)
									entities.Add(arc);
								break;
							case EntityType.Circle:
								Circle circle = (entity as Circle).Offset(insertPoint, offsetValue) as Circle;
								if (circle != null)
									entities.Add(circle);
								break;
							case EntityType.Ellipse:
								Ellipse ellipse = (entity as Ellipse).Offset(insertPoint, offsetValue) as Ellipse;
								if (ellipse != null)
									entities.Add(ellipse);
								break;
							case EntityType.Line:
								entities.Add((entity as Line).Offset(insertPoint, offsetValue) as EntityObject);
								break;
							case EntityType.LwPolyline:
								entities.Add((entity as LwPolyline).Offset(insertPoint, offsetValue) as EntityObject);
								break;
							case EntityType.Point:
								return;
							case EntityType.Text:
								return;
						}
					}
				}
			} catch { }
		}

		public static void SelectWindow(List<EntityObject> entities, Vector3 firstCorner, Vector3 secondCorner) {
			LwPolyline rect = PointToRect(firstCorner, secondCorner, out int direction);
			List<PointF> window = new List<PointF>();
			List<Vector3> intersection;

			foreach (LwPolylineVertex lwp in rect.Vertexes)
				window.Add(lwp.Position.ToPointF);

			switch (direction) {
				case 1: // Left to rhight selection
					foreach (EntityObject entity in entities) {
						switch (entity.Type) {
							case EntityType.Arc:
								if (IsArcInsidePolyline(window.ToArray(), entity as Arc)) {
									entity.Select();
								}
								break;
							case EntityType.Circle:
								if (IsCircleInsidePolyline(window.ToArray(), entity as Circle)) {
									entity.Select();
								}
								break;
							case EntityType.Ellipse:
								if (IsEllipseInsidePolyline(window.ToArray(), entity as Ellipse)) {
									entity.Select();
								}
								break;
							case EntityType.Line:
								if (IsLineInsidePolyline(window.ToArray(), entity as Line)) {
									entity.Select();
								}
								break;
							case EntityType.LwPolyline:
								if (IsPolylineInsidePolyline(window.ToArray(), entity as LwPolyline)) {
									entity.Select();
								}
								break;
							case EntityType.Point:
								if (IsPointInPolyline(window.ToArray(), (entity as Entities.Point).Position)) {
									entity.Select();
								}
								break;
							case EntityType.Text:
								if (IsPolylineInsidePolyline(window.ToArray(), (entity as Text).Rectangle))
									entity.Select();
								break;
						}
					}
					break;
				case 2: // Right to left selection
					foreach (EntityObject entity in entities) {
						switch (entity.Type) {
							case EntityType.Arc:
								intersection = ArcPolylineIntersection(entity as Arc, rect);
								if ((intersection.Count > 0) || (IsArcInsidePolyline(window.ToArray(), entity as Arc))) {
									entity.Select();
								}
								break;
							case EntityType.Ellipse:
								intersection = PolylineEllipseIntersection(rect,entity as Ellipse);
								if ((intersection.Count > 0) || (IsEllipseInsidePolyline(window.ToArray(), entity as Ellipse))) {
									entity.Select();
								}
								break;
							case EntityType.Circle:
								intersection = CirclePolylineIntersection(entity as Circle, rect);
								if ((intersection.Count > 0) || (IsCircleInsidePolyline(window.ToArray(), entity as Circle))) {
									entity.Select();
								}
								break;
							case EntityType.Line:
								intersection = LinePolylineIntersection(entity as Line, rect);
								if ((intersection.Count > 0) || (IsLineInsidePolyline(window.ToArray(), entity as Line))) {
									entity.Select();
								}
								break;
							case EntityType.LwPolyline:
								intersection = PolylinePolylineIntersection(entity as LwPolyline, rect);
								if ((intersection.Count > 0) || (IsPolylineInsidePolyline(window.ToArray(), entity as LwPolyline))) {
									entity.Select();
								}
								break;
							case EntityType.Point:
								if (IsPointInPolyline(window.ToArray(),(entity as Entities.Point).Position)) {
									entity.Select();
								}
								break;
							case EntityType.Text:
								intersection = PolylinePolylineIntersection(rect, (entity as Text).Rectangle);
								if ((intersection.Count>0 || IsPolylineInsidePolyline(window.ToArray(),(entity as Text).Rectangle))) {
									entity.Select();
								}
								break;
						}
					}
					break;
			}
		}

		public static void Delete(List<EntityObject> entities) {
			for (int i = 0; i < entities.Count; i++) {
				if (entities[i].IsSelected) {
					entities.RemoveAt(i);
					i--;
				}
			}
		}		
	}
}
