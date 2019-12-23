using System;
using System.Windows.Forms;

namespace Launch_Soft_Together
{
	public partial class FileSelection : Form
	{
		CommonMethod cm = new CommonMethod();

		public FileSelection()
		{
			InitializeComponent();
			cm.OpenConfig();
			//Program.xmlFiles = cm.OpenXmlFile();
			cm.OpenXmlFile();
			dataGridView_FileList.DataSource = Program.xmlFiles;
			checkBox_LaunchConfirm.Checked = Program.config.PrevData;
			ChangeGridViewStyle(dataGridView_FileList);

		}

		private void button_ListOpen_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow dgvRow in dataGridView_FileList.SelectedRows)
			{
				Program.xmlFile = Program.xmlFiles[dgvRow.Index];
			}
			Program.launchSofts = cm.DeserializeXML(Program.xmlFile.Path);
		}

		private void dataGridView_FileList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridView_FileList.SelectedRows.Count < 1)
			{
				string strList = "";
				foreach(XmlFiles xf in Program.xmlFiles)
				{
					strList = strList + "\n" + xf.Name + " : " + xf.Path;
				}
				MessageBox.Show("選択されたリストがありません。\nXmlファイルリスト\n" + strList);
				return;
			}
			foreach (DataGridViewRow dgvRow in dataGridView_FileList.SelectedRows)
			{
				Program.xmlFile = Program.xmlFiles[dgvRow.Index];
			}
			Program.launchSofts = cm.DeserializeXML(Program.xmlFile.Path);
		}

		private void dataGridView_FileList_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			foreach(DataGridViewRow dgvRow in dataGridView_FileList.SelectedRows)
			{
				Program.xmlFile = Program.xmlFiles[dgvRow.Index];
			}
		}

		private void FileSelection_FormClosing(object sender, FormClosingEventArgs e)
		{
			Program.config.PrevData = checkBox_LaunchConfirm.Checked;
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
