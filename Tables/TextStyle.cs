using System;
using System.Drawing;

namespace MyCAD.Tables {
	public class TextStyle {
		private static readonly string[] notAllowed = { "\\", "<", ">", "/", "?", "\"", ";", ":", "*", "|", ",", "=", "'" };
		private string name;
		private string fontFamilyName;
		private double height;
		private bool isBackward;
		private bool isUpsideDown;
		private double widthFactor;
		private FontStyle fontStyle;
		private bool reserved;

		public static TextStyle Default {
			get { return new TextStyle("Standard", "Arial"); }
		}

		public TextStyle(string name) : this(System.IO.Path.GetFileNameWithoutExtension(name), name) { }

		public TextStyle(string name,string fontFamily) : this(name, fontFamily, FontStyle.Regular) { }

		public TextStyle(string name,string fontFamily,FontStyle fontStyle) : this(name, fontFamily, fontStyle, true) { }

		internal TextStyle(string name,string fontFamily,FontStyle fontStyle,bool checkName) {
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException(nameof(name), "The text style name cannot be empty.");

			if (string.IsNullOrEmpty(fontFamily))
				throw new ArgumentNullException(nameof(fontFamily));

			if (checkName) {
				foreach (string s in notAllowed) {
					if (name.Contains(s))
						throw new ArgumentException("The following characters \\<>/?\":;*|',= are not supported for style name.");
				}
			}

			this.name = name;
			reserved = name.Equals("Standard", StringComparison.InvariantCultureIgnoreCase);
			fontFamilyName = fontFamily;
			isBackward = false;
			isUpsideDown = false;
			widthFactor = 1.0;
			this.fontStyle = fontStyle;
		}

		public string Name {
			get { return name; }
			set { name = value; }
		}

		public string FontFamilyName {
			get { return fontFamilyName; }
			set { fontFamilyName = value; }
		}

		public double Height {
			get { return height; }
			set {
				if (value < 0)
					throw new ArgumentOutOfRangeException(nameof(height), "The height cannot be less than zero.");
				height = value;
			}
		}

		public double WidthFactor {
			get { return widthFactor; }
			set {
				if (value < 0.01)
					throw new ArgumentOutOfRangeException(nameof(widthFactor), "The width factor valid values range from 0.01 to 100.");
				widthFactor = value;
			}
		}

		public bool IsBackward {
			get { return isBackward; }
			set { isBackward = value; }
		}

		public bool IsUpsideDown {
			get { return isUpsideDown; }
			set { isUpsideDown = value; }
		}

		public FontStyle FontStyle {
			get { return fontStyle; }
			set { fontStyle = value; }
		}

		public bool IsReserved {
			get { return reserved; }
			set { reserved = value; }
		}

		public object Clone() {
			return new TextStyle(name) {
				FontFamilyName = fontFamilyName,
				Height = height,
				IsBackward = isBackward,
				IsUpsideDown = isUpsideDown,
				WidthFactor = widthFactor,
				FontStyle = fontStyle
			};
		}
	}
}
