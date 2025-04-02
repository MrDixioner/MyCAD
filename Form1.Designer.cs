namespace MyCAD {
	partial class GraphicsForm {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphicsForm));
			this.popup = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cancelBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.closeBoundary = new System.Windows.Forms.ToolStripMenuItem();
			this.ribbon = new System.Windows.Forms.Ribbon();
			this.drawTab = new System.Windows.Forms.RibbonTab();
			this.drawPanel = new System.Windows.Forms.RibbonPanel();
			this.zoomPanel = new System.Windows.Forms.RibbonPanel();
			this.modifyTab = new System.Windows.Forms.RibbonTab();
			this.editPanel = new System.Windows.Forms.RibbonPanel();
			this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
			this.annotateTab = new System.Windows.Forms.RibbonTab();
			this.textPanel = new System.Windows.Forms.RibbonPanel();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.coordinate = new System.Windows.Forms.ToolStripStatusLabel();
			this.vS = new System.Windows.Forms.VScrollBar();
			this.hS = new System.Windows.Forms.HScrollBar();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.arcBtn = new System.Windows.Forms.RibbonButton();
			this.arcBtn11 = new System.Windows.Forms.RibbonButton();
			this.arcBtn12 = new System.Windows.Forms.RibbonButton();
			this.arcBtn13 = new System.Windows.Forms.RibbonButton();
			this.arcBtn14 = new System.Windows.Forms.RibbonButton();
			this.arcBtn15 = new System.Windows.Forms.RibbonButton();
			this.arcBtn16 = new System.Windows.Forms.RibbonButton();
			this.arcBtn17 = new System.Windows.Forms.RibbonButton();
			this.arcBtn18 = new System.Windows.Forms.RibbonButton();
			this.arcBtn19 = new System.Windows.Forms.RibbonButton();
			this.arcBtn20 = new System.Windows.Forms.RibbonButton();
			this.circleBtn = new System.Windows.Forms.RibbonButton();
			this.circleBtn21 = new System.Windows.Forms.RibbonButton();
			this.circleBtn22 = new System.Windows.Forms.RibbonButton();
			this.circleBtn23 = new System.Windows.Forms.RibbonButton();
			this.circleBtn24 = new System.Windows.Forms.RibbonButton();
			this.ellipseBtn = new System.Windows.Forms.RibbonButton();
			this.ellipseBtn31 = new System.Windows.Forms.RibbonButton();
			this.ellipseBtn32 = new System.Windows.Forms.RibbonButton();
			this.lineBtn = new System.Windows.Forms.RibbonButton();
			this.polylineBtn = new System.Windows.Forms.RibbonButton();
			this.polygonBtn = new System.Windows.Forms.RibbonButton();
			this.pointBtn = new System.Windows.Forms.RibbonButton();
			this.rectangleBtn = new System.Windows.Forms.RibbonButton();
			this.zoomInBtn = new System.Windows.Forms.RibbonButton();
			this.zoomOutBtn = new System.Windows.Forms.RibbonButton();
			this.zoomWinBtn = new System.Windows.Forms.RibbonButton();
			this.copyBtn = new System.Windows.Forms.RibbonButton();
			this.moveBtn = new System.Windows.Forms.RibbonButton();
			this.rotateBtn = new System.Windows.Forms.RibbonButton();
			this.mirrorBtn = new System.Windows.Forms.RibbonButton();
			this.scaleBtn = new System.Windows.Forms.RibbonButton();
			this.lineararrayBtn = new System.Windows.Forms.RibbonButton();
			this.circulararrayBtn = new System.Windows.Forms.RibbonButton();
			this.deleteBtn = new System.Windows.Forms.RibbonButton();
			this.stextBtn = new System.Windows.Forms.RibbonButton();
			this.textStyleBtn = new System.Windows.Forms.RibbonButton();
			this.drawing = new System.Windows.Forms.PictureBox();
			this.popup.SuspendLayout();
			this.statusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.drawing)).BeginInit();
			this.SuspendLayout();
			// 
			// popup
			// 
			this.popup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelBtn,
            this.closeBoundary});
			this.popup.Name = "menuStrip";
			this.popup.Size = new System.Drawing.Size(111, 48);
			// 
			// cancelBtn
			// 
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(110, 22);
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// closeBoundary
			// 
			this.closeBoundary.Name = "closeBoundary";
			this.closeBoundary.Size = new System.Drawing.Size(110, 22);
			this.closeBoundary.Text = "Close";
			this.closeBoundary.Click += new System.EventHandler(this.closeBoundary_Click);
			// 
			// ribbon
			// 
			this.ribbon.CaptionBarVisible = false;
			this.ribbon.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.ribbon.Location = new System.Drawing.Point(0, 0);
			this.ribbon.Minimized = false;
			this.ribbon.Name = "ribbon";
			// 
			// 
			// 
			this.ribbon.OrbDropDown.BorderRoundness = 8;
			this.ribbon.OrbDropDown.Location = new System.Drawing.Point(0, 0);
			this.ribbon.OrbDropDown.Name = "";
			this.ribbon.OrbDropDown.TabIndex = 0;
			this.ribbon.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
			this.ribbon.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
			this.ribbon.Size = new System.Drawing.Size(1111, 135);
			this.ribbon.TabIndex = 10;
			this.ribbon.Tabs.Add(this.drawTab);
			this.ribbon.Tabs.Add(this.modifyTab);
			this.ribbon.Tabs.Add(this.annotateTab);
			this.ribbon.TabSpacing = 3;
			this.ribbon.Text = "ribbon1";
			// 
			// drawTab
			// 
			this.drawTab.Name = "drawTab";
			this.drawTab.Panels.Add(this.drawPanel);
			this.drawTab.Panels.Add(this.zoomPanel);
			this.drawTab.Text = "Drawing";
			// 
			// drawPanel
			// 
			this.drawPanel.ButtonMoreEnabled = false;
			this.drawPanel.ButtonMoreVisible = false;
			this.drawPanel.Items.Add(this.arcBtn);
			this.drawPanel.Items.Add(this.circleBtn);
			this.drawPanel.Items.Add(this.ellipseBtn);
			this.drawPanel.Items.Add(this.lineBtn);
			this.drawPanel.Items.Add(this.polylineBtn);
			this.drawPanel.Items.Add(this.polygonBtn);
			this.drawPanel.Items.Add(this.pointBtn);
			this.drawPanel.Items.Add(this.rectangleBtn);
			this.drawPanel.Name = "drawPanel";
			this.drawPanel.Text = "";
			// 
			// zoomPanel
			// 
			this.zoomPanel.ButtonMoreVisible = false;
			this.zoomPanel.Items.Add(this.zoomInBtn);
			this.zoomPanel.Items.Add(this.zoomOutBtn);
			this.zoomPanel.Items.Add(this.zoomWinBtn);
			this.zoomPanel.Name = "zoomPanel";
			this.zoomPanel.Text = "";
			// 
			// modifyTab
			// 
			this.modifyTab.Name = "modifyTab";
			this.modifyTab.Panels.Add(this.editPanel);
			this.modifyTab.Text = "Modify";
			// 
			// editPanel
			// 
			this.editPanel.ButtonMoreVisible = false;
			this.editPanel.Items.Add(this.copyBtn);
			this.editPanel.Items.Add(this.moveBtn);
			this.editPanel.Items.Add(this.rotateBtn);
			this.editPanel.Items.Add(this.mirrorBtn);
			this.editPanel.Items.Add(this.scaleBtn);
			this.editPanel.Items.Add(this.ribbonSeparator1);
			this.editPanel.Items.Add(this.lineararrayBtn);
			this.editPanel.Items.Add(this.circulararrayBtn);
			this.editPanel.Items.Add(this.deleteBtn);
			this.editPanel.Name = "editPanel";
			this.editPanel.Text = "";
			// 
			// ribbonSeparator1
			// 
			this.ribbonSeparator1.Name = "ribbonSeparator1";
			// 
			// annotateTab
			// 
			this.annotateTab.Name = "annotateTab";
			this.annotateTab.Panels.Add(this.textPanel);
			this.annotateTab.Text = "Annotate";
			// 
			// textPanel
			// 
			this.textPanel.ButtonMoreVisible = false;
			this.textPanel.Items.Add(this.stextBtn);
			this.textPanel.Items.Add(this.textStyleBtn);
			this.textPanel.Name = "textPanel";
			this.textPanel.Text = "";
			// 
			// statusStrip
			// 
			this.statusStrip.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.statusStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coordinate});
			this.statusStrip.Location = new System.Drawing.Point(0, 626);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(1111, 35);
			this.statusStrip.TabIndex = 11;
			this.statusStrip.Text = "statusStrip1";
			// 
			// coordinate
			// 
			this.coordinate.AutoSize = false;
			this.coordinate.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.coordinate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
			this.coordinate.Name = "coordinate";
			this.coordinate.Size = new System.Drawing.Size(250, 30);
			this.coordinate.Text = "0.000, 0.000, 0.000";
			// 
			// vS
			// 
			this.vS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.vS.Location = new System.Drawing.Point(1094, 135);
			this.vS.Name = "vS";
			this.vS.Size = new System.Drawing.Size(17, 471);
			this.vS.TabIndex = 12;
			this.vS.Visible = false;
			this.vS.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vS_Scroll);
			// 
			// hS
			// 
			this.hS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.hS.Location = new System.Drawing.Point(0, 609);
			this.hS.Name = "hS";
			this.hS.Size = new System.Drawing.Size(1091, 17);
			this.hS.TabIndex = 13;
			this.hS.Visible = false;
			this.hS.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hS_Scroll);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// arcBtn
			// 
			this.arcBtn.DropDownItems.Add(this.arcBtn11);
			this.arcBtn.DropDownItems.Add(this.arcBtn12);
			this.arcBtn.DropDownItems.Add(this.arcBtn13);
			this.arcBtn.DropDownItems.Add(this.arcBtn14);
			this.arcBtn.DropDownItems.Add(this.arcBtn15);
			this.arcBtn.DropDownItems.Add(this.arcBtn16);
			this.arcBtn.DropDownItems.Add(this.arcBtn17);
			this.arcBtn.DropDownItems.Add(this.arcBtn18);
			this.arcBtn.DropDownItems.Add(this.arcBtn19);
			this.arcBtn.DropDownItems.Add(this.arcBtn20);
			this.arcBtn.Image = global::MyCAD.Properties.Resources.ArcSetIcon;
			this.arcBtn.LargeImage = global::MyCAD.Properties.Resources.ArcSetIcon;
			this.arcBtn.Name = "arcBtn";
			this.arcBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBtn.SmallImage")));
			this.arcBtn.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
			this.arcBtn.Text = "Arc";
			// 
			// arcBtn11
			// 
			this.arcBtn11.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
			this.arcBtn11.Image = ((System.Drawing.Image)(resources.GetObject("arcBtn11.Image")));
			this.arcBtn11.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBtn11.LargeImage")));
			this.arcBtn11.Name = "arcBtn11";
			this.arcBtn11.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBtn11.SmallImage")));
			this.arcBtn11.Text = "3-Point";
			this.arcBtn11.Click += new System.EventHandler(this.ArcBtn_Click);
			// 
			// arcBtn12
			// 
			this.arcBtn12.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
			this.arcBtn12.Image = ((System.Drawing.Image)(resources.GetObject("arcBtn12.Image")));
			this.arcBtn12.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBtn12.LargeImage")));
			this.arcBtn12.Name = "arcBtn12";
			this.arcBtn12.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBtn12.SmallImage")));
			this.arcBtn12.Text = "Start, Center, End";
			this.arcBtn12.Click += new System.EventHandler(this.ArcBtn_Click);
			// 
			// arcBtn13
			// 
			this.arcBtn13.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
			this.arcBtn13.Image = ((System.Drawing.Image)(resources.GetObject("arcBtn13.Image")));
			this.arcBtn13.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBtn13.LargeImage")));
			this.arcBtn13.Name = "arcBtn13";
			this.arcBtn13.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBtn13.SmallImage")));
			this.arcBtn13.Text = "Start, Center, Angle";
			this.arcBtn13.Click += new System.EventHandler(this.ArcBtn_Click);
			// 
			// arcBtn14
			// 
			this.arcBtn14.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
			this.arcBtn14.Image = ((System.Drawing.Image)(resources.GetObject("arcBtn14.Image")));
			this.arcBtn14.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBtn14.LargeImage")));
			this.arcBtn14.Name = "arcBtn14";
			this.arcBtn14.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBtn14.SmallImage")));
			this.arcBtn14.Text = "Start, Center, Length";
			this.arcBtn14.Click += new System.EventHandler(this.ArcBtn_Click);
			// 
			// arcBtn15
			// 
			this.arcBtn15.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
			this.arcBtn15.Image = ((System.Drawing.Image)(resources.GetObject("arcBtn15.Image")));
			this.arcBtn15.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBtn15.LargeImage")));
			this.arcBtn15.Name = "arcBtn15";
			this.arcBtn15.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBtn15.SmallImage")));
			this.arcBtn15.Text = "Start, End, Angle";
			this.arcBtn15.Click += new System.EventHandler(this.ArcBtn_Click);
			// 
			// arcBtn16
			// 
			this.arcBtn16.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
			this.arcBtn16.Image = ((System.Drawing.Image)(resources.GetObject("arcBtn16.Image")));
			this.arcBtn16.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBtn16.LargeImage")));
			this.arcBtn16.Name = "arcBtn16";
			this.arcBtn16.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBtn16.SmallImage")));
			this.arcBtn16.Text = "Start, End, Direction";
			this.arcBtn16.Click += new System.EventHandler(this.ArcBtn_Click);
			// 
			// arcBtn17
			// 
			this.arcBtn17.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
			this.arcBtn17.Image = ((System.Drawing.Image)(resources.GetObject("arcBtn17.Image")));
			this.arcBtn17.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBtn17.LargeImage")));
			this.arcBtn17.Name = "arcBtn17";
			this.arcBtn17.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBtn17.SmallImage")));
			this.arcBtn17.Text = "Start, End, Radius";
			this.arcBtn17.Click += new System.EventHandler(this.ArcBtn_Click);
			// 
			// arcBtn18
			// 
			this.arcBtn18.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
			this.arcBtn18.Image = ((System.Drawing.Image)(resources.GetObject("arcBtn18.Image")));
			this.arcBtn18.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBtn18.LargeImage")));
			this.arcBtn18.Name = "arcBtn18";
			this.arcBtn18.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBtn18.SmallImage")));
			this.arcBtn18.Text = "Center, Start, End";
			this.arcBtn18.Click += new System.EventHandler(this.ArcBtn_Click);
			// 
			// arcBtn19
			// 
			this.arcBtn19.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
			this.arcBtn19.Image = ((System.Drawing.Image)(resources.GetObject("arcBtn19.Image")));
			this.arcBtn19.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBtn19.LargeImage")));
			this.arcBtn19.Name = "arcBtn19";
			this.arcBtn19.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBtn19.SmallImage")));
			this.arcBtn19.Text = "Center, Start, Angle";
			this.arcBtn19.Click += new System.EventHandler(this.ArcBtn_Click);
			// 
			// arcBtn20
			// 
			this.arcBtn20.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
			this.arcBtn20.Image = ((System.Drawing.Image)(resources.GetObject("arcBtn20.Image")));
			this.arcBtn20.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBtn20.LargeImage")));
			this.arcBtn20.Name = "arcBtn20";
			this.arcBtn20.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBtn20.SmallImage")));
			this.arcBtn20.Text = "Center, Start, Length";
			this.arcBtn20.Click += new System.EventHandler(this.ArcBtn_Click);
			// 
			// circleBtn
			// 
			this.circleBtn.DropDownItems.Add(this.circleBtn21);
			this.circleBtn.DropDownItems.Add(this.circleBtn22);
			this.circleBtn.DropDownItems.Add(this.circleBtn23);
			this.circleBtn.DropDownItems.Add(this.circleBtn24);
			this.circleBtn.Image = global::MyCAD.Properties.Resources.CircleSetIcon;
			this.circleBtn.LargeImage = global::MyCAD.Properties.Resources.CircleSetIcon;
			this.circleBtn.Name = "circleBtn";
			this.circleBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("circleBtn.SmallImage")));
			this.circleBtn.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
			this.circleBtn.Text = "Circle";
			// 
			// circleBtn21
			// 
			this.circleBtn21.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
			this.circleBtn21.Image = ((System.Drawing.Image)(resources.GetObject("circleBtn21.Image")));
			this.circleBtn21.LargeImage = ((System.Drawing.Image)(resources.GetObject("circleBtn21.LargeImage")));
			this.circleBtn21.Name = "circleBtn21";
			this.circleBtn21.SmallImage = ((System.Drawing.Image)(resources.GetObject("circleBtn21.SmallImage")));
			this.circleBtn21.Text = "Center, Radius";
			this.circleBtn21.Click += new System.EventHandler(this.CircleBtn_Click);
			// 
			// circleBtn22
			// 
			this.circleBtn22.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
			this.circleBtn22.Image = ((System.Drawing.Image)(resources.GetObject("circleBtn22.Image")));
			this.circleBtn22.LargeImage = ((System.Drawing.Image)(resources.GetObject("circleBtn22.LargeImage")));
			this.circleBtn22.Name = "circleBtn22";
			this.circleBtn22.SmallImage = ((System.Drawing.Image)(resources.GetObject("circleBtn22.SmallImage")));
			this.circleBtn22.Text = "Center, Diameter";
			this.circleBtn22.Click += new System.EventHandler(this.CircleBtn_Click);
			// 
			// circleBtn23
			// 
			this.circleBtn23.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
			this.circleBtn23.Image = ((System.Drawing.Image)(resources.GetObject("circleBtn23.Image")));
			this.circleBtn23.LargeImage = ((System.Drawing.Image)(resources.GetObject("circleBtn23.LargeImage")));
			this.circleBtn23.Name = "circleBtn23";
			this.circleBtn23.SmallImage = ((System.Drawing.Image)(resources.GetObject("circleBtn23.SmallImage")));
			this.circleBtn23.Text = "3-Points";
			this.circleBtn23.Click += new System.EventHandler(this.CircleBtn_Click);
			// 
			// circleBtn24
			// 
			this.circleBtn24.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
			this.circleBtn24.Image = ((System.Drawing.Image)(resources.GetObject("circleBtn24.Image")));
			this.circleBtn24.LargeImage = ((System.Drawing.Image)(resources.GetObject("circleBtn24.LargeImage")));
			this.circleBtn24.Name = "circleBtn24";
			this.circleBtn24.SmallImage = ((System.Drawing.Image)(resources.GetObject("circleBtn24.SmallImage")));
			this.circleBtn24.Text = "2-Points";
			this.circleBtn24.Click += new System.EventHandler(this.CircleBtn_Click);
			// 
			// ellipseBtn
			// 
			this.ellipseBtn.DropDownItems.Add(this.ellipseBtn31);
			this.ellipseBtn.DropDownItems.Add(this.ellipseBtn32);
			this.ellipseBtn.Image = global::MyCAD.Properties.Resources.EllipseSetIcon;
			this.ellipseBtn.LargeImage = global::MyCAD.Properties.Resources.EllipseSetIcon;
			this.ellipseBtn.Name = "ellipseBtn";
			this.ellipseBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("ellipseBtn.SmallImage")));
			this.ellipseBtn.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
			this.ellipseBtn.Text = "Ellipse";
			// 
			// ellipseBtn31
			// 
			this.ellipseBtn31.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
			this.ellipseBtn31.Image = ((System.Drawing.Image)(resources.GetObject("ellipseBtn31.Image")));
			this.ellipseBtn31.LargeImage = ((System.Drawing.Image)(resources.GetObject("ellipseBtn31.LargeImage")));
			this.ellipseBtn31.Name = "ellipseBtn31";
			this.ellipseBtn31.SmallImage = ((System.Drawing.Image)(resources.GetObject("ellipseBtn31.SmallImage")));
			this.ellipseBtn31.Text = "Full Ellipse";
			this.ellipseBtn31.Click += new System.EventHandler(this.EllipseBtn_Click);
			// 
			// ellipseBtn32
			// 
			this.ellipseBtn32.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
			this.ellipseBtn32.Image = ((System.Drawing.Image)(resources.GetObject("ellipseBtn32.Image")));
			this.ellipseBtn32.LargeImage = ((System.Drawing.Image)(resources.GetObject("ellipseBtn32.LargeImage")));
			this.ellipseBtn32.Name = "ellipseBtn32";
			this.ellipseBtn32.SmallImage = ((System.Drawing.Image)(resources.GetObject("ellipseBtn32.SmallImage")));
			this.ellipseBtn32.Text = "Elliptical Arc";
			this.ellipseBtn32.Click += new System.EventHandler(this.EllipseBtn_Click);
			// 
			// lineBtn
			// 
			this.lineBtn.Image = global::MyCAD.Properties.Resources.LineSetIcon;
			this.lineBtn.LargeImage = global::MyCAD.Properties.Resources.LineSetIcon;
			this.lineBtn.Name = "lineBtn";
			this.lineBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("lineBtn.SmallImage")));
			this.lineBtn.Text = "Line";
			this.lineBtn.Click += new System.EventHandler(this.DrawBtn_Click);
			// 
			// polylineBtn
			// 
			this.polylineBtn.Image = global::MyCAD.Properties.Resources.PolylineIcon;
			this.polylineBtn.LargeImage = global::MyCAD.Properties.Resources.PolylineIcon;
			this.polylineBtn.Name = "polylineBtn";
			this.polylineBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("polylineBtn.SmallImage")));
			this.polylineBtn.Text = "Polyline";
			this.polylineBtn.Click += new System.EventHandler(this.DrawBtn_Click);
			// 
			// polygonBtn
			// 
			this.polygonBtn.Image = global::MyCAD.Properties.Resources.PolygonSetIcon;
			this.polygonBtn.LargeImage = global::MyCAD.Properties.Resources.PolygonSetIcon;
			this.polygonBtn.Name = "polygonBtn";
			this.polygonBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("polygonBtn.SmallImage")));
			this.polygonBtn.Text = "Polygon";
			this.polygonBtn.Click += new System.EventHandler(this.DrawBtn_Click);
			// 
			// pointBtn
			// 
			this.pointBtn.Image = global::MyCAD.Properties.Resources.PointIcon;
			this.pointBtn.LargeImage = global::MyCAD.Properties.Resources.PointIcon;
			this.pointBtn.Name = "pointBtn";
			this.pointBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("pointBtn.SmallImage")));
			this.pointBtn.Text = "Point";
			this.pointBtn.Click += new System.EventHandler(this.DrawBtn_Click);
			// 
			// rectangleBtn
			// 
			this.rectangleBtn.Image = global::MyCAD.Properties.Resources.RectSetIcon;
			this.rectangleBtn.LargeImage = global::MyCAD.Properties.Resources.RectSetIcon;
			this.rectangleBtn.Name = "rectangleBtn";
			this.rectangleBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("rectangleBtn.SmallImage")));
			this.rectangleBtn.Text = "Rectangle";
			this.rectangleBtn.Click += new System.EventHandler(this.DrawBtn_Click);
			// 
			// zoomInBtn
			// 
			this.zoomInBtn.Image = global::MyCAD.Properties.Resources.ZoomIn1;
			this.zoomInBtn.LargeImage = global::MyCAD.Properties.Resources.ZoomIn1;
			this.zoomInBtn.Name = "zoomInBtn";
			this.zoomInBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("zoomInBtn.SmallImage")));
			this.zoomInBtn.Text = "Zoom In";
			this.zoomInBtn.Click += new System.EventHandler(this.ZoomBtn_Click);
			// 
			// zoomOutBtn
			// 
			this.zoomOutBtn.Image = global::MyCAD.Properties.Resources.ZoomOut;
			this.zoomOutBtn.LargeImage = global::MyCAD.Properties.Resources.ZoomOut;
			this.zoomOutBtn.Name = "zoomOutBtn";
			this.zoomOutBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("zoomOutBtn.SmallImage")));
			this.zoomOutBtn.Text = "Zoom Out";
			this.zoomOutBtn.Click += new System.EventHandler(this.ZoomBtn_Click);
			// 
			// zoomWinBtn
			// 
			this.zoomWinBtn.Image = ((System.Drawing.Image)(resources.GetObject("zoomWinBtn.Image")));
			this.zoomWinBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("zoomWinBtn.LargeImage")));
			this.zoomWinBtn.Name = "zoomWinBtn";
			this.zoomWinBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("zoomWinBtn.SmallImage")));
			this.zoomWinBtn.Text = "Zoom Win";
			this.zoomWinBtn.Click += new System.EventHandler(this.ZoomBtn_Click);
			// 
			// copyBtn
			// 
			this.copyBtn.Image = global::MyCAD.Properties.Resources.CopyIcon;
			this.copyBtn.LargeImage = global::MyCAD.Properties.Resources.CopyIcon;
			this.copyBtn.Name = "copyBtn";
			this.copyBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("copyBtn.SmallImage")));
			this.copyBtn.Text = "Copy";
			this.copyBtn.Click += new System.EventHandler(this.ModifyBtn_Click);
			// 
			// moveBtn
			// 
			this.moveBtn.Image = global::MyCAD.Properties.Resources.MoveIcon;
			this.moveBtn.LargeImage = global::MyCAD.Properties.Resources.MoveIcon;
			this.moveBtn.Name = "moveBtn";
			this.moveBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("moveBtn.SmallImage")));
			this.moveBtn.Text = "Move";
			this.moveBtn.Click += new System.EventHandler(this.ModifyBtn_Click);
			// 
			// rotateBtn
			// 
			this.rotateBtn.Image = global::MyCAD.Properties.Resources.RotateIcon;
			this.rotateBtn.LargeImage = global::MyCAD.Properties.Resources.RotateIcon;
			this.rotateBtn.Name = "rotateBtn";
			this.rotateBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("rotateBtn.SmallImage")));
			this.rotateBtn.Text = "Rotate";
			this.rotateBtn.Click += new System.EventHandler(this.ModifyBtn_Click);
			// 
			// mirrorBtn
			// 
			this.mirrorBtn.Image = global::MyCAD.Properties.Resources.MirrorIcon;
			this.mirrorBtn.LargeImage = global::MyCAD.Properties.Resources.MirrorIcon;
			this.mirrorBtn.Name = "mirrorBtn";
			this.mirrorBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("mirrorBtn.SmallImage")));
			this.mirrorBtn.Text = "Mirror";
			this.mirrorBtn.Click += new System.EventHandler(this.ModifyBtn_Click);
			// 
			// scaleBtn
			// 
			this.scaleBtn.Image = global::MyCAD.Properties.Resources.ScaleIcon;
			this.scaleBtn.LargeImage = global::MyCAD.Properties.Resources.ScaleIcon;
			this.scaleBtn.Name = "scaleBtn";
			this.scaleBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("scaleBtn.SmallImage")));
			this.scaleBtn.Text = "Scale";
			this.scaleBtn.Click += new System.EventHandler(this.ModifyBtn_Click);
			// 
			// lineararrayBtn
			// 
			this.lineararrayBtn.Image = global::MyCAD.Properties.Resources.ArrayIcon;
			this.lineararrayBtn.LargeImage = global::MyCAD.Properties.Resources.ArrayIcon;
			this.lineararrayBtn.Name = "lineararrayBtn";
			this.lineararrayBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("lineararrayBtn.SmallImage")));
			this.lineararrayBtn.Text = "Linear";
			this.lineararrayBtn.Click += new System.EventHandler(this.ModifyBtn_Click);
			// 
			// circulararrayBtn
			// 
			this.circulararrayBtn.Image = global::MyCAD.Properties.Resources.ArrayCircularIcon;
			this.circulararrayBtn.LargeImage = global::MyCAD.Properties.Resources.ArrayCircularIcon;
			this.circulararrayBtn.Name = "circulararrayBtn";
			this.circulararrayBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("circulararrayBtn.SmallImage")));
			this.circulararrayBtn.Text = "Circular";
			this.circulararrayBtn.Click += new System.EventHandler(this.ModifyBtn_Click);
			// 
			// deleteBtn
			// 
			this.deleteBtn.Image = global::MyCAD.Properties.Resources.DeleteIcon;
			this.deleteBtn.LargeImage = global::MyCAD.Properties.Resources.DeleteIcon;
			this.deleteBtn.Name = "deleteBtn";
			this.deleteBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("deleteBtn.SmallImage")));
			this.deleteBtn.Text = "Delete";
			this.deleteBtn.Click += new System.EventHandler(this.ModifyBtn_Click);
			// 
			// stextBtn
			// 
			this.stextBtn.Image = global::MyCAD.Properties.Resources.AnnotationTextIcon;
			this.stextBtn.LargeImage = global::MyCAD.Properties.Resources.AnnotationTextIcon;
			this.stextBtn.Name = "stextBtn";
			this.stextBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("stextBtn.SmallImage")));
			this.stextBtn.Text = "Single Text";
			this.stextBtn.Click += new System.EventHandler(this.annotate_Click);
			// 
			// textStyleBtn
			// 
			this.textStyleBtn.Image = global::MyCAD.Properties.Resources.TextStyle;
			this.textStyleBtn.LargeImage = global::MyCAD.Properties.Resources.TextStyle;
			this.textStyleBtn.Name = "textStyleBtn";
			this.textStyleBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("textStyleBtn.SmallImage")));
			this.textStyleBtn.Text = "Text style";
			this.textStyleBtn.Click += new System.EventHandler(this.annotate_Click);
			// 
			// drawing
			// 
			this.drawing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.drawing.BackColor = System.Drawing.SystemColors.Window;
			this.drawing.ContextMenuStrip = this.popup;
			this.drawing.Location = new System.Drawing.Point(0, 135);
			this.drawing.Name = "drawing";
			this.drawing.Size = new System.Drawing.Size(1091, 471);
			this.drawing.TabIndex = 0;
			this.drawing.TabStop = false;
			this.drawing.Paint += new System.Windows.Forms.PaintEventHandler(this.drawing_Paint);
			this.drawing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawing_MouseDown);
			this.drawing.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawing_MouseMove);
			this.drawing.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawing_MouseUp);
			this.drawing.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.drawing_MouseWheel);
			// 
			// GraphicsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1111, 661);
			this.Controls.Add(this.hS);
			this.Controls.Add(this.vS);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.ribbon);
			this.Controls.Add(this.drawing);
			this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "GraphicsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MyCAD";
			this.Load += new System.EventHandler(this.GraphicsForm_Load);
			this.popup.ResumeLayout(false);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.drawing)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox drawing;
		private System.Windows.Forms.ContextMenuStrip popup;
		private System.Windows.Forms.ToolStripMenuItem cancelBtn;
		private System.Windows.Forms.Ribbon ribbon;
		private System.Windows.Forms.RibbonTab drawTab;
		private System.Windows.Forms.RibbonPanel drawPanel;
		private System.Windows.Forms.RibbonButton arcBtn;
		private System.Windows.Forms.RibbonButton arcBtn11;
		private System.Windows.Forms.RibbonButton circleBtn;
		private System.Windows.Forms.RibbonButton circleBtn21;
		private System.Windows.Forms.RibbonButton circleBtn22;
		private System.Windows.Forms.RibbonButton ellipseBtn;
		private System.Windows.Forms.RibbonButton lineBtn;
		private System.Windows.Forms.RibbonButton polylineBtn;
		private System.Windows.Forms.RibbonButton polygonBtn;
		private System.Windows.Forms.RibbonButton pointBtn;
		private System.Windows.Forms.RibbonButton rectangleBtn;
        private System.Windows.Forms.RibbonButton ellipseBtn31;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel coordinate;
        private System.Windows.Forms.VScrollBar vS;
        private System.Windows.Forms.HScrollBar hS;
        private System.Windows.Forms.ToolStripMenuItem closeBoundary;
        private System.Windows.Forms.RibbonButton arcBtn12;
        private System.Windows.Forms.RibbonButton arcBtn13;
        private System.Windows.Forms.RibbonButton arcBtn14;
        private System.Windows.Forms.RibbonButton arcBtn15;
        private System.Windows.Forms.RibbonButton arcBtn16;
        private System.Windows.Forms.RibbonButton arcBtn17;
        private System.Windows.Forms.RibbonButton circleBtn23;
        private System.Windows.Forms.RibbonButton circleBtn24;
        private System.Windows.Forms.RibbonButton ellipseBtn32;
        private System.Windows.Forms.RibbonPanel zoomPanel;
        private System.Windows.Forms.RibbonButton zoomInBtn;
        private System.Windows.Forms.RibbonButton zoomOutBtn;
        private System.Windows.Forms.RibbonButton zoomWinBtn;
        private System.Windows.Forms.RibbonTab modifyTab;
        private System.Windows.Forms.RibbonPanel editPanel;
        private System.Windows.Forms.RibbonButton copyBtn;
        private System.Windows.Forms.RibbonButton moveBtn;
        private System.Windows.Forms.RibbonButton rotateBtn;
		private System.Windows.Forms.RibbonButton mirrorBtn;
		private System.Windows.Forms.RibbonButton scaleBtn;
		private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
		private System.Windows.Forms.RibbonButton lineararrayBtn;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.RibbonButton circulararrayBtn;
		private System.Windows.Forms.RibbonButton arcBtn18;
		private System.Windows.Forms.RibbonButton arcBtn19;
		private System.Windows.Forms.RibbonButton arcBtn20;
		private System.Windows.Forms.RibbonTab annotateTab;
		private System.Windows.Forms.RibbonPanel textPanel;
		private System.Windows.Forms.RibbonButton stextBtn;
		private System.Windows.Forms.RibbonButton deleteBtn;
		private System.Windows.Forms.RibbonButton textStyleBtn;
	}
}

