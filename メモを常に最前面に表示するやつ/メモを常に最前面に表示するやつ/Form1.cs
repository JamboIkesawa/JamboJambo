using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace メモを常に最前面に表示するやつ
{
	public partial class Form1 : Form
	{
		const int checkboxSpan = 3;
		const int buttonSpan = 11;
		const string DocInitialName = "新規";
		string memoDocName = "新規テキストドキュメント";

		public Form1()
		{
			InitializeComponent();
			label_Title.Text = DocInitialName;
		}

		private void button_Open_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = null;
			Stream stream = null;

			ofd = FileOpen();
			if(ofd.ShowDialog() == DialogResult.OK)
			{
				label_Title.Text = Path.GetFileName(ofd.FileName.ToString());
				stream = ofd.OpenFile();
				if(stream != null)
				{
					StreamReader sr = new StreamReader(stream);
					richTextBox_Memo.Text = sr.ReadToEnd();
					sr.Close();
					stream.Close();
				}	// TODO:文字コードを勝手に決めてくれるようにしたい。
			}
			else
			{
				ofd.Reset();
				ofd.Dispose();
			}
		}

		private void button_Save_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = null;
			Stream stream = null;

			sfd = FileSave();
			if(sfd.ShowDialog() == DialogResult.OK)
			{
				stream = sfd.OpenFile();
				StreamWriter sw = new StreamWriter(stream);
			}
			else
			{
				sfd.Reset();
				sfd.Dispose();
			}
		}

		/// <summary>
		/// 書き込みの可否を入れ替える。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void checkBox_ReadOnly_CheckedChanged(object sender, EventArgs e)
		{
			// チェックされたらテキストボックスを読み込みのみにする。
			if(checkBox_ReadOnly.Checked == true)
			{
				richTextBox_Memo.ReadOnly = true;
			}
			else
			{
				richTextBox_Memo.ReadOnly = false;
			}
		}

		private OpenFileDialog FileOpen()
		{
			OpenFileDialog ofd = new OpenFileDialog();

			ofd.FileName = "";
			ofd.InitialDirectory = Directory.GetCurrentDirectory();
			ofd.Filter = "テキストファイル(*.txt)|*.txt|ログファイル(*.log)|*.log";
			ofd.FilterIndex = 1;
			ofd.Title = "開くファイルを選択してください";
			ofd.RestoreDirectory = true;
			ofd.Multiselect = false;    // TODO:後々タブみたいなの追加して複数選択できるようにしたい。

			return ofd;
		}

		private SaveFileDialog FileSave()
		{
			SaveFileDialog sfd = new SaveFileDialog();

			sfd.FileName = "";
			sfd.InitialDirectory = "C:\\Desktop";
			sfd.Filter = "テキストファイル(*.txt)|*.txt|ログファイル(*.log)|*.log";
			sfd.FilterIndex = 1;
			sfd.Title = "テキストをセーブします。";
			sfd.RestoreDirectory = true;

			return sfd;
		}

		private void richTextBox_Memo_Resize(object sender, EventArgs e)
		{
			int topToRichTextBox = 0;
			int richTextBoxToCheck = 0;
			int richTextBoxToButton = 0;

			// TODO:+方向にしか座標が変化していないからボタンが戻ってこない。
			topToRichTextBox = richTextBox_Memo.Location.Y + richTextBox_Memo.Size.Height;
			richTextBoxToCheck = topToRichTextBox + 1;
			richTextBoxToButton = richTextBoxToCheck + 1;

			checkBox_ReadOnly.Location = new Point(checkBox_ReadOnly.Location.X, (checkBox_ReadOnly.Location.Y + richTextBoxToCheck) / 2 + checkboxSpan);
			button_Open.Location = new Point(button_Open.Location.X, (button_Open.Location.Y + richTextBoxToButton) / 2 + buttonSpan);
			button_Save.Location = new Point(button_Save.Location.X, (button_Save.Location.Y + richTextBoxToButton) / 2 + buttonSpan);
		}

		private void richTextBox_Memo_TextChanged(object sender, EventArgs e)
		{
			label_Title.Text = memoDocName;
		}

		private void checkBox_TopMost_CheckedChanged(object sender, EventArgs e)
		{
			if(checkBox_topMost.Checked == true)
			{
				this.TopMost = true;
			}
			else
			{
				this.TopMost = false;
			}
		}
	}
}
