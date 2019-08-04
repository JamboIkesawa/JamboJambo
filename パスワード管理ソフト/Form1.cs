using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Collections.ObjectModel;


/*
	行を複数選択できない、セルを選択するとその行全体が選択されるようにする。 
	 https://dobon.net/vb/dotnet/datagridview/singleselect.html
	
	セルが選択されている行を取得する
	 https://dobon.net/vb/dotnet/datagridview/selectedcells.html

	メッセージボックスを表示する
	 https://dobon.net/vb/dotnet/form/msgbox.html
	 
	 */

namespace パスワード管理ソフト
{

	public partial class Form1 : Form
	{
		/* 定数宣言 */
		const int savable_num = 100;    /* 保存可能な数 */

		/* 変数宣言 */
		FileInputOutput fio = new FileInputOutput();
		List<Infomation> infos = new List<Infomation>();
		bool isBlank = false;

		List<Infomation> defInfo = new List<Infomation>();

		public Form1()
		{
			InitializeComponent();
			defInfo = new List<Infomation>()
			{
				new Infomation()
				{
					Title = "なんかのサイト",
					MailID = "id75912",
					Password = "J4jo6oOO",
					Explain = "なんかのWebサイトのIDとパスワード"
				},
				new Infomation()
				{
					Title = "testメール",
					MailID = "test1@test.co.jp",
					Password = "45test92jj",
					Explain = "マイメールアドレス＆パスワード"
				},
				new Infomation()
				{
					Title = "床屋",
					MailID = "junv_#9unv",
					Password = "1308537871",
					Explain = "床屋のネット予約用"
				}
			};
			infos = new List<Infomation>()
			{
				new Infomation()
				{
					Title = "",
					MailID = "",
					Password = "",
					Explain = ""
				}
			};
		}

		private void button_Add_Click(object sender, EventArgs e)
		{
			Infomation info = new Infomation();

			CheckBlank();
			if (isBlank)
			{
				label_error.Text = "メールアドレス/ID、またはパスワードが記入されていません。";
				return;
			}

			info.Title = textBox_InputTitle.Text;
			info.MailID = textBox_InputID.Text;
			info.Password = textBox_InputPass.Text;
			info.Explain = richTextBox_InputExplain.Text;
			try
			{
				if (infos == null)
				{
					infos = new List<Infomation>()
					{
						new Infomation()
						{
							Title = textBox_InputTitle.Text,
							MailID = textBox_InputID.Text,
							Password = textBox_InputPass.Text,
							Explain = richTextBox_InputExplain.Text
						}
					};
				}
				else
				infos.Add(info);
				UpdateList(infos);
				ClearText_Input();
			}
			catch(NullReferenceException ne)
			{
				label_error.Text = ne.Message;
			}
			
		}

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
				foreach (DataGridViewRow gdvRow in dataGridView_Data.SelectedRows)
				{
					infos.RemoveRange(gdvRow.Index, 1);
				}
				UpdateList(infos);
				ClearText_Output();
			}
			/* それ以外は何もしない */
			else if(result == DialogResult.No)
			{

			}
			else
			{

			}
		}
		
		private void button_Save_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show(
										"保存しますか？",
										"保存",
										MessageBoxButtons.YesNoCancel,
										MessageBoxIcon.Exclamation,
										MessageBoxDefaultButton.Button1);

			/* 保存するなら */
			if (result == DialogResult.Yes)
			{
				fio.Save(infos);
			}
			/* それ以外は何もしない */
			else if (result == DialogResult.No)
			{

			}
			else
			{

			}
		}

		private void Form_Load(object sender, EventArgs e)
		{
			infos = fio.Road();
		}

		private void CheckBlank()
		{
			if (textBox_InputID.Text == "")
				isBlank = true;
			if (textBox_InputPass.Text == "")
				isBlank = true;
		}

		private void ClearText_Input()
		{
			textBox_InputTitle.Text = "";
			textBox_InputID.Text = "";
			textBox_InputPass.Text = "";
			richTextBox_InputExplain.Text = "";
			label_error.Text = "";
		}

		private void ClearText_Output()
		{
			textBox_OutputTitle.Text = "";
			textBox_OutputID.Text = "";
			textBox_OutputPass.Text = "";
			richTextBox_OutputExplain.Text = "";
			label_error.Text = "";
		}

		private void UpdateList(List<Infomation> infoList)
		{
			List<Infomation_OnlyTitle> iotList = new List<Infomation_OnlyTitle>();
			Infomation_OnlyTitle iOT = new Infomation_OnlyTitle();

			foreach(Infomation inf in infoList)
			{
				iOT.Title = inf.Title;
				iotList.Add(iOT);
			}

			dataGridView_Data.DataSource = null;
			dataGridView_Data.DataSource = iotList;
		}

		private void DataGridView_Cell_Clicked(object sender, EventArgs e)
		{
			foreach (DataGridViewRow gdvRow in dataGridView_Data.SelectedRows)
			{
				textBox_OutputTitle.Text = infos[gdvRow.Index].Title;
				textBox_OutputID.Text = infos[gdvRow.Index].MailID;
				textBox_OutputPass.Text = infos[gdvRow.Index].Password;
				richTextBox_OutputExplain.Text = infos[gdvRow.Index].Explain;
			}
		}
	}

	public class Infomation
	{
		public string Title { get; set; }
		public string MailID { get; set; }
		public string Password { get; set; }
		public string Explain { get; set; }

		
	}

	public class Infomation_OnlyTitle
	{
		public string Title { get; set; }
	}
}
