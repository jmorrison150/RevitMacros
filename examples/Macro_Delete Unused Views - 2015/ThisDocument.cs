//
// Created by SharpDevelop.
// User: ArchSmarter.com
// Date: 12/02/2014
// Time: 10:39 PM
//
//This macro deletes all views not on a sheet or not containing the specified name prefix in the current model file. 

using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
namespace archSmarter {

	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	[Autodesk.Revit.DB.Macros.AddInId("FAE40FBF-A1C7-4FD0-AD98-931C197BC17D")]
	public partial class ThisDocument {
		public void DeleteUnusedViews() {
			//set current document
			Autodesk.Revit.DB.Document curDoc = this.Application.ActiveUIDocument.Document;

			//set prefix of views to keep
			string viewPrefix = "working_";

			//create string for list of views
			string viewDeleteString = "";

			//alert user that this macro will delete views
			Autodesk.Revit.UI.TaskDialog userAlert = new TaskDialog("Warning");
			userAlert.MainInstruction = "This macro will delete all views that are not on a sheet or are not named with the '" + viewPrefix + "' prefix. Are you sure you want to proceed?";
			userAlert.AddCommandLink(Autodesk.Revit.UI.TaskDialogCommandLinkId.CommandLink1, "Yes");
			userAlert.AddCommandLink(Autodesk.Revit.UI.TaskDialogCommandLinkId.CommandLink2, "No");

			Autodesk.Revit.UI.TaskDialogResult userAlertResults = userAlert.Show();

			if(TaskDialogResult.CommandLink2 == userAlertResults) {
				//cancel sub
				return;
			}

			//delete views 
			viewDeleteString = DeleteViews(curDoc, viewPrefix);

			//check if no views were deleted - if so then exit sub
			if(viewDeleteString == null) {
				return;
			}

			//delete views again to remove any dependent views
			viewDeleteString = viewDeleteString + DeleteViews(curDoc, viewPrefix);

			//alert user
			if(!string.IsNullOrEmpty(viewDeleteString)) {
				TaskDialog.Show("Deleted Views", "Deleted the following views: " + viewDeleteString);
			}

		}
		private ViewSheet getSheetView(Document curDoc) {
			//get all sheet views
			Autodesk.Revit.DB.FilteredElementCollector sheetCollector = new FilteredElementCollector(curDoc);
			sheetCollector.OfCategory(Autodesk.Revit.DB.BuiltInCategory.OST_Sheets).ToElements();

			//return first sheet
			return (ViewSheet) sheetCollector.FirstElement();

		}
		private string DeleteViews(Document curDoc, string viewsToKeepPrefix) {
			//string functionReturnValue = null;
			//collect all views in current model file
			FilteredElementCollector viewCollector = new FilteredElementCollector(curDoc);
			viewCollector.OfCategory(BuiltInCategory.OST_Views);

			//collect all sheets in current model file
			FilteredElementCollector sheetCollector = new FilteredElementCollector(curDoc);
			sheetCollector.OfCategory(BuiltInCategory.OST_Sheets);

			//check if there are any sheets in this model file - if not then alert user
			if(sheetCollector.Count() < 1) {
				//alert user
				TaskDialog dialog = new TaskDialog("Error");
				dialog.MainInstruction = "This model file does not contain any sheets. At least one sheet is needed to delete unused views.";
				dialog.MainIcon = TaskDialogIcon.TaskDialogIconWarning;
				dialog.Show();
				return null;
				//return functionReturnValue;
			}

			//get sheet to test views against
			ViewSheet tempSheet = null;
			tempSheet = (ViewSheet) sheetCollector.FirstElement();

			//create list of views to delete
			List<View> viewDeleteList = new List<View>();

			//create string for list of views
			string viewDeleteString = "";

			//loop through each view and check if it can be put onto a sheet
			foreach(View curView in viewCollector) {
				//check if current view is a template - skip view if template
				if(curView.IsTemplate == false) {
					//check if view has dependent views
					if(curView.GetDependentViewIds().Count == 0) {
						//check if view can be put on sheet - if it can then put in list of views to delete
						if(Viewport.CanAddViewToSheet(curDoc, tempSheet.Id, curView.Id) == true) {
							//check if view has prefix
							if(!curView.Name.StartsWith(viewsToKeepPrefix)) {
								//add view to delete list
								viewDeleteList.Add(curView);
							}
						}
					}
				}
			}

			//change the current view to the first sheet view
			ViewSheet curSheetView = getSheetView(curDoc);
			this.Application.ActiveUIDocument.ActiveView = curSheetView;

			//if there are views to delete then delete them
			if(viewDeleteList.Count > 0) {
				//create transaction and delete unused views
				using(Transaction curTrans = new Transaction(curDoc, "Delete views")) {
					if(curTrans.Start() == TransactionStatus.Started) {
						//loop through views to delete list and delete views
						foreach(View deleteView in viewDeleteList) {
							//add view to deleted view string
							viewDeleteString = viewDeleteString + " " + deleteView.Name + ", ";
							//delete view
							try {
								curDoc.Delete(deleteView.Id);

							} catch(Exception ex) {
								TaskDialog.Show("error", "Could not delete view " + deleteView.Name);
							}
						}
					}

					//commit changes to the model
					curTrans.Commit();

				}
			}

			//return list of deleted views
			return viewDeleteString;
			//return functionReturnValue;

		}
	}
}
