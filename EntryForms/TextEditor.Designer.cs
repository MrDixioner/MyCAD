using System;

namespace MyCAD.EntryForms {
	partial class TextEditor {
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
			this.label1 = new System.Windows.Forms.Label();
			this.acceptBtn = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.textStyle = new MyCAD.Components.MyComboBox();
			this.alignment = new MyCAD.Components.MyComboBox();
			this.height = new MyCAD.Components.MyTextBox();
			this.rotation = new MyCAD.Components.MyTextBox();
			this.text = new MyCAD.Components.MyTextBox();
			this.myFontComboBox1 = new MyCAD.Components.MyFontComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 19);
			this.label1.TabIndex = 5;
			this.label1.Text = "Input Text:";
			// 
			// acceptBtn
			// 
			this.acceptBtn.Location = new System.Drawing.Point(200, 207);
			this.acceptBtn.Name = "acceptBtn";
			this.acceptBtn.Size = new System.Drawing.Size(100, 35);
			this.acceptBtn.TabIndex = 10;
			this.acceptBtn.Text = "Accept";
			this.acceptBtn.UseVisualStyleBackColor = true;
			this.acceptBtn.Click += new System.EventHandler(this.acceptBtn_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 19);
			this.label2.TabIndex = 6;
			this.label2.Text = "Text style:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(187, 143);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(79, 19);
			this.label3.TabIndex = 9;
			this.label3.Text = "Alignment:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 142);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(52, 19);
			this.label4.TabIndex = 7;
			this.label4.Text = "Height";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(94, 142);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 19);
			this.label5.TabIndex = 8;
			this.label5.Text = "Rotation";
			// 
			// cancelBtn
			// 
			this.cancelBtn.Location = new System.Drawing.Point(306, 207);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(100, 35);
			this.cancelBtn.TabIndex = 11;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// textStyle
			// 
			this.textStyle.EnterAsTab = true;
			this.textStyle.FormattingEnabled = true;
			this.textStyle.Location = new System.Drawing.Point(11, 98);
			this.textStyle.Name = "textStyle";
			this.textStyle.Size = new System.Drawing.Size(297, 27);
			this.textStyle.TabIndex = 1;
			this.textStyle.SelectedIndexChanged += new System.EventHandler(this.textStyle_SelectedIndexChanged);
			// 
			// alignment
			// 
			this.alignment.EnterAsTab = true;
			this.alignment.FormattingEnabled = true;
			this.alignment.Location = new System.Drawing.Point(186, 165);
			this.alignment.Name = "alignment";
			this.alignment.Size = new System.Drawing.Size(121, 27);
			this.alignment.TabIndex = 4;
			this.alignment.DataSource = Enum.GetValues(typeof(Entities.TextAlignment));
			this.alignment.SelectedIndexChanged += new System.EventHandler(this.alignment_SelectedIndexChanged);
			// 
			// height
			// 
			this.height.EnterAsTab = true;
			this.height.Location = new System.Drawing.Point(11, 164);
			this.height.Name = "height";
			this.height.Size = new System.Drawing.Size(77, 27);
			this.height.TabIndex = 2;
			this.height.Text = "0";
			this.height.Type = MyCAD.Components.DataType.Decimal;
			this.height.TextChanged += new System.EventHandler(this.height_TextChanged);
			// 
			// rotation
			// 
			this.rotation.EnterAsTab = true;
			this.rotation.Location = new System.Drawing.Point(94, 165);
			this.rotation.Name = "rotation";
			this.rotation.Size = new System.Drawing.Size(86, 27);
			this.rotation.TabIndex = 3;
			this.rotation.Text = "0";
			this.rotation.Type = MyCAD.Components.DataType.Decimal;
			this.rotation.TextChanged += new System.EventHandler(this.rotation_TextChanged);
			// 
			// text
			// 
			this.text.EnterAsTab = true;
			this.text.Location = new System.Drawing.Point(11, 38);
			this.text.Name = "text";
			this.text.Size = new System.Drawing.Size(296, 27);
			this.text.TabIndex = 12;
			this.text.Type = MyCAD.Components.DataType.Text;
			this.text.TextChanged += new System.EventHandler(this.text_TextChanged);
			// 
			// myFontComboBox1
			// 
			this.myFontComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.myFontComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.myFontComboBox1.EnterAsTab = false;
			this.myFontComboBox1.FormattingEnabled = true;
			this.myFontComboBox1.Items.AddRange(new object[] {
            "AcadEref",
            "AcadEref",
            "Adobe Arabic",
            "Adobe Arabic",
            "Adobe Fan Heiti Std B",
            "Adobe Fan Heiti Std B",
            "Adobe Gothic Std B",
            "Adobe Gothic Std B",
            "Adobe Hebrew",
            "Adobe Hebrew",
            "Adobe Heiti Std R",
            "Adobe Heiti Std R",
            "Adobe Ming Std L",
            "Adobe Ming Std L",
            "Adobe Myungjo Std M",
            "Adobe Myungjo Std M",
            "Adobe Pi Std",
            "Adobe Pi Std",
            "Adobe Song Std L",
            "Adobe Song Std L",
            "Adobe Thai",
            "Adobe Thai",
            "AIGDT",
            "AIGDT",
            "Algerian",
            "Algerian",
            "AmdtSymbols",
            "AmdtSymbols",
            "AMGDT",
            "AMGDT",
            "AMGDT_IV25",
            "AMGDT_IV25",
            "AMGDT_IV50",
            "AMGDT_IV50",
            "AmpleSoundTab",
            "AmpleSoundTab",
            "Andale Mono IPA",
            "Andale Mono IPA",
            "Arial",
            "Arial",
            "Arial Black",
            "Arial Black",
            "Arial Narrow",
            "Arial Narrow",
            "Arial Unicode MS",
            "Arial Unicode MS",
            "Bahnschrift",
            "Bahnschrift",
            "Bahnschrift Condensed",
            "Bahnschrift Condensed",
            "Bahnschrift Light",
            "Bahnschrift Light",
            "Bahnschrift Light Condensed",
            "Bahnschrift Light Condensed",
            "Bahnschrift Light SemiCondensed",
            "Bahnschrift Light SemiCondensed",
            "Bahnschrift SemiBold",
            "Bahnschrift SemiBold",
            "Bahnschrift SemiBold Condensed",
            "Bahnschrift SemiBold Condensed",
            "Bahnschrift SemiBold SemiConden",
            "Bahnschrift SemiBold SemiConden",
            "Bahnschrift SemiCondensed",
            "Bahnschrift SemiCondensed",
            "Bahnschrift SemiLight",
            "Bahnschrift SemiLight",
            "Bahnschrift SemiLight Condensed",
            "Bahnschrift SemiLight Condensed",
            "Bahnschrift SemiLight SemiConde",
            "Bahnschrift SemiLight SemiConde",
            "BankGothic Lt BT",
            "BankGothic Lt BT",
            "BankGothic Md BT",
            "BankGothic Md BT",
            "Barlow Condensed",
            "Barlow Condensed",
            "Barrio",
            "Barrio",
            "Baskerville Old Face",
            "Baskerville Old Face",
            "Bauhaus 93",
            "Bauhaus 93",
            "Bell MT",
            "Bell MT",
            "Berlin Sans FB",
            "Berlin Sans FB",
            "Berlin Sans FB Demi",
            "Berlin Sans FB Demi",
            "Bernard MT Condensed",
            "Bernard MT Condensed",
            "Bodoni MT Poster Compressed",
            "Bodoni MT Poster Compressed",
            "Book Antiqua",
            "Book Antiqua",
            "Bookman Old Style",
            "Bookman Old Style",
            "Bookshelf Symbol 7",
            "Bookshelf Symbol 7",
            "Britannic Bold",
            "Britannic Bold",
            "Broadway",
            "Broadway",
            "Brush Script MT",
            "Brush Script MT",
            "Bubblegum Sans",
            "Bubblegum Sans",
            "Cabin Sketch",
            "Cabin Sketch",
            "Calibri",
            "Calibri",
            "Calibri Light",
            "Calibri Light",
            "Californian FB",
            "Californian FB",
            "Cambria",
            "Cambria",
            "Cambria Math",
            "Cambria Math",
            "Candara",
            "Candara",
            "Candara Light",
            "Candara Light",
            "Cascadia Code",
            "Cascadia Code",
            "Cascadia Code ExtraLight",
            "Cascadia Code ExtraLight",
            "Cascadia Code Light",
            "Cascadia Code Light",
            "Cascadia Code SemiBold",
            "Cascadia Code SemiBold",
            "Cascadia Code SemiLight",
            "Cascadia Code SemiLight",
            "Cascadia Mono",
            "Cascadia Mono",
            "Cascadia Mono ExtraLight",
            "Cascadia Mono ExtraLight",
            "Cascadia Mono Light",
            "Cascadia Mono Light",
            "Cascadia Mono SemiBold",
            "Cascadia Mono SemiBold",
            "Cascadia Mono SemiLight",
            "Cascadia Mono SemiLight",
            "Centaur",
            "Centaur",
            "Century",
            "Century",
            "Century Gothic",
            "Century Gothic",
            "Chiller",
            "Chiller",
            "CityBlueprint",
            "CityBlueprint",
            "Colonna MT",
            "Colonna MT",
            "Comfortaa",
            "Comfortaa",
            "Comic Sans MS",
            "Comic Sans MS",
            "CommercialPi BT",
            "CommercialPi BT",
            "CommercialScript BT",
            "CommercialScript BT",
            "Complex",
            "Complex",
            "Complex_IV25",
            "Complex_IV25",
            "Complex_IV50",
            "Complex_IV50",
            "Consolas",
            "Consolas",
            "Constantia",
            "Constantia",
            "Cooper Black",
            "Cooper Black",
            "Corbel",
            "Corbel",
            "Corbel Light",
            "Corbel Light",
            "CountryBlueprint",
            "CountryBlueprint",
            "Courier New",
            "Courier New",
            "Courier Std",
            "Courier Std",
            "Delius",
            "Delius",
            "Dosis",
            "Dosis",
            "DS ISO 1",
            "DS ISO 1",
            "Dubai",
            "Dubai",
            "Dubai Light",
            "Dubai Light",
            "Dubai Medium",
            "Dubai Medium",
            "Dutch801 Rm BT",
            "Dutch801 Rm BT",
            "Dutch801 XBd BT",
            "Dutch801 XBd BT",
            "Ebrima",
            "Ebrima",
            "Engraving singleline Font",
            "Engraving singleline Font",
            "EuroRoman",
            "EuroRoman",
            "Footlight MT Light",
            "Footlight MT Light",
            "Franklin Gothic Medium",
            "Franklin Gothic Medium",
            "Fredericka the Great",
            "Fredericka the Great",
            "Fredoka One",
            "Fredoka One",
            "Freestyle Script",
            "Freestyle Script",
            "Gabriola",
            "Gabriola",
            "Gadugi",
            "Gadugi",
            "Garamond",
            "Garamond",
            "GDT",
            "GDT",
            "GDT_IV25",
            "GDT_IV25",
            "GDT_IV50",
            "GDT_IV50",
            "GENISO",
            "GENISO",
            "Georgia",
            "Georgia",
            "GOST Common",
            "GOST Common",
            "GOST type A",
            "GOST type A",
            "GOST Type AU",
            "GOST Type AU",
            "GOST type B",
            "GOST type B",
            "GOST Type BU",
            "GOST Type BU",
            "GostBazis",
            "GostBazis",
            "GothicE",
            "GothicE",
            "GothicG",
            "GothicG",
            "GothicI",
            "GothicI",
            "GreekC",
            "GreekC",
            "GreekC_IV25",
            "GreekC_IV25",
            "GreekC_IV50",
            "GreekC_IV50",
            "GreekS",
            "GreekS",
            "GreekS_IV25",
            "GreekS_IV25",
            "GreekS_IV50",
            "GreekS_IV50",
            "Harlow Solid Italic",
            "Harlow Solid Italic",
            "Harrington",
            "Harrington",
            "High Tower Text",
            "High Tower Text",
            "HoloLens MDL2 Assets",
            "HoloLens MDL2 Assets",
            "HYSWLongFangSong",
            "HYSWLongFangSong",
            "Impact",
            "Impact",
            "Informal Roman",
            "Informal Roman",
            "Ink Free",
            "Ink Free",
            "ISOCP",
            "ISOCP",
            "ISOCP_IV25",
            "ISOCP_IV25",
            "ISOCP_IV50",
            "ISOCP_IV50",
            "ISOCP2",
            "ISOCP2",
            "ISOCP2_IV25",
            "ISOCP2_IV25",
            "ISOCP2_IV50",
            "ISOCP2_IV50",
            "ISOCP3",
            "ISOCP3",
            "ISOCP3_IV25",
            "ISOCP3_IV25",
            "ISOCP3_IV50",
            "ISOCP3_IV50",
            "ISOCPEUR",
            "ISOCPEUR",
            "ISOCT",
            "ISOCT",
            "ISOCT_IV25",
            "ISOCT_IV25",
            "ISOCT_IV50",
            "ISOCT_IV50",
            "ISOCT2",
            "ISOCT2",
            "ISOCT2_IV25",
            "ISOCT2_IV25",
            "ISOCT2_IV50",
            "ISOCT2_IV50",
            "ISOCT3",
            "ISOCT3",
            "ISOCT3_IV25",
            "ISOCT3_IV25",
            "ISOCT3_IV50",
            "ISOCT3_IV50",
            "ISOCTEUR",
            "ISOCTEUR",
            "Italic",
            "Italic",
            "Italic_IV25",
            "Italic_IV25",
            "Italic_IV50",
            "Italic_IV50",
            "ItalicC",
            "ItalicC",
            "ItalicT",
            "ItalicT",
            "Javanese Text",
            "Javanese Text",
            "JetBrains Mono",
            "JetBrains Mono",
            "JetBrains Mono ExtraBold",
            "JetBrains Mono ExtraBold",
            "JetBrains Mono ExtraLight",
            "JetBrains Mono ExtraLight",
            "JetBrains Mono Light",
            "JetBrains Mono Light",
            "JetBrains Mono Medium",
            "JetBrains Mono Medium",
            "JetBrains Mono SemiBold",
            "JetBrains Mono SemiBold",
            "JetBrains Mono Thin",
            "JetBrains Mono Thin",
            "Jokerman",
            "Jokerman",
            "Juice ITC",
            "Juice ITC",
            "Julius Sans One",
            "Julius Sans One",
            "Kozuka Gothic Pr6N M",
            "Kozuka Gothic Pr6N M",
            "Kozuka Mincho Pr6N R",
            "Kozuka Mincho Pr6N R",
            "Kristen ITC",
            "Kristen ITC",
            "Kunstler Script",
            "Kunstler Script",
            "Leelawadee",
            "Leelawadee",
            "Leelawadee UI",
            "Leelawadee UI",
            "Leelawadee UI Semilight",
            "Leelawadee UI Semilight",
            "Lucida Bright",
            "Lucida Bright",
            "Lucida Calligraphy",
            "Lucida Calligraphy",
            "Lucida Console",
            "Lucida Console",
            "Lucida Fax",
            "Lucida Fax",
            "Lucida Handwriting",
            "Lucida Handwriting",
            "Lucida Sans Unicode",
            "Lucida Sans Unicode",
            "Magneto",
            "Magneto",
            "Malgun Gothic",
            "Malgun Gothic",
            "Malgun Gothic Semilight",
            "Malgun Gothic Semilight",
            "Marlett",
            "Marlett",
            "Matura MT Script Capitals",
            "Matura MT Script Capitals",
            "Megrim",
            "Megrim",
            "Microsoft Himalaya",
            "Microsoft Himalaya",
            "Microsoft JhengHei",
            "Microsoft JhengHei",
            "Microsoft JhengHei Light",
            "Microsoft JhengHei Light",
            "Microsoft JhengHei UI",
            "Microsoft JhengHei UI",
            "Microsoft JhengHei UI Light",
            "Microsoft JhengHei UI Light",
            "Microsoft New Tai Lue",
            "Microsoft New Tai Lue",
            "Microsoft PhagsPa",
            "Microsoft PhagsPa",
            "Microsoft Sans Serif",
            "Microsoft Sans Serif",
            "Microsoft Tai Le",
            "Microsoft Tai Le",
            "Microsoft Uighur",
            "Microsoft Uighur",
            "Microsoft YaHei",
            "Microsoft YaHei",
            "Microsoft YaHei Light",
            "Microsoft YaHei Light",
            "Microsoft YaHei UI",
            "Microsoft YaHei UI",
            "Microsoft YaHei UI Light",
            "Microsoft YaHei UI Light",
            "Microsoft Yi Baiti",
            "Microsoft Yi Baiti",
            "MingLiU-ExtB",
            "MingLiU-ExtB",
            "MingLiU_HKSCS-ExtB",
            "MingLiU_HKSCS-ExtB",
            "Minion Pro",
            "Minion Pro",
            "Mistral",
            "Mistral",
            "Modern No. 20",
            "Modern No. 20",
            "Mongolian Baiti",
            "Mongolian Baiti",
            "Monospac821 BT",
            "Monospac821 BT",
            "Monoton",
            "Monoton",
            "Monotxt",
            "Monotxt",
            "Monotxt_IV25",
            "Monotxt_IV25",
            "Monotxt_IV50",
            "Monotxt_IV50",
            "Monotype Corsiva",
            "Monotype Corsiva",
            "MS Gothic",
            "MS Gothic",
            "MS Mincho",
            "MS Mincho",
            "MS PGothic",
            "MS PGothic",
            "MS Reference Sans Serif",
            "MS Reference Sans Serif",
            "MS Reference Specialty",
            "MS Reference Specialty",
            "MS UI Gothic",
            "MS UI Gothic",
            "MT Extra",
            "MT Extra",
            "MV Boli",
            "MV Boli",
            "Myanmar Text",
            "Myanmar Text",
            "Myriad CAD",
            "Myriad CAD",
            "Myriad Pro",
            "Myriad Pro",
            "Nanum Pen",
            "Nanum Pen",
            "Niagara Engraved",
            "Niagara Engraved",
            "Niagara Solid",
            "Niagara Solid",
            "Nirmala UI",
            "Nirmala UI",
            "Nirmala UI Semilight",
            "Nirmala UI Semilight",
            "NSimSun",
            "NSimSun",
            "Old English Text MT",
            "Old English Text MT",
            "OLF SimpleSansOC",
            "OLF SimpleSansOC",
            "Onyx",
            "Onyx",
            "Open Sans",
            "Open Sans",
            "Open Sans Light",
            "Open Sans Light",
            "Open Sans SemiBold",
            "Open Sans SemiBold",
            "Palatino Linotype",
            "Palatino Linotype",
            "Pangolin",
            "Pangolin",
            "PanRoman",
            "PanRoman",
            "Parchment",
            "Parchment",
            "Playbill",
            "Playbill",
            "PMingLiU-ExtB",
            "PMingLiU-ExtB",
            "Poor Richard",
            "Poor Richard",
            "Proxy 1",
            "Proxy 1",
            "Proxy 2",
            "Proxy 2",
            "Proxy 3",
            "Proxy 3",
            "Proxy 4",
            "Proxy 4",
            "Proxy 5",
            "Proxy 5",
            "Proxy 6",
            "Proxy 6",
            "Proxy 7",
            "Proxy 7",
            "Proxy 8",
            "Proxy 8",
            "Proxy 9",
            "Proxy 9",
            "Raleway",
            "Raleway",
            "Ravie",
            "Ravie",
            "Roboto",
            "Roboto",
            "Roboto Light",
            "Roboto Light",
            "Roboto Thin",
            "Roboto Thin",
            "RomanC",
            "RomanC",
            "RomanD",
            "RomanD",
            "RomanS",
            "RomanS",
            "RomanS_IV25",
            "RomanS_IV25",
            "RomanS_IV50",
            "RomanS_IV50",
            "RomanT",
            "RomanT",
            "Romantic",
            "Romantic",
            "SansSerif",
            "SansSerif",
            "ScriptC",
            "ScriptC",
            "ScriptS",
            "ScriptS",
            "ScriptS_IV25",
            "ScriptS_IV25",
            "ScriptS_IV50",
            "ScriptS_IV50",
            "Segoe MDL2 Assets",
            "Segoe MDL2 Assets",
            "Segoe Print",
            "Segoe Print",
            "Segoe Script",
            "Segoe Script",
            "Segoe UI",
            "Segoe UI",
            "Segoe UI Black",
            "Segoe UI Black",
            "Segoe UI Emoji",
            "Segoe UI Emoji",
            "Segoe UI Historic",
            "Segoe UI Historic",
            "Segoe UI Light",
            "Segoe UI Light",
            "Segoe UI Semibold",
            "Segoe UI Semibold",
            "Segoe UI Semilight",
            "Segoe UI Semilight",
            "Segoe UI Symbol",
            "Segoe UI Symbol",
            "Shadows Into Light",
            "Shadows Into Light",
            "Showcard Gothic",
            "Showcard Gothic",
            "Simplex",
            "Simplex",
            "Simplex_IV25",
            "Simplex_IV25",
            "Simplex_IV50",
            "Simplex_IV50",
            "SimSun",
            "SimSun",
            "SimSun-ExtB",
            "SimSun-ExtB",
            "SimSun-ExtG",
            "SimSun-ExtG",
            "Sitka Banner",
            "Sitka Banner",
            "Sitka Display",
            "Sitka Display",
            "Sitka Heading",
            "Sitka Heading",
            "Sitka Small",
            "Sitka Small",
            "Sitka Subheading",
            "Sitka Subheading",
            "Sitka Text",
            "Sitka Text",
            "Snap ITC",
            "Snap ITC",
            "Stencil",
            "Stencil",
            "Stylus BT",
            "Stylus BT",
            "SuperFrench",
            "SuperFrench",
            "SWAstro",
            "SWAstro",
            "SWComp",
            "SWComp",
            "SWGDT",
            "SWGDT",
            "SWGothe",
            "SWGothe",
            "SWGothg",
            "SWGothg",
            "SWGothi",
            "SWGothi",
            "SWGrekc",
            "SWGrekc",
            "SWGreks",
            "SWGreks",
            "Swipe Race Demo",
            "Swipe Race Demo",
            "Swis721 BdCnOul BT",
            "Swis721 BdCnOul BT",
            "Swis721 BdOul BT",
            "Swis721 BdOul BT",
            "Swis721 Blk BT",
            "Swis721 Blk BT",
            "Swis721 BlkCn BT",
            "Swis721 BlkCn BT",
            "Swis721 BlkEx BT",
            "Swis721 BlkEx BT",
            "Swis721 BlkOul BT",
            "Swis721 BlkOul BT",
            "Swis721 BT",
            "Swis721 BT",
            "Swis721 Cn BT",
            "Swis721 Cn BT",
            "Swis721 Ex BT",
            "Swis721 Ex BT",
            "Swis721 Lt BT",
            "Swis721 Lt BT",
            "Swis721 LtCn BT",
            "Swis721 LtCn BT",
            "Swis721 LtEx BT",
            "Swis721 LtEx BT",
            "SWIsop1",
            "SWIsop1",
            "SWIsop2",
            "SWIsop2",
            "SWIsop3",
            "SWIsop3",
            "SWIsot1",
            "SWIsot1",
            "SWIsot2",
            "SWIsot2",
            "SWIsot3",
            "SWIsot3",
            "SWItal",
            "SWItal",
            "SWItalc",
            "SWItalc",
            "SWItalt",
            "SWItalt",
            "SWLink",
            "SWLink",
            "SWMap",
            "SWMap",
            "SWMath",
            "SWMath",
            "SWMeteo",
            "SWMeteo",
            "SWMono",
            "SWMono",
            "SWMusic",
            "SWMusic",
            "SWRomnc",
            "SWRomnc",
            "SWRomnd",
            "SWRomnd",
            "SWRomns",
            "SWRomns",
            "SWRomnt",
            "SWRomnt",
            "SWScrpc",
            "SWScrpc",
            "SWScrps",
            "SWScrps",
            "SWSimp",
            "SWSimp",
            "SWTxt",
            "SWTxt",
            "Syastro",
            "Syastro",
            "Syastro_IV25",
            "Syastro_IV25",
            "Syastro_IV50",
            "Syastro_IV50",
            "Sylfaen",
            "Sylfaen",
            "Symap",
            "Symap",
            "Symap_IV25",
            "Symap_IV25",
            "Symap_IV50",
            "Symap_IV50",
            "Symath",
            "Symath",
            "Symath_IV25",
            "Symath_IV25",
            "Symath_IV50",
            "Symath_IV50",
            "Symbol",
            "Symbol",
            "Symbol type A",
            "Symbol type A",
            "Symbol type B",
            "Symbol type B",
            "Symeteo",
            "Symeteo",
            "Symeteo_IV25",
            "Symeteo_IV25",
            "Symeteo_IV50",
            "Symeteo_IV50",
            "Symusic",
            "Symusic",
            "Symusic_IV25",
            "Symusic_IV25",
            "Symusic_IV50",
            "Symusic_IV50",
            "T-FLEX Symbol Type A",
            "T-FLEX Symbol Type A",
            "T-FLEX Symbol Type B",
            "T-FLEX Symbol Type B",
            "T-FLEX Type A",
            "T-FLEX Type A",
            "T-FLEX Type B",
            "T-FLEX Type B",
            "T-FLEX Type T",
            "T-FLEX Type T",
            "T-FLEX Type TU",
            "T-FLEX Type TU",
            "Tahoma",
            "Tahoma",
            "Technic",
            "Technic",
            "TechnicBold",
            "TechnicBold",
            "TechnicLite",
            "TechnicLite",
            "Tempus Sans ITC",
            "Tempus Sans ITC",
            "Times New Roman",
            "Times New Roman",
            "Trebuchet MS",
            "Trebuchet MS",
            "Txt",
            "Txt",
            "Txt_IV25",
            "Txt_IV25",
            "Txt_IV50",
            "Txt_IV50",
            "UniversalMath1 BT",
            "UniversalMath1 BT",
            "Vast Shadow",
            "Vast Shadow",
            "Verdana",
            "Verdana",
            "Viner Hand ITC",
            "Viner Hand ITC",
            "Vineta BT",
            "Vineta BT",
            "Vivaldi",
            "Vivaldi",
            "Vladimir Script",
            "Vladimir Script",
            "Webdings",
            "Webdings",
            "Wide Latin",
            "Wide Latin",
            "Wingdings",
            "Wingdings",
            "Wingdings 2",
            "Wingdings 2",
            "Wingdings 3",
            "Wingdings 3",
            "Yu Gothic",
            "Yu Gothic",
            "Yu Gothic Light",
            "Yu Gothic Light",
            "Yu Gothic Medium",
            "Yu Gothic Medium",
            "Yu Gothic UI",
            "Yu Gothic UI",
            "Yu Gothic UI Light",
            "Yu Gothic UI Light",
            "Yu Gothic UI Semibold",
            "Yu Gothic UI Semibold",
            "Yu Gothic UI Semilight",
            "Yu Gothic UI Semilight",
            "Zilla Slab",
            "Zilla Slab"});
			this.myFontComboBox1.Location = new System.Drawing.Point(11, 207);
			this.myFontComboBox1.Name = "myFontComboBox1";
			this.myFontComboBox1.Size = new System.Drawing.Size(121, 28);
			this.myFontComboBox1.Sorted = true;
			this.myFontComboBox1.TabIndex = 13;
			// 
			// TextEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(418, 254);
			this.Controls.Add(this.myFontComboBox1);
			this.Controls.Add(this.text);
			this.Controls.Add(this.rotation);
			this.Controls.Add(this.height);
			this.Controls.Add(this.alignment);
			this.Controls.Add(this.textStyle);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.acceptBtn);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TextEditor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "TextEditor";
			this.Load += new System.EventHandler(this.TextEditor_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button acceptBtn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button cancelBtn;
		private Components.MyComboBox textStyle;
		private Components.MyComboBox alignment;
		private Components.MyTextBox height;
		private Components.MyTextBox rotation;
		private Components.MyTextBox text;
		private Components.MyFontComboBox myFontComboBox1;
	}
}