namespace MyCAD.EntryForms {
	partial class InputCircularArray {
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
			this.txtItems = new System.Windows.Forms.TextBox();
			this.isRotatedItems = new System.Windows.Forms.CheckBox();
			this.acceptBtn = new System.Windows.Forms.Button();
			this.txtFillAngle = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(121, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "Number of Items:";
			// 
			// txtItems
			// 
			this.txtItems.Location = new System.Drawing.Point(137, 13);
			this.txtItems.Name = "txtItems";
			this.txtItems.Size = new System.Drawing.Size(56, 27);
			this.txtItems.TabIndex = 1;
			this.txtItems.Text = "3";
			this.txtItems.TextChanged += new System.EventHandler(this.TextBox_TextChange);
			// 
			// isRotatedItems
			// 
			this.isRotatedItems.AutoSize = true;
			this.isRotatedItems.Location = new System.Drawing.Point(18, 91);
			this.isRotatedItems.Name = "isRotatedItems";
			this.isRotatedItems.Size = new System.Drawing.Size(119, 23);
			this.isRotatedItems.TabIndex = 2;
			this.isRotatedItems.Text = "Rotated items";
			this.isRotatedItems.UseVisualStyleBackColor = true;
			this.isRotatedItems.CheckedChanged += new System.EventHandler(this.TextBox_TextChange);
			// 
			// acceptBtn
			// 
			this.acceptBtn.Location = new System.Drawing.Point(18, 120);
			this.acceptBtn.Name = "acceptBtn";
			this.acceptBtn.Size = new System.Drawing.Size(100, 35);
			this.acceptBtn.TabIndex = 3;
			this.acceptBtn.Text = "Accept";
			this.acceptBtn.UseVisualStyleBackColor = true;
			this.acceptBtn.Click += new System.EventHandler(this.acceptBtn_Click);
			// 
			// txtFillAngle
			// 
			this.txtFillAngle.Location = new System.Drawing.Point(137, 48);
			this.txtFillAngle.Name = "txtFillAngle";
			this.txtFillAngle.Size = new System.Drawing.Size(56, 27);
			this.txtFillAngle.TabIndex = 5;
			this.txtFillAngle.Text = "360";
			this.txtFillAngle.TextChanged += new System.EventHandler(this.TextBox_TextChange);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 19);
			this.label2.TabIndex = 4;
			this.label2.Text = "Fill angle:";
			// 
			// cancelBtn
			// 
			this.cancelBtn.Location = new System.Drawing.Point(137, 120);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(100, 35);
			this.cancelBtn.TabIndex = 6;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// InputCircularArray
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(255, 171);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.txtFillAngle);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.acceptBtn);
			this.Controls.Add(this.isRotatedItems);
			this.Controls.Add(this.txtItems);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InputCircularArray";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "InputCircularArray";
			this.Load += new System.EventHandler(this.InputCircularArray_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtItems;
		private System.Windows.Forms.CheckBox isRotatedItems;
		private System.Windows.Forms.Button acceptBtn;
		private System.Windows.Forms.TextBox txtFillAngle;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button cancelBtn;
	}
}