namespace archSmarter
{
	//
	// Created by SharpDevelop.
	// User: michael
	// Date: 9/15/2015
	// Time: 3:58 PM
	// 
	// To change this template use Tools | Options | Coding | Edit Standard Headers.
	//
	partial class frmBatchLinkRVT : System.Windows.Forms.Form
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnSelectFiles = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.lbFileList = new System.Windows.Forms.ListBox();
			this.fbDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.SuspendLayout();
			//
			//btnCancel
			//
			this.btnCancel.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(391, 129);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 22);
			this.btnCancel.TabIndex = 10;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseCompatibleTextRendering = true;
			this.btnCancel.UseVisualStyleBackColor = true;
			//
			//btnOK
			//
			this.btnOK.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(310, 129);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 22);
			this.btnOK.TabIndex = 9;
			this.btnOK.Text = "OK";
			this.btnOK.UseCompatibleTextRendering = true;
			this.btnOK.UseVisualStyleBackColor = true;
			//
			//btnSelectFiles
			//
			this.btnSelectFiles.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnSelectFiles.Location = new System.Drawing.Point(391, 28);
			this.btnSelectFiles.Name = "btnSelectFiles";
			this.btnSelectFiles.Size = new System.Drawing.Size(75, 22);
			this.btnSelectFiles.TabIndex = 8;
			this.btnSelectFiles.Text = "Browse. . .";
			this.btnSelectFiles.UseCompatibleTextRendering = true;
			this.btnSelectFiles.UseVisualStyleBackColor = true;
			this.btnSelectFiles.Click += this.BtnSelectFilesClick;
			//
			//label2
			//
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 7;
			this.label2.Text = "Select RVT Files:";
			this.label2.UseCompatibleTextRendering = true;
			//
			//lbFileList
			//
			this.lbFileList.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
			this.lbFileList.FormattingEnabled = true;
			this.lbFileList.Location = new System.Drawing.Point(12, 28);
			this.lbFileList.Name = "lbFileList";
			this.lbFileList.Size = new System.Drawing.Size(373, 95);
			this.lbFileList.TabIndex = 11;
			//
			//frmBatchLinkRVT
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(474, 157);
			this.Controls.Add(this.lbFileList);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnSelectFiles);
			this.Controls.Add(this.label2);
			this.Name = "frmBatchLinkRVT";
			this.Text = "Batch Link RVT Files";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.FolderBrowserDialog fbDialog;
		private System.Windows.Forms.ListBox lbFileList;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnSelectFiles;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
	}
}
