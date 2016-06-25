namespace archSmarter
{
	//
	// Created by SharpDevelop.
	// User: michael
	// Date: 5/5/2015
	// Time: 3:14 PM
	// 
	// To change this template use Tools | Options | Coding | Edit Standard Headers.
	//
	partial class frmSelectFonts : System.Windows.Forms.Form
	{

		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.cmbReplaceFont = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbNewFont = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			//
			//cmbReplaceFont
			//
			this.cmbReplaceFont.FormattingEnabled = true;
			this.cmbReplaceFont.Location = new System.Drawing.Point(135, 6);
			this.cmbReplaceFont.Name = "cmbReplaceFont";
			this.cmbReplaceFont.Size = new System.Drawing.Size(286, 21);
			this.cmbReplaceFont.TabIndex = 0;
			//
			//label1
			//
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(117, 22);
			this.label1.TabIndex = 1;
			this.label1.Text = "Select font to replace:";
			this.label1.UseCompatibleTextRendering = true;
			//
			//cmbNewFont
			//
			this.cmbNewFont.FormattingEnabled = true;
			this.cmbNewFont.Location = new System.Drawing.Point(135, 33);
			this.cmbNewFont.Name = "cmbNewFont";
			this.cmbNewFont.Size = new System.Drawing.Size(286, 21);
			this.cmbNewFont.TabIndex = 2;
			//
			//label2
			//
			this.label2.Location = new System.Drawing.Point(12, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(117, 22);
			this.label2.TabIndex = 3;
			this.label2.Text = "Select new font:";
			this.label2.UseCompatibleTextRendering = true;
			//
			//button1
			//
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(346, 60);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "OK";
			this.button1.UseCompatibleTextRendering = true;
			this.button1.UseVisualStyleBackColor = true;
			//
			//button2
			//
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(265, 60);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 5;
			this.button2.Text = "Cancel";
			this.button2.UseCompatibleTextRendering = true;
			this.button2.UseVisualStyleBackColor = true;
			//
			//frmSelectFonts
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(434, 91);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cmbNewFont);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbReplaceFont);
			this.Name = "frmSelectFonts";
			this.Text = "Replace Font";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbNewFont;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbReplaceFont;
	}
}
