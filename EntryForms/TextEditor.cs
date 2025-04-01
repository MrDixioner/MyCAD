using System;
using System.Windows.Forms;

namespace MyCAD.EntryForms {
	public partial class TextEditor : Form {
		private GraphicsForm graphicsForm;
		
		public TextEditor(Form callingForm) {
			graphicsForm=callingForm as GraphicsForm;
			InitializeComponent();
		}

		public Vector3 Position { get; set; }
		public Entities.Text TEXT;

		private void TextEditor_Load(object sender, EventArgs e) {
			alignment.DataSource = Enum.GetValues(typeof(Entities.TextAlignment));

			foreach (Tables.TextStyle ts in graphicsForm.textStyles)
				textStyle.Items.Add(ts);
			textStyle.DisplayMember = "Name";

			graphicsForm.tempText = new Entities.Text("", Position);
			textStyle.SelectedIndex = textStyle.Items.IndexOf(graphicsForm.currentStyle);

			Left = Screen.PrimaryScreen.WorkingArea.Width - Width - 20;
			Top = Screen.PrimaryScreen.WorkingArea.Height - Height - 40;
		}

		private void acceptBtn_Click(object sender, EventArgs e) {
			if (string.IsNullOrEmpty(text.Text)) {
				MessageBox.Show("Input textBox cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				text.Focus();
				return;
			}

			if (string.IsNullOrEmpty(height.Text)) {
				MessageBox.Show("Text height cannot be null or empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				height.Focus();
				return;
			}

			DialogResult = DialogResult.OK;
		}

		private void cancelBtn_Click(object sender, EventArgs e) {
			Close();
		}

		private void Input_TextChange(object sender,EventArgs e) {
			graphicsForm.tempText = new Entities.Text(text.Text, Position);
			graphicsForm.tempText.Alignment = (Entities.TextAlignment)alignment.SelectedIndex;
			graphicsForm.tempText.Height = double.Parse(height.Text);
			graphicsForm.tempText.Rotation = double.Parse(rotation.Text);
			graphicsForm.tempText.Style = graphicsForm.textStyles[textStyle.SelectedIndex];
		}

		private void textStyle_SelectedIndexChanged(object sender, EventArgs e) {
			if (textStyle.SelectedIndex != -1) {				
				if (string.IsNullOrEmpty(height.Text)||double.Parse(height.Text)==0.0)
					height.Text = graphicsForm.textStyles[textStyle.SelectedIndex].Height.ToString();
			}
		}
	}
}
