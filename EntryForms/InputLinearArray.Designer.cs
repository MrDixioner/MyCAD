namespace MyCAD.EntryForms {
	partial class InputLinearArray {
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
			this.horizontalQty = new System.Windows.Forms.TextBox();
			this.direction = new System.Windows.Forms.ComboBox();
			this.acceptBtn = new System.Windows.Forms.Button();
			this.verticalQty = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.horizontalDist = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.verticalDist = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 19);
			this.label1.TabIndex = 9;
			this.label1.Text = "Horizontal:";
			// 
			// horizontalQty
			// 
			this.horizontalQty.Location = new System.Drawing.Point(89, 33);
			this.horizontalQty.Name = "horizontalQty";
			this.horizontalQty.Size = new System.Drawing.Size(121, 27);
			this.horizontalQty.TabIndex = 0;
			this.horizontalQty.Text = "0";
			this.horizontalQty.TextChanged += new System.EventHandler(this.InputBox_TextChange);
			// 
			// direction
			// 
			this.direction.FormattingEnabled = true;
			this.direction.Items.AddRange(new object[] {
            "Right-Bottom",
            "Right-Top",
            "Left-Bottom",
            "Left-Top"});
			this.direction.Location = new System.Drawing.Point(89, 99);
			this.direction.Name = "direction";
			this.direction.Size = new System.Drawing.Size(121, 27);
			this.direction.TabIndex = 4;
			this.direction.SelectedIndexChanged += new System.EventHandler(this.InputBox_TextChange);
			// 
			// acceptBtn
			// 
			this.acceptBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.acceptBtn.Location = new System.Drawing.Point(135, 137);
			this.acceptBtn.Name = "acceptBtn";
			this.acceptBtn.Size = new System.Drawing.Size(100, 35);
			this.acceptBtn.TabIndex = 5;
			this.acceptBtn.Text = "Accept";
			this.acceptBtn.UseVisualStyleBackColor = true;
			this.acceptBtn.Click += new System.EventHandler(this.acceptBtn_Click);
			// 
			// verticalQty
			// 
			this.verticalQty.Location = new System.Drawing.Point(89, 66);
			this.verticalQty.Name = "verticalQty";
			this.verticalQty.Size = new System.Drawing.Size(121, 27);
			this.verticalQty.TabIndex = 2;
			this.verticalQty.Text = "0";
			this.verticalQty.TextChanged += new System.EventHandler(this.InputBox_TextChange);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 19);
			this.label2.TabIndex = 10;
			this.label2.Text = "Vertical:";
			// 
			// horizontalDist
			// 
			this.horizontalDist.Location = new System.Drawing.Point(239, 33);
			this.horizontalDist.Name = "horizontalDist";
			this.horizontalDist.Size = new System.Drawing.Size(100, 27);
			this.horizontalDist.TabIndex = 1;
			this.horizontalDist.Text = "0";
			this.horizontalDist.TextChanged += new System.EventHandler(this.InputBox_TextChange);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(87, 11);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(115, 19);
			this.label3.TabIndex = 7;
			this.label3.Text = "Number of Array";
			// 
			// verticalDist
			// 
			this.verticalDist.Location = new System.Drawing.Point(239, 66);
			this.verticalDist.Name = "verticalDist";
			this.verticalDist.Size = new System.Drawing.Size(100, 27);
			this.verticalDist.TabIndex = 3;
			this.verticalDist.Text = "0";
			this.verticalDist.TextChanged += new System.EventHandler(this.InputBox_TextChange);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(236, 11);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(121, 19);
			this.label4.TabIndex = 8;
			this.label4.Text = "Distance of Array";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(11, 103);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 19);
			this.label5.TabIndex = 11;
			this.label5.Text = "Direction";
			// 
			// cancelBtn
			// 
			this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn.Location = new System.Drawing.Point(253, 137);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(100, 35);
			this.cancelBtn.TabIndex = 6;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// InputLinearArray
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(367, 184);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.verticalDist);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.horizontalDist);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.verticalQty);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.acceptBtn);
			this.Controls.Add(this.direction);
			this.Controls.Add(this.horizontalQty);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "InputLinearArray";
			this.Text = "InputLinearArray";
			this.Load += new System.EventHandler(this.InputLinearArray_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox horizontalQty;
		private System.Windows.Forms.ComboBox direction;
		private System.Windows.Forms.Button acceptBtn;
		private System.Windows.Forms.TextBox verticalQty;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox horizontalDist;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox verticalDist;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button cancelBtn;
	}
}