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
		GlobalVariables gv = new GlobalVariables();
		CommonClass cc = new CommonClass();

		/* フォームを開いたときにする処理 */
		public Main()
		{
			
			InitializeComponent();
			
			cc.OpenConfig();
			SetConfig();
			if (checkBox_LaunchConfirm.Checked == true)
			{
				liSoft = cc.OpenPrevData();
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

		private void FrmFS_FormClosing(object sender, FormClosingEventArgs e)
		{
			//throw new NotImplementedException();
		}

		/* 起動するファイルを追加する */
		private void button_Add_Click(object sender, EventArgs e)
		{
			LaunchSoft doc = new LaunchSoft();
			string filepath = "";
			doc.Launch = true;

			filepath = cc.OpenDialog("追加するファイルを選択してください", gv.GetDesktopPass(), "すべてのファイル|*.*");
			if (filepath.Length > 0)
			{
				doc.Name = Path.GetFileName(filepath);  //ファイル名のみを取得する
				doc.Path = filepath;                    //ファイルパスを取得する
				AddData(doc);
				UpdateData();
			}

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
			cc.SaveCurrentData(liSoft);
			cc.SaveConfig(checkBox_DuplicateCheck.Checked, 
						  checkBox_DeleteConfirm.Checked, 
						  checkBox_LaunchConfirm.Checked);
			Close();
		}

		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			cc.SaveCurrentData(liSoft);
			cc.SaveConfig(checkBox_DuplicateCheck.Checked,
						  checkBox_DeleteConfirm.Checked,
						  checkBox_LaunchConfirm.Checked);
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
			cc.SerializeXML(liSoft);
		}

		/* ダイアログからリスト(xml)を選択する */
		private void button_ChooseList_Click(object sender, EventArgs e)
		{
			liSoft = cc.DeserializeXML();
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

			richTextBox_CurrentPath.Text = liSoft[e.RowIndex].Path;
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

			richTextBox_PrevPath.Text = liSoft[e.RowIndex].Path;
		}

		/* データを追加する(重複があるかチェック) */
		private void AddData(LaunchSoft doc)
		{
			// 重複があり、かつ重複が許されていなければ
			if (cc.DuplicateCheck(liSoft, doc) && (checkBox_DuplicateCheck.Checked == false))
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

		/* データを更新する */
		// TODO: 呼ばれるたびにリストの形が崩れるので形を考える。
		private void UpdateData()
		{
			// リストを更新する
			dataGridView_Current.DataSource = null;
			dataGridView_Current.DataSource = liSoft;

			ChangeGridViewStyle(dataGridView_Current);
		}

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
		
		/// <summary>
		/// フォームオープン時にチェックボックスの内容を設定する。
		/// </summary>
		private void SetConfig()
		{
			Config config = new Config();
			checkBox_DuplicateCheck.Checked = config.Duplicate;
			checkBox_DeleteConfirm.Checked = config.Delete;
			checkBox_LaunchConfirm.Checked = config.PrevData;
		}
		
	}
}
