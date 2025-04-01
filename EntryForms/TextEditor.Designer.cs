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
			this.text = new System.Windows.Forms.TextBox();
			this.alignment = new System.Windows.Forms.ComboBox();
			this.acceptBtn = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.height = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.rotation = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.textStyle = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "Input Text:";
			// 
			// text
			// 
			this.text.Location = new System.Drawing.Point(7, 38);
			this.text.Name = "text";
			this.text.Size = new System.Drawing.Size(301, 27);
			this.text.TabIndex = 0;
			this.text.TextChanged += new System.EventHandler(this.Input_TextChange);
			// 
			// alignment
			// 
			this.alignment.FormattingEnabled = true;
			this.alignment.Location = new System.Drawing.Point(187, 164);
			this.alignment.Name = "alignment";
			this.alignment.Size = new System.Drawing.Size(121, 27);
			this.alignment.TabIndex = 4;
			this.alignment.SelectedIndexChanged += new System.EventHandler(this.Input_TextChange);
			// 
			// acceptBtn
			// 
			this.acceptBtn.Location = new System.Drawing.Point(101, 209);
			this.acceptBtn.Name = "acceptBtn";
			this.acceptBtn.Size = new System.Drawing.Size(100, 35);
			this.acceptBtn.TabIndex = 5;
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
			this.label2.TabIndex = 4;
			this.label2.Text = "Text style:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(187, 143);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(79, 19);
			this.label3.TabIndex = 6;
			this.label3.Text = "Alignment:";
			// 
			// height
			// 
			this.height.Location = new System.Drawing.Point(7, 164);
			this.height.Name = "height";
			this.height.Size = new System.Drawing.Size(77, 27);
			this.height.TabIndex = 2;
			this.height.Text = "30";
			this.height.TextChanged += new System.EventHandler(this.Input_TextChange);
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
			// rotation
			// 
			this.rotation.Location = new System.Drawing.Point(94, 164);
			this.rotation.Name = "rotation";
			this.rotation.Size = new System.Drawing.Size(83, 27);
			this.rotation.TabIndex = 3;
			this.rotation.Text = "0";
			this.rotation.TextChanged += new System.EventHandler(this.Input_TextChange);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(94, 142);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 19);
			this.label5.TabIndex = 9;
			this.label5.Text = "Rotation";
			// 
			// cancelBtn
			// 
			this.cancelBtn.Location = new System.Drawing.Point(207, 209);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(100, 35);
			this.cancelBtn.TabIndex = 6;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// textStyle
			// 
			this.textStyle.FormattingEnabled = true;
			this.textStyle.Location = new System.Drawing.Point(11, 103);
			this.textStyle.Name = "textStyle";
			this.textStyle.Size = new System.Drawing.Size(297, 27);
			this.textStyle.TabIndex = 10;
			this.textStyle.SelectedIndexChanged += new System.EventHandler(this.textStyle_SelectedIndexChanged);
			// 
			// TextEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(315, 254);
			this.Controls.Add(this.textStyle);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.rotation);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.height);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.acceptBtn);
			this.Controls.Add(this.alignment);
			this.Controls.Add(this.text);
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
		private System.Windows.Forms.TextBox text;
		private System.Windows.Forms.ComboBox alignment;
		private System.Windows.Forms.Button acceptBtn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox height;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox rotation;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.ComboBox textStyle;
	}
}