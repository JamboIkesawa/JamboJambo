using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Launch_Soft_Together
{
	public partial class FileSelection : Form
	{
		CommonMethod cm = new CommonMethod();
		List<XmlFiles> xmlFiles = new List<XmlFiles>();
		OneTimeSave ots = new OneTimeSave();
		GlobalVariables gv = new GlobalVariables();
		Config config = new Config();

		public FileSelection()
		{
			InitializeComponent();
			config = cm.OpenConfig();	// Configファイルを開く
			xmlFiles = cm.OpenXmlFile();	// Xmlフォルダ内のファイルをリストに格納
			dataGridView_FileList.DataSource = xmlFiles;
			checkBox_LaunchConfirm.Checked = config.PrevData;
			MessageBox.Show(dataGridView_FileList.Rows.Count.ToString());
			ChangeGridViewStyle(dataGridView_FileList);
			MessageBox.Show(dataGridView_FileList.Rows.Count.ToString());
		}

		private void button_ListOpen_Click(object sender, EventArgs e)
		{
			DataGridViewRow dgvRow = dataGridView_FileList.SelectedRows[0];
			MessageBox.Show(dgvRow.Cells[0].Value.ToString());
			MessageBox.Show(dgvRow.Cells[1].Value.ToString());
			//foreach (DataGridViewRow dgvRow in dataGridView_FileList.SelectedRows)
			//{
			//	ots.SerializeXML(gv.GetXmlFolderPass(), xmlFiles[dgvRow.Index].Path, config);
			//}
			// launchSofts = cm.DeserializeXML(xmlFile.Path);
		}

		private void dataGridView_FileList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			//if (dataGridView_FileList.SelectedRows.Count < 1)
			//{
			//	string strList = "";
			//	foreach (XmlFiles xf in xmlFiles)
			//	{
			//		strList = strList + "\n" + xf.Name + " : " + xf.Path;
			//	}
			//	MessageBox.Show("選択されたリストがありません。\nXmlファイルリスト\n" + strList);
			//	return;
			//}
			//else
			//{
			//	foreach (DataGridViewRow dgvRow in dataGridView_FileList.SelectedRows)
			//	{
			//		xmlFile = xmlFiles[dgvRow.Index];
			//	}
			//	// launchSofts = cm.DeserializeXML(xmlFile.Path);
			//}
			foreach (DataGridViewRow dgvRow in dataGridView_FileList.SelectedRows)
			{
				ots.SerializeXML(gv.GetXmlFolderPass(), xmlFiles[dgvRow.Index].Path, config);
			}
		}

		private void dataGridView_FileList_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			//foreach(DataGridViewRow dgvRow in dataGridView_FileList.SelectedRows)
			//{
			//	xmlFile = xmlFiles[dgvRow.Index];
			//}
		}

		private void FileSelection_FormClosing(object sender, FormClosingEventArgs e)
		{
			config.PrevData = checkBox_LaunchConfirm.Checked;
		}

		private void ChangeGridViewStyle(DataGridView changeGrid)
		{
			// 列ヘッダーを非表示にする
			changeGrid.RowHeadersVisible = false;

			// ユーザーが行列のサイズを調整できないようにする。
			changeGrid.AllowUserToResizeRows = false;
			changeGrid.AllowUserToResizeColumns = false;

			// ファイルパスを非表示にする。
			changeGrid.Columns[1].Visible = false;

			// DataGridViewの列幅を調整する。
			changeGrid.Columns[0].Width = changeGrid.Size.Width;

			// 列の名前を変更する。
			changeGrid.Columns[0].HeaderText = "XMLファイル名";

			// ヘッダーの高さを調整する。
			//changeGrid.Rows[0].Height = 100;
			changeGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

		}
	}
}
