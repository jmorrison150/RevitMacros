namespace ArchSmarter
{
	//
	// Created by SharpDevelop.
	// User: michael
	// Date: 9/17/2014
	// Time: 11:23 AM
	// 
	// To change this template use Tools | Options | Coding | Edit Standard Headers.
	//
	partial class frmWallsFromLines : System.Windows.Forms.Form
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnProcess = new System.Windows.Forms.Button();
			this.cmbLineStyle = new System.Windows.Forms.ComboBox();
			this.cmbWallType = new System.Windows.Forms.ComboBox();
			this.cmbLevel = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbUnits = new System.Windows.Forms.ComboBox();
			this.tbxHeight = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			//
			//label1
			//
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(151, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Select Line Style";
			this.label1.UseCompatibleTextRendering = true;
			//
			//label2
			//
			this.label2.Location = new System.Drawing.Point(12, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Select Base Level:";
			this.label2.UseCompatibleTextRendering = true;
			//
			//label3
			//
			this.label3.Location = new System.Drawing.Point(12, 63);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Select Wall Type:";
			this.label3.UseCompatibleTextRendering = true;
			//
			//btnCancel
			//
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(326, 113);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(85, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseCompatibleTextRendering = true;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += this.BtnCancelClick;
			//
			//btnProcess
			//
			this.btnProcess.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnProcess.Location = new System.Drawing.Point(235, 113);
			this.btnProcess.Name = "btnProcess";
			this.btnProcess.Size = new System.Drawing.Size(85, 23);
			this.btnProcess.TabIndex = 4;
			this.btnProcess.Text = "Create Walls";
			this.btnProcess.UseCompatibleTextRendering = true;
			this.btnProcess.UseVisualStyleBackColor = true;
			this.btnProcess.Click += this.BtnProcessClick;
			//
			//cmbLineStyle
			//
			this.cmbLineStyle.FormattingEnabled = true;
			this.cmbLineStyle.Location = new System.Drawing.Point(185, 6);
			this.cmbLineStyle.Name = "cmbLineStyle";
			this.cmbLineStyle.Size = new System.Drawing.Size(226, 21);
			this.cmbLineStyle.TabIndex = 5;
			//
			//cmbWallType
			//
			this.cmbWallType.FormattingEnabled = true;
			this.cmbWallType.Location = new System.Drawing.Point(185, 60);
			this.cmbWallType.Name = "cmbWallType";
			this.cmbWallType.Size = new System.Drawing.Size(226, 21);
			this.cmbWallType.TabIndex = 6;
			//
			//cmbLevel
			//
			this.cmbLevel.FormattingEnabled = true;
			this.cmbLevel.Location = new System.Drawing.Point(185, 33);
			this.cmbLevel.Name = "cmbLevel";
			this.cmbLevel.Size = new System.Drawing.Size(226, 21);
			this.cmbLevel.TabIndex = 7;
			//
			//label4
			//
			this.label4.Location = new System.Drawing.Point(12, 90);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(111, 23);
			this.label4.TabIndex = 8;
			this.label4.Text = "Enter Wall Height:";
			this.label4.UseCompatibleTextRendering = true;
			//
			//cmbUnits
			//
			this.cmbUnits.FormattingEnabled = true;
			this.cmbUnits.Location = new System.Drawing.Point(266, 86);
			this.cmbUnits.Name = "cmbUnits";
			this.cmbUnits.Size = new System.Drawing.Size(54, 21);
			this.cmbUnits.TabIndex = 9;
			//
			//tbxHeight
			//
			this.tbxHeight.Location = new System.Drawing.Point(185, 87);
			this.tbxHeight.Name = "tbxHeight";
			this.tbxHeight.Size = new System.Drawing.Size(75, 20);
			this.tbxHeight.TabIndex = 10;
			this.tbxHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			//frmWallsFromLines
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(423, 142);
			this.Controls.Add(this.tbxHeight);
			this.Controls.Add(this.cmbUnits);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cmbLevel);
			this.Controls.Add(this.cmbWallType);
			this.Controls.Add(this.cmbLineStyle);
			this.Controls.Add(this.btnProcess);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "frmWallsFromLines";
			this.Text = "Create Walls From Lines";
			Load += this.FrmWallsFromLinesLoad;
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox tbxHeight;
		private System.Windows.Forms.ComboBox cmbUnits;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cmbLevel;
		private System.Windows.Forms.ComboBox cmbWallType;
		private System.Windows.Forms.ComboBox cmbLineStyle;
		private System.Windows.Forms.Button btnProcess;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}
