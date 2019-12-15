using System;
using System.Windows.Forms;

namespace Launch_Soft_Together
{
	public partial class FileSelection : Form
	{
		CommonClass cc = new CommonClass();
		//Config config = new Config();
		//List<LaunchSoft> liSoft = new List<LaunchSoft>();
		//List<XmlFiles> xmlFile = new List<XmlFiles>();
		//XmlFiles CommonClass.xmlFile = new XmlFiles();

		public FileSelection()
		{
			InitializeComponent();
			cc.OpenConfig();
			CommonClass.xmlFiles = cc.OpenXmlFile();
			dataGridView_FileList.DataSource = CommonClass.xmlFiles;
			checkBox_LaunchConfirm.Checked = CommonClass.config.PrevData;
			ChangeGridViewStyle(dataGridView_FileList);
		}

		private void button_ListOpen_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow dgvRow in dataGridView_FileList.SelectedRows)
			{
				CommonClass.xmlFile = CommonClass.xmlFiles[dgvRow.Index];
			}
			CommonClass.launchSofts = cc.DeserializeXML(CommonClass.xmlFile.Path);
		}

		private void dataGridView_FileList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridView_FileList.SelectedRows.Count < 1)
			{
				string strList = "";
				foreach(XmlFiles xf in CommonClass.xmlFiles)
				{
					strList = strList + "\n" + xf.Name + " : " + xf.Path;
				}
				MessageBox.Show("選択されたリストがありません。\nXmlファイルリスト\n" + strList);
				return;
			}
			foreach (DataGridViewRow dgvRow in dataGridView_FileList.SelectedRows)
			{
				CommonClass.xmlFile = CommonClass.xmlFiles[dgvRow.Index];
			}
			CommonClass.launchSofts = cc.DeserializeXML(CommonClass.xmlFile.Path);
		}

		private void dataGridView_FileList_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			foreach(DataGridViewRow dgvRow in dataGridView_FileList.SelectedRows)
			{
				CommonClass.xmlFile = CommonClass.xmlFiles[dgvRow.Index];
			}
		}

		private void FileSelection_FormClosing(object sender, FormClosingEventArgs e)
		{
			CommonClass.config.PrevData = checkBox_LaunchConfirm.Checked;
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
