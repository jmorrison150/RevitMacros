using System;
using System.Collections.Generic;
using System.Linq;

using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;


[TransactionAttribute(TransactionMode.Manual)]
[RegenerationAttribute(RegenerationOption.Manual)]
public class TravelPath : IExternalCommand {

  public class XYZElement {
    private static FamilySymbol symbol = null;
    private FamilyInstance thisInstance = null;

    private static bool loadRevitFamily(Document doc, string familyFilePath, string symbolName, out FamilySymbol symbol) {
      bool res = false;
      symbol = null;

      try {
        if (!doc.LoadFamilySymbol(familyFilePath, symbolName, out symbol))
          return false;

        res = true;
      } catch (Exception e) {
        // Do nothing
      }

      return res;
    }

    public XYZElement(Document doc, XYZ vertex) {
      if (symbol == null)
        loadRevitFamily(doc, "PATH TO FAMILY.rfa", "XYZElement", out symbol);

      thisInstance = doc.Create.NewFamilyInstance(vertex, symbol, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
    }
  }


  public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements) {



    UIApplication uiApp = commandData.Application;
    UIDocument uiDoc = uiApp.ActiveUIDocument;
    Document doc = uiDoc.Document;
    Selection sel = uiApp.ActiveUIDocument.Selection;



    //pick a point
    List<XYZ> points = new List<XYZ>();

    for (int i = 0; i < 5; i++) {

      XYZ point = sel.PickPoint("pick a point inside a room");
      points.Add(point);

    }
    PolyLine polyline =  PolyLine.Create(points);
   



    using (Transaction tx = new Transaction(doc)) {
      tx.Start("create wall section view");


      foreach (XYZ point in points) {
        XYZElement e = new XYZElement(doc, point);
      }

      tx.Commit();
    }
    return Result.Succeeded;
  }

  
}


