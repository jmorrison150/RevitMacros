//
// Created by SharpDevelop.
// User: michael
// Date: 9/16/2014
// Time: 11:38 PM
// 
// To change this template use Tools | Options | Coding | Edit Standard Headers.
//
using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using System.Diagnostics;
namespace ArchSmarter
{

	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	[Autodesk.Revit.DB.Macros.AddInId("7E9EAA56-EC05-41B5-BC37-BF6FAA2BE120")]
	public partial class ThisDocument
	{

		public void WallsFromLines()
		{
			//open form
			using (frmWallsFromLines curForm = new frmWallsFromLines(this.Application.ActiveUIDocument.Document)) {
				//show form
				curForm.ShowDialog();

				if (curForm.DialogResult == System.Windows.Forms.DialogResult.Cancel) {
				//Result.Cancelled
				} else {
					//make the walls - use "0" to set wall location line to centerline
					CreateWallsFromLines(curForm.getLinetype(), curForm.getWallType(), curForm.getLevel(), 0, curForm.getHeight());

				}
			}

		}
		private void CreateWallsFromLines(string lineStyle, string wallType, string selLevel, int wallLocLine, double wallHeight)
		{
			//get lines
			List<ModelCurve> linesToConvert = new List<ModelCurve>();
			linesToConvert = getModelLinesByStyle(this.Application.ActiveUIDocument.Document, lineStyle);

			//get wall type
			WallType curWallType = null;
			curWallType = getWallType(this.Application.ActiveUIDocument.Document, wallType);

			//get level
			Level curLevel = null;
			curLevel = getLevel(this.Application.ActiveUIDocument.Document, selLevel);

			//create the walls
			if (linesToConvert.Count > 0) {
				using (Transaction t = new Transaction(this.Application.ActiveUIDocument.Document, "add walls")) {
					if (t.Start() == TransactionStatus.Started) {
						//loop through lines and create walls
						foreach (ModelCurve curLine in linesToConvert) {

							//create new wall
							try {
								Wall newWall = null;
								newWall = Wall.Create(this.Application.ActiveUIDocument.Document, curLine.GeometryCurve, curWallType.Id, curLevel.Id, wallHeight, 0, false, false);

							//reset wall location line based on argument value
							//newWall.Parameter(BuiltInParameter.WALL_KEY_REF_PARAM).Set(wallLocLine)

							} catch (Exception ex) {
								//alert user - can't create wall
								TaskDialog.Show("Error", "Could not create wall.");

							}

						}
					}

					//commit changes
					t.Commit();
				}
			}
		}

//---------------------------------------------------------------------
//------------------------------collectors-----------------------------

		public List<Level> getAllLevels(Document m_doc)
		{
			//returns list of all the levels in the current model - used by dialog box
			FilteredElementCollector m_colLevels = new FilteredElementCollector(m_doc);
			m_colLevels.OfCategory(BuiltInCategory.OST_Levels).ToElements();

			List<Level> m_levels = new List<Level>();
			foreach (Level curLevel_loopVariable in m_colLevels.ToElements()) {
				//Level curLevel = Level.Create(m_doc,curLevel_loopVariable);
				m_levels.Add(curLevel_loopVariable);
			}

			return m_levels;

		}
		public Level getLevel(Document m_doc, string levelName)
		{
			//returns level object from level string name
			FilteredElementCollector m_colLevels = new FilteredElementCollector(m_doc);
			m_colLevels.OfCategory(BuiltInCategory.OST_Levels).ToElements();

			foreach (Element curLevel_loopVariable in m_colLevels.ToElements()) {
				Level curLevel = (Level) curLevel_loopVariable;
				if (curLevel.Name.ToString() == levelName ) {
					return curLevel;
				}
			}
			return Level.Create(m_doc, 0.0);

		}
		public List<ModelCurve> getModelLinesByStyle(Document m_doc, string lineStyle)
		{
			//returns list containing all the models lines of the specific model line style
			List<ModelCurve> lineList = new List<ModelCurve>();
			FilteredElementCollector curCollector = new FilteredElementCollector(m_doc);
			CurveElementFilter curFilter = new CurveElementFilter(CurveElementType.ModelCurve);
			//GraphicsStyle curLineStyle = null;
			string curLineStyle;

			//loop through the elements - if element is a model line then add to list
			foreach (ModelCurve curCurve in curCollector.WherePasses(curFilter)) {
				curLineStyle = curCurve.LineStyle.ToString();
				
				if ( curLineStyle == lineStyle) {
					//add curve to list
					lineList.Add(curCurve);
				}
			}

			return lineList;
		}
		public List<string> getModelLineStyles(Document m_doc)
		{
			//returns list of all model line styles in current model - used by dialog box
			List<string> lineList = new List<string>();
			FilteredElementCollector curCollector = new FilteredElementCollector(m_doc);
			CurveElementFilter curFilter = new CurveElementFilter(CurveElementType.ModelCurve);
			//GraphicsStyle curLineStyle = null;

			//need to filter our arcs and other curved lines
			foreach (ModelCurve curLine in curCollector.WherePasses(curFilter).ToElements()) {
			//	curLineStyle = curLine.LineStyle;
				lineList.Add(curLine.LineStyle.Name.ToString());
					
			}

			//purge duplicates from list
			for (int i = lineList.Count - 1; i >= 1; i += -1) {
				if (lineList[i] == lineList[i - 1]) {
					lineList.RemoveAt(i);
				}
			}

			return lineList;

		}
		public List<string> getAllWallTypes(Document m_doc)
		{
			//returns list of all wall types in current model - used by dialog box
			List<string> wallList = new List<string>();
			FilteredElementCollector curCollector = new FilteredElementCollector(m_doc);
			curCollector.OfClass(typeof(WallType)).ToElements();

			foreach (WallType curWallType in curCollector) {
				//add wall type to list
				wallList.Add(curWallType.Name.ToString());
			}

			return wallList;

		}
		public WallType getWallType(Document m_doc, string wallTypeName)
		{
			//returns wall type object from specified wall type string
			FilteredElementCollector curCollector = new FilteredElementCollector(m_doc);
			curCollector.OfClass(typeof(WallType)).ToElements();

			foreach (WallType curWallType in curCollector) {
				if (curWallType.Name.ToString() == wallTypeName ) {
					return curWallType;
				}
			}
			return null;
		}

	}
}
