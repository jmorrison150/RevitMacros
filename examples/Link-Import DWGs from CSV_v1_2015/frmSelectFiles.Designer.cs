namespace archSmarter
{
	//
	// Created by SharpDevelop.
	// User: michael
	// Date: 1/30/2015
	// Time: 10:34 PM
	// 
	// To change this template use Tools | Options | Coding | Edit Standard Headers.
	//
	partial class frmSelectFiles : System.Windows.Forms.Form
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
			this.tbxCSVFile = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnSelectFile = new System.Windows.Forms.Button();
			this.btnProcess = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.ofdCSVFile = new System.Windows.Forms.OpenFileDialog();
			this.rbLink = new System.Windows.Forms.RadioButton();
			this.rbInsert = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			//
			//tbxCSVFile
			//
			this.tbxCSVFile.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
			this.tbxCSVFile.Location = new System.Drawing.Point(12, 35);
			this.tbxCSVFile.Multiline = true;
			this.tbxCSVFile.Name = "tbxCSVFile";
			this.tbxCSVFile.Size = new System.Drawing.Size(350, 25);
			this.tbxCSVFile.TabIndex = 2;
			//
			//label2
			//
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Select CSV File";
			this.label2.UseCompatibleTextRendering = true;
			//
			//btnSelectFile
			//
			this.btnSelectFile.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnSelectFile.Location = new System.Drawing.Point(369, 35);
			this.btnSelectFile.Name = "btnSelectFile";
			this.btnSelectFile.Size = new System.Drawing.Size(75, 25);
			this.btnSelectFile.TabIndex = 4;
			this.btnSelectFile.Text = "Browse. . .";
			this.btnSelectFile.UseCompatibleTextRendering = true;
			this.btnSelectFile.UseVisualStyleBackColor = true;
			this.btnSelectFile.Click += this.BtnSelectFileClick;
			//
			//btnProcess
			//
			this.btnProcess.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnProcess.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnProcess.Location = new System.Drawing.Point(287, 66);
			this.btnProcess.Name = "btnProcess";
			this.btnProcess.Size = new System.Drawing.Size(75, 25);
			this.btnProcess.TabIndex = 5;
			this.btnProcess.Text = "OK";
			this.btnProcess.UseCompatibleTextRendering = true;
			this.btnProcess.UseVisualStyleBackColor = true;
			//
			//btnCancel
			//
			this.btnCancel.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(369, 66);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 25);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseCompatibleTextRendering = true;
			this.btnCancel.UseVisualStyleBackColor = true;
			//
			//ofdCSVFile
			//
			this.ofdCSVFile.FileName = "ofdCSVFile";
			//
			//rbLink
			//
			this.rbLink.Checked = true;
			this.rbLink.Location = new System.Drawing.Point(12, 66);
			this.rbLink.Name = "rbLink";
			this.rbLink.Size = new System.Drawing.Size(47, 24);
			this.rbLink.TabIndex = 7;
			this.rbLink.TabStop = true;
			this.rbLink.Text = "Link";
			this.rbLink.UseCompatibleTextRendering = true;
			this.rbLink.UseVisualStyleBackColor = true;
			//
			//rbInsert
			//
			this.rbInsert.Location = new System.Drawing.Point(65, 66);
			this.rbInsert.Name = "rbInsert";
			this.rbInsert.Size = new System.Drawing.Size(59, 24);
			this.rbInsert.TabIndex = 8;
			this.rbInsert.Text = "Insert";
			this.rbInsert.UseCompatibleTextRendering = true;
			this.rbInsert.UseVisualStyleBackColor = true;
			//
			//frmSelectFiles
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(456, 100);
			this.Controls.Add(this.rbInsert);
			this.Controls.Add(this.rbLink);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnProcess);
			this.Controls.Add(this.btnSelectFile);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbxCSVFile);
			this.Name = "frmSelectFiles";
			this.Text = "Link or Insert DWGs From CSV";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.RadioButton rbInsert;
		private System.Windows.Forms.RadioButton rbLink;
		private System.Windows.Forms.OpenFileDialog ofdCSVFile;
		private System.Windows.Forms.Button btnSelectFile;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnProcess;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbxCSVFile;
	}
}
