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

		public void RunFontReplace()
		{
			//open form
			using (frmSelectFonts curForm = new frmSelectFonts(this.Application.ActiveUIDocument.Document)) {
				//show form
				curForm.ShowDialog();

				if (curForm.DialogResult == System.Windows.Forms.DialogResult.Cancel) {
				//Result.Cancelled
				} else {
					if (curForm.getOldFont() != null) {
						if (curForm.getNewFont() != null) {
							//replace fonts
							int counter = ReplaceFont(curForm.getOldFont(), curForm.getNewFont());

							//alert user
							if (counter == 1) {
								TaskDialog.Show("Complete", "Replaced font in " + counter + " text style.");
							} else {
								TaskDialog.Show("Complete", "Replaced font in " + counter + " text styles.");
							}
						} else {
							TaskDialog.Show("Error", "Please select a new font.");
						}
					} else {
						TaskDialog.Show("Error", "Please select a font to replace.");
					}
				}
			}
		}

		private int ReplaceFont(string oldFont, string newFont)
		{
			//Get the current document
			Document curDoc = this.Application.ActiveUIDocument.Document;

			int counter = 0;

			//Dim oldFont As String = "Arial"
			//Dim newFont As String = "Times New Roman"

			//get all text styles in current model
			FilteredElementCollector textStyleCol = new FilteredElementCollector(curDoc);
			textStyleCol.OfClass(typeof(TextNoteType));

			//loop through text styles and look for matching font
			using (Transaction curTrans = new Transaction(curDoc, "Replace Fonts")) {
				if (curTrans.Start() == TransactionStatus.Started) {

					foreach (TextNoteType curType in textStyleCol) {
						Debug.Print(curType.Name);

						//get font
						string curFont = functions.getParameterValue((Element)curType, "Text Font");

						if (curFont == oldFont) {
							Debug.Print("Found matching font");

							//do something
							functions.setParameterValueString((Element)curType, "Text Font", newFont);

							//increment counter
							counter = counter + 1;
						}

					}
				}

				//commit changes
				curTrans.Commit();
			}

			return counter;
		}

	}
}
