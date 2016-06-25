//
// Created by SharpDevelop.
// User: michael
// Date: 11/2/2015
// Time: 10:18 PM
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

	public static class mCollectors
	{
//----------------------------------------------------
		//collectors
		//----------------------------------------------------
		public static List<ViewSheet> getAllSheets(Document m_doc)
		{
			//get all views
			FilteredElementCollector m_colViews = new FilteredElementCollector(m_doc);
			m_colViews.OfCategory(BuiltInCategory.OST_Sheets);

			List<ViewSheet> m_Sheets = new List<ViewSheet>();
			foreach (ViewSheet x in m_colViews.ToElements()) {
				m_Sheets.Add(x);
			}

			return m_Sheets;
		}

		public static List<Room> getAllRooms(Document curDoc)
		{
			//get all rooms
			FilteredElementCollector curCollector = new FilteredElementCollector(curDoc);
			curCollector.OfCategory(BuiltInCategory.OST_Rooms);

			List<Room> roomList = new List<Room>();
			foreach (Room curRoom in curCollector.ToElements()) {
				roomList.Add(curRoom);
			}

			return roomList;

		}

		public static List<View> getAllViews(Document curDoc)
		{
			//get all views
			FilteredElementCollector curCollector = new FilteredElementCollector(curDoc);
			curCollector.OfCategory(BuiltInCategory.OST_Views);

			List<View> viewList = new List<View>();
			foreach (View curView in curCollector.ToElements()) {
				viewList.Add(curView);
			}

			return viewList;
		}

		public static List<ViewFamilyType> getAllViewTypes(Document m_doc)
		{
			//get list of view types
			FilteredElementCollector m_colVT = new FilteredElementCollector(m_doc);
			m_colVT.OfClass(typeof(ViewFamilyType));

			List<ViewFamilyType> m_vt = new List<ViewFamilyType>();
			foreach (ViewFamilyType x in m_colVT.ToElements()) {
				m_vt.Add(x);
			}

			return m_vt;

		}

		public static ElementId getDraftingViewFamilyTypeID(Document curDoc)
		{
			ElementId functionReturnValue = null;
			//get list of view types
			List<ViewFamilyType> vTypes = getAllViewTypes(curDoc);

			foreach (ViewFamilyType x in vTypes) {
				if (x.ViewFamily == ViewFamily.Drafting) {
					return x.Id;
					//return functionReturnValue;
				}
			}

			return null;
			//return functionReturnValue;

		}

	}
}
