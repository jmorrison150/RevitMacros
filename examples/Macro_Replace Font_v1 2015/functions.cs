//
// Created by SharpDevelop.
// User: michael
// Date: 5/5/2015
// Time: 4:14 PM
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

	public static class functions
	{
		public static string getParameterValue(Autodesk.Revit.DB.Element curElem, string paramName)
		{
			string functionReturnValue = null;
			Autodesk.Revit.DB.Parameter curParam = null;

			foreach (Parameter curParam_loopVariable in curElem.Parameters) {
				curParam = curParam_loopVariable;
				if (curParam.Definition.Name.ToString() == paramName) {
					Debug.Print("got parameter");
					functionReturnValue = curParam.AsString();
					return functionReturnValue;
				}
			}

			return null;
			//return functionReturnValue;
		}

		public static bool setParameterValueString(Autodesk.Revit.DB.Element curElem, string paramName, string newValue)
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
