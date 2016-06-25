//
// Created by SharpDevelop.
// User: michael
// Date: 2/16/2015
// Time: 1:20 PM
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


	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	[Autodesk.Revit.DB.Macros.AddInId("C52BCAC5-CD6A-48A8-B4B8-AEC9AFE252FF")]
	public partial class ThisDocument
	{

		public void ConvertDWGtoDetailLines()
		{
			//set current document
			Document curDoc = this.Application.ActiveUIDocument.Document;

			//set linestyle name
			string linestyleName = "Thin Lines";

			//prompt user to select DWG file
			ImportInstance curDWG = null;
			curDWG = SelectDWG(curDoc);

			//check if selected element is importinstanct - if so then run command
			if (curDWG != null) {
				int counter = 0;
				counter = ConvertDWG(curDoc, curDWG, "detail", linestyleName);

				if (counter > 0) {
					TaskDialog.Show("Complete", "Converted " + counter + " elements to detail lines.");
				}
			} else {
				TaskDialog.Show("Error", "Please select a DWG import or link.");
			}
		}

		public void ConvertDWGtoModelLines()
		{
			//set current document
			Document curDoc = this.Application.ActiveUIDocument.Document;

			//set linestyle name
			string linestyleName = "Thin Lines";

			//prompt user to select DWG file
			ImportInstance curDWG = null;
			curDWG = SelectDWG(curDoc);

			//check if selected element is importinstanct - if so then run command
			if (curDWG != null) {
				int counter = 0;
				counter = ConvertDWG(curDoc, curDWG, "model", linestyleName);

				if (counter > 0) {
					TaskDialog.Show("Complete", "Converted " + counter + " elements to model lines.");
				}
			} else {
				TaskDialog.Show("Error", "Please select a DWG import or link.");
			}
		}

		private int ConvertDWG(Document curDoc, ImportInstance curLink, string convertType, string linestyleName)
		{
			//check if family doc or project doc
			string docType = null;
			if (curDoc.IsFamilyDocument == true) {
				docType = "family";
			} else {
				docType = "project";
			}

			//set line counter
			int counter = 0;

			//get geometry curves from selected file
			List<GeometryObject> curGeomList = new List<GeometryObject>();
			curGeomList = GetLinkedDWGCurves(curLink, curDoc);

			//confirm linestyle exists
			if (doesLinestyleExist(curDoc, linestyleName) == false) {
				TaskDialog.Show("error", "The specified linestyle ( " + linestyleName + " ) does not exist in the current project file.");
				return counter;
			}

			//create transaction
			using (Transaction curTrans = new Transaction(curDoc, "Convert lines")) {
				if (curTrans.Start() == TransactionStatus.Started) {
					if (curGeomList.Count != 0) {
						//create detail lines for elements in geometry list
						foreach (GeometryObject curGeom in curGeomList) {
							if (curGeom.GetType() == typeof(Autodesk.Revit.DB.PolyLine)) {
								//figure out what to do with polylines
								PolyLine curPolyline = (PolyLine)curGeom;

								//get polyline coordinate points
								IList<XYZ> ptsList = curPolyline.GetCoordinates();

								//create lines from coordinates
								for (int i = 0; i <= ptsList.Count - 2; i++) {
									//create curve from polyline coordinates

									try {
										if (docType == "project") {
											//project
											if (convertType == "detail") {
												//detail line
												DetailCurve newLine = null;
												newLine = curDoc.Create.NewDetailCurve(curDoc.ActiveView, Line.CreateBound(ptsList[i], ptsList[i + 1]));

												//set new line style
												newLine.LineStyle = (Element)getLinestyleByName(curDoc, linestyleName);
											} else {
												//model line
												ModelCurve newLine = null;

												//get current sketchplane from view
												SketchPlane curSketchplane = null;
												curSketchplane = SketchPlane.Create(curDoc, curLink.LevelId);

												//create line
												newLine = curDoc.Create.NewModelCurve(Line.CreateBound(ptsList[i], ptsList[i + 1]), curSketchplane);

												//set new line style
												newLine.LineStyle = (Element)getLinestyleByName(curDoc, linestyleName);
											}
										} else {
											//family
											if (convertType == "detail") {
												//detail line
												DetailCurve newLine = null;

												try {
													//create line
													newLine = curDoc.FamilyCreate.NewDetailCurve(curDoc.ActiveView, Line.CreateBound(ptsList[i], ptsList[i + 1]));
												} catch (Exception ex) {
													TaskDialog.Show("Error", "Cannot create detail lines in this type of family.");
													return 0;
												}

												//set new line style
												newLine.LineStyle = (Element)getLinestyleByName(curDoc, linestyleName);
											} else {
												//model line
												ModelCurve newLine = null;

												try {
													//get current sketchplane from view
													SketchPlane curSketchplane = null;
													curSketchplane = SketchPlane.Create(curDoc, curLink.LevelId);

													//create line
													newLine = curDoc.FamilyCreate.NewModelCurve(Line.CreateBound(ptsList[i], ptsList[i + 1]), curSketchplane);
												} catch (Exception ex) {
													TaskDialog.Show("Error", "Cannot create model lines in this type of family.");
													return 0;
												}

												//set new line style
												newLine.LineStyle = (Element)getLinestyleByName(curDoc, linestyleName);
											}
										}

									} catch (Exception ex) {
										Debug.Print("could not create polyline");
									}

									//increment counter
									counter = counter + 1;
								}
							} else {
								try {
									//create line in current view
									if (docType == "project") {
										//project
										if (convertType == "detail") {
											//detail line
											DetailCurve newLine = null;
											newLine = curDoc.Create.NewDetailCurve(curDoc.ActiveView, (Curve)curGeom);

											//set new line style
											newLine.LineStyle = (Element)getLinestyleByName(curDoc, linestyleName);
										} else {
											//model line
											ModelCurve newLine = null;

											//get current sketchplane from view
											SketchPlane curSketchplane = null;
											curSketchplane = SketchPlane.Create(curDoc, curLink.LevelId);

											//create line
											newLine = curDoc.Create.NewModelCurve((Curve)curGeom, curSketchplane);

											//set new line style
											newLine.LineStyle = (Element)getLinestyleByName(curDoc, linestyleName);
										}
									} else {
										//family
										if (convertType == "detail") {
											//detail line
											DetailCurve newLine = null;

											try {
												//create line
												newLine = curDoc.FamilyCreate.NewDetailCurve(curDoc.ActiveView, (Curve)curGeom);
											} catch (Exception ex) {
												TaskDialog.Show("Error", "Cannot create detail lines in this type of family.");
												return 0;
											}

											//set new line style
											newLine.LineStyle = (Element)getLinestyleByName(curDoc, linestyleName);
										} else {
											//model line
											ModelCurve newLine = null;

											try {
												//get current sketchplane from view
												SketchPlane curSketchplane = null;
												curSketchplane = SketchPlane.Create(curDoc, curLink.LevelId);

												//create line
												newLine = curDoc.FamilyCreate.NewModelCurve((Curve)curGeom, curSketchplane);
											} catch (Exception ex) {
												TaskDialog.Show("Error", "Cannot create model lines in this type of family.");
												return 0;
											}

											//set new line style
											newLine.LineStyle = (Element)getLinestyleByName(curDoc, linestyleName);
										}
									}

									//increment counter
									counter = counter + 1;

								} catch (Exception ex) {
									Debug.Print("could not create line");
								}
							}
						}
					}
				}

				//commit changes
				curTrans.Commit();
			}

			return counter;
		}

		private ImportInstance SelectDWG(Document curDoc)
		{
			//prompt user to select DWG file
			ElementId curElemID = null;
			curElemID = this.Application.ActiveUIDocument.Selection.PickObject(ObjectType.Element, "Select DWG file").ElementId;

			//check that selected element is DWG file
			Element curElem = curDoc.GetElement(curElemID);

			//check that selected element is DWG
			if (curElem.GetType() == typeof(Autodesk.Revit.DB.ImportInstance)) {
				ImportInstance curLink = (ImportInstance)curElem;
				return curLink;
			}

			return null;
		}

		public List<GeometryObject> GetLinkedDWGCurves(ImportInstance curLink, Document curDoc)
		{
			//returns list of curves for linked DWG file
			List<GeometryObject> curveList = new List<GeometryObject>();
			Options curOptions = new Options();
			GeometryElement geoElement = null;
			GeometryInstance geoInstance = null;
			GeometryElement geoElem2 = null;

			//get geometry from current link
			geoElement = curLink.get_Geometry(curOptions);

			foreach (GeometryObject geoObject in geoElement) {
				//convert geoObject to geometry instance
				geoInstance = (GeometryInstance)geoObject;
				geoElem2 = geoInstance.GetInstanceGeometry();

				foreach (GeometryObject curObj in geoElem2) {
					//add object to list
					curveList.Add(curObj);
				}
			}

			//return list of geometry
			return curveList;
		}

		private ModelCurve drawLine(Document curDoc, SketchPlane curSketchPlane, XYZ pt1, XYZ pt2)
		{
			//draws model line using current view's sketchplane
			Line tmpLine = Line.CreateBound(pt1, pt2);
			ModelCurve curModelLine = curDoc.Create.NewModelCurve(tmpLine, curSketchPlane);

			//return line
			return curModelLine;
		}

		private GraphicsStyle getLinestyleByName(Document curDoc, string lineStyleName)
		{
			Category curCat = null;
			curCat = curDoc.Settings.Categories.get_Item(BuiltInCategory.OST_Lines).SubCategories.get_Item(lineStyleName);
			return curCat.GetGraphicsStyle(GraphicsStyleType.Projection);

		}

		private bool doesLinestyleExist(Document curDoc, string linestyleName)
		{
			try {
				getLinestyleByName(curDoc, linestyleName);
				return true;
			} catch (Exception ex) {
				return false;
			}

		}

	}
}
