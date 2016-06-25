namespace archSmarter
{
	//
	// Created by SharpDevelop.
	// User: michael
	// Date: 8/20/2015
	// Time: 9:38 AM
	// 
	// To change this template use Tools | Options | Coding | Edit Standard Headers.
	//
	partial class frmRenamer : System.Windows.Forms.Form
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbSheetNums = new System.Windows.Forms.RadioButton();
			this.rbRoomNums = new System.Windows.Forms.RadioButton();
			this.cbMatchWord = new System.Windows.Forms.CheckBox();
			this.cbMatchCase = new System.Windows.Forms.CheckBox();
			this.rbViewNames = new System.Windows.Forms.RadioButton();
			this.rbSheetNames = new System.Windows.Forms.RadioButton();
			this.rbRoomNames = new System.Windows.Forms.RadioButton();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.tbxFind = new System.Windows.Forms.TextBox();
			this.tbxReplace = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			//
			//label1
			//
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Find:";
			this.label1.UseCompatibleTextRendering = true;
			//
			//label2
			//
			this.label2.Location = new System.Drawing.Point(12, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Replace with:";
			this.label2.UseCompatibleTextRendering = true;
			//
			//groupBox1
			//
			this.groupBox1.Controls.Add(this.rbSheetNums);
			this.groupBox1.Controls.Add(this.rbRoomNums);
			this.groupBox1.Controls.Add(this.cbMatchWord);
			this.groupBox1.Controls.Add(this.cbMatchCase);
			this.groupBox1.Controls.Add(this.rbViewNames);
			this.groupBox1.Controls.Add(this.rbSheetNames);
			this.groupBox1.Controls.Add(this.rbRoomNames);
			this.groupBox1.Location = new System.Drawing.Point(12, 58);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(360, 154);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Scope";
			this.groupBox1.UseCompatibleTextRendering = true;
			//
			//rbSheetNums
			//
			this.rbSheetNums.Location = new System.Drawing.Point(6, 96);
			this.rbSheetNums.Name = "rbSheetNums";
			this.rbSheetNums.Size = new System.Drawing.Size(104, 24);
			this.rbSheetNums.TabIndex = 6;
			this.rbSheetNums.TabStop = true;
			this.rbSheetNums.Text = "Sheet Numbers";
			this.rbSheetNums.UseCompatibleTextRendering = true;
			this.rbSheetNums.UseVisualStyleBackColor = true;
			//
			//rbRoomNums
			//
			this.rbRoomNums.Location = new System.Drawing.Point(6, 44);
			this.rbRoomNums.Name = "rbRoomNums";
			this.rbRoomNums.Size = new System.Drawing.Size(104, 24);
			this.rbRoomNums.TabIndex = 5;
			this.rbRoomNums.TabStop = true;
			this.rbRoomNums.Text = "Room Numbers";
			this.rbRoomNums.UseCompatibleTextRendering = true;
			this.rbRoomNums.UseVisualStyleBackColor = true;
			//
			//cbMatchWord
			//
			this.cbMatchWord.Location = new System.Drawing.Point(138, 121);
			this.cbMatchWord.Name = "cbMatchWord";
			this.cbMatchWord.Size = new System.Drawing.Size(155, 24);
			this.cbMatchWord.TabIndex = 4;
			this.cbMatchWord.Text = "Match whole word only";
			this.cbMatchWord.UseCompatibleTextRendering = true;
			this.cbMatchWord.UseVisualStyleBackColor = true;
			//
			//cbMatchCase
			//
			this.cbMatchCase.Location = new System.Drawing.Point(138, 97);
			this.cbMatchCase.Name = "cbMatchCase";
			this.cbMatchCase.Size = new System.Drawing.Size(104, 24);
			this.cbMatchCase.TabIndex = 3;
			this.cbMatchCase.Text = "Match case";
			this.cbMatchCase.UseCompatibleTextRendering = true;
			this.cbMatchCase.UseVisualStyleBackColor = true;
			//
			//rbViewNames
			//
			this.rbViewNames.Location = new System.Drawing.Point(6, 121);
			this.rbViewNames.Name = "rbViewNames";
			this.rbViewNames.Size = new System.Drawing.Size(104, 24);
			this.rbViewNames.TabIndex = 2;
			this.rbViewNames.TabStop = true;
			this.rbViewNames.Text = "View Names";
			this.rbViewNames.UseCompatibleTextRendering = true;
			this.rbViewNames.UseVisualStyleBackColor = true;
			//
			//rbSheetNames
			//
			this.rbSheetNames.Location = new System.Drawing.Point(6, 69);
			this.rbSheetNames.Name = "rbSheetNames";
			this.rbSheetNames.Size = new System.Drawing.Size(104, 24);
			this.rbSheetNames.TabIndex = 1;
			this.rbSheetNames.TabStop = true;
			this.rbSheetNames.Text = "Sheet Names";
			this.rbSheetNames.UseCompatibleTextRendering = true;
			this.rbSheetNames.UseVisualStyleBackColor = true;
			//
			//rbRoomNames
			//
			this.rbRoomNames.Location = new System.Drawing.Point(6, 19);
			this.rbRoomNames.Name = "rbRoomNames";
			this.rbRoomNames.Size = new System.Drawing.Size(104, 24);
			this.rbRoomNames.TabIndex = 0;
			this.rbRoomNames.TabStop = true;
			this.rbRoomNames.Text = "Room Names";
			this.rbRoomNames.UseCompatibleTextRendering = true;
			this.rbRoomNames.UseVisualStyleBackColor = true;
			//
			//button1
			//
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(216, 218);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Replace";
			this.button1.UseCompatibleTextRendering = true;
			this.button1.UseVisualStyleBackColor = true;
			//
			//button2
			//
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(297, 218);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 4;
			this.button2.Text = "Cancel";
			this.button2.UseCompatibleTextRendering = true;
			this.button2.UseVisualStyleBackColor = true;
			//
			//tbxFind
			//
			this.tbxFind.Location = new System.Drawing.Point(118, 6);
			this.tbxFind.Multiline = true;
			this.tbxFind.Name = "tbxFind";
			this.tbxFind.Size = new System.Drawing.Size(254, 20);
			this.tbxFind.TabIndex = 5;
			//
			//tbxReplace
			//
			this.tbxReplace.Location = new System.Drawing.Point(118, 32);
			this.tbxReplace.Name = "tbxReplace";
			this.tbxReplace.Size = new System.Drawing.Size(254, 20);
			this.tbxReplace.TabIndex = 6;
			//
			//frmRenamer
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 252);
			this.Controls.Add(this.tbxReplace);
			this.Controls.Add(this.tbxFind);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "frmRenamer";
			this.Text = "Batch Rename";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.RadioButton rbRoomNums;
		private System.Windows.Forms.RadioButton rbSheetNums;
		private System.Windows.Forms.TextBox tbxReplace;
		private System.Windows.Forms.TextBox tbxFind;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RadioButton rbRoomNames;
		private System.Windows.Forms.RadioButton rbSheetNames;
		private System.Windows.Forms.RadioButton rbViewNames;
		private System.Windows.Forms.CheckBox cbMatchCase;
		private System.Windows.Forms.CheckBox cbMatchWord;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}
