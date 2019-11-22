using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Launch_Soft_Together
{

	public class CommonClass
	{
		List<XmlFiles> xmlFile = new List<XmlFiles>();
		GlobalVariables gv = new GlobalVariables();

		/// <summary>
		/// コンフィグファイルをオープンし、ファイル内容を取り込む。
		/// </summary>
		public void OpenConfig()
		{
			Config config = new Config();
			XmlSerializer xmlSer = new XmlSerializer(typeof(Config));
			try
			{
				if (File.Exists(gv.GetConfigPass()))
				{
					StreamReader sr = new StreamReader(gv.GetConfigPass(), new UTF8Encoding(false));
					config = (Config)xmlSer.Deserialize(sr);
					sr.Close();
				}
				else
				{
					config = new Config();
				}
			}
			catch (NotSupportedException nse)
			{
				config = new Config();
			}

		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public List<XmlFiles> OpenXmlFile()
		{
			string[] xmlfiles = Directory.GetFiles(gv.GetXmlFolderPass(), "*.xml", SearchOption.TopDirectoryOnly);
			foreach(String xf in xmlfiles)
			{
				xmlFile.Add(new XmlFiles
				{
					Name = Path.GetFileName(xf),
					Path = xf
				});
			}
			return xmlFile;
		}


	}

	public class GlobalVariables
	{
		private static string xmlFile = "\\XmlFile\\";
		private static string configFile = "\\config\\";
		private static string prevData = "Previous.xml";
		private static string configData = "config.xml";
		private static string myDirectory = Directory.GetCurrentDirectory();

		public string Xml
		{
			get{ return xmlFile; }
			//set{ xmlFile = value; }
		}
		public string Config
		{
			get { return configFile; }
			//set { configFile = value; }
		}
		public string PreviousName
		{
			get { return prevData; }
			//set { prevData = value; }
		}
		public string ConfigName
		{
			get { return configData; }
			//set { configData = value; }
		}
		public string MyDirectory
		{
			get { return myDirectory; }
			//set { myDirectory = value; }
		}
		public string GetXmlFolderPass()
		{
			return myDirectory + xmlFile;
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

	public class XmlFiles
	{
		private string FileName;
		private string FilePath;

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
