using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launch_Soft_Together
{
	
	public class CommonClass
	{
		/*
		public string xmlFile = "\\XmlFile\\";
		public string configFile = "\\config\\";
		public string prevData = "Previous.xml";
		public string configData = "config.xml";
		public string myDirectory = "";
		*/

		bool kore = false;

		public void changebool()
		{
			kore = !kore;
		}

		public bool getbool()
		{
			return kore;
		}
	}

	public class LaunchSoft
	{
		public bool isLaunch { get; set; }
		public string FileName { get; set; }
		public string FilePath { get; set; }
	}

	public class Config
	{
		public bool isDuplicatePermission { get; set; }
		public bool isDeleteConfirm { get; set; }
		public bool isOpenPrevData { get; set; }
	}
	
	/*public class LaunchSoftForDisplay
	{
		public bool isLaunch { get; set; }
		public bool FileName { get; set; }
	}*/
}
