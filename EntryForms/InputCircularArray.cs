using System;
using System.Windows.Forms;

namespace MyCAD.EntryForms {
	public partial class InputCircularArray : Form {
		private GraphicsForm graphics = new GraphicsForm();
		
		public InputCircularArray(Form callingForm) {
			graphics = callingForm as GraphicsForm;
			InitializeComponent();
		}

		private void acceptBtn_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
		}

		private void cancelBtn_Click(object sender, EventArgs e) {
			Close();
		}

		private void TextBox_TextChange(object sender,EventArgs e) {
			if (!string.IsNullOrEmpty(txtItems.Text))
				graphics.Value1=txtItems.Text;
			else
				graphics.Value1="3";

			if (!string.IsNullOrEmpty(txtFillAngle.Text))
				graphics.Value2 = txtFillAngle.Text;
			else
				graphics.Value2 = "360.0";

			graphics.Value5 = isRotatedItems.Checked;
		}

		private void InputCircularArray_Load(object sender, EventArgs e) {
			Text = "Input circular array values";
			Left = Screen.PrimaryScreen.WorkingArea.Width - Width - 20;
			Top = Screen.PrimaryScreen.WorkingArea.Height - Height - 40;
			TextBox_TextChange(sender, null);
		}
	}
}
