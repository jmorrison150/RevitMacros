//
// Created by SharpDevelop.
// User: ArchSmarter.com
// Date: 7/26/2014
// Time: 10:39 PM
// 
// Batch Link RVT Files-v1-2016
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
using System.IO;
namespace archSmarter
{

	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	[Autodesk.Revit.DB.Macros.AddInId("FAE40FBF-A1C7-4FD0-AD98-931C197BC17D")]
	public partial class ThisDocument
	{

		public struct structDWG
		{
			//structure for DWG file information
			public string fileName;
			public string linkView;
		}

		public void BatchLinkRVT()
		{
			//set the current document
			Document curDoc = this.Application.ActiveUIDocument.Document;
			int counter = 0;

			//open form
			using (frmBatchLinkRVT curForm = new frmBatchLinkRVT()) {
				//show form
				curForm.ShowDialog();

				if (curForm.DialogResult == System.Windows.Forms.DialogResult.Cancel) {
					//Result.Cancelled
					curForm.Close();
				} else {
					//close form
					curForm.Close();

					//get selected files
					List<string> fileList = curForm.getSelectedFiles();

					//get selected positioning
					//Dim linkPosition As String = curForm.getPositioning

					//check if files were selected
					if (fileList.Count == 0) {
						//alert user
						TaskDialog.Show("Error", "Please select files to link.");
						return;
					} else {

						//create transaction
						using (Transaction curTrans = new Transaction(curDoc, "Batch Link RVT Files")) {
							if (curTrans.Start() == TransactionStatus.Started) {
								//link files
								foreach (string curFile in fileList) {

									//create link and insert
									try {
										//create link
										ElementId curLink = CreateRevitLink(curDoc, curFile);

										//insert instance of link
										RevitLinkInstance curLinkInstance = null;
										curLinkInstance = RevitLinkInstance.Create(curDoc, curLink);

										//increment counter
										counter = counter + 1;

									} catch (Exception ex) {
										TaskDialog.Show("Error", ex.Message);
									}

								}
							}

							//commit changes
							curTrans.Commit();
						}

					}
				}
			}

			//alert user
			if (counter > 0) {
				TaskDialog.Show("Complete", "Inserted " + counter + " RVT files.");
			}
		}

		public ElementId CreateRevitLink(Document doc, string pathName)
		{
			FilePath path = new FilePath(pathName);
			RevitLinkOptions options = new RevitLinkOptions(false);

			// Create new revit link storing absolute path to a file
			RevitLinkLoadResult result = RevitLinkType.Create(doc, path, options);
			return (result.ElementId);
		}

	}
}
