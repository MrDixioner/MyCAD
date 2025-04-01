using System;

namespace MyCAD {
    public class Vector2 {
		private double x;
		private double y;

		public Vector2() : this(0.0, 0.0) { }

		public Vector2(double x, double y) {
			this.x = x;
			this.y = y;
		}

		public double  X {
			get { return x; }
			set { x = value; }
		}

		public double  Y {
			get { return y; }
			set { y = value; }
		}
		
		public static Vector2 Zero {
			get { return new Vector2(0.0, 0.0); }
		}

		public static Vector2 UnitX {
			get { return new Vector2(1.0, 0.0); }
		}

        public static Vector2 UnitY {
            get { return new Vector2(0.0, 1.0); }
        }

        public static Vector2 NaN {
            get { return new Vector2(double.NaN, double.NaN); }
        }

        public double this[int index] {
            get {
                switch (index) {
                    case 0:
                        return x;
                    case 1:
                        return y;                    
                    default:
                        throw (new ArgumentOutOfRangeException(nameof(index)));
                }
            }
            set {
                switch (index) {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;                    
                    default:
                        throw (new ArgumentOutOfRangeException(nameof(index)));
                }
            }
        }

        public static double DotProduct(Vector2 v1, Vector2 v2) {
            return v1.X * v2.Y + v1.Y * v2.X;
        }

        public static double CrossProduct(Vector2 v1, Vector2 v2) {            
            return v1.X * v2.Y - v1.Y * v2.X;
        }

        public static double Angle(Vector2 v) {
            double angle = Math.Atan2(v.Y, v.X);
            if (angle < 0)
                return 2 * Math.PI + angle;
            return angle;
        }

		public static double Angle(Vector2 p1,Vector2 p2) {
			Vector2 result = p2 - p1;
			return Angle(result);
		}

        public double AngleWith(Vector2 v) {
            double angle = Math.Atan2((v.Y - y), (v.X - x)) * 180.0 / Math.PI;
            if (angle < 0)
                angle += 360.0;
            return angle;
        }

        public double Modulus() {
            return Math.Sqrt(DotProduct(this, this));
        }

        public void Normalize() {
            double m = Modulus();
            if (HelperClass.IsZero(m, HelperClass.Epsilon))
                throw new ArithmeticException("Cannot normalize a zero vector.");
            double m_inv = 1 / m;
            x *= m_inv;
            y *= m_inv;            
        }

        public static bool operator ==(Vector2 v1, Vector2 v2) {
            return Equals(v1, v2);
        }

        public static bool operator !=(Vector2 v1, Vector2 v2) {
            return !Equals(v1, v2);
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2) {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2) {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector2 operator -(Vector2 v) {
            return new Vector2(-v.X, -v.Y);
        }

        public static Vector2 operator *(Vector2 v, double d) {
            return new Vector2(v.X * d, v.Y * d);
        }

        public static Vector2 operator *(double d, Vector2 v) {
            return new Vector2(v.X * d, v.Y * d);
        }

        public static Vector2 operator*(Vector2 v1,Vector2 v2) {
            return new Vector2(v1.X * v2.X, v1.Y * v2.Y);
        }

        public static Vector2 operator /(Vector2 v, double d) {
            double inv = 1 / d;
            return v * inv;
        }

        public static Vector2 operator /(Vector2 v1, Vector2 v2) {
            return new Vector2(v1.X / v2.X, v1.Y / v2.Y);
        }

        public bool Equals(Vector2 v) {
            return Equals(v,HelperClass.Epsilon);
        }

        public bool Equals(Vector2 v, double threshold) {
            return (HelperClass.IsEqual(v.X, threshold) &&
                HelperClass.IsEqual(v.Y, threshold));
        }

        public static bool Equals(Vector2 v1, Vector2 v2) {
            return v1.Equals(v2, HelperClass.Epsilon);
        }

        public static bool Equals(Vector2 v1,Vector2 v2, double threshold) {
            return v1.Equals(v2, threshold);
        }

        public override bool Equals(object obj) {
            if (obj is Vector2)
                return Equals((Vector2)obj);
            return false;
        }

        public Vector3 ToVector3 {
            get { return new Vector3(x, y); }
        }

        public Vector2 Transfer2D(double length, double angle) {
            double x = length * Math.Cos(angle * Math.PI / 180.0) + this.x;
            double y = length * Math.Sin(angle * Math.PI / 180.0) + this.y;

            return new Vector2(x, y);
        }

        public Vector2 CopyOrMove(Vector2 fromPoint,Vector2 toPoint) {
            double dx = toPoint.X - fromPoint.X;
            double dy = toPoint.Y - fromPoint.Y;

            return new Vector2(x + dx, y + dy);
        }

        public Vector2 Rotate2D(Vector3 basePoint,Vector3 targetPoint) {
            double angle = basePoint.AngleWith(targetPoint);
            double length = basePoint.DistanceFrom(ToVector3);
            angle += basePoint.AngleWith(ToVector3);

            double sin = Math.Sin(angle * Math.PI / 180.0);
            double cos = Math.Cos(angle * Math.PI / 180.0);

            double x = length * cos + basePoint.X;
            double y = length * sin + basePoint.Y;

            return new Vector2(x, y);
        }

		public Vector2 Rotate2D(Vector3 basePoint, double angle) {
			angle += basePoint.AngleWith(ToVector3);
			double length = basePoint.DistanceFrom(ToVector3);

			double sin = Math.Sin(angle * Math.PI / 180.0);
			double cos = Math.Cos(angle * Math.PI / 180.0);

			double x = length * cos + basePoint.X;
			double y = length * sin + basePoint.Y;

			return new Vector2(x, y);
		}

        public Vector2 Mirror2D(Vector3 basePoint,Vector3 targetPoint) {
            double angle = basePoint.AngleWith(targetPoint);
            angle = 2 * angle - basePoint.AngleWith(ToVector3);
            double length = basePoint.DistanceFrom(ToVector3);

            double sin = Math.Sin(angle * Math.PI / 180.0);
            double cos = Math.Cos(angle * Math.PI / 180.0);

            double x = length * cos + basePoint.X;
            double y = length * sin + basePoint.Y;

            return new Vector2(x, y);
        }

		public Vector2 Scale(Vector3 basePoint, double value) {
			double length = DistanceFrom(basePoint.ToVector2) * value;
			double angle = basePoint.AngleWith(ToVector3) * Math.PI / 180.0;
			double x = length * Math.Cos(angle) + basePoint.X;
			double y = length * Math.Sin(angle) + basePoint.Y;
			return new Vector2(x, y);
		}

		public override string ToString() {
            return string.Format($"{x,0:F3}, {y,0:F3}");
        }
        
        public double DistanceFrom(Vector2 v) {
			double dx=v.X-X;
			double dy=v.Y-Y;
			return Math.Sqrt(dx * dx + dy * dy);
		}

		public System.Drawing.PointF ToPointF {
			get { return new System.Drawing.PointF((float)X, (float)Y); }
		}
	}
}
