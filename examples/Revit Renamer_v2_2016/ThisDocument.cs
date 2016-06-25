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

		public void RunRenamer()
		{
			//define current docucment
			Document curDoc = this.Application.ActiveUIDocument.Document;

			//run renamer
			mRenamer.RevitRenamer(curDoc);

		}

	}
}
