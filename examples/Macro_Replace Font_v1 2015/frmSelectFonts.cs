//
// Created by SharpDevelop.
// User: michael
// Date: 5/5/2015
// Time: 3:14 PM
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
using System.Drawing.Text;
//using System.Drawing.FontFamily;
namespace archSmarter
{

	public partial class frmSelectFonts
	{
		public frmSelectFonts(Document curDoc)
		{
			// The Me.InitializeComponent call is required for Windows Forms designer support.
			this.InitializeComponent();

			//
			// TODO : Add constructor code after InitializeComponents
			//

			//get all fonts in use in current model
			List<string> RVTFonts = new List<string>();
			RVTFonts = getAllFontsInUse(curDoc);

			//add font names to combo box
			foreach (string curRVTFont in RVTFonts) {
				cmbReplaceFont.Items.Add(curRVTFont);
			}

			//get all fonts on system
			List<string> fontList = new List<string>();
			fontList = getAllInstalledFonts();

			foreach (string curFont in fontList) {
				cmbNewFont.Items.Add(curFont);
			}

		}

		private List<string> getAllFontsInUse(Document curDoc)
		{
			List<string> fontList = new List<string>();

			//get all fonts in current model file
			FilteredElementCollector textStyleCol = new FilteredElementCollector(curDoc);
			textStyleCol.OfClass(typeof(TextNoteType));

			//loop through text styles and add font to list
			foreach (TextNoteType curStyle in textStyleCol) {
				string curFont = functions.getParameterValue((Element)curStyle, "Text Font");

				//add to list
				if (fontList.Contains(curFont) == false) {
					fontList.Add(curFont);
				}
			}

			return fontList;
		}

		private List<string> getAllInstalledFonts()
		{
			InstalledFontCollection installedFontCollection = new InstalledFontCollection();
			System.Drawing.FontFamily[] fontFamilies = null;

			// Get the array of FontFamily objects.
			fontFamilies = installedFontCollection.Families;

			// list of all font family names. 
			int count = fontFamilies.Length;
			int j = 0;

			List<string> installedFontList = new List<string>();

			while (j < count) {
				installedFontList.Add(fontFamilies[j].Name);
				j += 1;
			}

			return installedFontList;

		}

		public string getOldFont()
		{
			if (cmbReplaceFont.SelectedIndex == -1) {
				return null;
			} else {
				return cmbReplaceFont.SelectedItem.ToString();
			}

		}

		public string getNewFont()
		{
			if (cmbNewFont.SelectedIndex == -1) {
				return null;
			} else {
				return cmbNewFont.SelectedItem.ToString();
			}

		}

	}
}


