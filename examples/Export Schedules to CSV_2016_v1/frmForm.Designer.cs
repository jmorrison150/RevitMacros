namespace ArchSmarter
{
	//
	// Created by SharpDevelop.
	// User: michael
	// Date: 10/13/2015
	// Time: 12:36 PM
	// 
	// To change this template use Tools | Options | Coding | Edit Standard Headers.
	//
	partial class frmForm : System.Windows.Forms.Form
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
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbxFolderPath = new System.Windows.Forms.TextBox();
			this.lbxSchedules = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			//
			//btnOK
			//
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(176, 222);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.UseCompatibleTextRendering = true;
			this.btnOK.UseVisualStyleBackColor = true;
			//
			//btnCancel
			//
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(257, 222);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseCompatibleTextRendering = true;
			this.btnCancel.UseVisualStyleBackColor = true;
			//
			//btnSelect
			//
			this.btnSelect.Location = new System.Drawing.Point(257, 27);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(75, 23);
			this.btnSelect.TabIndex = 2;
			this.btnSelect.Text = "Select...";
			this.btnSelect.UseCompatibleTextRendering = true;
			this.btnSelect.UseVisualStyleBackColor = true;
			this.btnSelect.Click += this.BtnSelectClick;
			//
			//label1
			//
			this.label1.Location = new System.Drawing.Point(12, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(209, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Select Folder for CSV Files";
			this.label1.UseCompatibleTextRendering = true;
			//
			//label2
			//
			this.label2.Location = new System.Drawing.Point(12, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(178, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Select Schedules to Export";
			this.label2.UseCompatibleTextRendering = true;
			//
			//tbxFolderPath
			//
			this.tbxFolderPath.Location = new System.Drawing.Point(12, 29);
			this.tbxFolderPath.Name = "tbxFolderPath";
			this.tbxFolderPath.Size = new System.Drawing.Size(239, 20);
			this.tbxFolderPath.TabIndex = 8;
			//
			//lbxSchedules
			//
			this.lbxSchedules.FormattingEnabled = true;
			this.lbxSchedules.Location = new System.Drawing.Point(12, 77);
			this.lbxSchedules.Name = "lbxSchedules";
			this.lbxSchedules.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lbxSchedules.Size = new System.Drawing.Size(320, 134);
			this.lbxSchedules.TabIndex = 9;
			//
			//frmForm
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 251);
			this.Controls.Add(this.lbxSchedules);
			this.Controls.Add(this.tbxFolderPath);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSelect);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Name = "frmForm";
			this.Text = "Export Schedules to CSV";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ListBox lbxSchedules;
		private System.Windows.Forms.TextBox tbxFolderPath;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
	}
}
