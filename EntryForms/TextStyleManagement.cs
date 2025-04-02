using MyCAD.Tables;
using MyCAD.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyCAD.EntryForms {
	public partial class TextStyleManagement : Form {
		private GraphicsForm graphicsForm = new GraphicsForm();
		
		public TextStyleManagement(Form callingForm) {
			graphicsForm = callingForm as GraphicsForm;
			InitializeComponent();
		}	
		
		public TextStyle Style { get; set; }
		private List<TextStyle> textStyles;
		public List<TextStyle> TextStyles {
			get { return textStyles; }
			set { textStyles = value; }
		}
		private BindingSource bs;
		private Text text = new Text("AaBb123", 6);
		private string name="name";
		private int index;
		private bool IsChanged = false;

		private void TextStyleManagement_Load(object sender, EventArgs e) {			
			currentStyle.Text = "Current style: " + Style.Name;
			SetStyleList();
		}

		private void SetStyleList() {
			bs = new BindingSource();
			bs.DataSource = textStyles;
			bs.Position = index;
			styles.DataSource = bs;
			styles.DisplayMember = "Name";
		}

		private void styles_SelectedIndexChanged(object sender, EventArgs e) {
			CheckIsChanged(sender);
			index = bs.Position;
			Style = (TextStyle)styles.Items[styles.SelectedIndex];
			name = Style.Name;
			fontStyle.SelectedIndex = (int)Style.FontStyle;
			if (fontFamily.Items.IndexOf(Style.FontFamilyName) != -1)
				fontFamily.SelectedIndex = fontFamily.Items.IndexOf(Style.FontFamilyName);
			height.Text = Style.Height.ToString();
			widthFactor.Text = Style.WidthFactor.ToString();
			upsideDown.Checked = Style.IsUpsideDown;
			backward.Checked = Style.IsBackward;
			deleteBtn.Enabled = !Style.IsReserved;
			IsChanged = false;
			SetSampleText();
		}

		private void picBox_Paint(object sender, PaintEventArgs e) {
			e.Graphics.SetParameters(0, 0, 1, HelperClass.PixelToMillimeters(picBox.Height));
			e.Graphics.DrawText(new Pen(Color.Black), text);
		}

		private void fontFamily_SelectedIndexChanged(object sender, EventArgs e) {
			if (fontFamily.SelectedIndex != -1)
				SetSampleText();
			IsChanged = true;
		}

		private void SetSampleText() {
			text.Style = new TextStyle(name) {
				FontFamilyName = fontFamily.Text,
				FontStyle = (FontStyle)fontStyle.SelectedIndex,
				IsUpsideDown = upsideDown.Checked,
				IsBackward = backward.Checked,
				WidthFactor = double.Parse(widthFactor.Text),
				Height = double.Parse(height.Text)
			};
			text.Alignment = TextAlignment.MiddleLeft;
			double x = (HelperClass.PixelToMillimeters(picBox.Width) - text.Size.Width * text.Style.WidthFactor) / 2;
			double y = HelperClass.PixelToMillimeters(picBox.Height) / 2;
			if (x < 0)
				x = 0;
			if (backward.Checked)
				x += text.Size.Width;
			text.Position = new Vector3(x, y);
			picBox.Refresh();
		}

		private void CheckIsChanged(object sender) {
			if (IsChanged) {
				if (MessageBox.Show("Do you want to save the changes?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
					saveBtn_Click(sender, null);
				}
			}
		}

		private void fontStyle_SelectedIndexChanged(object sender, EventArgs e) {
			if (fontStyle.SelectedIndex != -1) {
				SetSampleText();
				IsChanged = true;
			}
		}

		private void widthFactor_TextChanged(object sender, EventArgs e) {
			if (!string.IsNullOrEmpty(widthFactor.Text)){
				SetSampleText();
				IsChanged = true;
			}
		}

		private void upsideDown_CheckedChanged(object sender, EventArgs e) {
			SetSampleText();
			IsChanged = true;
		}

		private void backward_CheckedChanged(object sender, EventArgs e) {
			SetSampleText();
			IsChanged = true;
		}

		private void setcurrentBtn_Click(object sender, EventArgs e) {
			CheckIsChanged(sender);
			graphicsForm.currentStyle = Style;
			currentStyle.Text = "Current style: " + Style.Name;
		}

		private void newBtn_Click(object sender, EventArgs e) {
			CheckIsChanged(sender);
			using (var newstylefrm=new SetStyleNameForm()) {
				var result = newstylefrm.ShowDialog();
				if (result == DialogResult.OK) {
					Style = new TextStyle(newstylefrm.StyleName);
					if (!textStyles.Contains(Style) && CheckItem(newstylefrm.StyleName)) {
						textStyles.Add(Style);
						SetStyleList();
						bs.MoveLast();
					}
				} else
					MessageBox.Show("The style with this name is available in the list", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private bool CheckItem(string name) {
			foreach (TextStyle ts in textStyles) {
				if (name.Equals(ts.Name))
					return false;
			}
			return true;
		}

		private void deleteBtn_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Do you want to delete this style", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
				if (styles.SelectedIndex != -1) {
					graphicsForm.textStyles.RemoveAt(styles.SelectedIndex);
					SetStyleList();
				}
			}
		}

		private void saveBtn_Click(object sender, EventArgs e) {
			if (fontFamily.SelectedIndex != -1)	{
				Style.FontFamilyName = fontFamily.Text;
			} else {
				MessageBox.Show("Font name cannot be empty","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
				fontFamily.Focus();
				return;
			}

			if (fontStyle.SelectedIndex != -1) {
				Style.FontStyle = (FontStyle)fontStyle.SelectedIndex;
			} else {
				MessageBox.Show("Font name cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
				fontStyle.Focus();
				return;
			}

			if (!string.IsNullOrEmpty(height.Text) && height.ToDouble >= 0) {
				Style.Height = double.Parse(height.Text);
			} else {
				MessageBox.Show("The height cannot be empty or less than zero", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
				height.Focus();
				return;
			}

			if (!string.IsNullOrEmpty(widthFactor.Text) && (widthFactor.ToDouble > 0.01 && widthFactor.ToDouble < 100)){
				Style.WidthFactor = double.Parse(widthFactor.Text);
			} else {
				MessageBox.Show("The width factor cannot be empty or smaller than 0.01 and larger than 100", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
				widthFactor.Focus();
				return;
			}
				Style.IsUpsideDown = upsideDown.Checked;
			Style.IsBackward = backward.Checked;
			IsChanged = false;
		}

		private void closeBtn_Click(object sender, EventArgs e) {
			CheckIsChanged(sender);
			Close();
		}

		private void height_TextChanged(object sender, EventArgs e) {
			IsChanged = true;
		}
	}
}
