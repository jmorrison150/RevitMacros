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
using System.IO;
namespace archSmarter {

	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	[Autodesk.Revit.DB.Macros.AddInId("FAE40FBF-A1C7-4FD0-AD98-931C197BC17D")]
	public partial class ThisDocument {

		public struct structDWG {
			//structure for DWG file information
			public string fileName;
			public string linkView;
		}

		public void LinkDWGsFromCSV() {
			//set the current document
			Document curDoc = this.Application.ActiveUIDocument.Document;
			int counter = 0;

			//open form
			using(frmSelectFiles curForm = new frmSelectFiles()) {
				//show form
				curForm.ShowDialog();

				if(curForm.DialogResult == System.Windows.Forms.DialogResult.Cancel) {
					//Result.Cancelled
					curForm.Close();
				} else {
					//close form
					curForm.Close();

					//set CSV file
					string CSVFile = curForm.getCSVFile();

					//set import options
					DWGImportOptions curOptions = new DWGImportOptions();
					curOptions.ThisViewOnly = false;
					curOptions.ColorMode = ImportColorMode.BlackAndWhite;
					curOptions.Placement = ImportPlacement.Origin;
					curOptions.Unit = ImportUnit.Default;

					//set current link ID
					ElementId curLinkID = null;

					//read CSV file and create sheet based on info
					IList<structDWG> fileList = default(IList<structDWG>);
					fileList = ReadCSV(CSVFile, true);

					using(Transaction t = new Transaction(curDoc, "Link - Import DWGs")) {
						if(t.Start() == TransactionStatus.Started) {

							//loop through DWG files and insert at correct level
							foreach(structDWG curDWG in fileList) {
								//get level
								View curView = getViewByName(curDWG.linkView, curDoc);

								//check if file exists
								string curFile = curDWG.fileName;
								if(File.Exists(curFile) == true) {

									//check if link or insert
									if(curForm.GetLinkInsert() == "link") {
										//insert DWG to specified level
										try {
											if(curDoc.Link(curFile, curOptions, curView, out curLinkID) == true) {


												Debug.Print("Created link for " + curDWG.fileName);
												counter = counter + 1;
											}
										} catch(Exception ex) {
											TaskDialog.Show("Error", "Could not create link for file " + curDWG.fileName + ".");
										}
									} else {
										//insert DWG to specified level
										try {
											if(curDoc.Import(curFile, curOptions, curView, out curLinkID) == true) {
												Debug.Print("Imported " + curDWG.fileName);
												counter = counter + 1;
											}
										} catch(Exception ex) {
											TaskDialog.Show("Error", "Could not import file " + curDWG.fileName);
										}
									}
								} else {
									//alert user file cannot be found
									TaskDialog.Show("Alert", "Cannot find file - " + curFile);
								}
							}
						}

						//commit changes
						t.Commit();

					}

					//alert user
					if(curForm.GetLinkInsert() == "import") {
						TaskDialog.Show("Import DWGs", "Imported " + counter + "DWG files.");
					} else {
						//alert user
						TaskDialog.Show("Link DWG from CSV", "Linked " + counter + " DWG files.");
					}

				}
			}


		}

		private List<structDWG> ReadCSV(string filePathName, bool hasHeaders) {
			List<structDWG> dwgList = new List<structDWG>();

			using(Microsoft.VisualBasic.FileIO.TextFieldParser MyReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(filePathName)) {
				MyReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
				MyReader.Delimiters = new string[] { "," };
				string[] currentRow = null;

				//if CSV file has headers then discard first line
				if(hasHeaders == true) {
					MyReader.ReadLine().Skip(1);
				}

				while(!MyReader.EndOfData) {
					try {
						currentRow = MyReader.ReadFields();

						//create temp sheet
						structDWG curFile = new structDWG();
						curFile.fileName = currentRow[0];
						curFile.linkView = currentRow[1];

						//add sheet to list
						dwgList.Add(curFile);

					} catch(Microsoft.VisualBasic.FileIO.MalformedLineException ex) {
						Debug.Print("Line " + ex.Message + " is invalid.  Skipping");
					}
				}

				return dwgList;
			}

		}

		private View getViewByName(string viewName, Document curDoc) {
			View functionReturnValue = default(View);
			Autodesk.Revit.DB.FilteredElementCollector m_colViews = new FilteredElementCollector(curDoc);
			m_colViews.OfCategory(BuiltInCategory.OST_Views);
			m_colViews.OfClass(typeof(ViewPlan)).ToElements();

			//loop through views in the collector
			foreach(View curView in m_colViews) {
				if(curView.Name == viewName) {
					return curView;
					//return functionReturnValue;
				}
			}

			return null;
			return functionReturnValue;
		}

	}
}
