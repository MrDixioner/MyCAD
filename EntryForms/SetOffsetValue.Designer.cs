namespace MyCAD.EntryForms {
	partial class SetOffsetValue {
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
			this.offset = new MyCAD.Components.MyTextBox();
			this.acceptBtn = new System.Windows.Forms.Button();
			this.multiple = new MyCAD.Components.MyCheckBox();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 19);
			this.label1.TabIndex = 4;
			this.label1.Text = "Value:";
			// 
			// offset
			// 
			this.offset.EnterAsTab = true;
			this.offset.Location = new System.Drawing.Point(64, 12);
			this.offset.Name = "offset";
			this.offset.Size = new System.Drawing.Size(153, 27);
			this.offset.TabIndex = 0;
			this.offset.Type = MyCAD.Components.DataType.Decimal;
			// 
			// acceptBtn
			// 
			this.acceptBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.acceptBtn.Location = new System.Drawing.Point(11, 94);
			this.acceptBtn.Name = "acceptBtn";
			this.acceptBtn.Size = new System.Drawing.Size(100, 35);
			this.acceptBtn.TabIndex = 2;
			this.acceptBtn.Text = "Accept";
			this.acceptBtn.UseVisualStyleBackColor = true;
			this.acceptBtn.Click += new System.EventHandler(this.acceptBtn_Click);
			// 
			// multiple
			// 
			this.multiple.AutoSize = true;
			this.multiple.EnterAsTab = false;
			this.multiple.Location = new System.Drawing.Point(16, 55);
			this.multiple.Name = "multiple";
			this.multiple.Size = new System.Drawing.Size(82, 23);
			this.multiple.TabIndex = 1;
			this.multiple.Text = "Multiple";
			this.multiple.UseVisualStyleBackColor = true;
			// 
			// cancelBtn
			// 
			this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn.Location = new System.Drawing.Point(117, 94);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(100, 35);
			this.cancelBtn.TabIndex = 3;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// SetOffsetValue
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(229, 141);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.multiple);
			this.Controls.Add(this.acceptBtn);
			this.Controls.Add(this.offset);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SetOffsetValue";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Set Offset";
			this.Load += new System.EventHandler(this.SetOffsetValue_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private Components.MyTextBox offset;
		private System.Windows.Forms.Button acceptBtn;
		private Components.MyCheckBox multiple;
		private System.Windows.Forms.Button cancelBtn;
	}
}