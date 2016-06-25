//
// Created by SharpDevelop.
// User: michael
// Date: 3/27/2015
// Time: 2:51 PM
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
namespace ArchSmarter
{

	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	[Autodesk.Revit.DB.Macros.AddInId("7BD4FE06-702E-4A54-88B0-A70EFD65F60B")]
	public partial class ThisDocument
	{

		public void AlignViews()
		{
			//Get the current document
			Document curDoc = this.Application.ActiveUIDocument.Document;

			//set counter 
			int counter = 0;

			//check if this model file has sheets and viewports
			if (doesModelHaveSheets(curDoc) == true) {
				if (doesModelHaveViewports(curDoc) == true) {
					//open form
					using (frmAlignViews curForm = new frmAlignViews(curDoc)) {
						//show form
						curForm.ShowDialog();

						if (curForm.DialogResult == System.Windows.Forms.DialogResult.Cancel) {
						//Result.Cancelled
						} else {
							//get selected views from form
							Viewport primaryView = curForm.getPrimaryView(curDoc);
							List<Viewport> viewAlignList = curForm.getViewList(curDoc);
							string alignType = curForm.getAlignmentType();

							//align views
							XYZ primaryCenter = primaryView.GetBoxCenter();
							Outline primaryOutline = primaryView.GetBoxOutline();

							//start transaction
							using (Transaction curTrans = new Transaction(curDoc, "Align Views")) {
								if (curTrans.Start() == TransactionStatus.Started) {
									foreach (Viewport curVP in viewAlignList) {

										if (curVP.Id != primaryView.Id) {
											XYZ newCenter = primaryCenter;

											//center current view
											curVP.SetBoxCenter(primaryCenter);

											XYZ delta = null;
											Outline curVPOutline = curVP.GetBoxOutline();
											XYZ d1;
											XYZ d2;

											//get new center based on alignment type
											switch (alignType) {
												case "Center":
													newCenter = primaryCenter;
													break;

												case "Top Left":
													d1 = new XYZ(primaryOutline.MinimumPoint.X, primaryOutline.MaximumPoint.Y, primaryOutline.MaximumPoint.Z);
													d2 = new XYZ(curVPOutline.MinimumPoint.X, curVPOutline.MaximumPoint.Y, curVPOutline.MaximumPoint.Z);

													delta = d2.Subtract(d1);
													newCenter = curVP.GetBoxCenter().Subtract(delta);
													break;

												case "Top Right":
													d1 = primaryOutline.MaximumPoint;
													d2 = curVPOutline.MaximumPoint;

													delta = d1.Subtract(d2);
													newCenter = curVP.GetBoxCenter().Add(delta);
													break;

												case "Bottom Left":
													d1 = primaryOutline.MinimumPoint;
													d2 = curVPOutline.MinimumPoint;

													delta = d2.Subtract(d1);
													newCenter = curVP.GetBoxCenter().Subtract(delta);
													break;

												case "Bottom Right":
													d1 = new XYZ(primaryOutline.MaximumPoint.X, primaryOutline.MinimumPoint.Y, primaryOutline.MaximumPoint.Z);
													d2 = new XYZ(curVPOutline.MaximumPoint.X, curVPOutline.MinimumPoint.Y, curVPOutline.MaximumPoint.Z);

													delta = d1.Subtract(d2);
													newCenter = curVP.GetBoxCenter().Add(delta);
													break;
											}

											//move to new center
											curVP.SetBoxCenter(newCenter);
											counter = counter + 1;
										}
									}

								}

								//commit changes
								curTrans.Commit();
							}
						}
					}

					//alert user
					if (counter > 0) {
						TaskDialog.Show("Complete", "Aligned " + counter + " views");
					}
				} else {
					TaskDialog.Show("Error", "The current model file does not contain any viewports.");
				}
			} else {
				TaskDialog.Show("Error", "The current model file does not contain any sheets.");
			}
		}

		private bool doesModelHaveSheets(Document curDoc)
		{
			//get all sheets
			clsCollectors collectors = new clsCollectors();
			List<ViewSheet> sheetList = collectors.getAllSheets(curDoc);

			//get sheet count
			if (sheetList.Count > 0) {
				return true;
			} else {
				return false;
			}
		}

		private bool doesModelHaveViewports(Document curDoc)
		{
			//get all viewports
			clsCollectors collectors = new clsCollectors();
			List<Viewport> vpList = collectors.getAllViewports(curDoc);

			//get vp count
			if (vpList.Count > 0) {
				return true;
			} else {
				return false;
			}
		}

	}
}
