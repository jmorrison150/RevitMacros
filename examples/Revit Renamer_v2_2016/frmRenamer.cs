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
	public partial class frmRenamer
	{
		public frmRenamer()
		{
			// The Me.InitializeComponent call is required for Windows Forms designer support.
			this.InitializeComponent();

			//
			// TODO : Add constructor code after InitializeComponents
			//
			//reset control values
			this.tbxFind.Text = "";
			this.tbxReplace.Text = "";

			this.cbMatchCase.Checked = false;
			this.cbMatchWord.Checked = false;

			this.rbRoomNames.Checked = true;
		}

		public string getSelectedScope()
		{
			if (this.rbRoomNames.Checked == true) {
				return "room names";
			} else if (this.rbSheetNames.Checked == true) {
				return "sheet names";
			} else if (this.rbViewNames.Checked == true) {
				return "views";
			} else if (this.rbSheetNums.Checked == true) {
				return "sheet numbers";
			} else if (this.rbRoomNums.Checked == true) {
				return "room numbers";
			} else {
				return null;
			}

		}

		public string getFind()
		{
			return this.tbxFind.Text;
		}

		public string getReplace()
		{
			return this.tbxReplace.Text;
		}

		public bool getMatchCase()
		{
			return this.cbMatchCase.Checked;
		}

		public bool getMatchWord()
		{
			return this.cbMatchWord.Checked;
		}
	}
}
