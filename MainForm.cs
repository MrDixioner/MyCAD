using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyCAD {
	public partial class MainForm : Form {
		public MainForm() {
			InitializeComponent();
		}

		private ToolStripMenuItem btnWindows=new ToolStripMenuItem();
		private GraphicsForm graphics;
		private int counter = 1;

		private void btnNew_Click(object sender, EventArgs e) {
			btnWindows.Name = "btnWindows";
			btnWindows.Text = "Windows";
			btnWindows.Size = new Size(120, 28);

			var item = mainMenu.Items.IndexOf(btnWindows);
			if (item == -1) {
				mainMenu.Items.Add(btnWindows);
				mainMenu.MdiWindowListItem = btnWindows;
			}

			graphics = new GraphicsForm();
			graphics.Name = string.Concat("Graphics", counter.ToString());
			graphics.Text = graphics.Name;
			graphics.MdiParent = this;
			graphics.Show();
			graphics.WindowState = FormWindowState.Maximized;

			counter++;
		}
	}
}
