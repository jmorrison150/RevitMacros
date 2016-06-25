//
// Created by SharpDevelop.
// User: michael
// Date: 2/1/2016
// Time: 12:10 PM
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

	public static class mExportSchedules
	{

		public static void ExportSchedules(Document curDoc)
		{
			int counter = 0;

			ViewScheduleExportOptions curOptions = new ViewScheduleExportOptions();
			curOptions.ColumnHeaders = ExportColumnHeaders.MultipleRows;

			//open form
			using (frmForm curForm = new frmForm(curDoc)) {
				//show form
				curForm.ShowDialog();

				if (curForm.DialogResult == System.Windows.Forms.DialogResult.Cancel) {
					//Cancel pressed - do something
					return;
				} else {
					//check if folder path selected
					if (!string.IsNullOrEmpty(curForm.getSelectedFolder())) {
						List<string> schedList = curForm.getSelectedSchedules();

						//loop through each schedule and export
						foreach (string tmpSched in schedList) {
							//get selected schedule
							ViewSchedule curSched = getScheduleByName(curDoc, tmpSched);
							string exportFile = curSched.Name + ".csv";

							try {
								curSched.Export(curForm.getSelectedFolder(), exportFile, curOptions);
								counter = counter + 1;
							} catch (Exception ex) {
								TaskDialog.Show("Error", "Could not export schedule " + curSched.Name);

							}

						}
					} else {
						TaskDialog.Show("Error", "Please select an export folder path.");
						return;
					}

				}
			}

			//alert user
			TaskDialog.Show("Complete", "Exported " + counter + " schedules.");

		}

//------------------collectors--------------------------------------------

		public static List<ViewSchedule> getAllSchedules(Document curDoc)
		{
			List<ViewSchedule> schedList = new List<ViewSchedule>();

			FilteredElementCollector curCollector = new FilteredElementCollector(curDoc);
			curCollector.OfClass(typeof(ViewSchedule));

			//loop through views and check if schedule - if so then put into schedule list
			foreach (ViewSchedule curView in curCollector) {
				if (curView.ViewType == ViewType.Schedule) {
					schedList.Add((ViewSchedule)curView);
				}
			}

			return schedList;
		}

		//return the specified area plan
		public static ViewSchedule getScheduleByName(Document curDoc, string schedName)
		{
			ViewSchedule functionReturnValue = null;
			//collect all schedules in current model
			List<ViewSchedule> viewCollector = getAllSchedules(curDoc);

			//loop through collection
			foreach (ViewSchedule curView in viewCollector) {
				if (curView.Name == schedName) {
					//return specified schedule
					return curView;
					return functionReturnValue;
				}
			}

			return null;
			return functionReturnValue;
		}

	}
}
