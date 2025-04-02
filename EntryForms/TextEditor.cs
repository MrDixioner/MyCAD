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
		public int Status = -1;

		private void TextEditor_Load(object sender, EventArgs e) {
			foreach (Tables.TextStyle ts in graphicsForm.textStyles)
				textStyle.Items.Add(ts);
			textStyle.DisplayMember = "Name";

			if (Status == 1) {
				Position = graphicsForm.tempText.Position;
				alignment.SelectedIndex=(int)graphicsForm.tempText.Alignment;
				text.Text = graphicsForm.tempText.Value;
				height.Text = graphicsForm.tempText.Height.ToString();
				rotation.Text = graphicsForm.tempText.Rotation.ToString();
				textStyle.SelectedIndex = textStyle.Items.IndexOf(graphicsForm.tempText.Style);
			} else {
				graphicsForm.tempText = new Entities.Text("", Position);
				textStyle.SelectedIndex = textStyle.Items.IndexOf(graphicsForm.currentStyle);
				alignment.SelectedIndex = (int)Entities.TextAlignment.BottomLeft;
			}

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
			if (textStyle.SelectedIndex != -1)
				graphicsForm.tempText.Style = graphicsForm.textStyles[textStyle.SelectedIndex];
		}

		private void textStyle_SelectedIndexChanged(object sender, EventArgs e) {
			if (textStyle.SelectedIndex != -1) {
				graphicsForm.tempText.Style = graphicsForm.textStyles[textStyle.SelectedIndex];
				if (string.IsNullOrEmpty(height.Text) || double.Parse(height.Text) == 0.0)
					height.Text = graphicsForm.textStyles[textStyle.SelectedIndex].Height.ToString();
			}
		}

		private void text_TextChanged(object sender, EventArgs e) {
			if (!string.IsNullOrEmpty(text.Text))
				graphicsForm.tempText = new Entities.Text(text.Text, Position);
		}

		private void alignment_SelectedIndexChanged(object sender, EventArgs e) {
			if (alignment.SelectedIndex != -1)
				graphicsForm.tempText.Alignment = (Entities.TextAlignment)alignment.SelectedIndex;
		}

		private void height_TextChanged(object sender, EventArgs e) {
			if (!string.IsNullOrEmpty(height.Text))
				graphicsForm.tempText.Height = height.ToDouble;
		}

		private void rotation_TextChanged(object sender, EventArgs e) {
			if (!string.IsNullOrEmpty(height.Text))
				graphicsForm.tempText.Rotation = rotation.ToDouble;
		}
	}
}
