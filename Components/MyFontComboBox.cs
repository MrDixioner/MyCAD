using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MyCAD.Components {
	internal class MyFontComboBox : ComboBox {
		private bool _enterAsTab = false;

		[Category("My Settings")]
		public bool EnterAsTab {
			get { return _enterAsTab; }
			set { _enterAsTab = value; }
		}

		public MyFontComboBox() {
			DrawMode=DrawMode.OwnerDrawVariable;
			DropDownStyle= ComboBoxStyle.DropDownList;
			LoadFont();
			Sorted = true;
			SelectedIndex = 1;
		}

		private void LoadFont() {
			if (Items.Count == 0) {
				foreach (System.Drawing.FontFamily font in System.Drawing.FontFamily.Families)
					Items.Add(font.Name);
			}
		}

		protected override void OnKeyPress(KeyPressEventArgs e) {
			if (_enterAsTab && e.KeyChar == 13) {
				e.Handled = true;
				SendKeys.Send("{TAB}");
			}

			base.OnKeyPress(e);
		}

		protected override void OnDrawItem(DrawItemEventArgs e) {
			e.DrawBackground();

			if ((e.Index == -1) || (e.Index > Items.Count))
				return;

			using (SolidBrush brush=new SolidBrush(e.ForeColor)) {
				using (StringFormat sf=new StringFormat()) {
					sf.Alignment = StringAlignment.Near;
					sf.LineAlignment = StringAlignment.Center;
					string font = Items[e.Index].ToString();
					e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
					e.Graphics.DrawString(font, new Font(font, 12), brush, e.Bounds, sf);
				}
			}
			e.DrawFocusRectangle();
			base.OnDrawItem(e);
		}
	}
}
