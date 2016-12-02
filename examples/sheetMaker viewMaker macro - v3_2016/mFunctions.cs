using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Microsoft.VisualBasic;
namespace JRM {

  public static class mFunctions {

    //---------------- collectors ------------------------------------------
    public static FamilySymbol getTitleblock(Document curDoc, string[] tblockName) {
      //FamilySymbol functionReturnValue = null;
      //get all titleblocks
      List<FamilySymbol> tBlockList = getAllTitleblocks(curDoc);

      //loop through titleblocks and find specified tblock
      if (tBlockList.Count > 0) {
        //loop through tblocks
        foreach (FamilySymbol curTB in tBlockList) {
          if (curTB.FamilyName == tblockName[0] && curTB.Name == tblockName[1]
) {
            return curTB;
            //				return functionReturnValue;
          }
        }
      }

      return null;
      //return functionReturnValue;
    }
    public static List<FamilySymbol> getAllTitleblocks(Document curDoc) {
      //get all titleblocks
      FilteredElementCollector colTblock = new FilteredElementCollector(curDoc);
      colTblock.WhereElementIsElementType();
      colTblock.OfCategory(BuiltInCategory.OST_TitleBlocks);

      List<FamilySymbol> tBlockList = new List<FamilySymbol>();
      foreach (Element curElem in colTblock.ToElements()) {
        FamilySymbol curTB = (FamilySymbol)curElem;
        tBlockList.Add(curTB);
      }

      return tBlockList;
    }
    public static List<string> getAllTitleblockNames(Document curDoc) {
      //get all titleblocks
      List<FamilySymbol> tBlockList = getAllTitleblocks(curDoc);
      List<string> tBlockNames = new List<string>();

      foreach (FamilySymbol curTB in tBlockList) {
        tBlockNames.Add(curTB.FamilyName + " | " + curTB.Name);
      }

      return tBlockNames;

    }
    public static View getView(string viewName, Document m_doc) {
      //View functionReturnValue = null;
      //get all views
      FilteredElementCollector m_colViews = new FilteredElementCollector(m_doc);
      m_colViews.OfCategory(BuiltInCategory.OST_Views);

      List<View> m_Views = new List<View>();
      foreach (View x in m_colViews.ToElements()) {
        if (x.Name == viewName // ERROR: Unknown binary operator Like
) {
          return x;
          //return functionReturnValue;
        }
      }

      return null;
      //return functionReturnValue;

    }
    public static List<ViewFamilyType> getViewTypes(Document m_doc) {
      //get list of view types
      FilteredElementCollector m_colVT = new FilteredElementCollector(m_doc);
      m_colVT.OfClass(typeof(ViewFamilyType));

      List<ViewFamilyType> m_vt = new List<ViewFamilyType>();
      foreach (ViewFamilyType x in m_colVT.ToElements()) {
        m_vt.Add(x);
      }

      return m_vt;

    }
    public static List<Level> getAllLevels(Document m_doc) {
      FilteredElementCollector m_colLevels = new FilteredElementCollector(m_doc);
      m_colLevels.OfCategory(BuiltInCategory.OST_Levels);

      List<Level> m_levels = new List<Level>();
      foreach (Element x_loopVariable in m_colLevels.ToElements()) {
        Level x = (Level)x_loopVariable;
        if (x is Level) {
          m_levels.Add((Level)x);
        }
      }

      return m_levels;

    }
    public static List<DesignOption> getAllDesignOptions(Document curDoc) {
      FilteredElementCollector curCollector = new FilteredElementCollector(curDoc);
      curCollector.OfCategory(BuiltInCategory.OST_DesignOptions);

      List<DesignOption> designOptList = new List<DesignOption>();
      foreach (DesignOption curOpt in curCollector) {
        designOptList.Add(curOpt);
      }

      return designOptList;
    }
    public static DesignOption getDesignOptionByName(Document curDoc, string designOpt) {
      //DesignOption functionReturnValue = null;
      //get all design options
      List<DesignOption> designOptList = getAllDesignOptions(curDoc);

      //loop through design options and look for match
      foreach (DesignOption curOpt in designOptList) {

        if (curOpt.Name == designOpt // ERROR: Unknown binary operator Like


) {
          return curOpt;
          //return functionReturnValue;
        }
      }

      return null;
      //return functionReturnValue;

    }
    //return the specified level 
    public static Level getLevelByName(Document curDoc, string levelName) {
      //Level functionReturnValue = null;
      List<Level> levelList = getAllLevels(curDoc);

      //loop through levels and find match for levelName argument
      foreach (Level tmpLevel in levelList) {
        if (tmpLevel.Name == levelName // ERROR: Unknown binary operator Like
) {
          return tmpLevel;
          //return functionReturnValue;
        }
      }

      return null;
      //return functionReturnValue;
    }
    public static ElementId getViewTemplateID(string viewTemplateName, Document m_doc) {
      //ElementId functionReturnValue = null;
      //returns view template ID 

      //get all views
      List<View> viewList = null;
      viewList = getAllViews(m_doc);

      //loop through views and check for view template
      foreach (View v in viewList) {
        if (v.IsTemplate && v.Name == viewTemplateName // ERROR: Unknown binary operator Like

//			If v.IsTemplate And v.Name Like viewTemplateName Then

) {
          return v.Id;
          //return functionReturnValue;
        }
      }

      return null;
      //return functionReturnValue;
    }
    public static List<string> getAllViewTemplates(Document m_doc) {
      //returns list of view templates 
      List<string> viewTempList = new List<string>();
      List<View> viewList = null;
      viewList = getAllViews(m_doc);

      //loop through views and check if is view template
      foreach (View v in viewList) {
        if (v.IsTemplate == true) {
          //add view template to list
          viewTempList.Add(v.Name);
        }
      }

      return viewTempList;
    }
    public static ElementId getViewportTypeID(string viewportTypeName, Document m_doc) {
      //ElementId functionReturnValue = null;
      //returns viewport type ID 

      FilteredElementCollector m_colVPTypes = new FilteredElementCollector(m_doc);
      m_colVPTypes.OfCategory(BuiltInCategory.OST_Viewports);

      //loop through viewports and get specified viewport type
      foreach (Viewport vp in m_colVPTypes) {
        if (vp.Name == viewportTypeName// ERROR: Unknown binary operator Like

) {
          //return element ID of type
          return vp.GetTypeId();
          //return functionReturnValue;
        }
      }

      return null;
      //return functionReturnValue;
    }
    public static List<string> getAllViewportTypes(Document m_doc) {
      //returns list of viewports in current model 

      FilteredElementCollector m_colVPTypes = new FilteredElementCollector(m_doc);
      m_colVPTypes.OfCategory(BuiltInCategory.OST_Viewports);

      //loop through viewports and output name to list
      List<string> m_vp = new List<string>();

      foreach (Viewport vp in m_colVPTypes) {
        Debug.Print(vp.Name);

        m_vp.Add(vp.Name);
      }

      return m_vp;

    }
    public static ElementId getScopeBoxID(string scopeBoxName, Document m_doc) {
      //ElementId functionReturnValue = null;
      //return scope box ID

      FilteredElementCollector m_colScope = new FilteredElementCollector(m_doc);
      m_colScope.OfCategory(BuiltInCategory.OST_VolumeOfInterest);

      //loop through scope boxes and check for specified one
      foreach (Element sb_loopVariable in m_colScope) {
        Element sb = sb_loopVariable;
        if (sb.Name == scopeBoxName
) {
          return sb.Id;
          //return functionReturnValue;
        }
      }

      return null;
      //return functionReturnValue;

    }
    public static List<string> getAllScopeBoxes(Document m_doc) {
      FilteredElementCollector m_colScope = new FilteredElementCollector(m_doc);
      m_colScope.OfCategory(BuiltInCategory.OST_VolumeOfInterest);

      List<string> scopeBoxList = new List<string>();

      //loop through scope boxes and check for specified one
      foreach (Element sb_loopVariable in m_colScope) {
        //sb = sb_loopVariable;
        scopeBoxList.Add(sb_loopVariable.Name);
      }

      return scopeBoxList;
    }
    public static bool doesScopeBoxExist(string scopeBoxName, Document m_doc) {
      //bool functionReturnValue = false;
      FilteredElementCollector m_colScope = new FilteredElementCollector(m_doc);
      m_colScope.OfCategory(BuiltInCategory.OST_VolumeOfInterest);

      //loop through scope boxes and check for specified one
      foreach (Element sb_loopVariable in m_colScope) {
        //sb = sb_loopVariable;
        if (sb_loopVariable.Name == scopeBoxName) {
          return true;
          //return functionReturnValue;
        }
      }

      return false;
      //return functionReturnValue;
    }
    public static List<View> getAllViews(Document m_doc) {
      //get all views
      FilteredElementCollector m_colViews = new FilteredElementCollector(m_doc);
      m_colViews.OfCategory(BuiltInCategory.OST_Views);

      List<View> m_Views = new List<View>();
      foreach (View x in m_colViews.ToElements()) {
        m_Views.Add(x);
      }

      return m_Views;
    }
    public static List<ViewSheet> getAllSheets(Document m_doc) {
      //get all views
      FilteredElementCollector m_colViews = new FilteredElementCollector(m_doc);
      m_colViews.OfCategory(BuiltInCategory.OST_Sheets);

      List<ViewSheet> m_Sheets = new List<ViewSheet>();
      foreach (ViewSheet x in m_colViews.ToElements()) {
        m_Sheets.Add(x);
      }

      return m_Sheets;
    }
    public static bool doesTblockExist(Document curDoc, string[] tblockName) {
      FamilySymbol curTblock = null;

      curTblock = getTitleblock(curDoc, tblockName);

      if (curTblock != null) {
        return true;
      } else {
        return false;
      }
    }
    public static List<ElementId> getAllRoomsInView(ElementId curLevel, Document m_doc) {
      FilteredElementCollector m_col = new FilteredElementCollector(m_doc);
      m_col.OfClass(typeof(SpatialElement)).ToElements();

      //loop through room and find rooms for specified level
      List<ElementId> roomList = new List<ElementId>();
      if (m_col.Count() > 0) {
        foreach (SpatialElement e in m_col) {
          Debug.Print(e.GetType().ToString());

          try {
            roomList.Add(e.Id);
          } catch (Exception ex) {
            Debug.Print(ex.Message);
          }

          //				If curRoom.LevelId = curLevel Then
          //roomList.Add(curRoom)
          //				End If
        }
      }

      return roomList;

    }
    public static string GetViewTypeFromViewFamily(Document curDoc, string viewFamily) {
      //collect all view types in current model
      List<ViewFamilyType> viewFamilies = getViewTypes(curDoc);

      foreach (ViewFamilyType curVFT in getViewTypes(curDoc)) {
        if (curVFT.Name == viewFamily
) {
          return curVFT.ViewFamily.ToString();
        }
      }

      return null;
    }



