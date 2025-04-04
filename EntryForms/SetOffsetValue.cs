using System;
using System.Windows.Forms;

namespace MyCAD.EntryForms {
	public partial class SetOffsetValue : Form {
		public SetOffsetValue() {
			InitializeComponent();
		}

		public double OffsetValue { get; set; }
		public bool Multiple { get; private set; }
		
		private void acceptBtn_Click(object sender, EventArgs e) {
			if (string.IsNullOrEmpty(offset.Text)) {
				MessageBox.Show("Offset value cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				offset.Focus();
				return;
			}

			OffsetValue = offset.ToDouble;
			Multiple = multiple.Checked;
			DialogResult = DialogResult.OK;
		}

		private void cancelBtn_Click(object sender, EventArgs e) {
			Close();
		}

		private void SetOffsetValue_Load(object sender, EventArgs e) {
			offset.Text = OffsetValue.ToString();
		}
	}
}
