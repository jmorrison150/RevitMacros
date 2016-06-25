//
// Created by SharpDevelop.
// User: michael
// Date: 4/2/2015
// Time: 12:21 PM
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

	public class clsCollectors
	{
		public List<ViewSheet> getAllSheets(Document curDoc)
		{
			//get all sheets
			FilteredElementCollector m_colViews = new FilteredElementCollector(curDoc);
			m_colViews.OfCategory(BuiltInCategory.OST_Sheets);

			List<ViewSheet> m_Sheets = new List<ViewSheet>();
			foreach (ViewSheet x in m_colViews.ToElements()) {
				m_Sheets.Add(x);
			}

			return m_Sheets;
		}

		public List<Viewport> getAllViewports(Document curDoc)
		{
			//get all viewports
			FilteredElementCollector vpCollector = new FilteredElementCollector(curDoc);
			vpCollector.OfCategory(BuiltInCategory.OST_Viewports);

			//output viewports to list
			List<Viewport> vpList = new List<Viewport>();
			foreach (Viewport curVP in vpCollector) {
				//add to list
				vpList.Add(curVP);
			}

			return vpList;

		}
	}
}
