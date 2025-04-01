using System;
using System.Windows.Forms;

namespace MyCAD.EntryForms {
	public partial class InputLinearArray : Form {
		private GraphicsForm graphics=new GraphicsForm();
		
		public InputLinearArray(Form callfrom) {
			graphics = callfrom as GraphicsForm;
			InitializeComponent();
		}

		private void InputLinearArray_Load(object sender, EventArgs e) {
			Left = Screen.PrimaryScreen.WorkingArea.Width - Width - 20;
			Top= Screen.PrimaryScreen.WorkingArea.Height - Height - 40;
			direction.SelectedIndex = 0;
		}

		private void acceptBtn_Click(object sender, EventArgs e) {
			DialogResult=DialogResult.OK;
		}

		private void cancelBtn_Click(object sender, EventArgs e) {
			Close();
		}

		private void InputBox_TextChange(object sender, EventArgs e) {
			graphics.Value1=!string.IsNullOrEmpty(horizontalQty.Text)?horizontalQty.Text:"0";
			graphics.Value2=!string.IsNullOrEmpty(verticalQty.Text)?verticalQty.Text:"0";
			graphics.Value3=!string.IsNullOrEmpty(horizontalDist.Text)?horizontalDist.Text:"0";
			graphics.Value4=!string.IsNullOrEmpty(verticalDist.Text)?verticalDist.Text:"0";
			graphics.direction = direction.SelectedIndex;
		}
	}
}
