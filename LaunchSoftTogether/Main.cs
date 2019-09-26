using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Launch_Soft_Together
{
	
	public partial class Main : Form
	{
		List<LaunchSoft> liSoft = new List<LaunchSoft>();
		string thisDirectory = "";
		
		/* フォームを開いたときにする処理 */
		public Main()
		{
			InitializeComponent();
			thisDirectory = Directory.GetCurrentDirectory();
		}

		/* ゆくゆくはファイルを開くボタンになります。 */
		private void button_Display_Click(object sender, EventArgs e)
		{
			LoadData();
		}

		/* 起動するファイルを追加する */
		private void button_Add_Click(object sender, EventArgs e)
		{
			LaunchSoft doc = new LaunchSoft();
			doc.isLaunch = true;

			OpenFileDialog oFD = new OpenFileDialog();
			oFD.Title = "追加するファイルを選択してください";
			oFD.InitialDirectory = @"Users\\BP-022\\Desktop\\";
			oFD.FileName = "";
			oFD.Filter = "すべてのファイル|*.*";
			oFD.FilterIndex = 1;
			oFD.RestoreDirectory = true;
			oFD.Multiselect = true;
			oFD.ShowHelp = true;
			oFD.ShowReadOnly = true;
			oFD.ReadOnlyChecked = true;
			if(oFD.ShowDialog() == DialogResult.OK)
			{
				doc.FileName = Path.GetFileName(oFD.FileName);	//ファイル名のみを取得する
				doc.FilePath = oFD.FileName;					//ファイルのアドレスを取得する
				AddData(doc);
				UpdateData();
			}

			oFD.Dispose();
		}

		/* リスト管理画面を開く */
		private void button_Edit_Click(object sender, EventArgs e)
		{
			ListManagement lmForm = new ListManagement();
			lmForm.Show();
		}

		/* リストのソフトを起動する */
		private void button_Launch_Click(object sender, EventArgs e)
        {
			Process pLaunch = new Process();

			if (liSoft.Count > 0)
			{
				foreach (LaunchSoft ls in liSoft)
				{
					try
					{
						using (Process pro = new Process())
						{
							if (ls.isLaunch == true)
							{
								pro.StartInfo.FileName = ls.FilePath;
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
						//nantekottai
					}
				}
			}
			else
			{
				MessageBox.Show("追加するソフトがありません。");
			}
        }

		/* フォームを閉じる */
        private void button_Close_Click(object sender, EventArgs e)
        {
			Close();
        }

		/* リストの選択したソフトを削除する */
		private void button_Delete_Click(object sender, EventArgs e)
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
				foreach (DataGridViewRow gdvRow in dataGridView1.SelectedRows)
				{
					liSoft.RemoveRange(gdvRow.Index, 1);
				}
				UpdateData();
			}
			/* それ以外は何もしない */
			else if (result == DialogResult.No)
			{

			}
			else
			{

			}
		}

		/* XMLファイルとしてリストを保存する */
		private void button_Save_Click(object sender, EventArgs e)
		{
			SerializeXML(liSoft);
		}

		/* ダイアログからリスト(xml)を選択する */
		private void button_ChooseList_Click(object sender, EventArgs e)
		{
			liSoft = DeserializeXml();
			UpdateData();
		}

		/* データを追加する(重複があるかチェック) */
		private void AddData(LaunchSoft doc)
		{
			liSoft.Add(doc);
		}

		/* 保存情報があるときに使う。 */
		private void LoadData()
		{
			/* リストが無いなら何もしない */
			if (liSoft.Count < 1)
			{
				return;
			}
			UpdateData();
		}

		/* データを更新する */
		private void UpdateData()
		{
			dataGridView1.DataSource = null;
			dataGridView1.DataSource = liSoft;
		}

		/* リストをXMLファイルとして保存する */
		private void SerializeXML(List<LaunchSoft> lList)
		{
			string myDirectory = Directory.GetCurrentDirectory();
			string xmlFile = "\\XmlFile\\";
			string fileName = "test.xml";

			/* ダイアログを表示して開きたいリストを選択する */
			SaveFileDialog sFD = new SaveFileDialog();
			sFD.Title = "セーブします";
			sFD.InitialDirectory = myDirectory + xmlFile;
			sFD.FileName = "";
			sFD.Filter = "XMLファイル|*.xml";
			sFD.FilterIndex = 1;
			sFD.RestoreDirectory = true;
			sFD.ShowHelp = true;
			
			if (sFD.ShowDialog() == DialogResult.OK)
			{
				//filePath = sFD.FileName;

				/* 選択したファイルをデシリアライズしてリストに格納する。 */
				XmlSerializer xmlSer = new XmlSerializer(typeof(List<LaunchSoft>));
				
				StreamWriter sw = new StreamWriter(sFD.FileName, false, new UTF8Encoding(false));

				xmlSer.Serialize(sw, lList);
				sw.Close();
			}
			else
			{

			}

			sFD.Dispose();

			//XmlSerializer xmlSer = new XmlSerializer(typeof(List<LaunchSoft>));
			//StreamWriter sw = new StreamWriter(myDirectory + xmlFile + fileName, false, new UTF8Encoding(false));

			//xmlSer.Serialize(sw, lList);
			//sw.Close();
		}

		/* XMLファイルからリストを開く */
		private List<LaunchSoft> DeserializeXml()
		{
			List<LaunchSoft> llist = new List<LaunchSoft>();
			string myDirectory = Directory.GetCurrentDirectory() + "\\";
			string filePath = "";

			/* ダイアログを表示して開きたいリストを選択する */
			OpenFileDialog oFD = new OpenFileDialog();
			oFD.Title = "オープンするファイルを選択してください";
			oFD.InitialDirectory = myDirectory;
			oFD.FileName = "";
			oFD.Filter = "XMLファイル|*.xml";
			oFD.FilterIndex = 1;
			oFD.RestoreDirectory = true;
			oFD.Multiselect = true;
			oFD.ShowHelp = true;
			oFD.ShowReadOnly = true;
			oFD.ReadOnlyChecked = true;
			if (oFD.ShowDialog() == DialogResult.OK)
			{
				filePath = oFD.FileName;

				/* 選択したファイルをデシリアライズしてリストに格納する。 */
				XmlSerializer xmlSer = new XmlSerializer(typeof(List<LaunchSoft>));
				try
				{
					StreamReader sr = new StreamReader(filePath, new UTF8Encoding(false));
					llist = (List<LaunchSoft>)xmlSer.Deserialize(sr);
					sr.Close();
				}
				catch(NotSupportedException nse)
				{
					llist = new List<LaunchSoft>()
					{
						new LaunchSoft()
						{
							isLaunch = false,
							FileName = "できない",
							FilePath = nse.ToString()
						}
					};
				}
			}
			else
			{
				
			}

			oFD.Dispose();
			
			return llist;
		}
		
		public class LaunchSoft
		{
			public bool isLaunch { get; set; }
			public string FileName { get; set; }
			public string FilePath { get; set; }
		}

	}
    
}
