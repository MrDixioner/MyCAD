using System;

namespace MyCAD.Entities {
	public class LwPolylineVertex:ICloneable {
		private Vector2 position;
		private double bulge; // С помощью bulge (выпуклости) мы можем определить радиус вершины

		public LwPolylineVertex():this(Vector2.Zero, 0.0) { }

		public LwPolylineVertex(Vector2 position,double bulge) {
			this.position = position;
			this.bulge = bulge;
		}

		public LwPolylineVertex(Vector2 position):this(position, 0.0) { }
		public LwPolylineVertex(double x,double y):this(new Vector2(x,y), 0.0) { }
		
		public Vector2 Position {
			get { return position; }
			set { position = value; }
		}

		public double Bulge {
			get { return bulge; }
			set { bulge = value; }
		}

		public object Clone() {
			return new LwPolylineVertex {
				Position = position,
				Bulge = bulge
			};
		}
	}
}
