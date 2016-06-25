//
// Created by SharpDevelop.
// User: michael
// Date: 11/2/2015
// Time: 10:15 PM
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
using System.Text.RegularExpressions;
namespace archSmarter
{

	public static class mRenamer
	{
		public static void RevitRenamer(Document curDoc)
		{
			int counter = 0;

			//open form
			using (frmRenamer curForm = new frmRenamer()) {
				//show form
				curForm.ShowDialog();

				if (curForm.DialogResult == System.Windows.Forms.DialogResult.Cancel) {
				//Result.Cancelled
				} else {
					//validate dialog values
					if (!string.IsNullOrEmpty(curForm.getFind())) {
						//rename by scope
						string curScope = curForm.getSelectedScope();
						counter = RenameElements(curDoc, curScope, curForm.getFind(), curForm.getReplace(), curForm.getMatchCase(), curForm.getMatchWord());

						//alert user
						alertUser(curScope, counter);
					} else {
						//alert user
						TaskDialog.Show("Error", "Please enter text to find.");
					}
				}
			}
		}

		public static int RenameElements(Document curDoc, string curScope, string findText, string replaceText, bool matchCase, bool matchWord)
		{
			int counter = 0;

			if (curScope == "sheet names" | curScope == "sheet numbers") {
				//get list of all sheets in project file
				List<ViewSheet> sheetList = mCollectors.getAllSheets(curDoc);

				//create transaction
				using (Transaction curTrans = new Transaction(curDoc, "Rename sheets")) {
					if (curTrans.Start() == TransactionStatus.Started) {

						//loop through all sheets and rename
						foreach (ViewSheet curSheet in sheetList) {
							//------------------SHEET NAMES--------------------------------------
							if (curScope == "sheet names") {
								if (checkMatch(curSheet.Name, findText, matchCase, matchWord) == true) {
									try {
										//reset name
										string newSheetName = replaceTextValue(curSheet.Name, findText, replaceText, matchCase, matchWord);

										//update sheet name	
										curSheet.Name = newSheetName;

										counter = counter + 1;

									} catch (Exception ex) {
										TaskDialog.Show("Error", "Could not rename sheet.");

									}
								}

							//------------------SHEET NUMBERS-------------------------------------
							} else if (curScope == "sheet numbers") {
								if (checkMatch(curSheet.SheetNumber, findText, matchCase, matchWord) == true) {
									//renumber sheet	
									try {
										//reset sheet number
										string newSheetNum = replaceTextValue(curSheet.SheetNumber, findText, replaceText, matchCase, matchWord);

										//update sheet number
										curSheet.SheetNumber = newSheetNum;

										counter = counter + 1;

										//refresh project browser
										refreshProjBrowser(curDoc);

									//TODO - need to update project browser - only for sheet numbers!!!!!

									} catch (Exception ex) {
										TaskDialog.Show("Error", "Could not renumber sheet.");

									}
								}
							}
						}
					}

					//commit changes
					curTrans.Commit();
				}

			} else if (curScope == "room names" | curScope == "room numbers") {
				//get list of all rooms
				List<Room> roomList = mCollectors.getAllRooms(curDoc);

				//create transaction
				using (Transaction curTrans = new Transaction(curDoc, "Rename rooms")) {
					if (curTrans.Start() == TransactionStatus.Started) {

						//loop through rooms and update building prefix
						foreach (Room curRoom in roomList) {

							//------------------ROOM NAMES--------------------------------------
							if (curScope == "room names") {
								string tmpName = mParameters.getParameterValueString(curRoom, "Name");
								if (checkMatch(tmpName, findText, matchCase, matchWord) == true) {
									try {
										if (matchWord == true) {
											mParameters.setParameterValueString(curRoom, "Name", Regex.Replace(tmpName, "\\b" + findText + "\\b", replaceText));
										} else {
											mParameters.setParameterValueString(curRoom, "Name", tmpName.Replace(findText, replaceText));
										}

										counter = counter + 1;

									} catch (Exception ex) {
										TaskDialog.Show("Error", "Could not rename room.");

									}
								}

							//------------------ROOM NUMBERS--------------------------------------
							} else if (curScope == "room numbers") {
								if (checkMatch(curRoom.Number, findText, matchCase, matchWord) == true) {
									try {
										if (matchWord == true) {
											curRoom.Number = Regex.Replace(curRoom.Number, "\\b" + findText + "\\b", replaceText);
										} else {
											curRoom.Number = curRoom.Number.Replace(findText, replaceText);
										}

										counter = counter + 1;

									} catch (Exception ex) {
										TaskDialog.Show("Error", "Could not renumber room.");

									}
								}
							}
						}
					}

					//commit changes
					curTrans.Commit();

				}

			//------------------VIEW NAMES--------------------------------------
			} else if (curScope == "views") {
				//get list of all views
				List<View> viewList = mCollectors.getAllViews(curDoc);

				//create transaction
				using (Transaction curTrans = new Transaction(curDoc, "Rename views")) {
					if (curTrans.Start() == TransactionStatus.Started) {

						//loop through views and update building prefix
						foreach (View curView in viewList) {
							if (checkMatch(curView.Name, findText, matchCase, matchWord) == true) {
								try {
									string newViewText = replaceTextValue(curView.Name, findText, replaceText, matchCase, matchWord);

									//update view name
									curView.ViewName = newViewText;

									counter = counter + 1;
								} catch (Exception ex) {
									TaskDialog.Show("Error", "Could not rename view.");

								}
							}
						}
					}

					//commit changes
					curTrans.Commit();

				}
			}

			return counter;
		}

