using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launch_Soft_Together
{
	
	public class GlobalVariables
	{
		private static string xmlFile = "\\XmlFile\\";
		private static string configFile = "\\config\\";
		private static string prevData = "Previous.xml";
		private static string configData = "config.xml";
		private static string myDirectory = "";

		public string Xml
		{
			get{ return xmlFile; }
			set{ xmlFile = value; }
		}
		public string Config
		{
			get { return configFile; }
			set { configFile = value; }
		}
		public string PreviousName
		{
			get { return prevData; }
			set { prevData = value; }
		}
		public string ConfigName
		{
			get { return configData; }
			set { configData = value; }
		}
		public string MyDirectory
		{
			get { return myDirectory; }
			set { myDirectory = value; }
		}
		public string GetPreviousFilePass()
		{
			return myDirectory + xmlFile + prevData;
		}
		public string GetConfigPass()
		{
			return myDirectory + xmlFile + configFile + configData;
		}
	}


	public class CommonClass
	{
		
	}

	public class LaunchSoft
	{
		private static bool isLaunch;
		private static string FileName;
		private static string FilePath;

		public bool Launch
		{
			get { return isLaunch; }
			set { isLaunch = value; }
		}
		public string Name
		{
			get { return FileName; }
			set { FileName = value; }
		}
		public string Path
		{
			get { return FilePath; }
			set { FilePath = value; }
		}
	}

	public class Config
	{
		private static bool isDuplicatePermission;
		private static bool isDeleteConfirm;
		private static bool isOpenPrevData;

		public bool Duplicate
		{
			get { return isDuplicatePermission; }
			set { isDuplicatePermission = value; }
		}
		public bool Delete
		{
			get { return isDeleteConfirm; }
			set { isDeleteConfirm = value; }
		}
		public bool PrevData
		{
			get { return isOpenPrevData; }
			set { isOpenPrevData = value; }
		}
	}
	
}
