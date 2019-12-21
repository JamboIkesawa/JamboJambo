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
		public static List<XmlFiles> xmlFiles = new List<XmlFiles>();
		public static XmlFiles xmlFile = new XmlFiles();
		public static List<LaunchSoft> launchSofts = new List<LaunchSoft>();
		public static GlobalVariables gv = new GlobalVariables();
		public static Config config = new Config();
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

		/// <summary>
		/// コンフィグファイルをオープンし、ファイル内容を取り込む。
		/// </summary>
		public void OpenConfig()
		{
			XmlSerializer xmlSer = new XmlSerializer(typeof(Config));
			try
			{
				if (File.Exists(Program.gv.GetConfigPass()))
				{
					// ファイルが存在した場合、
					StreamReader sr = new StreamReader(Program.gv.GetConfigPass(), new UTF8Encoding(false));
					Program.config = (Config)xmlSer.Deserialize(sr);
					sr.Close();
				}
				else
				{
					// ファイルパスのファイルが無ければConfigのインスタンスを生成
					Program.config = new Config();
				}
			}
			catch (NotSupportedException nse)
			{
				Program.config = new Config();
			}

		}

		/// <summary>
		/// XMLファイルが保存されているフォルダ内のXMLファイルを表示する。
		/// (configフォルダ内のXMLファイルは表示しない。)
		/// </summary>
		/// <returns>XMLファイルのパスが格納された配列</returns>
		public List<XmlFiles> OpenXmlFile()
		{
			string[] xmlfiles = Directory.GetFiles(Program.gv.GetXmlFolderPass(), "*.xml", SearchOption.TopDirectoryOnly);
			foreach (String xf in xmlfiles)
			{
				Program.xmlFiles.Add(new XmlFiles
				{
					Name = Path.GetFileName(xf),
					Path = xf
				});
			}
			return Program.xmlFiles;
		}

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
		/// リストをXMLファイルに保存する。
		/// </summary>
		/// <param name="lList">保存するリスト</param>
		public void SerializeXML(List<LaunchSoft> lList)
		{
			string filePath = "";

			filePath = SaveDialog("セーブします", Program.gv.GetXmlFolderPass(), "XMLファイル|*.xml");
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

				StreamWriter sw = new StreamWriter(Program.gv.GetPreviousFilePass(), false, new UTF8Encoding(false));

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
				StreamWriter sw = new StreamWriter(Program.gv.GetConfigPass(), false, new UTF8Encoding(false));
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
		/// XMLファイルからリストを開く
		/// </summary>
		/// <returns>XMLから開いたリスト</returns>
		public List<LaunchSoft> DeserializeXML()
		{
			List<LaunchSoft> llist = new List<LaunchSoft>();
			string filePath = "";

			filePath = OpenDialog("オープンするファイルを選択してください", Program.gv.MyDirectory, "XMLファイル|*.xml");
			if (filePath.Length > 0)
			{
				/* 選択したファイルをデシリアライズしてリストに格納する。 */
				XmlSerializer xmlSer = new XmlSerializer(typeof(List<LaunchSoft>));
				try
				{
					StreamReader sr = new StreamReader(filePath, new UTF8Encoding(false));
					llist = (List<LaunchSoft>)xmlSer.Deserialize(sr);
					sr.Close();
				}
				catch (NotSupportedException nse)
				{
					llist = new List<LaunchSoft>()
					{
						new LaunchSoft()
						{
							Launch = false,
							Name = "できない",
							Path = nse.ToString()
						}
					};
				}
			}
			else
			{
				/* 処理なし */
			}

			return llist;
		}


		public List<LaunchSoft> DeserializeXML(string xmlFilePath)
		{
			List<LaunchSoft> llist = new List<LaunchSoft>();

			if (Program.xmlFile.Path.Length > 0)
			{
				/* 選択したファイルをデシリアライズしてリストに格納する。 */
				XmlSerializer xmlSer = new XmlSerializer(typeof(List<LaunchSoft>));
				try
				{
					StreamReader sr = new StreamReader(Program.xmlFile.Path, new UTF8Encoding(false));
					llist = (List<LaunchSoft>)xmlSer.Deserialize(sr);
					sr.Close();
				}
				catch (NotSupportedException nse)
				{
					llist = new List<LaunchSoft>()
					{
						new LaunchSoft()
						{
							Launch = false,
							Name = "できない",
							Path = nse.ToString()
						}
					};
				}
			}
			else
			{
				/* 処理なし */
			}

			return llist;
		}

		/// <summary>
		/// 前回使用していたデータを開く。
		/// 無ければ
		/// </summary>
		/// <returns>前回使用していたデータ</returns>
		public List<LaunchSoft> OpenPrevData()
		{
			List<LaunchSoft> llist = new List<LaunchSoft>();

			/* 選択したファイルをデシリアライズしてリストに格納する。 */
			XmlSerializer xmlSer = new XmlSerializer(typeof(List<LaunchSoft>));
			try
			{
				if (File.Exists(Program.gv.GetPreviousFilePass()))
				{
					StreamReader sr = new StreamReader(Program.gv.GetPreviousFilePass(), new UTF8Encoding(false));
					llist = (List<LaunchSoft>)xmlSer.Deserialize(sr);
					sr.Close();
				}
				else
				{
					llist = new List<LaunchSoft>();
				}
			}
			catch (NotSupportedException nse)
			{
				llist = new List<LaunchSoft>()
				{
					new LaunchSoft()
					{
						Launch = false,
						Name = "できない",
						Path = nse.ToString()
					}
				};
			}

			return llist;
		}

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
					finally
					{
						MessageBox.Show("");
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
