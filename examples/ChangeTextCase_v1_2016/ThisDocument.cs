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

		public void convertAllTextToUpper()
		{
			convertText("upper");

		}

		public void convertAllTextToLower()
		{
			convertText("lower");

		}

		public void convertAllTextToTitle()
		{
			convertText("title");

		}

		private void convertText(string convertType)
		{
			//define current document
			Document curDoc = this.Application.ActiveUIDocument.Document;

			int counter = 0;

			//get all text notes
			List<TextNote> noteList = getAllTextNotes(curDoc);

			using (Transaction curTrans = new Transaction(curDoc, "Current Transaction")) {
				if (curTrans.Start() == TransactionStatus.Started) {

					foreach (TextNote curNote in noteList) {
						switch (convertType) {
							case "upper":
								curNote.Text = curNote.Text.ToUpper();
								break;

							case "lower":
								curNote.Text = curNote.Text.ToLower();
								break;

							case "title":
								curNote.Text = curNote.Text.ToLower();
								curNote.Text = Strings.StrConv(curNote.Text, VbStrConv.ProperCase);
								break;
						}

						//increment counter
						counter = counter + 1;
					}
				}

				//commit changes
				curTrans.Commit();
			}

			//alert user
			TaskDialog.Show("Complete", "Converted " + counter + " text notes.");

		}

//get all text notes in the current model
		public List<TextNote> getAllTextNotes(Document curDoc)
		{
			//get all text notes
			FilteredElementCollector curCollector = new FilteredElementCollector(curDoc);
			curCollector.OfClass(typeof(TextNote));

			//create list for text notes
			List<TextNote> noteList = new List<TextNote>();

			//loop through text notes and add to list
			foreach (TextNote curNote in curCollector) {
				//add to list
				noteList.Add(curNote);
			}

			return noteList;
		}
	}
}
