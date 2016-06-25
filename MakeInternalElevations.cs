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
public class MakeInternalElevations : IExternalCommand {

  /// <summary>
  /// return a section box for view perpendicular to wall
  /// </summary>
  /// <param name="wall"></param>
  /// <returns></returns>
  BoundingBoxXYZ getSectionVewPerpindicularToWall(Wall wall) {
    LocationCurve lc = wall.Location as LocationCurve;

    //using 0.5 and "true" to specify the parameter is normalized places the transform origin at the center of the location curve
    Transform curveTransform = lc.Curve.ComputeDerivatives(0.5, true);

    //the transform contains the location curve mid-point and tangent, and we can obtain its normal in the xy plane
    XYZ origin = curveTransform.Origin;
    XYZ viewDir = curveTransform.BasisX.Normalize();
    XYZ up = XYZ.BasisZ;
    XYZ right = up.CrossProduct(viewDir);

    //set up view transform, assuming wall's up is vertical. for non vertical situation such as sloped floor, the surface normal would be needed
    Transform transform = Transform.Identity;
    transform.Origin = origin;
    transform.BasisX = right;
    transform.BasisY = up;
    transform.BasisZ = viewDir;

    BoundingBoxXYZ sectionBox = new BoundingBoxXYZ();
    sectionBox.Transform = transform;

    //min max x define section line length on each side of the wall,
    //max y is height
    //max z is far clip offset

    double d = wall.WallType.Width;
    BoundingBoxXYZ bb = wall.get_BoundingBox(null);
    double minZ = bb.Min.Z;
    double maxZ = bb.Max.Z;
    double h = maxZ - minZ;

    sectionBox.Min = new XYZ(-2 * d, -1, 0);
    sectionBox.Max = new XYZ(2 * d, h + 1, 5);



    return sectionBox;
  }


  /// <summary>
  /// return section box for a view parallel to given wall
  /// </summary>
  /// <param name="wall"></param>
  /// <returns></returns>
  BoundingBoxXYZ getSectionVewParallelToWall(Wall wall) {
    LocationCurve lc = wall.Location as LocationCurve;
    Curve curve = lc.Curve;

    //view direction sectionBox.Transform.BasisZ
    //up direction sectionBox.Transform.BasisY
    //right hand is computed so that (right,up viewdirection) form a left handed coordinate system
    //crop region projections of BoundingBoxXYZ.Min and BoundingBoxXYZ.Max onto the view cut plane
    //far clip distance difference of the z-coordinates of BoundingBoxXYZ.Min and BoundingBoxXYZ.Max

    XYZ p = curve.GetEndPoint(0);
    XYZ q = curve.GetEndPoint(1);
    XYZ v = q - p;

    BoundingBoxXYZ bb = wall.get_BoundingBox(null);
    double minZ = bb.Min.Z;
    double maxZ = bb.Max.Z;

    double w = v.GetLength();
    double h = maxZ - minZ;
    double d = wall.WallType.Width;
    double offset = 0.1 * w;

    XYZ min = new XYZ(-w, minZ - offset, -offset);
    XYZ max = new XYZ(w, maxZ + offset, offset);

    XYZ midpoint = p + 0.5 * v;
    XYZ walldir = v.Normalize();
    XYZ up = XYZ.BasisZ;
    XYZ viewDir = walldir.CrossProduct(up);

    Transform t = Transform.Identity;
    t.Origin = midpoint;
    t.BasisX = walldir;
    t.BasisY = up;
    t.BasisZ = viewDir;

    BoundingBoxXYZ sectionBox = new BoundingBoxXYZ();
    sectionBox.Transform = t;
    sectionBox.Min = min;
    sectionBox.Max = max;

    return sectionBox;
  }




  public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements) {
    UIApplication uiApp = commandData.Application;
    UIDocument uiDoc = uiApp.ActiveUIDocument;
    Document doc = uiDoc.Document;
    Selection sel = uiApp.ActiveUIDocument.Selection;

    //pick a point
    XYZ point = sel.PickPoint("pick a point inside a room");
    Room room = doc.GetRoomAtPoint(point);
    SpatialElementBoundaryOptions options = new SpatialElementBoundaryOptions();
    IList<IList<BoundarySegment>> boundaries = room.GetBoundarySegments(options);



    //create wall section view
    ViewFamilyType vftElevation = new FilteredElementCollector(doc).OfClass(typeof(ViewFamilyType)).Cast<ViewFamilyType>().FirstOrDefault<ViewFamilyType>(x => ViewFamily.Elevation == x.ViewFamily);
    ViewFamilyType vftSection = new FilteredElementCollector(doc).OfClass(typeof(ViewFamilyType)).Cast<ViewFamilyType>().FirstOrDefault<ViewFamilyType>(x => ViewFamily.Section == x.ViewFamily);

    using (Transaction tx = new Transaction(doc)) {
      tx.Start("create wall section view");

      for (int i = 0; i < boundaries.Count; i++) {
        for (int j = 0; j < boundaries[i].Count; j++) {
          Wall wall0 = boundaries[i][j].Element as Wall;
          BoundingBoxXYZ section = getSectionVewParallelToWall(wall0);

          ElevationMarker marker = ElevationMarker.CreateElevationMarker(doc, vftElevation.Id, point, 96);


          //ViewPlan viewPlan = ViewPlan.Create(doc, , wall0.LevelId);
          //viewPlan.CropBox = section;
          ViewSection.CreateSection(doc, vftSection.Id, section);
        }
      }




      tx.Commit();
    }
    return Result.Succeeded;
  }
}