//
// Created by SharpDevelop.
// User: michael
// Date: 1/4/2016
// Time: 12:28 PM
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

	public static class mSheetMaker
	{
		public struct structSheet
		{
			//structure for sheet information
			public string sheetNum;
			public string sheetName;
			public string viewName;
		}

		public static void runSheetMaker(Document curDoc)
		{
			//open form
			using (frmSheetMaker curForm = new frmSheetMaker(curDoc)) {
				//show form
				curForm.ShowDialog();

				if (curForm.DialogResult == System.Windows.Forms.DialogResult.Cancel) {
				//Result.Cancelled
				} else {
					string vPortName = "Viewport 1";

					//create the sheets
					makeSheets(curDoc, curForm.getTblock(), vPortName, curForm.getCSVFile(), curForm.getSheetType());

				}
			}
		}

		public static void makeSheets(Document curDoc, string[] tblockName, string vPortName, string CSVFile, string sheetType)
		{
			//arguments are: document, title block to use for new sheets, viewport type for views and path to CSV file with sheet names, numbers and views

			//check if title block exists
			FamilySymbol tblock = null;
			if (mFunctions.doesTblockExist(curDoc, tblockName) == true) {
				//get tblock
				tblock = mFunctions.getTitleblock(curDoc, tblockName);
			} else {
				TaskDialog.Show("alert", "Could not find titleblock");
				return;
			}

			//success and failures
			List<string> m_s = new List<string>();
			List<string> m_f = new List<string>();

			//check if CSV file exists
			if (System.IO.File.Exists(CSVFile) == false) {
				//file doesn't exist - abort
				TaskDialog.Show("Error", "The CSV file " + CSVFile + " cannot be found.");
				return;
			}

			//transaction
			using (Transaction t = new Transaction(curDoc, "Create Sheets")) {
				if (t.Start() == TransactionStatus.Started) {
					//the sheet object
					ViewSheet m_vs = null;

					//read CSV file and create sheet based on info
					IList<structSheet> sheetList = null;
					sheetList = mFunctions.ReadCSV(CSVFile, true);

					//create sheet for each sheet in list
					foreach (structSheet curSheet in sheetList) {
						try {
							//create sheets
							if (sheetType == "Placeholder Sheet") {
								m_vs = ViewSheet.CreatePlaceholder(curDoc);
							} else {
								m_vs = ViewSheet.Create(curDoc, tblock.Id);
							}

							m_vs.Name = curSheet.sheetName;
							m_vs.SheetNumber = curSheet.sheetNum;

							//record success
							m_s.Add("Created sheet: " + m_vs.SheetNumber + " " + Constants.vbCr);

							//loop through view string and add views to sheet
							foreach (string tmpView in curSheet.viewName.Split(new char[] { ',' })) {
								//get current view
								View curView = mFunctions.getView(tmpView.Trim(), curDoc);

								Viewport curVP = null;
								try {
									if (Viewport.CanAddViewToSheet(curDoc, m_vs.Id, curView.Id)) {
										//add it
										curVP = Viewport.Create(curDoc, m_vs.Id, curView.Id, new XYZ(0, 0, 0));

										//center viewport on sheet
										mFunctions.centerViewOnSheet(curVP, curView, m_vs, curDoc);

										//change viewport type of plan view to no title
										ElementId vpTypeID = null;
										vpTypeID = mFunctions.getViewportTypeID(vPortName, curDoc);
										curVP.ChangeTypeId(vpTypeID);

										//record success
										m_s.Add("Added view: " + curView.Name + " " + Constants.vbCr);

									}
								} catch (Exception ex1) {
									m_f.Add("Could not add view " + tmpView + " to sheet " + m_vs.SheetNumber + Constants.vbCr);
								}
							}

						} catch (Exception ex2) {
							//record failure
							m_f.Add("sheet error: " + ex2.Message);
						}
					}

					//commit
					t.Commit();

					//report sheets created
					if (m_s.Count > 0) {
						using (TaskDialog m_td = new TaskDialog("Success!!")) {
							m_td.MainInstruction = "Created Sheets:";
							foreach (string x_loopVariable in m_s) {
								//x = x_loopVariable;
								m_td.MainContent += x_loopVariable;
							}

							//show dialog
							m_td.Show();

						}
					}

					if (m_f.Count > 0) {
						using (TaskDialog m_td2 = new TaskDialog("Failures")) {
							m_td2.MainInstruction = "Problems:";
							foreach (string x_loopVariable in m_f) {
								//x = x_loopVariable;
								m_td2.MainContent += x_loopVariable;
							}

							//show dialog
							m_td2.Show();

						}
					}
				}
			}
		}
	}
}
