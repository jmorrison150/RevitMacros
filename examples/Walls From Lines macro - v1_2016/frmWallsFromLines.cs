//
// Created by SharpDevelop.
// User: michael
// Date: 9/17/2014
// Time: 11:23 AM
// 
// To change this template use Tools | Options | Coding | Edit Standard Headers.
//
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System;
namespace ArchSmarter
{

	public partial class frmWallsFromLines
	{
		public frmWallsFromLines(Autodesk.Revit.DB.Document curDoc)
		{
			// The Me.InitializeComponent call is required for Windows Forms designer support.
			this.InitializeComponent();

			//
			// TODO : Add constructor code after InitializeComponents
			//
			ThisDocument collectors = new ThisDocument();

			//get model line styles in current file
			List<string> curLineStyles = new List<string>();

			try {
				//get model lines in current file
				curLineStyles = collectors.getModelLineStyles(curDoc);

				//add model lines to combo box
				foreach (string lineStyle in curLineStyles) {
					this.cmbLineStyle.Items.Add(lineStyle);
				}
				this.cmbLineStyle.SelectedIndex = 0;

			} catch (Exception ex) {
				//error - no model lines
				TaskDialog.Show("Error", "There are no model lines in the current file.");
				this.Close();
				return;
			}

			//get wall types in current file
			List<string> curWallTypes = new List<string>();
			curWallTypes = collectors.getAllWallTypes(curDoc);

			//add wall types to combo box
			foreach (string curWallType in curWallTypes) {
				this.cmbWallType.Items.Add(curWallType);
			}
			this.cmbWallType.SelectedIndex = 0;

			//get levels in current file
			List<Level> curLevels = new List<Level>();
			curLevels = collectors.getAllLevels(curDoc);

			//add levels to combo box
			foreach (Level curLevel in curLevels) {
				this.cmbLevel.Items.Add(curLevel.Name.ToString());
			}
			this.cmbLevel.SelectedIndex = 0;

			//add unit types to combo box
			this.cmbUnits.Items.Add("ft");
			this.cmbUnits.Items.Add("mm");
			this.cmbUnits.SelectedIndex = 0;

		}

		public void BtnCancelClick(object sender, System.EventArgs e)
		{
			//close form
			this.Close();
		}

		public void BtnProcessClick(object sender, System.EventArgs e)
		{

		}

//---- return functions from dialog box ------------------------------
		public string getLinetype()
		{
			return this.cmbLineStyle.SelectedItem.ToString();
		}

		public string getWallType()
		{
			return this.cmbWallType.SelectedItem.ToString();
		}

		public string getLevel()
		{
			return this.cmbLevel.SelectedItem.ToString();
		}

		public double getHeight()
		{
			if (string.IsNullOrEmpty(tbxHeight.Text)) {
				//return default value of 20'
				return 20;
			} else {
				//return specificed value
				if (
					this.cmbUnits.SelectedItem.ToString() == "ft"
) {
					return Convert.ToDouble(this.tbxHeight.Text);
				} else {
					//convert mm to feet
					return mm2ft(Convert.ToDouble(this.tbxHeight.Text));
				}
			}
		}

		public double mm2ft(double curVar)
		{
			//converts millimeters to feet
			return curVar * 0.03937 / 12;

		}

		public void FrmWallsFromLinesLoad(object sender, EventArgs e)
		{

		}
	}
}
