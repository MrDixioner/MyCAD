using System;
using System.Globalization;
using System.Windows.Forms;

namespace MyCAD {
	internal static class Program {
		[STAThread]
		static void Main() {
			CultureInfo.CurrentCulture= new CultureInfo("en-US");
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
