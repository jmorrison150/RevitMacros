//
// Created by SharpDevelop.
// User: michael
// Date: 10/13/2015
// Time: 12:36 PM
// 
// To change this template use Tools | Options | Coding | Edit Standard Headers.
//
using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace ArchSmarter
{

	public partial class frmForm
	{
		public frmForm(Document curDoc)
		{
			// The Me.InitializeComponent call is required for Windows Forms designer support.
			this.InitializeComponent();

			//get all schedules
			List<ViewSchedule> schedList = mExportSchedules.getAllSchedules(curDoc);

			//add schedules to list box
			foreach (ViewSchedule curSched in schedList) {
				lbxSchedules.Items.Add(curSched.Name.ToString());
			}
			// TODO : Add constructor code after InitializeComponents
			//
		}

//click select files button
		public void BtnSelectClick(object sender, EventArgs e)
		{
			//select folder
			string folderPath = selectFolder();

			//add folder path to text box
			this.tbxFolderPath.Text = folderPath;
		}

//returns list of files from list box
		public List<string> getSelectedSchedules()
		{
			List<string> schedList = new List<string>();

			foreach (string curSched in lbxSchedules.SelectedItems) {
				schedList.Add(curSched);
			}

			return schedList;
		}

//returns text from text box
		public string getSelectedFolder()
		{
			return tbxFolderPath.Text;
		}

//select folder using folder browser dialog
		public string selectFolder()
		{
			//select folder dialog
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			string curFolder = "";

			fbd.RootFolder = Environment.SpecialFolder.MyComputer;
			fbd.Description = "Select folder path";

			if (fbd.ShowDialog() == DialogResult.OK) {
				curFolder = fbd.SelectedPath;
			}

			return curFolder;
		}
	}
}
