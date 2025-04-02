namespace MyCAD.EntryForms {
	partial class TextStyleManagement {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.styles = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.closeBtn = new System.Windows.Forms.Button();
			this.saveBtn = new System.Windows.Forms.Button();
			this.deleteBtn = new System.Windows.Forms.Button();
			this.newBtn = new System.Windows.Forms.Button();
			this.setcurrentBtn = new System.Windows.Forms.Button();
			this.currentStyle = new System.Windows.Forms.Label();
			this.picBox = new System.Windows.Forms.PictureBox();
			this.backward = new MyCAD.Components.MyCheckBox();
			this.upsideDown = new MyCAD.Components.MyCheckBox();
			this.widthFactor = new MyCAD.Components.MyTextBox();
			this.height = new MyCAD.Components.MyTextBox();
			this.fontStyle = new MyCAD.Components.MyComboBox();
			this.fontFamily = new MyCAD.Components.MyFontComboBox();
			((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
			this.SuspendLayout();
			// 
			// styles
			// 
			this.styles.FormattingEnabled = true;
			this.styles.ItemHeight = 19;
			this.styles.Location = new System.Drawing.Point(12, 34);
			this.styles.Name = "styles";
			this.styles.Size = new System.Drawing.Size(209, 289);
			this.styles.TabIndex = 0;
			this.styles.SelectedIndexChanged += new System.EventHandler(this.styles_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "Styles:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(237, 34);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(81, 19);
			this.label2.TabIndex = 4;
			this.label2.Text = "Font name:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(451, 34);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(76, 19);
			this.label3.TabIndex = 6;
			this.label3.Text = "Font style:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(237, 101);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 19);
			this.label4.TabIndex = 8;
			this.label4.Text = "Height:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(451, 101);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(94, 19);
			this.label5.TabIndex = 10;
			this.label5.Text = "Width factor:";
			// 
			// closeBtn
			// 
			this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.closeBtn.Location = new System.Drawing.Point(557, 363);
			this.closeBtn.Name = "closeBtn";
			this.closeBtn.Size = new System.Drawing.Size(100, 35);
			this.closeBtn.TabIndex = 13;
			this.closeBtn.Text = "Close";
			this.closeBtn.UseVisualStyleBackColor = true;
			this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
			// 
			// saveBtn
			// 
			this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.saveBtn.Location = new System.Drawing.Point(557, 322);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new System.Drawing.Size(100, 35);
			this.saveBtn.TabIndex = 14;
			this.saveBtn.Text = "Save";
			this.saveBtn.UseVisualStyleBackColor = true;
			this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
			// 
			// deleteBtn
			// 
			this.deleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.deleteBtn.Location = new System.Drawing.Point(557, 281);
			this.deleteBtn.Name = "deleteBtn";
			this.deleteBtn.Size = new System.Drawing.Size(100, 35);
			this.deleteBtn.TabIndex = 15;
			this.deleteBtn.Text = "Delete";
			this.deleteBtn.UseVisualStyleBackColor = true;
			this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
			// 
			// newBtn
			// 
			this.newBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.newBtn.Location = new System.Drawing.Point(557, 240);
			this.newBtn.Name = "newBtn";
			this.newBtn.Size = new System.Drawing.Size(100, 35);
			this.newBtn.TabIndex = 16;
			this.newBtn.Text = "New";
			this.newBtn.UseVisualStyleBackColor = true;
			this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
			// 
			// setcurrentBtn
			// 
			this.setcurrentBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.setcurrentBtn.Location = new System.Drawing.Point(557, 199);
			this.setcurrentBtn.Name = "setcurrentBtn";
			this.setcurrentBtn.Size = new System.Drawing.Size(100, 35);
			this.setcurrentBtn.TabIndex = 17;
			this.setcurrentBtn.Text = "Set current";
			this.setcurrentBtn.UseVisualStyleBackColor = true;
			this.setcurrentBtn.Click += new System.EventHandler(this.setcurrentBtn_Click);
			// 
			// currentStyle
			// 
			this.currentStyle.AutoSize = true;
			this.currentStyle.Location = new System.Drawing.Point(237, 382);
			this.currentStyle.Name = "currentStyle";
			this.currentStyle.Size = new System.Drawing.Size(0, 19);
			this.currentStyle.TabIndex = 18;
			// 
			// picBox
			// 
			this.picBox.BackColor = System.Drawing.SystemColors.Window;
			this.picBox.Location = new System.Drawing.Point(12, 328);
			this.picBox.Name = "picBox";
			this.picBox.Size = new System.Drawing.Size(209, 71);
			this.picBox.TabIndex = 2;
			this.picBox.TabStop = false;
			this.picBox.Paint += new System.Windows.Forms.PaintEventHandler(this.picBox_Paint);
			// 
			// backward
			// 
			this.backward.AutoSize = true;
			this.backward.EnterAsTab = false;
			this.backward.Location = new System.Drawing.Point(237, 220);
			this.backward.Name = "backward";
			this.backward.Size = new System.Drawing.Size(91, 23);
			this.backward.TabIndex = 12;
			this.backward.Text = "Backward";
			this.backward.UseVisualStyleBackColor = true;
			this.backward.CheckedChanged += new System.EventHandler(this.backward_CheckedChanged);
			// 
			// upsideDown
			// 
			this.upsideDown.AutoSize = true;
			this.upsideDown.EnterAsTab = false;
			this.upsideDown.Location = new System.Drawing.Point(237, 182);
			this.upsideDown.Name = "upsideDown";
			this.upsideDown.Size = new System.Drawing.Size(114, 23);
			this.upsideDown.TabIndex = 11;
			this.upsideDown.Text = "Upside Down";
			this.upsideDown.UseVisualStyleBackColor = true;
			this.upsideDown.CheckedChanged += new System.EventHandler(this.upsideDown_CheckedChanged);
			// 
			// widthFactor
			// 
			this.widthFactor.EnterAsTab = false;
			this.widthFactor.Location = new System.Drawing.Point(451, 122);
			this.widthFactor.Name = "widthFactor";
			this.widthFactor.Size = new System.Drawing.Size(206, 27);
			this.widthFactor.TabIndex = 9;
			this.widthFactor.Text = "1";
			this.widthFactor.Type = MyCAD.Components.DataType.Text;
			this.widthFactor.TextChanged += new System.EventHandler(this.widthFactor_TextChanged);
			// 
			// height
			// 
			this.height.EnterAsTab = false;
			this.height.Location = new System.Drawing.Point(237, 122);
			this.height.Name = "height";
			this.height.Size = new System.Drawing.Size(201, 27);
			this.height.TabIndex = 7;
			this.height.Text = "0";
			this.height.Type = MyCAD.Components.DataType.Text;
			// 
			// fontStyle
			// 
			this.fontStyle.EnterAsTab = false;
			this.fontStyle.FormattingEnabled = true;
			this.fontStyle.Location = new System.Drawing.Point(451, 57);
			this.fontStyle.Name = "fontStyle";
			this.fontStyle.Size = new System.Drawing.Size(206, 27);
			this.fontStyle.TabIndex = 5;
			this.fontStyle.SelectedIndexChanged += new System.EventHandler(this.fontStyle_SelectedIndexChanged);
			// 
			// fontFamily
			// 
			this.fontFamily.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.fontFamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.fontFamily.EnterAsTab = false;
			this.fontFamily.FormattingEnabled = true;
			this.fontFamily.Items.AddRange(new object[] {
            "AcadEref",
            "AcadEref",
            "AcadEref",
            "Adobe Arabic",
            "Adobe Arabic",
            "Adobe Arabic",
            "Adobe Fan Heiti Std B",
            "Adobe Fan Heiti Std B",
            "Adobe Fan Heiti Std B",
            "Adobe Gothic Std B",
            "Adobe Gothic Std B",
            "Adobe Gothic Std B",
            "Adobe Hebrew",
            "Adobe Hebrew",
            "Adobe Hebrew",
            "Adobe Heiti Std R",
            "Adobe Heiti Std R",
            "Adobe Heiti Std R",
            "Adobe Ming Std L",
            "Adobe Ming Std L",
            "Adobe Ming Std L",
            "Adobe Myungjo Std M",
            "Adobe Myungjo Std M",
            "Adobe Myungjo Std M",
            "Adobe Pi Std",
            "Adobe Pi Std",
            "Adobe Pi Std",
            "Adobe Song Std L",
            "Adobe Song Std L",
            "Adobe Song Std L",
            "Adobe Thai",
            "Adobe Thai",
            "Adobe Thai",
            "AIGDT",
            "AIGDT",
            "AIGDT",
            "Algerian",
            "Algerian",
            "Algerian",
            "AmdtSymbols",
            "AmdtSymbols",
            "AmdtSymbols",
            "AMGDT",
            "AMGDT",
            "AMGDT",
            "AMGDT_IV25",
            "AMGDT_IV25",
            "AMGDT_IV25",
            "AMGDT_IV50",
            "AMGDT_IV50",
            "AMGDT_IV50",
            "AmpleSoundTab",
            "AmpleSoundTab",
            "AmpleSoundTab",
            "Andale Mono IPA",
            "Andale Mono IPA",
            "Andale Mono IPA",
            "Arial",
            "Arial",
            "Arial",
            "Arial Black",
            "Arial Black",
            "Arial Black",
            "Arial Narrow",
            "Arial Narrow",
            "Arial Narrow",
            "Arial Unicode MS",
            "Arial Unicode MS",
            "Arial Unicode MS",
            "Bahnschrift",
            "Bahnschrift",
            "Bahnschrift",
            "Bahnschrift Condensed",
            "Bahnschrift Condensed",
            "Bahnschrift Condensed",
            "Bahnschrift Light",
            "Bahnschrift Light",
            "Bahnschrift Light",
            "Bahnschrift Light Condensed",
            "Bahnschrift Light Condensed",
            "Bahnschrift Light Condensed",
            "Bahnschrift Light SemiCondensed",
            "Bahnschrift Light SemiCondensed",
            "Bahnschrift Light SemiCondensed",
            "Bahnschrift SemiBold",
            "Bahnschrift SemiBold",
            "Bahnschrift SemiBold",
            "Bahnschrift SemiBold Condensed",
            "Bahnschrift SemiBold Condensed",
            "Bahnschrift SemiBold Condensed",
            "Bahnschrift SemiBold SemiConden",
            "Bahnschrift SemiBold SemiConden",
            "Bahnschrift SemiBold SemiConden",
            "Bahnschrift SemiCondensed",
            "Bahnschrift SemiCondensed",
            "Bahnschrift SemiCondensed",
            "Bahnschrift SemiLight",
            "Bahnschrift SemiLight",
            "Bahnschrift SemiLight",
            "Bahnschrift SemiLight Condensed",
            "Bahnschrift SemiLight Condensed",
            "Bahnschrift SemiLight Condensed",
            "Bahnschrift SemiLight SemiConde",
            "Bahnschrift SemiLight SemiConde",
            "Bahnschrift SemiLight SemiConde",
            "BankGothic Lt BT",
            "BankGothic Lt BT",
            "BankGothic Lt BT",
            "BankGothic Md BT",
            "BankGothic Md BT",
            "BankGothic Md BT",
            "Barlow Condensed",
            "Barlow Condensed",
            "Barlow Condensed",
            "Barrio",
            "Barrio",
            "Barrio",
            "Baskerville Old Face",
            "Baskerville Old Face",
            "Baskerville Old Face",
            "Bauhaus 93",
            "Bauhaus 93",
            "Bauhaus 93",
            "Bell MT",
            "Bell MT",
            "Bell MT",
            "Berlin Sans FB",
            "Berlin Sans FB",
            "Berlin Sans FB",
            "Berlin Sans FB Demi",
            "Berlin Sans FB Demi",
            "Berlin Sans FB Demi",
            "Bernard MT Condensed",
            "Bernard MT Condensed",
            "Bernard MT Condensed",
            "Bodoni MT Poster Compressed",
            "Bodoni MT Poster Compressed",
            "Bodoni MT Poster Compressed",
            "Book Antiqua",
            "Book Antiqua",
            "Book Antiqua",
            "Bookman Old Style",
            "Bookman Old Style",
            "Bookman Old Style",
            "Bookshelf Symbol 7",
            "Bookshelf Symbol 7",
            "Bookshelf Symbol 7",
            "Britannic Bold",
            "Britannic Bold",
            "Britannic Bold",
            "Broadway",
            "Broadway",
            "Broadway",
            "Brush Script MT",
            "Brush Script MT",
            "Brush Script MT",
            "Bubblegum Sans",
            "Bubblegum Sans",
            "Bubblegum Sans",
            "Cabin Sketch",
            "Cabin Sketch",
            "Cabin Sketch",
            "Calibri",
            "Calibri",
            "Calibri",
            "Calibri Light",
            "Calibri Light",
            "Calibri Light",
            "Californian FB",
            "Californian FB",
            "Californian FB",
            "Cambria",
            "Cambria",
            "Cambria",
            "Cambria Math",
            "Cambria Math",
            "Cambria Math",
            "Candara",
            "Candara",
            "Candara",
            "Candara Light",
            "Candara Light",
            "Candara Light",
            "Cascadia Code",
            "Cascadia Code",
            "Cascadia Code",
            "Cascadia Code ExtraLight",
            "Cascadia Code ExtraLight",
            "Cascadia Code ExtraLight",
            "Cascadia Code Light",
            "Cascadia Code Light",
            "Cascadia Code Light",
            "Cascadia Code SemiBold",
            "Cascadia Code SemiBold",
            "Cascadia Code SemiBold",
            "Cascadia Code SemiLight",
            "Cascadia Code SemiLight",
            "Cascadia Code SemiLight",
            "Cascadia Mono",
            "Cascadia Mono",
            "Cascadia Mono",
            "Cascadia Mono ExtraLight",
            "Cascadia Mono ExtraLight",
            "Cascadia Mono ExtraLight",
            "Cascadia Mono Light",
            "Cascadia Mono Light",
            "Cascadia Mono Light",
            "Cascadia Mono SemiBold",
            "Cascadia Mono SemiBold",
            "Cascadia Mono SemiBold",
            "Cascadia Mono SemiLight",
            "Cascadia Mono SemiLight",
            "Cascadia Mono SemiLight",
            "Centaur",
            "Centaur",
            "Centaur",
            "Century",
            "Century",
            "Century",
            "Century Gothic",
            "Century Gothic",
            "Century Gothic",
            "Chiller",
            "Chiller",
            "Chiller",
            "CityBlueprint",
            "CityBlueprint",
            "CityBlueprint",
            "Colonna MT",
            "Colonna MT",
            "Colonna MT",
            "Comfortaa",
            "Comfortaa",
            "Comfortaa",
            "Comic Sans MS",
            "Comic Sans MS",
            "Comic Sans MS",
            "CommercialPi BT",
            "CommercialPi BT",
            "CommercialPi BT",
            "CommercialScript BT",
            "CommercialScript BT",
            "CommercialScript BT",
            "Complex",
            "Complex",
            "Complex",
            "Complex_IV25",
            "Complex_IV25",
            "Complex_IV25",
            "Complex_IV50",
            "Complex_IV50",
            "Complex_IV50",
            "Consolas",
            "Consolas",
            "Consolas",
            "Constantia",
            "Constantia",
            "Constantia",
            "Cooper Black",
            "Cooper Black",
            "Cooper Black",
            "Corbel",
            "Corbel",
            "Corbel",
            "Corbel Light",
            "Corbel Light",
            "Corbel Light",
            "CountryBlueprint",
            "CountryBlueprint",
            "CountryBlueprint",
            "Courier New",
            "Courier New",
            "Courier New",
            "Courier Std",
            "Courier Std",
            "Courier Std",
            "Delius",
            "Delius",
            "Delius",
            "Dosis",
            "Dosis",
            "Dosis",
            "DS ISO 1",
            "DS ISO 1",
            "DS ISO 1",
            "Dubai",
            "Dubai",
            "Dubai",
            "Dubai Light",
            "Dubai Light",
            "Dubai Light",
            "Dubai Medium",
            "Dubai Medium",
            "Dubai Medium",
            "Dutch801 Rm BT",
            "Dutch801 Rm BT",
            "Dutch801 Rm BT",
            "Dutch801 XBd BT",
            "Dutch801 XBd BT",
            "Dutch801 XBd BT",
            "Ebrima",
            "Ebrima",
            "Ebrima",
            "Engraving singleline Font",
            "Engraving singleline Font",
            "Engraving singleline Font",
            "EuroRoman",
            "EuroRoman",
            "EuroRoman",
            "Footlight MT Light",
            "Footlight MT Light",
            "Footlight MT Light",
            "Franklin Gothic Medium",
            "Franklin Gothic Medium",
            "Franklin Gothic Medium",
            "Fredericka the Great",
            "Fredericka the Great",
            "Fredericka the Great",
            "Fredoka One",
            "Fredoka One",
            "Fredoka One",
            "Freestyle Script",
            "Freestyle Script",
            "Freestyle Script",
            "Gabriola",
            "Gabriola",
            "Gabriola",
            "Gadugi",
            "Gadugi",
            "Gadugi",
            "Garamond",
            "Garamond",
            "Garamond",
            "GDT",
            "GDT",
            "GDT",
            "GDT_IV25",
            "GDT_IV25",
            "GDT_IV25",
            "GDT_IV50",
            "GDT_IV50",
            "GDT_IV50",
            "GENISO",
            "GENISO",
            "GENISO",
            "Georgia",
            "Georgia",
            "Georgia",
            "GOST Common",
            "GOST Common",
            "GOST Common",
            "GOST type A",
            "GOST type A",
            "GOST type A",
            "GOST Type AU",
            "GOST Type AU",
            "GOST Type AU",
            "GOST type B",
            "GOST type B",
            "GOST type B",
            "GOST Type BU",
            "GOST Type BU",
            "GOST Type BU",
            "GostBazis",
            "GostBazis",
            "GostBazis",
            "GothicE",
            "GothicE",
            "GothicE",
            "GothicG",
            "GothicG",
            "GothicG",
            "GothicI",
            "GothicI",
            "GothicI",
            "GreekC",
            "GreekC",
            "GreekC",
            "GreekC_IV25",
            "GreekC_IV25",
            "GreekC_IV25",
            "GreekC_IV50",
            "GreekC_IV50",
            "GreekC_IV50",
            "GreekS",
            "GreekS",
            "GreekS",
            "GreekS_IV25",
            "GreekS_IV25",
            "GreekS_IV25",
            "GreekS_IV50",
            "GreekS_IV50",
            "GreekS_IV50",
            "Harlow Solid Italic",
            "Harlow Solid Italic",
            "Harlow Solid Italic",
            "Harrington",
            "Harrington",
            "Harrington",
            "High Tower Text",
            "High Tower Text",
            "High Tower Text",
            "HoloLens MDL2 Assets",
            "HoloLens MDL2 Assets",
            "HoloLens MDL2 Assets",
            "HYSWLongFangSong",
            "HYSWLongFangSong",
            "HYSWLongFangSong",
            "Impact",
            "Impact",
            "Impact",
            "Informal Roman",
            "Informal Roman",
            "Informal Roman",
            "Ink Free",
            "Ink Free",
            "Ink Free",
            "ISOCP",
            "ISOCP",
            "ISOCP",
            "ISOCP_IV25",
            "ISOCP_IV25",
            "ISOCP_IV25",
            "ISOCP_IV50",
            "ISOCP_IV50",
            "ISOCP_IV50",
            "ISOCP2",
            "ISOCP2",
            "ISOCP2",
            "ISOCP2_IV25",
            "ISOCP2_IV25",
            "ISOCP2_IV25",
            "ISOCP2_IV50",
            "ISOCP2_IV50",
            "ISOCP2_IV50",
            "ISOCP3",
            "ISOCP3",
            "ISOCP3",
            "ISOCP3_IV25",
            "ISOCP3_IV25",
            "ISOCP3_IV25",
            "ISOCP3_IV50",
            "ISOCP3_IV50",
            "ISOCP3_IV50",
            "ISOCPEUR",
            "ISOCPEUR",
            "ISOCPEUR",
            "ISOCT",
            "ISOCT",
            "ISOCT",
            "ISOCT_IV25",
            "ISOCT_IV25",
            "ISOCT_IV25",
            "ISOCT_IV50",
            "ISOCT_IV50",
            "ISOCT_IV50",
            "ISOCT2",
            "ISOCT2",
            "ISOCT2",
            "ISOCT2_IV25",
            "ISOCT2_IV25",
            "ISOCT2_IV25",
            "ISOCT2_IV50",
            "ISOCT2_IV50",
            "ISOCT2_IV50",
            "ISOCT3",
            "ISOCT3",
            "ISOCT3",
            "ISOCT3_IV25",
            "ISOCT3_IV25",
            "ISOCT3_IV25",
            "ISOCT3_IV50",
            "ISOCT3_IV50",
            "ISOCT3_IV50",
            "ISOCTEUR",
            "ISOCTEUR",
            "ISOCTEUR",
            "Italic",
            "Italic",
            "Italic",
            "Italic_IV25",
            "Italic_IV25",
            "Italic_IV25",
            "Italic_IV50",
            "Italic_IV50",
            "Italic_IV50",
            "ItalicC",
            "ItalicC",
            "ItalicC",
            "ItalicT",
            "ItalicT",
            "ItalicT",
            "Javanese Text",
            "Javanese Text",
            "Javanese Text",
            "JetBrains Mono",
            "JetBrains Mono",
            "JetBrains Mono",
            "JetBrains Mono ExtraBold",
            "JetBrains Mono ExtraBold",
            "JetBrains Mono ExtraBold",
            "JetBrains Mono ExtraLight",
            "JetBrains Mono ExtraLight",
            "JetBrains Mono ExtraLight",
            "JetBrains Mono Light",
            "JetBrains Mono Light",
            "JetBrains Mono Light",
            "JetBrains Mono Medium",
            "JetBrains Mono Medium",
            "JetBrains Mono Medium",
            "JetBrains Mono SemiBold",
            "JetBrains Mono SemiBold",
            "JetBrains Mono SemiBold",
            "JetBrains Mono Thin",
            "JetBrains Mono Thin",
            "JetBrains Mono Thin",
            "Jokerman",
            "Jokerman",
            "Jokerman",
            "Juice ITC",
            "Juice ITC",
            "Juice ITC",
            "Julius Sans One",
            "Julius Sans One",
            "Julius Sans One",
            "Kozuka Gothic Pr6N M",
            "Kozuka Gothic Pr6N M",
            "Kozuka Gothic Pr6N M",
            "Kozuka Mincho Pr6N R",
            "Kozuka Mincho Pr6N R",
            "Kozuka Mincho Pr6N R",
            "Kristen ITC",
            "Kristen ITC",
            "Kristen ITC",
            "Kunstler Script",
            "Kunstler Script",
            "Kunstler Script",
            "Leelawadee",
            "Leelawadee",
            "Leelawadee",
            "Leelawadee UI",
            "Leelawadee UI",
            "Leelawadee UI",
            "Leelawadee UI Semilight",
            "Leelawadee UI Semilight",
            "Leelawadee UI Semilight",
            "Lucida Bright",
            "Lucida Bright",
            "Lucida Bright",
            "Lucida Calligraphy",
            "Lucida Calligraphy",
            "Lucida Calligraphy",
            "Lucida Console",
            "Lucida Console",
            "Lucida Console",
            "Lucida Fax",
            "Lucida Fax",
            "Lucida Fax",
            "Lucida Handwriting",
            "Lucida Handwriting",
            "Lucida Handwriting",
            "Lucida Sans Unicode",
            "Lucida Sans Unicode",
            "Lucida Sans Unicode",
            "Magneto",
            "Magneto",
            "Magneto",
            "Malgun Gothic",
            "Malgun Gothic",
            "Malgun Gothic",
            "Malgun Gothic Semilight",
            "Malgun Gothic Semilight",
            "Malgun Gothic Semilight",
            "Marlett",
            "Marlett",
            "Marlett",
            "Matura MT Script Capitals",
            "Matura MT Script Capitals",
            "Matura MT Script Capitals",
            "Megrim",
            "Megrim",
            "Megrim",
            "Microsoft Himalaya",
            "Microsoft Himalaya",
            "Microsoft Himalaya",
            "Microsoft JhengHei",
            "Microsoft JhengHei",
            "Microsoft JhengHei",
            "Microsoft JhengHei Light",
            "Microsoft JhengHei Light",
            "Microsoft JhengHei Light",
            "Microsoft JhengHei UI",
            "Microsoft JhengHei UI",
            "Microsoft JhengHei UI",
            "Microsoft JhengHei UI Light",
            "Microsoft JhengHei UI Light",
            "Microsoft JhengHei UI Light",
            "Microsoft New Tai Lue",
            "Microsoft New Tai Lue",
            "Microsoft New Tai Lue",
            "Microsoft PhagsPa",
            "Microsoft PhagsPa",
            "Microsoft PhagsPa",
            "Microsoft Sans Serif",
            "Microsoft Sans Serif",
            "Microsoft Sans Serif",
            "Microsoft Tai Le",
            "Microsoft Tai Le",
            "Microsoft Tai Le",
            "Microsoft Uighur",
            "Microsoft Uighur",
            "Microsoft Uighur",
            "Microsoft YaHei",
            "Microsoft YaHei",
            "Microsoft YaHei",
            "Microsoft YaHei Light",
            "Microsoft YaHei Light",
            "Microsoft YaHei Light",
            "Microsoft YaHei UI",
            "Microsoft YaHei UI",
            "Microsoft YaHei UI",
            "Microsoft YaHei UI Light",
            "Microsoft YaHei UI Light",
            "Microsoft YaHei UI Light",
            "Microsoft Yi Baiti",
            "Microsoft Yi Baiti",
            "Microsoft Yi Baiti",
            "MingLiU-ExtB",
            "MingLiU-ExtB",
            "MingLiU-ExtB",
            "MingLiU_HKSCS-ExtB",
            "MingLiU_HKSCS-ExtB",
            "MingLiU_HKSCS-ExtB",
            "Minion Pro",
            "Minion Pro",
            "Minion Pro",
            "Mistral",
            "Mistral",
            "Mistral",
            "Modern No. 20",
            "Modern No. 20",
            "Modern No. 20",
            "Mongolian Baiti",
            "Mongolian Baiti",
            "Mongolian Baiti",
            "Monospac821 BT",
            "Monospac821 BT",
            "Monospac821 BT",
            "Monoton",
            "Monoton",
            "Monoton",
            "Monotxt",
            "Monotxt",
            "Monotxt",
            "Monotxt_IV25",
            "Monotxt_IV25",
            "Monotxt_IV25",
            "Monotxt_IV50",
            "Monotxt_IV50",
            "Monotxt_IV50",
            "Monotype Corsiva",
            "Monotype Corsiva",
            "Monotype Corsiva",
            "MS Gothic",
            "MS Gothic",
            "MS Gothic",
            "MS Mincho",
            "MS Mincho",
            "MS Mincho",
            "MS PGothic",
            "MS PGothic",
            "MS PGothic",
            "MS Reference Sans Serif",
            "MS Reference Sans Serif",
            "MS Reference Sans Serif",
            "MS Reference Specialty",
            "MS Reference Specialty",
            "MS Reference Specialty",
            "MS UI Gothic",
            "MS UI Gothic",
            "MS UI Gothic",
            "MT Extra",
            "MT Extra",
            "MT Extra",
            "MV Boli",
            "MV Boli",
            "MV Boli",
            "Myanmar Text",
            "Myanmar Text",
            "Myanmar Text",
            "Myriad CAD",
            "Myriad CAD",
            "Myriad CAD",
            "Myriad Pro",
            "Myriad Pro",
            "Myriad Pro",
            "Nanum Pen",
            "Nanum Pen",
            "Nanum Pen",
            "Niagara Engraved",
            "Niagara Engraved",
            "Niagara Engraved",
            "Niagara Solid",
            "Niagara Solid",
            "Niagara Solid",
            "Nirmala UI",
            "Nirmala UI",
            "Nirmala UI",
            "Nirmala UI Semilight",
            "Nirmala UI Semilight",
            "Nirmala UI Semilight",
            "NSimSun",
            "NSimSun",
            "NSimSun",
            "Old English Text MT",
            "Old English Text MT",
            "Old English Text MT",
            "OLF SimpleSansOC",
            "OLF SimpleSansOC",
            "OLF SimpleSansOC",
            "Onyx",
            "Onyx",
            "Onyx",
            "Open Sans",
            "Open Sans",
            "Open Sans",
            "Open Sans Light",
            "Open Sans Light",
            "Open Sans Light",
            "Open Sans SemiBold",
            "Open Sans SemiBold",
            "Open Sans SemiBold",
            "Palatino Linotype",
            "Palatino Linotype",
            "Palatino Linotype",
            "Pangolin",
            "Pangolin",
            "Pangolin",
            "PanRoman",
            "PanRoman",
            "PanRoman",
            "Parchment",
            "Parchment",
            "Parchment",
            "Playbill",
            "Playbill",
            "Playbill",
            "PMingLiU-ExtB",
            "PMingLiU-ExtB",
            "PMingLiU-ExtB",
            "Poor Richard",
            "Poor Richard",
            "Poor Richard",
            "Proxy 1",
            "Proxy 1",
            "Proxy 1",
            "Proxy 2",
            "Proxy 2",
            "Proxy 2",
            "Proxy 3",
            "Proxy 3",
            "Proxy 3",
            "Proxy 4",
            "Proxy 4",
            "Proxy 4",
            "Proxy 5",
            "Proxy 5",
            "Proxy 5",
            "Proxy 6",
            "Proxy 6",
            "Proxy 6",
            "Proxy 7",
            "Proxy 7",
            "Proxy 7",
            "Proxy 8",
            "Proxy 8",
            "Proxy 8",
            "Proxy 9",
            "Proxy 9",
            "Proxy 9",
            "Raleway",
            "Raleway",
            "Raleway",
            "Ravie",
            "Ravie",
            "Ravie",
            "Roboto",
            "Roboto",
            "Roboto",
            "Roboto Light",
            "Roboto Light",
            "Roboto Light",
            "Roboto Thin",
            "Roboto Thin",
            "Roboto Thin",
            "RomanC",
            "RomanC",
            "RomanC",
            "RomanD",
            "RomanD",
            "RomanD",
            "RomanS",
            "RomanS",
            "RomanS",
            "RomanS_IV25",
            "RomanS_IV25",
            "RomanS_IV25",
            "RomanS_IV50",
            "RomanS_IV50",
            "RomanS_IV50",
            "RomanT",
            "RomanT",
            "RomanT",
            "Romantic",
            "Romantic",
            "Romantic",
            "SansSerif",
            "SansSerif",
            "SansSerif",
            "ScriptC",
            "ScriptC",
            "ScriptC",
            "ScriptS",
            "ScriptS",
            "ScriptS",
            "ScriptS_IV25",
            "ScriptS_IV25",
            "ScriptS_IV25",
            "ScriptS_IV50",
            "ScriptS_IV50",
            "ScriptS_IV50",
            "Segoe MDL2 Assets",
            "Segoe MDL2 Assets",
            "Segoe MDL2 Assets",
            "Segoe Print",
            "Segoe Print",
            "Segoe Print",
            "Segoe Script",
            "Segoe Script",
            "Segoe Script",
            "Segoe UI",
            "Segoe UI",
            "Segoe UI",
            "Segoe UI Black",
            "Segoe UI Black",
            "Segoe UI Black",
            "Segoe UI Emoji",
            "Segoe UI Emoji",
            "Segoe UI Emoji",
            "Segoe UI Historic",
            "Segoe UI Historic",
            "Segoe UI Historic",
            "Segoe UI Light",
            "Segoe UI Light",
            "Segoe UI Light",
            "Segoe UI Semibold",
            "Segoe UI Semibold",
            "Segoe UI Semibold",
            "Segoe UI Semilight",
            "Segoe UI Semilight",
            "Segoe UI Semilight",
            "Segoe UI Symbol",
            "Segoe UI Symbol",
            "Segoe UI Symbol",
            "Shadows Into Light",
            "Shadows Into Light",
            "Shadows Into Light",
            "Showcard Gothic",
            "Showcard Gothic",
            "Showcard Gothic",
            "Simplex",
            "Simplex",
            "Simplex",
            "Simplex_IV25",
            "Simplex_IV25",
            "Simplex_IV25",
            "Simplex_IV50",
            "Simplex_IV50",
            "Simplex_IV50",
            "SimSun",
            "SimSun",
            "SimSun",
            "SimSun-ExtB",
            "SimSun-ExtB",
            "SimSun-ExtB",
            "SimSun-ExtG",
            "SimSun-ExtG",
            "SimSun-ExtG",
            "Sitka Banner",
            "Sitka Banner",
            "Sitka Banner",
            "Sitka Display",
            "Sitka Display",
            "Sitka Display",
            "Sitka Heading",
            "Sitka Heading",
            "Sitka Heading",
            "Sitka Small",
            "Sitka Small",
            "Sitka Small",
            "Sitka Subheading",
            "Sitka Subheading",
            "Sitka Subheading",
            "Sitka Text",
            "Sitka Text",
            "Sitka Text",
            "Snap ITC",
            "Snap ITC",
            "Snap ITC",
            "Stencil",
            "Stencil",
            "Stencil",
            "Stylus BT",
            "Stylus BT",
            "Stylus BT",
            "SuperFrench",
            "SuperFrench",
            "SuperFrench",
            "SWAstro",
            "SWAstro",
            "SWAstro",
            "SWComp",
            "SWComp",
            "SWComp",
            "SWGDT",
            "SWGDT",
            "SWGDT",
            "SWGothe",
            "SWGothe",
            "SWGothe",
            "SWGothg",
            "SWGothg",
            "SWGothg",
            "SWGothi",
            "SWGothi",
            "SWGothi",
            "SWGrekc",
            "SWGrekc",
            "SWGrekc",
            "SWGreks",
            "SWGreks",
            "SWGreks",
            "Swipe Race Demo",
            "Swipe Race Demo",
            "Swipe Race Demo",
            "Swis721 BdCnOul BT",
            "Swis721 BdCnOul BT",
            "Swis721 BdCnOul BT",
            "Swis721 BdOul BT",
            "Swis721 BdOul BT",
            "Swis721 BdOul BT",
            "Swis721 Blk BT",
            "Swis721 Blk BT",
            "Swis721 Blk BT",
            "Swis721 BlkCn BT",
            "Swis721 BlkCn BT",
            "Swis721 BlkCn BT",
            "Swis721 BlkEx BT",
            "Swis721 BlkEx BT",
            "Swis721 BlkEx BT",
            "Swis721 BlkOul BT",
            "Swis721 BlkOul BT",
            "Swis721 BlkOul BT",
            "Swis721 BT",
            "Swis721 BT",
            "Swis721 BT",
            "Swis721 Cn BT",
            "Swis721 Cn BT",
            "Swis721 Cn BT",
            "Swis721 Ex BT",
            "Swis721 Ex BT",
            "Swis721 Ex BT",
            "Swis721 Lt BT",
            "Swis721 Lt BT",
            "Swis721 Lt BT",
            "Swis721 LtCn BT",
            "Swis721 LtCn BT",
            "Swis721 LtCn BT",
            "Swis721 LtEx BT",
            "Swis721 LtEx BT",
            "Swis721 LtEx BT",
            "SWIsop1",
            "SWIsop1",
            "SWIsop1",
            "SWIsop2",
            "SWIsop2",
            "SWIsop2",
            "SWIsop3",
            "SWIsop3",
            "SWIsop3",
            "SWIsot1",
            "SWIsot1",
            "SWIsot1",
            "SWIsot2",
            "SWIsot2",
            "SWIsot2",
            "SWIsot3",
            "SWIsot3",
            "SWIsot3",
            "SWItal",
            "SWItal",
            "SWItal",
            "SWItalc",
            "SWItalc",
            "SWItalc",
            "SWItalt",
            "SWItalt",
            "SWItalt",
            "SWLink",
            "SWLink",
            "SWLink",
            "SWMap",
            "SWMap",
            "SWMap",
            "SWMath",
            "SWMath",
            "SWMath",
            "SWMeteo",
            "SWMeteo",
            "SWMeteo",
            "SWMono",
            "SWMono",
            "SWMono",
            "SWMusic",
            "SWMusic",
            "SWMusic",
            "SWRomnc",
            "SWRomnc",
            "SWRomnc",
            "SWRomnd",
            "SWRomnd",
            "SWRomnd",
            "SWRomns",
            "SWRomns",
            "SWRomns",
            "SWRomnt",
            "SWRomnt",
            "SWRomnt",
            "SWScrpc",
            "SWScrpc",
            "SWScrpc",
            "SWScrps",
            "SWScrps",
            "SWScrps",
            "SWSimp",
            "SWSimp",
            "SWSimp",
            "SWTxt",
            "SWTxt",
            "SWTxt",
            "Syastro",
            "Syastro",
            "Syastro",
            "Syastro_IV25",
            "Syastro_IV25",
            "Syastro_IV25",
            "Syastro_IV50",
            "Syastro_IV50",
            "Syastro_IV50",
            "Sylfaen",
            "Sylfaen",
            "Sylfaen",
            "Symap",
            "Symap",
            "Symap",
            "Symap_IV25",
            "Symap_IV25",
            "Symap_IV25",
            "Symap_IV50",
            "Symap_IV50",
            "Symap_IV50",
            "Symath",
            "Symath",
            "Symath",
            "Symath_IV25",
            "Symath_IV25",
            "Symath_IV25",
            "Symath_IV50",
            "Symath_IV50",
            "Symath_IV50",
            "Symbol",
            "Symbol",
            "Symbol",
            "Symbol type A",
            "Symbol type A",
            "Symbol type A",
            "Symbol type B",
            "Symbol type B",
            "Symbol type B",
            "Symeteo",
            "Symeteo",
            "Symeteo",
            "Symeteo_IV25",
            "Symeteo_IV25",
            "Symeteo_IV25",
            "Symeteo_IV50",
            "Symeteo_IV50",
            "Symeteo_IV50",
            "Symusic",
            "Symusic",
            "Symusic",
            "Symusic_IV25",
            "Symusic_IV25",
            "Symusic_IV25",
            "Symusic_IV50",
            "Symusic_IV50",
            "Symusic_IV50",
            "T-FLEX Symbol Type A",
            "T-FLEX Symbol Type A",
            "T-FLEX Symbol Type A",
            "T-FLEX Symbol Type B",
            "T-FLEX Symbol Type B",
            "T-FLEX Symbol Type B",
            "T-FLEX Type A",
            "T-FLEX Type A",
            "T-FLEX Type A",
            "T-FLEX Type B",
            "T-FLEX Type B",
            "T-FLEX Type B",
            "T-FLEX Type T",
            "T-FLEX Type T",
            "T-FLEX Type T",
            "T-FLEX Type TU",
            "T-FLEX Type TU",
            "T-FLEX Type TU",
            "Tahoma",
            "Tahoma",
            "Tahoma",
            "Technic",
            "Technic",
            "Technic",
            "TechnicBold",
            "TechnicBold",
            "TechnicBold",
            "TechnicLite",
            "TechnicLite",
            "TechnicLite",
            "Tempus Sans ITC",
            "Tempus Sans ITC",
            "Tempus Sans ITC",
            "Times New Roman",
            "Times New Roman",
            "Times New Roman",
            "Trebuchet MS",
            "Trebuchet MS",
            "Trebuchet MS",
            "Txt",
            "Txt",
            "Txt",
            "Txt_IV25",
            "Txt_IV25",
            "Txt_IV25",
            "Txt_IV50",
            "Txt_IV50",
            "Txt_IV50",
            "UniversalMath1 BT",
            "UniversalMath1 BT",
            "UniversalMath1 BT",
            "Vast Shadow",
            "Vast Shadow",
            "Vast Shadow",
            "Verdana",
            "Verdana",
            "Verdana",
            "Viner Hand ITC",
            "Viner Hand ITC",
            "Viner Hand ITC",
            "Vineta BT",
            "Vineta BT",
            "Vineta BT",
            "Vivaldi",
            "Vivaldi",
            "Vivaldi",
            "Vladimir Script",
            "Vladimir Script",
            "Vladimir Script",
            "Webdings",
            "Webdings",
            "Webdings",
            "Wide Latin",
            "Wide Latin",
            "Wide Latin",
            "Wingdings",
            "Wingdings",
            "Wingdings",
            "Wingdings 2",
            "Wingdings 2",
            "Wingdings 2",
            "Wingdings 3",
            "Wingdings 3",
            "Wingdings 3",
            "Yu Gothic",
            "Yu Gothic",
            "Yu Gothic",
            "Yu Gothic Light",
            "Yu Gothic Light",
            "Yu Gothic Light",
            "Yu Gothic Medium",
            "Yu Gothic Medium",
            "Yu Gothic Medium",
            "Yu Gothic UI",
            "Yu Gothic UI",
            "Yu Gothic UI",
            "Yu Gothic UI Light",
            "Yu Gothic UI Light",
            "Yu Gothic UI Light",
            "Yu Gothic UI Semibold",
            "Yu Gothic UI Semibold",
            "Yu Gothic UI Semibold",
            "Yu Gothic UI Semilight",
            "Yu Gothic UI Semilight",
            "Yu Gothic UI Semilight",
            "Zilla Slab",
            "Zilla Slab",
            "Zilla Slab"});
			this.fontFamily.Location = new System.Drawing.Point(237, 56);
			this.fontFamily.Name = "fontFamily";
			this.fontFamily.Size = new System.Drawing.Size(201, 28);
			this.fontFamily.Sorted = true;
			this.fontFamily.TabIndex = 3;
			this.fontFamily.SelectedIndexChanged += new System.EventHandler(this.fontFamily_SelectedIndexChanged);
			// 
			// TextStyleManagement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(669, 410);
			this.Controls.Add(this.currentStyle);
			this.Controls.Add(this.setcurrentBtn);
			this.Controls.Add(this.newBtn);
			this.Controls.Add(this.deleteBtn);
			this.Controls.Add(this.saveBtn);
			this.Controls.Add(this.closeBtn);
			this.Controls.Add(this.backward);
			this.Controls.Add(this.upsideDown);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.widthFactor);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.height);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.fontStyle);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.fontFamily);
			this.Controls.Add(this.picBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.styles);
			this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TextStyleManagement";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "TextStyleManagement";
			this.Load += new System.EventHandler(this.TextStyleManagement_Load);
			((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox styles;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox picBox;
		private Components.MyFontComboBox fontFamily;
		private System.Windows.Forms.Label label2;
		private Components.MyComboBox fontStyle;
		private System.Windows.Forms.Label label3;
		private Components.MyTextBox height;
		private System.Windows.Forms.Label label4;
		private Components.MyTextBox widthFactor;
		private System.Windows.Forms.Label label5;
		private Components.MyCheckBox upsideDown;
		private Components.MyCheckBox backward;
		private System.Windows.Forms.Button closeBtn;
		private System.Windows.Forms.Button saveBtn;
		private System.Windows.Forms.Button deleteBtn;
		private System.Windows.Forms.Button newBtn;
		private System.Windows.Forms.Button setcurrentBtn;
		private System.Windows.Forms.Label currentStyle;
	}
}