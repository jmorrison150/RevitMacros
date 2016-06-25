namespace archSmarter
{
	//
	// Created by SharpDevelop.
	// User: michael
	// Date: 9/15/2014
	// Time: 1:12 PM
	// 
	// To change this template use Tools | Options | Coding | Edit Standard Headers.
	//
	partial class frmSheetMaker : System.Windows.Forms.Form
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
			this.components = new System.ComponentModel.Container();
			this.lblSelectFile = new System.Windows.Forms.Label();
			this.ofdCSVFile = new System.Windows.Forms.OpenFileDialog();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.tbxCSVFile = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnProcess = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbTitleblock = new System.Windows.Forms.ComboBox();
			this.cmbSheetType = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnCreateCSV = new System.Windows.Forms.Button();
			this.ttCreateCSV = new System.Windows.Forms.ToolTip(this.components);
			this.sfdCreateCSV = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			//
			//lblSelectFile
			//
			this.lblSelectFile.Location = new System.Drawing.Point(12, 9);
			this.lblSelectFile.Name = "lblSelectFile";
			this.lblSelectFile.Size = new System.Drawing.Size(100, 23);
			this.lblSelectFile.TabIndex = 0;
			this.lblSelectFile.Text = "Select CSV File:";
			this.lblSelectFile.UseCompatibleTextRendering = true;
			//
			//ofdCSVFile
			//
			this.ofdCSVFile.FileName = "openFileDialog1";
			this.ofdCSVFile.FileOk += this.OpenFileDialog1FileOk;
			//
			//btnBrowse
			//
			this.btnBrowse.Location = new System.Drawing.Point(401, 4);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(75, 23);
			this.btnBrowse.TabIndex = 1;
			this.btnBrowse.Text = "Browse";
			this.btnBrowse.UseCompatibleTextRendering = true;
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += this.BtnBrowseClick;
			//
			//tbxCSVFile
			//
			this.tbxCSVFile.Location = new System.Drawing.Point(118, 6);
			this.tbxCSVFile.Name = "tbxCSVFile";
			this.tbxCSVFile.Size = new System.Drawing.Size(277, 20);
			this.tbxCSVFile.TabIndex = 2;
			//
			//btnCancel
			//
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(401, 90);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseCompatibleTextRendering = true;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += this.Button1Click;
			//
			//btnProcess
			//
			this.btnProcess.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnProcess.Location = new System.Drawing.Point(311, 90);
			this.btnProcess.Name = "btnProcess";
			this.btnProcess.Size = new System.Drawing.Size(84, 23);
			this.btnProcess.TabIndex = 4;
			this.btnProcess.Text = "Make Sheets";
			this.btnProcess.UseCompatibleTextRendering = true;
			this.btnProcess.UseVisualStyleBackColor = true;
			this.btnProcess.Click += this.BtnProcessClick;
			//
			//label1
			//
			this.label1.Location = new System.Drawing.Point(12, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "Select Title Block:";
			this.label1.UseCompatibleTextRendering = true;
			//
			//cmbTitleblock
			//
			this.cmbTitleblock.FormattingEnabled = true;
			this.cmbTitleblock.Location = new System.Drawing.Point(118, 34);
			this.cmbTitleblock.Name = "cmbTitleblock";
			this.cmbTitleblock.Size = new System.Drawing.Size(277, 21);
			this.cmbTitleblock.TabIndex = 7;
			//
			//cmbSheetType
			//
			this.cmbSheetType.FormattingEnabled = true;
			this.cmbSheetType.Items.AddRange(new object[] {
				"Sheet",
				"Placeholder Sheet"
			});
			this.cmbSheetType.Location = new System.Drawing.Point(118, 63);
			this.cmbSheetType.Name = "cmbSheetType";
			this.cmbSheetType.Size = new System.Drawing.Size(277, 21);
			this.cmbSheetType.TabIndex = 9;
			//
			//label2
			//
			this.label2.Location = new System.Drawing.Point(12, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 8;
			this.label2.Text = "Select Sheet Type:";
			this.label2.UseCompatibleTextRendering = true;
			//
			//btnCreateCSV
			//
			this.btnCreateCSV.Location = new System.Drawing.Point(12, 90);
			this.btnCreateCSV.Name = "btnCreateCSV";
			this.btnCreateCSV.Size = new System.Drawing.Size(24, 23);
			this.btnCreateCSV.TabIndex = 10;
			this.btnCreateCSV.Text = "+";
			this.ttCreateCSV.SetToolTip(this.btnCreateCSV, "Click button to create a default CSV file. You will be prompted to select a locat" + "ion to save the file. The CSV file will automatically open after it is created.");
			this.btnCreateCSV.UseCompatibleTextRendering = true;
			this.btnCreateCSV.UseVisualStyleBackColor = true;
			this.btnCreateCSV.Click += this.BtnCreateCSVClick;
			//
			//frmSheetMaker
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(483, 120);
			this.Controls.Add(this.btnCreateCSV);
			this.Controls.Add(this.cmbSheetType);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cmbTitleblock);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnProcess);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.tbxCSVFile);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.lblSelectFile);
			this.Name = "frmSheetMaker";
			this.Text = "Sheet Maker";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.SaveFileDialog sfdCreateCSV;
		private System.Windows.Forms.ToolTip ttCreateCSV;
		private System.Windows.Forms.Button btnCreateCSV;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbSheetType;
		private System.Windows.Forms.ComboBox cmbTitleblock;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnProcess;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox tbxCSVFile;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.OpenFileDialog ofdCSVFile;
		private System.Windows.Forms.Label lblSelectFile;

		public void Button1Click(object sender, System.EventArgs e)
		{
			this.Close();

		}
	}
}