    //-----------------------------functions-------------------------------------------
    public static void writeCSVFile(string filePath, string fileContents) {
      System.IO.StreamWriter file = null;

      //write to file
      file = JRM.My.MyProject.Computer.FileSystem.OpenTextFileWriter(filePath, true);
      file.WriteLine(fileContents);

      //close file
      file.Close();

    }
    public static List<JRM.mSheetMaker.structSheet> ReadCSV(string filePathName, bool hasHeaders) {
      List<JRM.mSheetMaker.structSheet> sheetList = new List<JRM.mSheetMaker.structSheet>();

      using (Microsoft.VisualBasic.FileIO.TextFieldParser MyReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(filePathName)) {
        MyReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
        MyReader.Delimiters = new string[] { "," };
        string[] currentRow = null;

        //if CSV file has headers then discard first line
        if (hasHeaders == true) {
          MyReader.ReadLine().Skip(1);
        }

        while (!MyReader.EndOfData) {
          try {
            currentRow = MyReader.ReadFields();

            //create temp sheet

            JRM.mSheetMaker.structSheet curSheet = new JRM.mSheetMaker.structSheet();
            curSheet.sheetNum = currentRow[0];
            curSheet.sheetName = currentRow[1];
            curSheet.viewName = currentRow[2];

            //add sheet to list
            sheetList.Add(curSheet);

          } catch (Microsoft.VisualBasic.FileIO.MalformedLineException ex) {
            Debug.Print("Line " + ex.Message + " is invalid.  Skipping");
          }
        }

        return sheetList.ToList();
      }

    }
    public static void centerViewOnSheet(Viewport curVP, View curView, ViewSheet curSheet, Document m_doc) {
      //get center point of viewport
      XYZ vpCenter = null;
      Outline vpOutline = null;
      BoundingBoxUV sheetOutline = null;
      UV sheetCenter = new UV();

      vpCenter = curVP.GetBoxCenter();
      vpOutline = curVP.GetBoxOutline();

      sheetOutline = curSheet.Outline;
      sheetCenter = (sheetOutline.Min + sheetOutline.Max) * 0.5;

      XYZ sheetCenterXYZ = new XYZ(sheetCenter.U, sheetCenter.V, 0);

      //move viewport to sheet center
      curVP.SetBoxCenter(sheetCenterXYZ);

    }

  }
}
