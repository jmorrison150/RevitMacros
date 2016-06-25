//
// Created by SharpDevelop.
// User: ArchSmarter.com
// Date: 10/2/2015
// Time: 10:35 AM
// 
// ArchSmarter Revit Macro Tempate - Revit 2016 - Version 1.0
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

	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	[Autodesk.Revit.DB.Macros.AddInId("22B7418D-5AFC-4651-993A-67A14F2B9DE3")]
	public partial class ThisDocument
	{

		public void RunExportSchedules()
		{
			//define current app and document
			UIApplication curUIApp = this.Application;
			Document curDoc = curUIApp.ActiveUIDocument.Document;

			//export schedules
			mExportSchedules.ExportSchedules(curDoc);

		}
	}
}
