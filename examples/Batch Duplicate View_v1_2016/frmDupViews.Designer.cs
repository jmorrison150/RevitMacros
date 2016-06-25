namespace ArchSmarter
{
	//
	// Created by SharpDevelop.
	// User: michael
	// Date: 12/17/2015
	// Time: 1:04 PM
	// 
	// To change this template use Tools | Options | Coding | Edit Standard Headers.
	//
	partial class frmDupViews : System.Windows.Forms.Form
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
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.cmbNumDupes = new System.Windows.Forms.ComboBox();
			this.rbDup = new System.Windows.Forms.RadioButton();
			this.rbDupDetailing = new System.Windows.Forms.RadioButton();
			this.rbDupDependent = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.clbViewsToDup = new System.Windows.Forms.CheckedListBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			//
			//label3
			//
			this.label3.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.label3.Location = new System.Drawing.Point(12, 120);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(178, 23);
			this.label3.TabIndex = 13;
			this.label3.Text = "Select Number of Duplicates:";
			this.label3.UseCompatibleTextRendering = true;
			//
			//label2
			//
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(178, 23);
			this.label2.TabIndex = 11;
			this.label2.Text = "Select Views to Duplicate:";
			this.label2.UseCompatibleTextRendering = true;
			//
			//btnCancel
			//
			this.btnCancel.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(199, 281);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 10;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseCompatibleTextRendering = true;
			this.btnCancel.UseVisualStyleBackColor = true;
			//
			//btnOK
			//
			this.btnOK.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(118, 281);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 9;
			this.btnOK.Text = "OK";
			this.btnOK.UseCompatibleTextRendering = true;
			this.btnOK.UseVisualStyleBackColor = true;
			//
			//cmbNumDupes
			//
			this.cmbNumDupes.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
			this.cmbNumDupes.FormattingEnabled = true;
			this.cmbNumDupes.Location = new System.Drawing.Point(12, 137);
			this.cmbNumDupes.Name = "cmbNumDupes";
			this.cmbNumDupes.Size = new System.Drawing.Size(262, 21);
			this.cmbNumDupes.TabIndex = 14;
			//
			//rbDup
			//
			this.rbDup.Location = new System.Drawing.Point(6, 19);
			this.rbDup.Name = "rbDup";
			this.rbDup.Size = new System.Drawing.Size(104, 24);
			this.rbDup.TabIndex = 15;
			this.rbDup.TabStop = true;
			this.rbDup.Text = "Duplicate";
			this.rbDup.UseCompatibleTextRendering = true;
			this.rbDup.UseVisualStyleBackColor = true;
			//
			//rbDupDetailing
			//
			this.rbDupDetailing.Location = new System.Drawing.Point(6, 49);
			this.rbDupDetailing.Name = "rbDupDetailing";
			this.rbDupDetailing.Size = new System.Drawing.Size(188, 24);
			this.rbDupDetailing.TabIndex = 16;
			this.rbDupDetailing.TabStop = true;
			this.rbDupDetailing.Text = "Duplicate with Detailing";
			this.rbDupDetailing.UseCompatibleTextRendering = true;
			this.rbDupDetailing.UseVisualStyleBackColor = true;
			//
			//rbDupDependent
			//
			this.rbDupDependent.Location = new System.Drawing.Point(6, 79);
			this.rbDupDependent.Name = "rbDupDependent";
			this.rbDupDependent.Size = new System.Drawing.Size(217, 24);
			this.rbDupDependent.TabIndex = 17;
			this.rbDupDependent.TabStop = true;
			this.rbDupDependent.Text = "Duplicate as a Dependent";
			this.rbDupDependent.UseCompatibleTextRendering = true;
			this.rbDupDependent.UseVisualStyleBackColor = true;
			//
			//groupBox1
			//
			this.groupBox1.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.rbDup);
			this.groupBox1.Controls.Add(this.rbDupDependent);
			this.groupBox1.Controls.Add(this.rbDupDetailing);
			this.groupBox1.Location = new System.Drawing.Point(12, 164);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(262, 111);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Duplicate Settings";
			this.groupBox1.UseCompatibleTextRendering = true;
			//
			//clbViewsToDup
			//
			this.clbViewsToDup.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
			this.clbViewsToDup.FormattingEnabled = true;
			this.clbViewsToDup.Location = new System.Drawing.Point(12, 26);
			this.clbViewsToDup.Name = "clbViewsToDup";
			this.clbViewsToDup.Size = new System.Drawing.Size(262, 79);
			this.clbViewsToDup.TabIndex = 19;
			this.clbViewsToDup.UseCompatibleTextRendering = true;
			//
			//frmDupViews
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 312);
			this.Controls.Add(this.clbViewsToDup);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cmbNumDupes);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Name = "frmDupViews";
			this.Text = "Batch Duplicate Views";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.CheckedListBox clbViewsToDup;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbDupDependent;
		private System.Windows.Forms.RadioButton rbDupDetailing;
		private System.Windows.Forms.RadioButton rbDup;
		private System.Windows.Forms.ComboBox cmbNumDupes;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}
