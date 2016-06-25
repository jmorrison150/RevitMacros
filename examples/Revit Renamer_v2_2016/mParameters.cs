//
// Created by SharpDevelop.
// User: ArchSmarter.com
// Date: 10/2/2015
// Time: 10:35 AM
// 
// ArchSmarter Revit Macro Tempate - Revit 2015 - Version 1.0
//
using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
namespace archSmarter
{

	public static class mParameters
	{
//returns the specified parameter value as a string
		public static string getParameterValueString(Element curElem, string paramName)
		{
			string functionReturnValue = null;
			Parameter curParam = null;

			foreach (Parameter curParam_loopVariable in curElem.Parameters) {
				curParam = curParam_loopVariable;
				if (curParam.Definition.Name.ToString() == paramName) {
					Debug.Print("got parameter");
					return curParam.AsString();
					//return functionReturnValue;
				}
			}

			return null;
			//return functionReturnValue;
		}

//returns the specified parameter value as a double
		public static double getParameterValueDouble(Element curElem, string paramName)
		{
			double functionReturnValue = 0;
			Parameter curParam = null;

			foreach (Parameter curParam_loopVariable in curElem.Parameters) {
				curParam = curParam_loopVariable;
				if (curParam.Definition.Name.ToString() == paramName) {
					Debug.Print("got parameter");
					return curParam.AsDouble();
					return functionReturnValue;
				}
			}

			//return null;
			return functionReturnValue;
		}

//set specified parameter as a string value for the given element
		public static bool setParameterValueString(Element curElem, string paramName, string newValue)
		{
			bool functionReturnValue = false;
			Autodesk.Revit.DB.Parameter curParam = curElem.GetParameters(paramName).First();

			try {
				curParam.Set(newValue);
				return true;
				//return functionReturnValue;
			} catch (Exception ex) {
				//error		
				TaskDialog.Show("Error", "Could not change parameter value");
			}

			return false;
			//return functionReturnValue;
		}

//set specified parameter as element ID for the given element
		public static bool setParameterValueAsID(Autodesk.Revit.DB.Element curElem, string paramName, ElementId newValue)
		{
			bool functionReturnValue = false;
			Autodesk.Revit.DB.Parameter curParam = curElem.GetParameters(paramName).First();

			try {
				curParam.Set(newValue);
				return true;
				//return functionReturnValue;
			} catch (Exception ex) {
				//error		
				TaskDialog.Show("Error", "Could not change parameter value");
			}

			return false;
			//return functionReturnValue;
		}

//set specified parameter as double for the given element
		public static bool setParameterValueAsDouble(Autodesk.Revit.DB.Element curElem, string paramName, double newValue)
		{
			//bool functionReturnValue = false;
			Autodesk.Revit.DB.Parameter curParam = curElem.GetParameters(paramName).First();

			try {
				curParam.Set(newValue);
				return true;
				//return functionReturnValue;
			} catch (Exception ex) {
				//error		
				TaskDialog.Show("Error", "Could not change parameter value");
			}

			return false;
			//return functionReturnValue;
		}
	}
}