		private static void alertUser(string curScope, int counter)
		{
			//alert user after rename complete
			string scopeType = null;
			if (counter == 1) {
				scopeType = Strings.Left(curScope, curScope.Length - 1);
			} else {
				scopeType = curScope;
			}

			//display task dialog
			TaskDialog.Show("Complete", "Updated " + counter.ToString() + " " + scopeType + ".");
		}

		private static bool checkMatch(string origString, string findString, bool matchCase, bool matchWord)
		{
			//bool functionReturnValue = false;
			//check if find string is found in original string - if yes then return true
			if (matchCase == true & matchWord == false) {
				//matchcase only
				if (origString.Contains(findString) == true) {
					return true;
					//return functionReturnValue;

				}

			} else if (matchCase == false & matchWord == true) {
				//matchword only
				string patt = "\\b" + findString + "\\b";
				if (Regex.IsMatch(origString, patt, RegexOptions.IgnoreCase) == true) {
					return true;
					//return functionReturnValue;
				}

			} else if (matchCase == true & matchWord == true) {
				//matchcase and matchword
				string patt = "\\b" + findString + "\\b";

				if (Regex.IsMatch(origString, patt) == true) {
					return true;
					//return functionReturnValue;
				}

			} else {
				//neither matchword or matchcase
				if (origString.IndexOf(findString, 0, StringComparison.CurrentCultureIgnoreCase) > -1) {
					return true;
					//return functionReturnValue;
				}
			}

			return false;
			//return functionReturnValue;
		}

		private static string replaceTextValue(string origString, string findString, string replaceString, bool matchCase, bool matchWord)
		{
			//check if find string is found in original string - if yes then return true
			string newText = "";

			if (matchCase == true & matchWord == false) {
				//matchcase only
				newText = origString.Replace(findString, replaceString);

			} else if (matchCase == false & matchWord == true) {
				//matchword only
				string patt = "\\b" + findString + "\\b";
				newText = Regex.Replace(origString, patt, replaceString, RegexOptions.IgnoreCase);

			} else if (matchCase == true & matchWord == true) {
				//matchcase and matchword
				string patt = "\\b" + findString + "\\b";
				newText = Regex.Replace(origString, patt, replaceString);

			} else {
				//neither matchword or matchcase
				newText = Regex.Replace(origString, findString, replaceString, RegexOptions.IgnoreCase);

			}

			return newText;
		}

		private static void refreshProjBrowser(Document curDoc)
		{
			//create temp drafting view
			ViewDrafting tmpView = null;

			tmpView = ViewDrafting.Create(curDoc, mCollectors.getDraftingViewFamilyTypeID(curDoc));
			tmpView.Name = "zzz_temp";

			//delete view
			curDoc.Delete(tmpView.Id);

		}

	}
}
