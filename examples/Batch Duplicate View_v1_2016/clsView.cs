//
// Created by SharpDevelop.
// User: michael
// Date: 1/8/2016
// Time: 11:00 AM
// 
// To change this template use Tools | Options | Coding | Edit Standard Headers.
//
using System;
namespace ArchSmarter
{

	public class clsView
	{
		private string m_viewName;
		private string m_viewType;

		public string viewName {
			get { return m_viewName; }

			set { m_viewName = value; }
		}


		public string viewType {
			get { return m_viewType; }

			set { m_viewType = value; }
		}

		public void setViewValues(string viewString)
		{
			//split and strip whitespaces
			string[] viewAr = null;
			viewAr = viewString.Split(new char[] { ':' });

			viewType = viewAr[0].Trim(new char[] { ' ' });
			viewName = viewAr[1].Trim(new char[] { ' ' });
		}
	}
}
