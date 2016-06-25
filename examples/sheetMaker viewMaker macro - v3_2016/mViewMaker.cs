//
// Created by SharpDevelop.
// User: michael
// Date: 1/7/2016
// Time: 1:09 PM
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

	public static class mViewMaker
	{

		public static void runViewMaker(Document curDoc)
		{
			string viewType = null;

			//open form
			using (frmViewMaker curForm = new frmViewMaker(curDoc)) {
				//show form
				curForm.ShowDialog();

				if (curForm.DialogResult == System.Windows.Forms.DialogResult.Cancel) {
					//Result.Cancelled
					return;
				} else if (curForm.DialogResult == System.Windows.Forms.DialogResult.OK) {
					//create views

					//get view type from view family type
					viewType = mFunctions.GetViewTypeFromViewFamily(curDoc, curForm.getViewFamilyType());

					//create new views
					mViewMaker.CreateViews(curDoc, viewType, curForm.getViewFamilyType(), curForm.getViewTemplate(), curForm.getScopeBox(), curForm.getDesignOption(), curForm.getLevels());

				}
			}

		}

		public static void CreateViews(Document curDoc, string viewType, string viewFamilyType, string viewTemplate, string scopeBox, string designOpt, List<Level> m_levels)
		{
			//creates plan or RCP views for each floor level in the supplied model

			//set view type
			ViewFamily viewTypeSetting = default(ViewFamily);
			if (viewType == "CeilingPlan") {
				viewTypeSetting = ViewFamily.CeilingPlan;
			} else if (viewType == "AreaPlan") {
				viewTypeSetting = ViewFamily.AreaPlan;
			} else if (viewType == "StructuralPlan") {
				viewTypeSetting = ViewFamily.StructuralPlan;
			} else {
				viewTypeSetting = ViewFamily.FloorPlan;
			}

			//get list of view types
			List<ViewFamilyType> m_vt = new List<ViewFamilyType>();
			m_vt = mFunctions.getViewTypes(curDoc);

			//success and error list
			List<string> m_s = new List<string>();
			List<string> m_e = new List<string>();

			//new transaction
			using (Transaction t = new Transaction(curDoc, "Create views")) {

				//start transaction
				if (t.Start() == TransactionStatus.Started) {

					//create a plan or RCP for specified levels
					foreach (Level lev in m_levels) {
						//views for plan only
						foreach (ViewFamilyType vt in m_vt) {
							if (vt.Name == viewFamilyType) {
								try {
									//create the plan view
									ViewPlan m_fp = null;
									m_fp = ViewPlan.Create(curDoc, vt.Id, lev.Id);

									//rename the view
									m_fp.Name = lev.Name.ToUpper() + " " + vt.Name.ToUpper();
									m_s.Add(lev.Name.ToUpper() + " " + vt.Name.ToUpper());

									//modify the view as needed
									//-----------------------------------------------------
									//add view template to view
									if (viewTemplate != "None") {
										m_fp.ViewTemplateId = mFunctions.getViewTemplateID(viewTemplate, curDoc);
									}

									//add scope box to view
									if (scopeBox != "None") {
										Parameter curParam = null;
										curParam = m_fp.get_Parameter(BuiltInParameter.VIEWER_VOLUME_OF_INTEREST_CROP);

										if (curParam.Definition.Name.ToString() == "Scope Box") {
											//check if scope box exist
											if (mFunctions.doesScopeBoxExist(scopeBox, curDoc)) {
												try {
													//set scope box value
													curParam.Set(mFunctions.getScopeBoxID(scopeBox, curDoc));
												} catch (Exception ex) {
													Debug.Print(ex.Message);
												}
											} else {
												Debug.Print("SCOPE BOX DOESN'T EXIST");
											}
										}
									}

									//add design option to view
									if (designOpt != "None") {
										//assign selected design option to view
										DesignOption curDesignOption = mFunctions.getDesignOptionByName(curDoc, designOpt);

										Parameter desOptParam = m_fp.get_Parameter(BuiltInParameter.VIEWER_OPTION_VISIBILITY);

										try {
											desOptParam.Set(curDesignOption.Id);
										} catch (Exception ex) {
											TaskDialog.Show("error", "could not set design option paramerter");
										}
									}

								} catch (Exception ex) {
									m_e.Add(ex.Message + ": " + lev.Name.ToUpper() + " " + vt.Name.ToUpper());
								}
							}
						}
					}

					//report views created
					if (m_s.Count > 0) {
						using (TaskDialog m_td = new TaskDialog("Success")) {
							m_td.MainInstruction = "Created views:";
							foreach (string x_loopVariable in m_s) {
								m_td.MainContent += x_loopVariable + Constants.vbCr;
							}
							m_td.Show();
						}
					}

					//report errors if any
					if (m_e.Count > 0) {
						using (TaskDialog m_td = new TaskDialog("Errors")) {
							m_td.MainInstruction = "Issues with views:";
							foreach (string x_loopVariable in m_e) {
								m_td.MainContent += x_loopVariable + Constants.vbCr;
							}
							m_td.Show();
						}
					}

					//commit
					t.Commit();

				}
			}
		}

	}
}
