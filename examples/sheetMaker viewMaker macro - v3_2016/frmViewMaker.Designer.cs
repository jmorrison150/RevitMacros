namespace JRM
{
	//
	// Created by SharpDevelop.
	// User: michael
	// Date: 9/16/2014
	// Time: 11:18 AM
	// 
	// To change this template use Tools | Options | Coding | Edit Standard Headers.
	//
	partial class frmViewMaker : System.Windows.Forms.Form
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
			this.btnProcess = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.cmbViewType = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmbDesignOption = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cmbScopeBox = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbViewTemplate = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lbLevels = new System.Windows.Forms.ListBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			//
			//btnProcess
			//
			this.btnProcess.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnProcess.Location = new System.Drawing.Point(254, 282);
			this.btnProcess.Name = "btnProcess";
			this.btnProcess.Size = new System.Drawing.Size(84, 23);
			this.btnProcess.TabIndex = 6;
			this.btnProcess.Text = "OK";
			this.btnProcess.UseCompatibleTextRendering = true;
			this.btnProcess.UseVisualStyleBackColor = true;
			//
			//btnCancel
			//
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(344, 282);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseCompatibleTextRendering = true;
			this.btnCancel.UseVisualStyleBackColor = true;
			//
			//cmbViewType
			//
			this.cmbViewType.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
			this.cmbViewType.FormattingEnabled = true;
			this.cmbViewType.Location = new System.Drawing.Point(142, 12);
			this.cmbViewType.Name = "cmbViewType";
			this.cmbViewType.Size = new System.Drawing.Size(277, 21);
			this.cmbViewType.TabIndex = 9;
			//
			//label1
			//
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 8;
			this.label1.Text = "Select View Type:";
			this.label1.UseCompatibleTextRendering = true;
			//
			//label4
			//
			this.label4.Location = new System.Drawing.Point(12, 39);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 14;
			this.label4.Text = "Select Levels:";
			this.label4.UseCompatibleTextRendering = true;
			//
			//groupBox1
			//
			this.groupBox1.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.cmbDesignOption);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.cmbScopeBox);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.cmbViewTemplate);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(12, 165);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(407, 111);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Options";
			this.groupBox1.UseCompatibleTextRendering = true;
			//
			//cmbDesignOption
			//
			this.cmbDesignOption.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
			this.cmbDesignOption.FormattingEnabled = true;
			this.cmbDesignOption.Location = new System.Drawing.Point(130, 74);
			this.cmbDesignOption.Name = "cmbDesignOption";
			this.cmbDesignOption.Size = new System.Drawing.Size(271, 21);
			this.cmbDesignOption.TabIndex = 23;
			//
			//label5
			//
			this.label5.Location = new System.Drawing.Point(6, 77);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(124, 23);
			this.label5.TabIndex = 22;
			this.label5.Text = "Design Option:";
			this.label5.UseCompatibleTextRendering = true;
			//
			//cmbScopeBox
			//
			this.cmbScopeBox.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
			this.cmbScopeBox.FormattingEnabled = true;
			this.cmbScopeBox.Location = new System.Drawing.Point(130, 47);
			this.cmbScopeBox.Name = "cmbScopeBox";
			this.cmbScopeBox.Size = new System.Drawing.Size(271, 21);
			this.cmbScopeBox.TabIndex = 21;
			//
			//label3
			//
			this.label3.Location = new System.Drawing.Point(6, 50);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 20;
			this.label3.Text = "Scope Box:";
			this.label3.UseCompatibleTextRendering = true;
			//
			//cmbViewTemplate
			//
			this.cmbViewTemplate.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
			this.cmbViewTemplate.FormattingEnabled = true;
			this.cmbViewTemplate.Location = new System.Drawing.Point(130, 20);
			this.cmbViewTemplate.Name = "cmbViewTemplate";
			this.cmbViewTemplate.Size = new System.Drawing.Size(271, 21);
			this.cmbViewTemplate.TabIndex = 19;
			//
			//label2
			//
			this.label2.Location = new System.Drawing.Point(6, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(124, 23);
			this.label2.TabIndex = 18;
			this.label2.Text = "View Template:";
			this.label2.UseCompatibleTextRendering = true;
			//
			//lbLevels
			//
			this.lbLevels.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
			this.lbLevels.FormattingEnabled = true;
			this.lbLevels.Location = new System.Drawing.Point(142, 39);
			this.lbLevels.Name = "lbLevels";
			this.lbLevels.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lbLevels.Size = new System.Drawing.Size(277, 121);
			this.lbLevels.TabIndex = 20;
			//
			//frmViewMaker
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(431, 312);
			this.Controls.Add(this.lbLevels);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cmbViewType);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnProcess);
			this.Controls.Add(this.btnCancel);
			this.Name = "frmViewMaker";
			this.Text = "Plan View Maker";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ListBox lbLevels;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cmbDesignOption;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbScopeBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbViewTemplate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbViewType;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnProcess;
	}
}
