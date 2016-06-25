//
// Created by SharpDevelop.
// User: michael
// Date: 12/17/2015
// Time: 1:04 PM
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
namespace ArchSmarter
{

	public partial class frmDupViews
	{
		public frmDupViews(Document curDoc)
		{
			// The Me.InitializeComponent call is required for Windows Forms designer support.
			this.InitializeComponent();

			//
			// TODO : Add constructor code after InitializeComponents
			//

			//set number of duplicates control box
			for (int i = 1; i <= 100; i++) {
				this.cmbNumDupes.Items.Add(i);
			}

			//set selected number of dupes
			this.cmbNumDupes.SelectedIndex = 0;

			//set selected duplicate option
			this.rbDup.Checked = true;

			//get all views in current model file
			List<View> viewList = null;
			viewList = mBatchDuplicate.getAllViews(curDoc);

			//create list of view names for combobox
			List<string> viewNameList = new List<string>();
			foreach (View curView in viewList) {
				string viewTypeName  =curView.ViewType.ToString();
				viewNameList.Add(viewTypeName + " : " + curView.Name);
			}

			//sort list
			viewNameList.Sort();

			//add view names to combo box
			foreach (string curViewName in viewNameList) {
				clbViewsToDup.Items.Add(curViewName);
			}

		}

		public List<clsView> getSelectedViews()
		{
			List<clsView> viewList = new List<clsView>();

			//loop through checked views and add to list
			foreach (string curSelectedView in clbViewsToDup.CheckedItems) {
				//create new view class
				clsView curView = new clsView();
				curView.setViewValues(curSelectedView);

				//add to list
				viewList.Add(curView);
			}

			//return view to duplicate
			//Dim selectedView As String = Me.cmbViewToDup.SelectedItem.ToString

			//split and strip whitespaces
			//Dim viewAr As String()
			//viewAr = selectedView.Split(New Char() {":"c})

			//viewAr(0) = viewAr(0).Trim(New Char() {" "c})
			//viewAr(1) = viewAr(1).Trim(New Char() {" "c})

			return viewList;
		}

		public int getNumDupes()
		{
			//return selected number of duplicates
			return Convert.ToInt32(this.cmbNumDupes.SelectedItem.ToString());
		}

		public string getDuplicateType()
		{
			//return duplicate type value
			if (this.rbDupDetailing.Checked == true) {
				return "detailing";
			} else if (this.rbDupDependent.Checked == true) {
				return "dependent";
			} else {
				return "duplicate";
			}
		}


	}
}
