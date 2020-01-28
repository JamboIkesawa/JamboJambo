using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Launch_Soft_Together
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			try
			{
				Application.Run(new FileSelection());
				Application.Run(new Main());
			}
			catch(InvalidOperationException ioe)
			{
				MessageBox.Show(ioe.Message);
			}
		}
	}

	public class CommonMethod
	{
		const string _Kakuchoshi_XMLFile = "XMLファイル|*.xml";
		Config config = new Config();
		GlobalVariables gv = new GlobalVariables();
		List<XmlFiles> xmlFiles = new List<XmlFiles>();

		/// <summary>
		/// 指定したディレクトリからファイルを選択するダイアログを開く。
		/// </summary>
		/// <param name="Title">ダイアログのタイトル</param>
		/// <param name="InitialDirectory">ダイアログ表示時に示すディレクトリ</param>
		/// <param name="Filter">開くファイルの形式(拡張子)</param>
		/// <returns>選択したファイルのパス</returns>
		public string OpenDialog(string Title, string InitialDirectory, string Filter)
		{
			string filePath = "";
			OpenFileDialog oFD = new OpenFileDialog();
			oFD.Title = Title;
			oFD.InitialDirectory = InitialDirectory;
			oFD.FileName = "";
			oFD.Filter = Filter;
			oFD.FilterIndex = 1;
			oFD.RestoreDirectory = true;
			oFD.Multiselect = true;
			oFD.ShowHelp = true;
			oFD.ShowReadOnly = true;
			oFD.ReadOnlyChecked = true;

			oFD.ShowDialog();
			filePath = oFD.FileName;

			oFD.Reset();
			oFD.Dispose();

			return filePath;
		}

		/// <summary>
		/// 指定したディレクトリにファイルを保存するディレクトリを開く。
		/// </summary>
		/// <param name="Title">ダイアログのタイトル</param>
		/// <param name="InitialDirectory">ダイアログ表示時に示すディレクトリ</param>
		/// <param name="Filter">保存するファイルの形式(拡張子)</param>
		/// <returns>保存したファイルのパス</returns>
		public string SaveDialog(string Title, string InitialDirectory, string Filter)
		{
			string filePath = "";
			SaveFileDialog sFD = new SaveFileDialog();
			sFD.Title = Title;
			sFD.InitialDirectory = InitialDirectory;
			sFD.FileName = "";
			sFD.Filter = Filter;
			sFD.FilterIndex = 1;
			sFD.RestoreDirectory = true;
			sFD.ShowHelp = true;

			sFD.ShowDialog();
			filePath = sFD.FileName;

			sFD.Reset();
			sFD.Dispose();

			return filePath;
		}

		/// <summary>
		/// コンフィグファイルをオープンし、ファイル内容を取り込む。
		/// </summary>
		public Config OpenConfig()
		{
			XmlSerializer xmlSer = new XmlSerializer(typeof(Config));
			try
			{
				if (File.Exists(gv.GetConfigPass()))
				{
					// ファイルが存在した場合、
					StreamReader sr = new StreamReader(gv.GetConfigPass(), new UTF8Encoding(false));
					config = (Config)xmlSer.Deserialize(sr);
					sr.Close();
				}
				else
				{
					// ファイルパスのファイルが無ければConfigのインスタンスを生成
					config = new Config();
				}
			}
			catch (NotSupportedException nse)
			{
				config = new Config();
			}
			return config;
		}

		/// <summary>
		/// XMLファイルが保存されているフォルダ内のXMLファイルを表示する。
		/// (configフォルダ内のXMLファイルは表示しない。)
		/// </summary>
		/// <returns>XMLファイルのパスが格納された配列</returns>
		public List<XmlFiles> OpenXmlFile()
		{
			string[] xmlfiles = Directory.GetFiles(gv.GetXmlFolderPass(), "*.xml", SearchOption.TopDirectoryOnly);
			xmlFiles = new List<XmlFiles>();
			foreach (String xf in xmlfiles)
			{
				XmlFiles xml = new XmlFiles();
				xml.Name = Path.GetFileName(xf);
				xml.Path = xf;
				xmlFiles.Add(xml);
			}
			return xmlFiles;
		}

		/// <summary>
		/// リストをXMLファイルに保存する。
		/// </summary>
		/// <param name="lList">保存するリスト</param>
		public void SerializeXML(List<LaunchSoft> lList)
		{
			string filePath = "";

			filePath = SaveDialog("セーブします", gv.GetXmlFolderPass(), _Kakuchoshi_XMLFile);
			if (filePath.Length > 0)
			{
				/* 選択したファイルをデシリアライズしてリストに格納する。 */
				XmlSerializer xmlser = new XmlSerializer(typeof(List<LaunchSoft>));

				StreamWriter sw = new StreamWriter(filePath, false, new UTF8Encoding(false));

				xmlser.Serialize(sw, lList);
				sw.Close();
			}
			else
			{
				/* 処理なし */
			}
		}

		/// <summary>
		/// フォームを閉じる前の状態で保存する。
		/// </summary>
		/// <param name="lList">保存するリスト</param>
		public void SaveCurrentData(List<LaunchSoft> lList)
		{

			/* 選択したファイルをデシリアライズしてリストに格納する。 */
			if (lList.Count > 0)
			{
				XmlSerializer xmlSer = new XmlSerializer(typeof(List<LaunchSoft>));

				StreamWriter sw = new StreamWriter(gv.GetPreviousFilePass(), false, new UTF8Encoding(false));

				xmlSer.Serialize(sw, lList);
				sw.Close();
			}
		}

		/// <summary>
		/// フォームクローズ時にチェックボックスの設定を保存する。
		/// </summary>
		/// <param name="Dup">重複可否チェック</param>
		/// <param name="Del">削除確認チェック</param>
		/// <param name="Pre">前回ファイルチェック</param>
		public void SaveConfig(bool Dup, bool Del, bool Pre)
		{
			Config config = new Config();
			XmlSerializer xmlSer = new XmlSerializer(typeof(Config));
			try
			{
				StreamWriter sw = new StreamWriter(gv.GetConfigPass(), false, new UTF8Encoding(false));
				config.Duplicate = Dup;
				config.Delete = Del;
				config.PrevData = Pre;

				xmlSer.Serialize(sw, config);
				sw.Close();
			}
			catch (StackOverflowException soe)
			{
				MessageBox.Show(soe.ToString());
			}
		}

		/// <summary>
		/// ファイルパスからファイルをオープンして変数に持つ。
		/// </summary>
		/// <param name="filePath">オープンするファイルパス</param>
		/// <param name="lncConfirm">前回ファイルを開くかのチェック</param>
		/// <returns></returns>
		public List<LaunchSoft> DeserializeXML(string filePath = "", bool lncConfirm = false)
		{
			List<LaunchSoft> rtnList = new List<LaunchSoft>();
			string openPath = "";

			if(filePath.Length < 1 && lncConfirm == false)
			{
				// ダイアログからファイルを開く場合
				openPath = OpenDialog("オープンするファイルを選択してください", gv.MyDirectory, _Kakuchoshi_XMLFile);
			}
			else if(lncConfirm == true)
			{
				// 前回ファイルを開く場合
				filePath = gv.GetPreviousFilePass();
			}
			else
			{
				// パスを指定してファイルを開く場合
				openPath = filePath;
			}

			/* 選択したファイルをデシリアライズしてリストに格納する。 */
			XmlSerializer xmlSer = new XmlSerializer(typeof(List<LaunchSoft>));
			try
			{
				if (File.Exists(gv.GetPreviousFilePass()))
				{
					StreamReader sr = new StreamReader(gv.GetPreviousFilePass(), new UTF8Encoding(false));
					rtnList = (List<LaunchSoft>)xmlSer.Deserialize(sr);
					sr.Close();
				}
				else
				{
					MessageBox.Show("指定されたファイルが存在しません。");
					rtnList = new List<LaunchSoft>();
				}
			}
			catch (NotSupportedException nse)
			{
				MessageBox.Show("関数OpenPrevDataでエラーが発生しました。\n" + nse.HResult + " : " + nse.Message);
				rtnList = new List<LaunchSoft>();
			}

			return rtnList;
		}

		///// <summary>
		///// XMLファイルからリストを開く
		///// </summary>
		///// <returns>XMLから開いたリスト</returns>
		//public List<LaunchSoft> DeserializeXML()
		//{
		//	List<LaunchSoft> llist = new List<LaunchSoft>();
		//	string filePath = "";

		//	filePath = OpenDialog("オープンするファイルを選択してください", gv.MyDirectory, _Kakuchoshi_XMLFile);
		//	if (filePath.Length > 0)
		//	{
		//		/* 選択したファイルをデシリアライズしてリストに格納する。 */
		//		XmlSerializer xmlSer = new XmlSerializer(typeof(List<LaunchSoft>));
		//		try
		//		{
		//			StreamReader sr = new StreamReader(filePath, new UTF8Encoding(false));
		//			llist = (List<LaunchSoft>)xmlSer.Deserialize(sr);
		//			sr.Close();
		//		}
		//		catch (NotSupportedException nse)
		//		{
		//			llist = new List<LaunchSoft>()
		//			{
		//				new LaunchSoft()
		//				{
		//					Launch = false,
		//					Name = "できない",
		//					Path = nse.ToString()
		//				}
		//			};
		//		}
		//	}
		//	else
		//	{
		//		/* 処理なし */
		//	}

		//	return llist;
		//}


		//public List<LaunchSoft> DeserializeXML(string xmlFilePath)
		//{
		//	List<LaunchSoft> llist = new List<LaunchSoft>();

		//	if (xmlFile.Path.Length > 0)
		//	{
		//		/* 選択したファイルをデシリアライズしてリストに格納する。 */
		//		XmlSerializer xmlSer = new XmlSerializer(typeof(List<LaunchSoft>));
		//		try
		//		{
		//			StreamReader sr = new StreamReader(xmlFile.Path, new UTF8Encoding(false));
		//			llist = (List<LaunchSoft>)xmlSer.Deserialize(sr);
		//			sr.Close();
		//		}
		//		catch (NotSupportedException nse)
		//		{
		//			llist = new List<LaunchSoft>()
		//			{
		//				new LaunchSoft()
		//				{
		//					Launch = false,
		//					Name = "できない",
		//					Path = nse.ToString()
		//				}
		//			};
		//		}
		//	}
		//	else
		//	{
		//		/* 処理なし */
		//	}

		//	return llist;
		//}

		///// <summary>
		///// 前回使用していたデータを開く。
		///// 無ければ
		///// </summary>
		///// <returns>前回使用していたデータ</returns>
		//public List<LaunchSoft> OpenPrevData()
		//{
		//	List<LaunchSoft> llist = new List<LaunchSoft>();

		//	/* 選択したファイルをデシリアライズしてリストに格納する。 */
		//	XmlSerializer xmlSer = new XmlSerializer(typeof(List<LaunchSoft>));
		//	try
		//	{
		//		if (File.Exists(gv.GetPreviousFilePass()))
		//		{
		//			StreamReader sr = new StreamReader(gv.GetPreviousFilePass(), new UTF8Encoding(false));
		//			llist = (List<LaunchSoft>)xmlSer.Deserialize(sr);
		//			sr.Close();
		//		}
		//		else
		//		{
		//			llist = new List<LaunchSoft>();
		//		}
		//	}
		//	catch (NotSupportedException nse)
		//	{
		//		MessageBox.Show("関数OpenPrevDataでエラーが発生しました。\n" + nse.HResult + " : " + nse.Message );
		//		llist = new List<LaunchSoft>();
		//	}

		//	return llist;
		//}

		/// <summary>
		/// リスト内の重複をチェックする。
		/// </summary>
		/// <param name="checkList">チェックするリスト</param>
		/// <param name="checkData">チェックするデータ</param>
		/// <returns>重複の有無</returns>
		private bool DuplicateCheck(List<LaunchSoft> checkList, LaunchSoft checkData)
		{
			bool isDuplicate = false;

			foreach (LaunchSoft ls in checkList)
			{
				if (ls.Name.Contains(checkData.Name))
				{
					isDuplicate = true;
				}
			}

			return isDuplicate;
		}

		/// <summary>
		/// リストにソフトの情報(名前やパス)を追加する。
		/// </summary>
		/// <param name="lList">ソフトの情報を追加するリスト</param>
		/// <param name="doc">追加するソフトの情報</param>
		/// <param name="DupChk">重複のチェックボックスの状態</param>
		public void AddData(List<LaunchSoft> lList, LaunchSoft doc, bool DupChk)
		{
			// 重複があり、かつ重複が許されていなければ
			if (DuplicateCheck(lList, doc) && (DupChk == false))
			{
				DialogResult dr = new DialogResult();
				dr = MessageBox.Show("既に追加されています。\n同じデータを追加してもよろしいですか？", "重複確認", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

				if (dr == DialogResult.Yes)
				{
					lList.Add(doc);
				}
				return;
			}
			else
			{
				lList.Add(doc);
			}

			return;
		}

		/// <summary>
		/// コレクションのソフトを開く。
		/// </summary>
		/// <param name="lList">開くソフトを入れているコレクション</param>
		public void LaunchSoftsTogether(List<LaunchSoft> lList)
		{
			Process pLaunch = new Process();

			if (lList.Count > 0)
			{
				foreach (LaunchSoft ls in lList)
				{
					try
					{
						using (Process pro = new Process())
						{
							if (ls.Launch == true)
							{
								pro.StartInfo.FileName = ls.Path;
								pro.Start();
							}
						}
					}
					catch (InvalidOperationException ioe)
					{
						MessageBox.Show("エラー\n" + ioe.ToString());
					}
					catch (Win32Exception w32e)
					{
						MessageBox.Show("エラー\n" + w32e.ToString());
					}
					catch (FileNotFoundException fnfe)
					{
						MessageBox.Show("エラー\n" + fnfe.ToString());
					}
				}
			}
			else
			{
				MessageBox.Show("追加するソフトがありません。");
			}
		}

		/// <summary>
		/// 削除するかの判定を行う。
		/// </summary>
		/// <param name="DelChk">削除前確認のチェックボックスの状態</param>
		/// <returns>削除の否応</returns>
		public bool DeleteConfirm(bool DelChk)
		{
			bool isDelete = false;

			if (DelChk)
			{
				isDelete = true;
			}
			else
			{
				DialogResult result = MessageBox.Show(
											"削除しますか？",
											"削除",
											MessageBoxButtons.YesNoCancel,
											MessageBoxIcon.Exclamation,
											MessageBoxDefaultButton.Button1);

				/* 削除するなら */
				if (result == DialogResult.Yes)
				{
					isDelete = true;
				}
				/* それ以外は何もしない */
				else if (result == DialogResult.No)
				{
					isDelete = false;
				}
				else
				{
					isDelete = false;
				}
			}

			return isDelete;
		}

		/* TODO
		 　・フォルダを選択したらフォルダ内のソフトをまとめて立ち上げるように
		 　・ドラッグアンドドロップでソフトを追加できるように
		 */

	}

	public class GlobalVariables
	{
		private static string xmlFile = "\\XmlFile\\";
		private static string configFile = "\\config\\";
		private static string prevData = "Previous.xml";
		private static string configData = "config.xml";
		private static string saveTempo = "temp.xml";
		private static string myDirectory = Directory.GetCurrentDirectory();
		private static string userDesktop = "C:\\Users\\" + Environment.UserName + "\\Desktop\\";

		public string Xml
		{
			get { return xmlFile; }
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
		public string GetDesktopPass()
		{
			return userDesktop;
		}
	}

	public class XmlFiles
	{
		private string FileName = "";
		private string FilePath = "";

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
		private bool isLaunch = false;
		private string FileName = "";
		private string FilePath = "";

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
		private bool isDuplicatePermission = false;
		private bool isDeleteConfirm = false;
		private bool isOpenPrevData = false;

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
	
	public class OneTimeSave
	{
		private static string FilePath = "";
		private static Config ConfClass = new Config();

		public string XmlFilePath
		{
			get { return FilePath; }
			set { FilePath = value; }
		}
		public Config config
		{
			get { return ConfClass; }
			set { ConfClass = value; }
		}

		/// <summary>
		/// ファイル選択画面で指定したファイルパスとコンフィグを一時的に保存する。
		/// </summary>
		/// <param name="savePath">保存先のファイルパス</param>
		/// <param name="xmlFilePath">保存するXMLファイルのパス</param>
		/// <param name="config">保存するコンフィグ</param>
		public void SerializeXML(string savePath, string xmlFilePath, Config config)
		{
			OneTimeSave ots = new OneTimeSave();
			ots.XmlFilePath = xmlFilePath;
			ots.config = config;

			if(savePath.Length > 0)
			{
				XmlSerializer xmlser = new XmlSerializer(typeof(OneTimeSave));

				StreamWriter sw = new StreamWriter(savePath, false, new UTF8Encoding(false));

				xmlser.Serialize(sw, ots);
				sw.Close();
			}
			else
			{

			}
		}

		/// <summary>
		/// 一時的にファイル選択画面で保存したファイルパスとコンフィグを開く。
		/// 一時的に保存していたファイルは削除する。
		/// </summary>
		/// <param name="openPath">オープンするファイルのパス</param>
		/// <returns></returns>
		public OneTimeSave DeserializeXML(string openPath)
		{
			OneTimeSave ots = new OneTimeSave();

			try
			{
				XmlSerializer xmlSer = new XmlSerializer(typeof(OneTimeSave));
				if (File.Exists(openPath))
				{
					StreamReader sr = new StreamReader(openPath, new UTF8Encoding(false));
					ots = (OneTimeSave)xmlSer.Deserialize(sr);
					sr.Close();
					File.Delete(openPath);
				}
				else
				{
					MessageBox.Show("指定されたファイルが存在しません。");
					ots = new OneTimeSave();
				}
			}
			catch (NotSupportedException nse)
			{
				MessageBox.Show("関数OpenPrevDataでエラーが発生しました。\n" + nse.HResult + " : " + nse.Message);
				ots = new OneTimeSave();
			}

			return ots;
		}
	}

}
