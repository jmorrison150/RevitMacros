//
// Created by SharpDevelop.
// User: michael
// Date: 12/17/2015
// Time: 1:30 PM
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
using System.Globalization;
namespace ArchSmarter
{

	public static class mBatchDuplicate
	{
		public static void BatchDuplicateViews(Document curDoc)
		{
			int counter = 0;

			//open form
			using (frmDupViews curForm = new frmDupViews(curDoc)) {
				//show form
				curForm.ShowDialog();

				if (curForm.DialogResult == System.Windows.Forms.DialogResult.Cancel) {
					//Result.Cancelled
					return;
				} else {
					if (curForm.getSelectedViews().Count > 0) {
						//get selected view and view type
						List<clsView> viewList = curForm.getSelectedViews();

						//create transaction
						using (Transaction curTrans = new Transaction(curDoc, "Current Transaction")) {

							if (curTrans.Start() == TransactionStatus.Started) {
								//loop through view list and dup views
								foreach (clsView tmpView in viewList) {
									//get view from view name and view type
									View curView = getViewByNameAndType(curDoc, tmpView.viewType, tmpView.viewName);

									//duplicate view
									if (curView != null) {
										//set duplication settings based on user selection
										ViewDuplicateOption dupOptions = default(ViewDuplicateOption);

										switch (curForm.getDuplicateType()) {
											case "duplicate":
												dupOptions = ViewDuplicateOption.Duplicate;
												break;

											case "detailing":
												dupOptions = ViewDuplicateOption.WithDetailing;
												break;

											case "dependent":
												dupOptions = ViewDuplicateOption.AsDependent;
												break;

										}

										//loop through dup count and duplicate views
										for (int i = 1; i <= curForm.getNumDupes(); i++) {
											//duplicate view
											try {
												curView.Duplicate(dupOptions);
												counter = counter + 1;

											} catch (Exception ex) {
												TaskDialog.Show("Error", "Could not duplicate view.");
												throw;
											}
										}
									}
								}
							}

							//commit changes
							curTrans.Commit();
						}

						//alert user
						TaskDialog.Show("Complete", "Created " + counter + " view duplicates.");

					} else {
						//no views to duplicate
						TaskDialog.Show("Error", "Please select views to duplicate.");
						return;
					}
				}
			}

		}

//returns a list of all the views in the current model file
		public static List<View> getAllViews(Document curDoc)
		{
			//get all views
			FilteredElementCollector colViews = new FilteredElementCollector(curDoc);
			colViews.OfCategory(BuiltInCategory.OST_Views);

			List<View> curViews = new List<View>();
			foreach (View x in colViews) {
				if (x.IsTemplate == false) {
					curViews.Add(x);
				}
			}

			return curViews;
		}

//return the specified view
		public static View getViewByNameAndType(Document curDoc, string viewTypeName, string viewName)
		{
			//View functionReturnValue = null;
			//return the specified view by level
			List<View> viewCollector = getAllViews(curDoc);

			//loop through views and find match for levelName argument
			foreach(View tmpView in viewCollector) {
				//get view type name
				string tmpTypeName = tmpView.ViewType.ToString();

				//check if view name and view type name match current view - if so then return
				if(tmpView.Name == viewName && tmpTypeName == viewTypeName) {
					return tmpView;
					//return functionReturnValue;
				}
			}

			return null;
			//return functionReturnValue;
		}
	}
}
