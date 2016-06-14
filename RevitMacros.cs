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
public class RevitMacro : IExternalCommand {
  public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements) {

    //get application and document objects
    UIApplication uiApp = commandData.Application;
    Document doc = uiApp.ActiveUIDocument.Document;

    //define reference
    Reference pickedRef = null;

    ////pick
    Selection sel = uiApp.ActiveUIDocument.Selection;
    //pickedRef = sel.PickObject(ObjectType.Element, "select an element");
    //Element elem = doc.GetElement(pickedRef);
    //Group group = elem as Group;

    //pick a point
    XYZ point = sel.PickPoint("pick a point inside a room");
    Room room = doc.GetRoomAtPoint(point);
    SpatialElementBoundaryOptions options = new SpatialElementBoundaryOptions();
    IList<IList<BoundarySegment>> boundaries = room.GetBoundarySegments(options);

    //boundary[room][boundary].curve
    //boundary[room][boundary].element
    TaskDialog.Show("title", "room picked");

    //transaction
    Transaction trans = new Transaction(doc);
    trans.Start("macro");

    trans.Commit();

    return Result.Succeeded;
  }


}


