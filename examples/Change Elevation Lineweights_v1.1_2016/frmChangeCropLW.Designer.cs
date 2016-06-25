namespace archSmarter
{
	//
	// Created by SharpDevelop.
	// User: michael
	// Date: 7/7/2015
	// Time: 8:58 PM
	// 
	// To change this template use Tools | Options | Coding | Edit Standard Headers.
	//
	partial class frmChangeCropLW : System.Windows.Forms.Form
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
			this.cmbLW = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnProcess = new System.Windows.Forms.Button();
			this.lbViews = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			//
			//label1
			//
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Select Views:";
			this.label1.UseCompatibleTextRendering = true;
			//
			//cmbLW
			//
			this.cmbLW.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
			this.cmbLW.FormattingEnabled = true;
			this.cmbLW.Items.AddRange(new object[] {
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9",
				"10",
				"11",
				"12",
				"13",
				"14",
				"15",
				"16"
			});
			this.cmbLW.Location = new System.Drawing.Point(119, 159);
			this.cmbLW.Name = "cmbLW";
			this.cmbLW.Size = new System.Drawing.Size(207, 21);
			this.cmbLW.TabIndex = 2;
			//
			//label2
			//
			this.label2.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.label2.Location = new System.Drawing.Point(13, 162);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Select Line Weight:";
			this.label2.UseCompatibleTextRendering = true;
			//
			//btnCancel
			//
			this.btnCancel.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(251, 186);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseCompatibleTextRendering = true;
			this.btnCancel.UseVisualStyleBackColor = true;
			//
			//btnProcess
			//
			this.btnProcess.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnProcess.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnProcess.Location = new System.Drawing.Point(170, 186);
			this.btnProcess.Name = "btnProcess";
			this.btnProcess.Size = new System.Drawing.Size(75, 23);
			this.btnProcess.TabIndex = 5;
			this.btnProcess.Text = "OK";
			this.btnProcess.UseCompatibleTextRendering = true;
			this.btnProcess.UseVisualStyleBackColor = true;
			//
			//lbViews
			//
			this.lbViews.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
			this.lbViews.FormattingEnabled = true;
			this.lbViews.Location = new System.Drawing.Point(119, 9);
			this.lbViews.Name = "lbViews";
			this.lbViews.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lbViews.Size = new System.Drawing.Size(207, 134);
			this.lbViews.TabIndex = 6;
			//
			//frmChangeCropLW
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 212);
			this.Controls.Add(this.lbViews);
			this.Controls.Add(this.btnProcess);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cmbLW);
			this.Controls.Add(this.label1);
			this.Name = "frmChangeCropLW";
			this.Text = "Change Crop Line Weight";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ListBox lbViews;
		private System.Windows.Forms.Button btnProcess;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbLW;
		private System.Windows.Forms.Label label1;
	}
}
