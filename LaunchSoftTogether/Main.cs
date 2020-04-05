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
		GlobalVariables gv = new GlobalVariables();
		CommonMethod cc = new CommonMethod();
		OneTimeSave ots = new OneTimeSave();

		/* フォームを開いたときにする処理 */
		public Main()
		{
			List<LaunchSoft> prevSoft = new List<LaunchSoft>();
			
			InitializeComponent();

			// TODO:ここで一時保存したファイルを変数に保持する
			// 設定項目(チェックボックス)の内容をコンフィグファイルから設定
			ots = ots.DeserializeXML(gv.GetTempFilePass());

			//cc.OpenConfig();
			SetConfig(cc.OpenConfig(), ots.config);

			// ファイル選択画面で指定したファイルを開く。
			liSoft = cc.DeserializeXML(ots.XmlFilePath);
			
			// 前回ファイルを開く
			if (checkBox_LaunchConfirm.Checked == true)
			{
				prevSoft = cc.DeserializeXML(gv.GetPreviousFilePass());
			}
			else
			{
				prevSoft = new List<LaunchSoft>();
			}
			dataGridView_Prev.DataSource = prevSoft;	// 前回データを表示する
			dataGridView_Current.DataSource = liSoft;	// 今回ファイルを表示する。
			UpdateData();
			ChangeGridViewStyle(dataGridView_Prev);
			ChangeGridViewStyle(dataGridView_Current);
		}

		/* 起動するファイルを追加する */
		private void button_Add_Click(object sender, EventArgs e)
		{
			string filepath = "";
			LaunchSoft addSoft = new LaunchSoft();

			filepath = cc.OpenDialog("追加するファイルを選択してください", gv.GetDesktopPass(), "すべてのファイル|*.*");
			if (filepath.Length > 0)
			{
				addSoft.Launch = true;
				addSoft.Name = Path.GetFileName(filepath);
				addSoft.Path = filepath;
				cc.AddData(liSoft, 
						   addSoft, 
						   checkBox_DuplicateCheck.Checked);
				UpdateData();
			}

		}
		
		/* リストのソフトを起動する */
		private void button_Launch_Click(object sender, EventArgs e)
		{
			cc.LaunchSoftsTogether(liSoft);
		}

		/* フォームを閉じる */
		private void button_Close_Click(object sender, EventArgs e)
		{
			CloseForm();
		}

		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseForm();
		}

		/* リストの選択したソフトを削除する */
		private void button_Delete_Click(object sender, EventArgs e)
		{
			bool isDelete = cc.DeleteConfirm(checkBox_DeleteConfirm.Checked);
			if (isDelete)
			{
				foreach (DataGridViewRow gdvRow in dataGridView_Current.SelectedRows)
				{
					liSoft.RemoveRange(gdvRow.Index, 1);
				}
				UpdateData();
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

		/* データを更新する */
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
		private void SetConfig(Config config, Config otsConfig)
		{
			config.PrevData = otsConfig.PrevData;
			checkBox_DuplicateCheck.Checked = config.Duplicate;
			checkBox_DeleteConfirm.Checked = config.Delete;
			checkBox_LaunchConfirm.Checked = config.PrevData;
		}
		
		/// <summary>
		/// フォームクローズ時に原状況を保存する。
		/// </summary>
		private void CloseForm()
		{
			cc.SaveCurrentData(liSoft);
			cc.SaveConfig(checkBox_DuplicateCheck.Checked,
						  checkBox_DeleteConfirm.Checked,
						  checkBox_LaunchConfirm.Checked);
			this.Dispose(true);
		}

	}
}
