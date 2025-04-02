using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MyCAD.Components {
	public class MyTextBox:TextBox {
		private bool _enterAsTab = false;
		private DataType _dataType = DataType.Text;

		[Category("My Settings")]
		public bool EnterAsTab {
			get { return _enterAsTab; }
			set { _enterAsTab = value; }
		}

		[Category("My Settings")]
		public DataType Type {
			get { return _dataType; }
			set { _dataType = value; }
		}

		public double ToDouble {
			get {
				var nf = new System.Globalization.NumberFormatInfo();
				nf.NegativeSign = "-";
				try {
				return double.Parse(Text, nf);
				} catch {
					return 0;
				}
			}
		}

		protected override void OnKeyPress(KeyPressEventArgs e) {
			string numbers = "0123456789" + (char)8 + (char)45;

			if (_enterAsTab && e.KeyChar == 13) {
				e.Handled = true;
				SendKeys.Send("{TAB}");
			}
			
			switch ((int)Type) {
				case 1: // Integer
					if (numbers.IndexOf(e.KeyChar) == -1) {
						e.Handled = true;
					}
					break;
				case 2: // Decimal
					if (!char.IsControl(e.KeyChar)&&!char.IsDigit(e.KeyChar)&&e.KeyChar != '.'&&e.KeyChar!='-'&&e.KeyChar!='+') {
						e.Handled = true;
					}

					if (e.KeyChar == '.' && Text.IndexOf('.') > -1) {
						e.Handled = true;
					}
					break;
			}
			base.OnKeyPress(e);
		}

		protected override void OnTextChanged(EventArgs e) {
			if (Text.IndexOf('.') == 0) {
				Text = "0" + Text;
				SelectionStart = Text.Length;
			}			
			base.OnTextChanged(e);
		}
	}
}
