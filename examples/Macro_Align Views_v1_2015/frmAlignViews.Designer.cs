namespace ArchSmarter
{
	//
	// Created by SharpDevelop.
	// User: michael
	// Date: 3/27/2015
	// Time: 2:58 PM
	// 
	// To change this template use Tools | Options | Coding | Edit Standard Headers.
	//
	partial class frmAlignViews : System.Windows.Forms.Form
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
			this.cmbPrimary = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lbxViews = new System.Windows.Forms.ListBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbAlignType = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			//
			//cmbPrimary
			//
			this.cmbPrimary.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
			this.cmbPrimary.FormattingEnabled = true;
			this.cmbPrimary.Location = new System.Drawing.Point(12, 34);
			this.cmbPrimary.Name = "cmbPrimary";
			this.cmbPrimary.Size = new System.Drawing.Size(260, 21);
			this.cmbPrimary.TabIndex = 0;
			//
			//label1
			//
			this.label1.Location = new System.Drawing.Point(11, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(260, 22);
			this.label1.TabIndex = 1;
			this.label1.Text = "Select view to align to:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.label1.UseCompatibleTextRendering = true;
			//
			//lbxViews
			//
			this.lbxViews.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
			this.lbxViews.FormattingEnabled = true;
			this.lbxViews.Location = new System.Drawing.Point(12, 84);
			this.lbxViews.Name = "lbxViews";
			this.lbxViews.ScrollAlwaysVisible = true;
			this.lbxViews.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lbxViews.Size = new System.Drawing.Size(259, 173);
			this.lbxViews.TabIndex = 2;
			//
			//btnOK
			//
			this.btnOK.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(196, 312);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			this.btnOK.UseCompatibleTextRendering = true;
			this.btnOK.UseVisualStyleBackColor = true;
			//
			//btnCancel
			//
			this.btnCancel.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(115, 312);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseCompatibleTextRendering = true;
			this.btnCancel.UseVisualStyleBackColor = true;
			//
			//label2
			//
			this.label2.Location = new System.Drawing.Point(11, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(260, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Select views to align:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.label2.UseCompatibleTextRendering = true;
			//
			//label3
			//
			this.label3.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.label3.Location = new System.Drawing.Point(12, 260);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(260, 22);
			this.label3.TabIndex = 6;
			this.label3.Text = "Select alignment point:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.label3.UseCompatibleTextRendering = true;
			//
			//cmbAlignType
			//
			this.cmbAlignType.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
			this.cmbAlignType.FormattingEnabled = true;
			this.cmbAlignType.Items.AddRange(new object[] {
				"Top Left",
				"Top Right",
				"Center",
				"Bottom Left",
				"Bottom Right"
			});
			this.cmbAlignType.Location = new System.Drawing.Point(12, 285);
			this.cmbAlignType.Name = "cmbAlignType";
			this.cmbAlignType.Size = new System.Drawing.Size(260, 21);
			this.cmbAlignType.TabIndex = 7;
			//
			//frmAlignViews
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 345);
			this.Controls.Add(this.cmbAlignType);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.lbxViews);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbPrimary);
			this.Name = "frmAlignViews";
			this.Text = "Align Views";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ComboBox cmbAlignType;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.ListBox lbxViews;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbPrimary;
	}
}
