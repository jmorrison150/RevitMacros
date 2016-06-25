//
// Created by SharpDevelop.
// User: michael
// Date: 9/15/2015
// Time: 3:58 PM
// 
// To change this template use Tools | Options | Coding | Edit Standard Headers.
//
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections.Generic;
namespace archSmarter
{

	public partial class frmBatchLinkRVT
	{
		public frmBatchLinkRVT()
		{
			// The Me.InitializeComponent call is required for Windows Forms designer support.
			this.InitializeComponent();

			//
			// TODO : Add constructor code after InitializeComponents
			//
			//clear list box
			lbFileList.Items.Clear();

			//set default positioning
			//cmbPositioning.SelectedIndex = 0

		}

		public void BtnSelectFilesClick(object sender, System.EventArgs e)
		{
			//prompt user to select files
			//select file dialog 
			OpenFileDialog fd = new OpenFileDialog();

			fd.Title = "Select RVT files to link";
			fd.InitialDirectory = "C:\\";
			fd.Filter = "RVT files (*.RVT)|*.RVT";
			fd.FilterIndex = 2;
			fd.RestoreDirectory = true;
			fd.Multiselect = true;

			if (fd.ShowDialog() == DialogResult.OK) {
				//update list box
				foreach (string curFile in fd.FileNames) {
					//add to list box
					lbFileList.Items.Add(curFile);
				}
			}

		}

		public List<string> getSelectedFiles()
		{
			List<string> fileList = new List<string>();

			foreach (string curFile in this.lbFileList.Items) {
				fileList.Add(curFile);
			}

			return fileList;

		}

//Public Function getPositioning() As String
		//Return Me.cmbPositioning.SelectedItem.ToString
//End Function
	}
}
