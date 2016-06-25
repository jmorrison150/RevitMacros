//
// Created by SharpDevelop.
// User: ArchSmarter.com
// Date: 7/26/2014
// Time: 10:39 PM
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

	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	[Autodesk.Revit.DB.Macros.AddInId("FAE40FBF-A1C7-4FD0-AD98-931C197BC17D")]
	public partial class ThisDocument
	{

		public void Run()
		{
			//Get the current document
			Document curDoc = this.Application.ActiveUIDocument.Document;

			//open form
			using (frmChangeCropLW curForm = new frmChangeCropLW(this.Application.ActiveUIDocument.Document)) {
				//show form
				curForm.ShowDialog();

				if (curForm.DialogResult == System.Windows.Forms.DialogResult.Cancel) {
				//Result.Cancelled
				} else {
					//get list of views
					List<View> viewList = curForm.getSelectedViews(curDoc);

					//get selected line weight
					string curLW = curForm.getSelectedLW();

					//change line weight
					int changedViews = ChangeCropLW(curDoc, viewList, curLW);

					//alert user
					TaskDialog.Show("Complete", "Changed the crop line weight in " + changedViews + " views.");

				}
			}
		}

		public int ChangeCropLW(Document curDoc, List<View> viewList, string newLW)
		{
			//create counter
			int counter = 0;

			//create graphic override
			OverrideGraphicSettings ogs = new OverrideGraphicSettings();
			ogs.SetProjectionLineWeight(Convert.ToInt32(newLW));

			//create transaction
			using (Transaction curTrans = new Transaction(curDoc, "Change Crop View Lineweight")) {
				if (curTrans.Start() == TransactionStatus.Started) {

					//loop through views and check for int elev prefix
					foreach (View curView in viewList) {
						//get all the elements in the current view
						FilteredElementCollector viewElemColl = new FilteredElementCollector(curDoc, curView.Id);

						//loop through elements in view
						foreach (Element curElem in viewElemColl) {
							if (curElem.GetType() == typeof(Element)) {
								//check category
								Category curCat = curElem.Category;

								if (curCat != null) {
									if (curCat.Name == "Views") {
										//change LW
										curView.SetElementOverrides(curElem.Id, ogs);

										//increment counter
										counter = counter + 1;
									}
								}
							}
						}
					}
				}

				//commit changes
				curTrans.Commit();
			}

			return counter;

		}

		private List<View> getAllElevations(Document curDoc)
		{
			List<View> viewList = new List<View>();

			//get all views in current project
			FilteredElementCollector elevCollector = new FilteredElementCollector(curDoc);
			elevCollector.OfCategory(BuiltInCategory.OST_Views);

			//loop through each view and check type
			foreach (View curView in elevCollector.ToElements()) {
				if (curView.IsTemplate == false) {
					if (curView.GetType() == typeof(ViewSection)) {
						//add to list
						viewList.Add(curView);
					}
				}
			}

			return viewList;
		}
	}
}
