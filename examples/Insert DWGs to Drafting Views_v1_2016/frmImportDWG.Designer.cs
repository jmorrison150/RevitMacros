namespace ArchSmarter
{
	//
	// Created by SharpDevelop.
	// User: michael
	// Date: 7/8/2015
	// Time: 10:32 PM
	// 
	// To change this template use Tools | Options | Coding | Edit Standard Headers.
	//
	partial class frmImportDWG : System.Windows.Forms.Form
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
			this.lbFiles = new System.Windows.Forms.ListBox();
			this.btnSelectFiles = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbInsertType = new System.Windows.Forms.ComboBox();
			this.cmbPositioning = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbColors = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			//
			//label1
			//
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(157, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Select Files to Import:";
			this.label1.UseCompatibleTextRendering = true;
			//
			//lbFiles
			//
			this.lbFiles.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
			this.lbFiles.FormattingEnabled = true;
			this.lbFiles.Location = new System.Drawing.Point(12, 31);
			this.lbFiles.Name = "lbFiles";
			this.lbFiles.Size = new System.Drawing.Size(340, 121);
			this.lbFiles.TabIndex = 1;
			//
			//btnSelectFiles
			//
			this.btnSelectFiles.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnSelectFiles.Location = new System.Drawing.Point(359, 31);
			this.btnSelectFiles.Name = "btnSelectFiles";
			this.btnSelectFiles.Size = new System.Drawing.Size(75, 23);
			this.btnSelectFiles.TabIndex = 2;
			this.btnSelectFiles.Text = "Select Files";
			this.btnSelectFiles.UseCompatibleTextRendering = true;
			this.btnSelectFiles.UseVisualStyleBackColor = true;
			this.btnSelectFiles.Click += this.Button1Click;
			//
			//btnCancel
			//
			this.btnCancel.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(359, 241);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseCompatibleTextRendering = true;
			this.btnCancel.UseVisualStyleBackColor = true;
			//
			//btnOK
			//
			this.btnOK.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(278, 241);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.UseCompatibleTextRendering = true;
			this.btnOK.UseVisualStyleBackColor = true;
			//
			//openFileDialog1
			//
			this.openFileDialog1.FileName = "openFile";
			this.openFileDialog1.InitialDirectory = "C:\\";
			this.openFileDialog1.FileOk += this.OpenFileDialog1FileOk;
			//
			//label2
			//
			this.label2.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.label2.Location = new System.Drawing.Point(55, 161);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Insert Type:";
			this.label2.UseCompatibleTextRendering = true;
			//
			//label3
			//
			this.label3.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.label3.Location = new System.Drawing.Point(55, 190);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Positioning:";
			this.label3.UseCompatibleTextRendering = true;
			//
			//cmbInsertType
			//
			this.cmbInsertType.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.cmbInsertType.FormattingEnabled = true;
			this.cmbInsertType.Items.AddRange(new object[] {
				"Import",
				"Link"
			});
			this.cmbInsertType.Location = new System.Drawing.Point(131, 158);
			this.cmbInsertType.Name = "cmbInsertType";
			this.cmbInsertType.Size = new System.Drawing.Size(221, 21);
			this.cmbInsertType.TabIndex = 7;
			//
			//cmbPositioning
			//
			this.cmbPositioning.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.cmbPositioning.FormattingEnabled = true;
			this.cmbPositioning.Items.AddRange(new object[] {
				"Center to Center",
				"Origin to Origin"
			});
			this.cmbPositioning.Location = new System.Drawing.Point(131, 187);
			this.cmbPositioning.Name = "cmbPositioning";
			this.cmbPositioning.Size = new System.Drawing.Size(221, 21);
			this.cmbPositioning.TabIndex = 8;
			//
			//label4
			//
			this.label4.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.label4.Location = new System.Drawing.Point(55, 217);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 23);
			this.label4.TabIndex = 9;
			this.label4.Text = "Colors:";
			this.label4.UseCompatibleTextRendering = true;
			//
			//cmbColors
			//
			this.cmbColors.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.cmbColors.FormattingEnabled = true;
			this.cmbColors.Items.AddRange(new object[] {
				"Invert",
				"Preserve",
				"Black and White"
			});
			this.cmbColors.Location = new System.Drawing.Point(131, 214);
			this.cmbColors.Name = "cmbColors";
			this.cmbColors.Size = new System.Drawing.Size(221, 21);
			this.cmbColors.TabIndex = 10;
			//
			//frmImportDWG
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(446, 271);
			this.Controls.Add(this.cmbColors);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cmbPositioning);
			this.Controls.Add(this.cmbInsertType);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSelectFiles);
			this.Controls.Add(this.lbFiles);
			this.Controls.Add(this.label1);
			this.Name = "frmImportDWG";
			this.Text = "Insert DWGs to Drafting Views";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ComboBox cmbColors;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cmbPositioning;
		private System.Windows.Forms.ComboBox cmbInsertType;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSelectFiles;
		private System.Windows.Forms.ListBox lbFiles;
		private System.Windows.Forms.Label label1;
	}
}
