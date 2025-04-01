using System;
using System.Windows.Forms;

namespace MyCAD.EntryForms {
    public partial class SetPolygonValuesForm : Form {
        public SetPolygonValuesForm() {
            InitializeComponent();
        }

        public int SidesQty { get; private set; }
        public int Inscribed { get; private set; }

        private void button1_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(sides.Text) || (Convert.ToInt32(sides.Text) < 3)) {
                MessageBox.Show("Sides entry is not correct", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sides.Focus();
                return;
            }

            SidesQty=Convert.ToInt32(sides.Text);
            Inscribed = inscribed.SelectedIndex;
            DialogResult=DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e) {
            Close();
        }

        private void SetPolygonValuesForm_Load(object sender, EventArgs e) {
            Text = "Polygon setting";
            inscribed.SelectedIndex = 0;
            Left = Screen.PrimaryScreen.WorkingArea.Width - Width - 20;
            Top = Screen.PrimaryScreen.WorkingArea.Height - Height - 20;
        }
    }
}
