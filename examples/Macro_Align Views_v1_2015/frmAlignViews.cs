//
// Created by SharpDevelop.
// User: michael
// Date: 3/27/2015
// Time: 2:58 PM
// 
// To change this template use Tools | Options | Coding | Edit Standard Headers.
//
using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Microsoft.VisualBasic;
namespace ArchSmarter
{

	public partial class frmAlignViews
	{
		public struct structVP
		{
			//structure for viewport information
			public string vpViewName;
			public string vpSheetNum;
			public Viewport vport;
		}

		public frmAlignViews(Document curDoc)
		{
			// The Me.InitializeComponent call is required for Windows Forms designer support.
			this.InitializeComponent();

			//
			// TODO : Add constructor code after InitializeComponents
			//		
			//loop through viewports and add to list of structures
			List<structVP> vpList = new List<structVP>();
			clsCollectors collectors = new clsCollectors();

			foreach (Viewport curVP in collectors.getAllViewports(curDoc)) {
				structVP tmpVP = default(structVP);
				View tmpView = (View)curDoc.GetElement(curVP.ViewId);
				ViewSheet tmpSheet = (ViewSheet)curDoc.GetElement(curVP.SheetId);

				tmpVP.vport = curVP;
				tmpVP.vpViewName = tmpView.Name;
				tmpVP.vpSheetNum = tmpSheet.SheetNumber;

				//add to list
				vpList.Add(tmpVP);
			}

			//order list by sheet #
			vpList = vpList.OrderBy(x => x.vpSheetNum).ToList();

			//output to form
			foreach (structVP tmpVP in vpList) {
				this.cmbPrimary.Items.Add(tmpVP.vpSheetNum + ", " + tmpVP.vpViewName);
				this.lbxViews.Items.Add(tmpVP.vpSheetNum + ", " + tmpVP.vpViewName);
			}

			//preselect primary and alignment
			this.cmbPrimary.SelectedIndex = 0;
			this.cmbAlignType.SelectedItem = "Center";

		}


		public string getAlignmentType()
		{
			return this.cmbAlignType.SelectedItem.ToString();

		}

		public Viewport getPrimaryView(Document curDoc)
		{
			string viewName = this.cmbPrimary.SelectedItem.ToString();

			//get view from view name
			string[] vpArray = Strings.Split(viewName, ", ");

			//get all viewports
			clsCollectors collectors = new clsCollectors();
			List<Viewport> vpList = collectors.getAllViewports(curDoc);

			foreach (Viewport curVP in vpList) {
				ViewSheet tmpSheet = (ViewSheet)curDoc.GetElement(curVP.SheetId);
				View tmpView = (View)curDoc.GetElement(curVP.ViewId);

				if (tmpSheet.SheetNumber == vpArray[0] & tmpView.ViewName == vpArray[1]) {
					Debug.Print("found match");
					return curVP;

				}
			}

			return null;
		}

		public List<Viewport> getViewList(Document curDoc)
		{
			clsCollectors collectors = new clsCollectors();
			List<Viewport> viewList = new List<Viewport>();
			int i = 0;

			for (i = 0; i <= this.lbxViews.SelectedItems.Count - 1; i++) {
				string curItem = this.lbxViews.SelectedItems[i].ToString();

				//get view from view name
				string[] vpArray = Strings.Split(curItem, ", ");

				//get all viewports
				List<Viewport> vpList = collectors.getAllViewports(curDoc);

				foreach (Viewport curVP in vpList) {
					ViewSheet tmpSheet = (ViewSheet)curDoc.GetElement(curVP.SheetId);
					View tmpView = (View)curDoc.GetElement(curVP.ViewId);

					if (tmpSheet.SheetNumber == vpArray[0] & tmpView.ViewName == vpArray[1]) {
						//add to list
						Debug.Print("found match");
						viewList.Add(curVP);
					}
				}

			}

			return viewList;

		}
	}
}
