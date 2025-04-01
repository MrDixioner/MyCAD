using System;

namespace MyCAD.Entities {
	public abstract class EntityObject:ICloneable {
		private readonly EntityType type;
		protected bool isVisible;
		protected bool selected;

		public EntityObject(EntityType type) {
			this.type = type;
			isVisible = true;
			selected = false;
		}

		public EntityType Type {
			get { return type; }
		}

		public bool IsVisible {
			get { return isVisible; }
			set { isVisible = value; }
		}

		public bool Selected {
			get { return selected; }
			set { selected = value; }
		}

		public bool IsSelected {
			get { return selected; }
		}

		public void Select() {
			selected = true;
		}

		public void DeSelect() {
			selected = false;
		}

		public abstract object CopyOrMove(Vector3 fromPoint, Vector3 toPoint);
		public abstract object Rotate2D(Vector3 basePoint, Vector3 targetPoint);
		public abstract object Rotate2D(Vector3 basePoint, double angle);
		public abstract object Mirror2D(Vector3 basePoint, Vector3 targetPoint);
		public abstract object Scale(Vector3 basePoint, double value);
		public abstract object LinearArray2D(
			int horizontalQty,
			int verticalQty,
			double horizontalDistance,
			double verticalDistance,
			int direction);
		public abstract object CircularArray2D(Vector3 basePoint, double fillAngle, int items, bool isRotatedItems);
		public abstract object Clone();
	}    
}
