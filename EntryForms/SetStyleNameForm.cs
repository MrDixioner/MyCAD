using System;
using System.Windows.Forms;

namespace MyCAD.EntryForms {
	public partial class SetStyleNameForm : Form {
		public SetStyleNameForm() {
			InitializeComponent();
		}

		public string StyleName { get; set; }
		
		private void saveBtn_Click(object sender, EventArgs e) {
			if (string.IsNullOrEmpty(name.Text)) {
				MessageBox.Show("style name cannot be empty","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				name.Focus();
				return;
			}
			StyleName = name.Text;
			DialogResult = DialogResult.OK;
		}

		private void cancelBtn_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
