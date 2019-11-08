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
		//List<LaunchSoftForDisplay> lifdSoft = new List<LaunchSoftForDisplay>();
		string thisDirectory = "";
		string xmlFile = "\\XmlFile\\";
		string prevData = "Previous.xml";
		string configFile = "\\config\\";
		string configData = "config.xml";

		/* フォームを開いたときにする処理 */
		public Main()
		{

			FileSelection frmFS = new FileSelection();
			frmFS.Show();
			
			InitializeComponent();

			thisDirectory = Directory.GetCurrentDirectory() + xmlFile;
			
			OpenConfig();

			if (checkBox_LaunchConfirm.Checked == true)
			{
				liSoft = OpenPrevData();
			}
			else
			{
				liSoft = new List<LaunchSoft>();
			}
			dataGridView_Prev.DataSource = liSoft;
			dataGridView_Current.DataSource = liSoft;
			UpdateData();
			ChangeGridViewStyle(dataGridView_Prev);
			ChangeGridViewStyle(dataGridView_Current);
		}

		/* 起動するファイルを追加する */
		private void button_Add_Click(object sender, EventArgs e)
		{
			LaunchSoft doc = new LaunchSoft();
			doc.isLaunch = true;

			OpenFileDialog oFD = new OpenFileDialog();
			oFD.Title = "追加するファイルを選択してください";
			// TODO:自分のパソコンしか使えないので、他の環境でも使えるようにパス部分を変更。(C:\が無難)
			oFD.InitialDirectory = "C:\\Users\\"+Environment.UserName+"\\Desktop\\";
			oFD.FileName = "";
			oFD.Filter = "すべてのファイル|*.*";
			oFD.FilterIndex = 1;
			oFD.RestoreDirectory = true;
			oFD.Multiselect = true;
			oFD.ShowHelp = true;
			oFD.ShowReadOnly = true;
			oFD.ReadOnlyChecked = true;
			if (oFD.ShowDialog() == DialogResult.OK)
			{
				doc.FileName = Path.GetFileName(oFD.FileName);  //ファイル名のみを取得する
				doc.FilePath = oFD.FileName;                    //ファイルパスを取得する
				AddData(doc);
				UpdateData();
			}

			oFD.Reset();
			oFD.Dispose();
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
			SaveCurrentData(liSoft);
			SaveConfig();
			Close();
		}

		/* リストの選択したソフトを削除する */
		private void button_Delete_Click(object sender, EventArgs e)
		{
			if (checkBox_DeleteConfirm.Checked == true)
			{
				foreach (DataGridViewRow gdvRow in dataGridView_Current.SelectedRows)
				{
					liSoft.RemoveRange(gdvRow.Index, 1);
				}
				UpdateData();
				return;
			}
			DialogResult result = MessageBox.Show(
										"削除しますか？",
										"削除",
										MessageBoxButtons.YesNoCancel,
										MessageBoxIcon.Exclamation,
										MessageBoxDefaultButton.Button1);

			/* 削除するなら */
			if (result == DialogResult.Yes)
			{
				foreach (DataGridViewRow gdvRow in dataGridView_Current.SelectedRows)
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
			liSoft = DeserializeXML();
			UpdateData();
		}

		/* DataGridViewで削除ボタンを押された行のデータを削除する。 */
		private void dataGridView_Current_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dgv = (DataGridView)sender;
			// クリックしたセルの列名がボタンならば
			// (他のセルをクリックしても削除されないように)
			if (dgv.Columns[e.ColumnIndex].Name == "ボタン")
			{
				liSoft.RemoveRange(e.RowIndex, 1);
				UpdateData();
			}

			richTextBox_CurrentPath.Text = liSoft[e.RowIndex].FilePath;
		}

		/* DataGridViewで削除ボタンを押された行のデータを削除する。 */
		private void dataGridView_Prev_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dgv = (DataGridView)sender;
			// クリックしたセルの列名がボタンならば
			// (他のセルをクリックしても削除されないように)
			if (dgv.Columns[e.ColumnIndex].Name == "ボタン")
			{
				liSoft.RemoveRange(e.RowIndex, 1);
				UpdateData();
			}

			richTextBox_PrevPath.Text = liSoft[e.RowIndex].FilePath;
		}

		/* データを追加する(重複があるかチェック) */
		// TODO: 新規ボタンを追加したときにいったん新規ボタンの行を削除してデータ追加後、新規ボタン追加としてみる。
		private void AddData(LaunchSoft doc)
		{
			// 重複があり、かつ重複が許されていなければ
			if (DuplicateCheck(liSoft, doc) && (checkBox_DuplicateCheck.Checked == false))
			{
				DialogResult dr = new DialogResult();
				dr = MessageBox.Show("既に追加されています。\n同じデータを追加してもよろしいですか？", "重複確認", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

				if(dr == DialogResult.Yes)
				{
					liSoft.Add(doc);
				}
				return;
			}
			else
			{
				liSoft.Add(doc);
			}
			
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
		// TODO: 呼ばれるたびにリストの形が崩れるので形を考える。
		private void UpdateData()
		{
			// リストを更新する
			dataGridView_Current.DataSource = null;
			dataGridView_Current.DataSource = liSoft;

			ChangeGridViewStyle(dataGridView_Current);

			//ChangeGridViewStyle(dataGridView_Current);
		}

		// DataGridView_Currentに削除ボタンを追加する。
		// TODO: 呼ばれるたびにリストの形が崩れるので形を考える。
		/*private void ChangeGridViewStyle_AddDeleteButton()
		{
			DataGridViewButtonColumn col = new DataGridViewButtonColumn();
			col.Name = "ボタン";
			col.UseColumnTextForButtonValue = true;
			col.Text = "削除";
			col.Width = 40;
			dataGridView_Current.Columns.Add(col);
		}

		// TODO: 新規作成ボタン追加処理
		private void ChangeGridViewStyle_AddAddButton()
		{

		}*/

		private void ChangeGridViewStyle(DataGridView changeGrid)
		{
			// 列ヘッダーを非表示にする
			changeGrid.RowHeadersVisible = false;

			// ユーザーが行列のサイズを調整できないようにする。
			changeGrid.AllowUserToResizeRows = false;
			changeGrid.AllowUserToResizeColumns = false;

			// ファイルパスを非表示にする。
			changeGrid.Columns[2].Visible = false;

			// DataGridViewの列幅を調整する。
			changeGrid.Columns[0].Width = 30;
			changeGrid.Columns[1].Width = 165;

			// 列の名前を変更する。
			changeGrid.Columns[0].HeaderText = "起動";
			changeGrid.Columns[1].HeaderText = "ソフト名";

			// ヘッダーの高さを調整する。
			//changeGrid.Rows[0].Height = 100;
			changeGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


		}

		/* リストをXMLファイルとして保存する */
		private void SerializeXML(List<LaunchSoft> lList)
		{
			/* ダイアログを表示して開きたいリストを選択する */
			SaveFileDialog sFD = new SaveFileDialog();
			sFD.Title = "セーブします";
			sFD.InitialDirectory = thisDirectory;
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

			sFD.Reset();
			sFD.Dispose();

		}

		/// <summary>
		/// フォームを閉じる前の状態で保存する。
		/// </summary>
		/// <param name="lList">保存するリスト</param>
		private void SaveCurrentData(List<LaunchSoft> lList)
		{

			/* 選択したファイルをデシリアライズしてリストに格納する。 */
			if (liSoft.Count > 0)
			{
				XmlSerializer xmlSer = new XmlSerializer(typeof(List<LaunchSoft>));

				StreamWriter sw = new StreamWriter(thisDirectory + prevData, false, new UTF8Encoding(false));

				xmlSer.Serialize(sw, lList);
				sw.Close();
			}

		}

		/// <summary>
		/// フォームクローズ時にチェックボックスの設定を保存する。
		/// </summary>
		private void SaveConfig()
		{
			Config config = new Config();
			XmlSerializer xmlSer = new XmlSerializer(typeof(Config));
			StreamWriter sw = new StreamWriter(thisDirectory + configFile + configData, false, new UTF8Encoding(false));

			config.isDuplicatePermission = checkBox_DuplicateCheck.Checked;
			config.isDeleteConfirm = checkBox_DeleteConfirm.Checked;
			config.isOpenPrevData = checkBox_LaunchConfirm.Checked;

			xmlSer.Serialize(sw, config);
			sw.Close();

		}

		/// <summary>
		/// XMLファイルからリストを開く
		/// </summary>
		/// <returns>XMLから開いたリスト</returns>
		private List<LaunchSoft> DeserializeXML()
		{
			List<LaunchSoft> llist = new List<LaunchSoft>();
			string filePath = "";

			/* ダイアログを表示して開きたいリストを選択する */
			OpenFileDialog oFD = new OpenFileDialog();
			oFD.Title = "オープンするファイルを選択してください";
			oFD.InitialDirectory = thisDirectory;
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
				catch (NotSupportedException nse)
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

		/// <summary>
		/// 前回使用していたデータを開く。
		/// 無ければ
		/// </summary>
		/// <returns>前回使用していたデータ</returns>
		private List<LaunchSoft> OpenPrevData()
		{
			DialogResult dr;
			List<LaunchSoft> llist = new List<LaunchSoft>();

			/*dr = MessageBox.Show("前回使用していたデータを開きますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (dr == DialogResult.No)
			{
				return new List<LaunchSoft>();
			}*/

			/* 選択したファイルをデシリアライズしてリストに格納する。 */
			XmlSerializer xmlSer = new XmlSerializer(typeof(List<LaunchSoft>));
			try
			{
				if (File.Exists(thisDirectory + prevData))
				{
					StreamReader sr = new StreamReader(thisDirectory + prevData, new UTF8Encoding(false));
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
						isLaunch = false,
						FileName = "できない",
						FilePath = nse.ToString()
					}
				};
			}

			return llist;
		}

		private void OpenConfig()
		{
			Config config = new Config();
			XmlSerializer xmlSer = new XmlSerializer(typeof(Config));
			try
			{
				if(File.Exists(thisDirectory + configFile + configData))
				{
					StreamReader sr = new StreamReader(thisDirectory + configFile + configData, new UTF8Encoding(false));
					config = (Config)xmlSer.Deserialize(sr);
					sr.Close();
				}
				else
				{
					config = new Config();
				}
			}
			catch(NotSupportedException nse)
			{
				config = new Config();
			}

			checkBox_DuplicateCheck.Checked = config.isDuplicatePermission;
			checkBox_DeleteConfirm.Checked = config.isDeleteConfirm;
			checkBox_LaunchConfirm.Checked = config.isOpenPrevData;
		}

		// リスト内の重複をチェックする。
		// リストにソフトを追加するタイミングで使用。
		private bool DuplicateCheck(List<LaunchSoft> checkList, LaunchSoft checkData)
		{
			bool isDuplicate = false;

			foreach (LaunchSoft ls in checkList)
			{
				if (ls.FileName.Contains(checkData.FileName))
				{
					isDuplicate = true;
				}
			}

			return isDuplicate;
		}

	}
}
