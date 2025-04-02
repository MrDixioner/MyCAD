using System.ComponentModel;
using System.Windows.Forms;

namespace MyCAD.Components {
	internal class MyComboBox:ComboBox {
		private bool _enterAsTab = false;

		[Category("My Settings")]
		public bool EnterAsTab {
			get { return _enterAsTab; }
			set { _enterAsTab = value; }
		}

		protected override void OnKeyPress(KeyPressEventArgs e) {
			if (_enterAsTab && e.KeyChar == 13) {
				e.Handled = true;
				SendKeys.Send("{TAB}");
			}

			base.OnKeyPress(e);
		}
	}
}
