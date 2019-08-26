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

namespace Launch_Soft_Together
{
	
	public partial class Main : Form
	{
		List<LaunchSoft> liSoft = new List<LaunchSoft>();
		
		/* フォームを開いたときにする処理 */
		public Main()
		{
			InitializeComponent();
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
			oFD.InitialDirectory = @"C:\";
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

		/* リストを追加する */
		private void button_ChooseList_Click(object sender, EventArgs e)
		{

		}

		private void button_Edit_Click(object sender, EventArgs e)
		{
			
		}

		/* リストのソフトを起動する */
		private void button_Launch_Click(object sender, EventArgs e)
        {
			Process pLaunch = new Process();

			foreach(LaunchSoft ls in liSoft)
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

		/* データを追加する(重複があるかチェック) */
		public void AddData(LaunchSoft doc)
		{
			liSoft.Add(doc);
		}

		/* 保存情報があるときに使う。 */
		public void LoadData()
		{
			/* リストが無いなら何もしない */
			if (liSoft.Count < 1)
			{
				return;
			}
			UpdateData();
		}

		/* データを更新する */
		public void UpdateData()
		{
			dataGridView1.DataSource = null;
			dataGridView1.DataSource = liSoft;
		}
		
		public class LaunchSoft
		{
			public bool isLaunch { get; set; }
			public string FileName { get; set; }
			public string FilePath { get; set; }
		}

	}
    
}
