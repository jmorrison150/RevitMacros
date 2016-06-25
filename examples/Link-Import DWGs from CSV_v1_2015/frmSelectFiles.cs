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
	public partial class frmSelectFiles
	{
		public frmSelectFiles()
		{
			// The Me.InitializeComponent call is required for Windows Forms designer support.
			this.InitializeComponent();

			//
			// TODO : Add constructor code after InitializeComponents
			//
			this.tbxCSVFile.Text = "";

		}

		public void BtnSelectFileClick(object sender, System.EventArgs e)
		{
			string showFile = null;

			//get OpenFileDialog
			var _with1 = ofdCSVFile;
			_with1.InitialDirectory = "C:\\";
			_with1.Title = "Select CSV File";
			_with1.FileName = "";
			_with1.Filter = "CSV Files (*.csv)|*.csv";

			if (_with1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel) {
				showFile = _with1.FileName;

				//add file to dialog
				tbxCSVFile.Text = showFile;
			}
		}

		public string getCSVFile()
		{
			//return selected CSV file
			return this.tbxCSVFile.Text;
		}

		public string GetLinkInsert()
		{
			//return whether link or insert
			if (this.rbInsert.Checked == true) {
				return "insert";
			} else {
				return "link";
			}
		}
	}
}
