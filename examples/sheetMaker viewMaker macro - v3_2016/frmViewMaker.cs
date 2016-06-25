//
// Created by SharpDevelop.
// User: michael
// Date: 9/16/2014
// Time: 11:18 AM
// 
// To change this template use Tools | Options | Coding | Edit Standard Headers.
//
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
namespace archSmarter
{

	public partial class frmViewMaker
	{
		public Document curDoc;

		public frmViewMaker(Document curDocument)
		{
			// The Me.InitializeComponent call is required for Windows Forms designer support.
			this.InitializeComponent();

			//
			// TODO : Add constructor code after InitializeComponents

			//set curDoc value
			curDoc = curDocument;

			//------------levels-----------------------
			//---------------------------------------------
			//get levels in current model
			List<Level> levelList = mFunctions.getAllLevels(curDoc);

			//add levels to listbox
			foreach (Level curLevel in levelList) {
				this.lbLevels.Items.Add(curLevel.Name);
			}

			//set selected level
			this.lbLevels.SelectedIndex = 0;

			//------------view types-----------------------
			//---------------------------------------------
			//get plan view family types
			List<string> viewFamilyList = new List<string>();
			foreach (ViewFamilyType curViewPlanType in mFunctions.getViewTypes(curDoc)) {
				if (curViewPlanType.ViewFamily == ViewFamily.FloorPlan | curViewPlanType.ViewFamily == ViewFamily.CeilingPlan | curViewPlanType.ViewFamily == ViewFamily.AreaPlan | curViewPlanType.ViewFamily == ViewFamily.StructuralPlan) {
					//add to list
					viewFamilyList.Add(curViewPlanType.ViewFamily.ToString() + " | " + curViewPlanType.Name);
				}
			}

			//sort list alphabetically
			viewFamilyList.Sort();

			//set view family type combo box
			foreach (string curViewFam in viewFamilyList) {
				//add to combo box
				this.cmbViewType.Items.Add(curViewFam);
			}

			//set view family selected index
			this.cmbViewType.SelectedIndex = 0;

			//------------view templates-------------------
			//---------------------------------------------
			//get view templates in current model and output to combo box
			List<string> curViewTemplates = null;
			curViewTemplates = mFunctions.getAllViewTemplates(curDoc);

			//populate combo box
			this.cmbViewTemplate.Items.Add("None");
			foreach (string viewTemp in curViewTemplates) {
				this.cmbViewTemplate.Items.Add(viewTemp);
			}

			//set view template combo box to "none"
			this.cmbViewTemplate.SelectedIndex = 0;

			//------------scope boxes----------------------
			//---------------------------------------------
			//get scope boxes in current model and output to combo box
			List<string> curScopeBoxes = mFunctions.getAllScopeBoxes(curDoc);

			//populate scope box combobox
			this.cmbScopeBox.Items.Add("None");
			foreach (string scopeBox in curScopeBoxes) {
				this.cmbScopeBox.Items.Add(scopeBox);
			}

			//set scope combo box to "none"
			this.cmbScopeBox.SelectedIndex = 0;

			//------------design options-------------------
			//---------------------------------------------
			//get design options in current model and output to combo box
			List<DesignOption> designOptList = mFunctions.getAllDesignOptions(curDoc);

			//populate design options scope box
			this.cmbDesignOption.Items.Add("None");
			foreach (DesignOption curOpt in designOptList) {
				this.cmbDesignOption.Items.Add(curOpt.Name);
			}

			//set design options combo box to none
			this.cmbDesignOption.SelectedIndex = 0;

		}

		public string getViewFamilyType()
		{
			//parse vft from text
			string curString = this.cmbViewType.SelectedItem.ToString();
			string[] tmpArr = curString.Split(new char[] { '|' });

			return tmpArr[1].Trim();
		}

		public string getViewTemplate()
		{
			//return view template
			return this.cmbViewTemplate.SelectedItem.ToString();

		}

		public string getScopeBox()
		{
			//return scope box
			return this.cmbScopeBox.SelectedItem.ToString();

		}

		public List<Level> getLevels()
		{
			List<Level> levelList = new List<Level>();

			//loop through listbox and get selected levels
			foreach (string tmpLevel in this.lbLevels.SelectedItems) {
				//get level and add to list
				Level curLevel = mFunctions.getLevelByName(curDoc, tmpLevel);

				//add to list
				levelList.Add(curLevel);
			}

			return levelList;
		}

		public string getDesignOption()
		{
			//return selected design option
			return this.cmbDesignOption.SelectedItem.ToString();

		}
	}
}
