using System;
using System.IO;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.UI;
namespace JRM
{

	public partial class frmSheetMaker
	{
		public frmSheetMaker(Autodesk.Revit.DB.Document curDoc)
		{
			// The Me.InitializeComponent call is required for Windows Forms designer support.
			this.InitializeComponent();

			//
			// TODO : Add constructor code after InitializeComponents
			List<string> curTblocks = null;

			//get titleblocks in current model and output to combo box
			curTblocks = mFunctions.getAllTitleblockNames(curDoc);
			foreach (string tblock in curTblocks) {
				this.cmbTitleblock.Items.Add(tblock);
			}

			//set combo box to first titleblock
			this.cmbTitleblock.SelectedIndex = 0;

			//set sheet type to regular sheet
			this.cmbSheetType.SelectedIndex = 0;

			//set btnCreateCSV tooltip
			this.ttCreateCSV.ToolTipTitle = "Create Default CSV File";

		}

		public void BtnBrowseClick(object sender, System.EventArgs e)
		{
			//set open file dialog settings
			ofdCSVFile.InitialDirectory = "C:\\";
			ofdCSVFile.Title = "Select a CSV file";
			ofdCSVFile.FileName = "";
			ofdCSVFile.Filter = "CSV Files (*.csv)|*.csv";

			if (ofdCSVFile.ShowDialog() != System.Windows.Forms.DialogResult.Cancel) {
				tbxCSVFile.Text = ofdCSVFile.FileName;
			} else {
				tbxCSVFile.Text = "";
			}
		}


		public void OpenFileDialog1FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
		}

		public void BtnProcessClick(object sender, System.EventArgs e)
		{

			//validate data
			if (string.IsNullOrEmpty(tbxCSVFile.Text)) {
				//prompt user to select file
				TaskDialog.Show("Select CSV File", "Please select a CSV file.");
				this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

			} else if (string.IsNullOrEmpty(cmbTitleblock.SelectedItem.ToString())) {
				TaskDialog.Show("Select Title block", "Please select a title block.");
				this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

			} else {
				//close dialog
				this.Close();
			}

		}

		public string getCSVFile()
		{
			//return selected CSV file
			return this.tbxCSVFile.Text;
		}

		public string[] getTblock()
		{
			//return selected tblock
			string tBlockString = this.cmbTitleblock.SelectedItem.ToString();
			string[] tmpArr = tBlockString.Split(new char[] { '|' });

			string[] tBlockArr = new string[2];
			tBlockArr[0] = tmpArr[0].Trim();
			tBlockArr[1] = tmpArr[1].Trim();

			return tBlockArr;
		}

		public string getSheetType()
		{
			//return selected sheet type
			return this.cmbSheetType.SelectedItem.ToString();
		}


		public void BtnCreateCSVClick(object sender, System.EventArgs e)
		{
			//launch file save dialog to save default CSV file
			sfdCreateCSV.InitialDirectory = "C:\\";
			sfdCreateCSV.Title = "Select location to save default CSV file";
			sfdCreateCSV.FileName = "default.csv";
			sfdCreateCSV.Filter = "CSV Files (*.csv)|*.csv";

			if (sfdCreateCSV.ShowDialog() != System.Windows.Forms.DialogResult.Cancel) {
				string saveFile = sfdCreateCSV.FileName;

				//create CSV file
				string headerString = "Sheet #, Sheet Name, View(s)";
				string Line1 = "A100,TEST SHEET 0, Site";
				string Line2 = "A101,TEST SHEET 1,\"Level 1, East\"";
				string Line3 = "A102,TEST SHEET 2,\"Level 2, West\"";

				//check if file exists - if so then delete
				if (File.Exists(saveFile) == true) {
					//delete file
					File.Delete(saveFile);
				}

				//write CSV data to file
				mFunctions.writeCSVFile(saveFile, headerString);
				mFunctions.writeCSVFile(saveFile, Line1);
				mFunctions.writeCSVFile(saveFile, Line2);
				mFunctions.writeCSVFile(saveFile, Line3);

				//open CSV file if possible
				try {
					System.Diagnostics.Process.Start(saveFile);

				} catch (Exception ex) {
					Debug.Print("Could not open file.");
				}

			}
		}
	}
}
