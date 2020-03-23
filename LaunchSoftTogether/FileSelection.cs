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
			ChangeGridViewStyle(dataGridView_FileList);
		}

		private void button_ListOpen_Click(object sender, EventArgs e)
		{
			if(dataGridView_FileList.SelectedRows.Count < 1)
			{
				DisplayError("ここ不具合ポイント");
			}
			else
			{
				foreach (DataGridViewRow dgvRow in dataGridView_FileList.SelectedRows)
				{
					OutOTS(xmlFiles[dgvRow.Index].Path);
				}
			}
			FormClose(true);
			
		}

		private void dataGridView_FileList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridView_FileList.SelectedRows.Count < 1)
			{
				DisplayError("ここ不具合ポイント");
			}
			else
			{
				foreach (DataGridViewRow dgvRow in dataGridView_FileList.SelectedRows)
				{
					OutOTS(xmlFiles[dgvRow.Index].Path);
				}
			}
			FormClose(true);
			
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
			OutOTS("");
			FormClose(true);
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

		private void OutOTS(string listPath)
		{
			ots.SerializeXML(gv.GetTempFilePass(), listPath, config);
		}

		private void FormClose(bool disposing)
		{
			this.Dispose(disposing);
		}
		
		private void DisplayError(string errorMessage)
		{
			MessageBox.Show(errorMessage);
		}
	}
}
