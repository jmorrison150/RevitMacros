//
// Created by SharpDevelop.
// User: michael
// Date: 7/7/2015
// Time: 8:58 PM
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
using System.Diagnostics;
using Microsoft.VisualBasic;
namespace archSmarter
{

	public partial class frmChangeCropLW
	{
		public frmChangeCropLW(Document curDoc)
		{
			// The Me.InitializeComponent call is required for Windows Forms designer support.
			this.InitializeComponent();

			//
			// TODO : Add constructor code after InitializeComponents
			//

			//get all elevation views in current document
			List<View> elevList = getAllElevations(curDoc);

			foreach (View curElev in elevList) {
				this.lbViews.Items.Add(curElev.Name);
			}

			//set selected LW
			this.cmbLW.SelectedIndex = 0;

		}

		public List<View> getAllElevations(Document curDoc)
		{
			//get all selevation views in current document
			FilteredElementCollector viewCollector = new FilteredElementCollector(curDoc);
			viewCollector.OfCategory(BuiltInCategory.OST_Views);

			//create list for views
			List<View> viewList = new List<View>();

			//loop through views and check for elevation views
			foreach (View x in viewCollector.ToElements()) {
				if (x.GetType() == typeof(ViewSection)) {
					if (x.IsTemplate == false) {
						if (x.ViewType == ViewType.Elevation) {
							//add view to list
							viewList.Add(x);
						}
					}
				}
			}

			return viewList;
		}

		public List<View> getSelectedViews(Document curDoc)
		{
			List<string> viewNameList = new List<string>();

			//get views from combo box
			for (int i = 0; i <= lbViews.SelectedItems.Count - 1; i++) {
				viewNameList.Add(lbViews.SelectedItems[i].ToString());
			}

			//get view from view name
			List<View> viewList = new List<View>();
			foreach (string curView in viewNameList) {
				viewList.Add(getViewByName(curDoc, curView));
			}

			return viewList;

		}

		public string getSelectedLW()
		{
			return cmbLW.SelectedItem.ToString();
		}

		public View getViewByName(Document curDoc, string viewName)
		{
			//returns views
			List<View> viewList = null;
			viewList = getAllElevations(curDoc);

			//loop through views and check if is view template
			foreach (View v in viewList) {
				if (string.Compare(v.Name, viewName) == 0) {
					return v;
				}
			}

			return null;
		}

	}
}
