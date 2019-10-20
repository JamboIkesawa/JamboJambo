using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using パスワード管理ソフト;

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

	public partial class MainForm : Form
	{
		/* 定数宣言 */
		const int savable_num = 100;    /* 保存可能な数 */
		const string filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";

		/* 変数宣言 */
		MainFormProcess mfp = new MainFormProcess();
		CommonProcess comp = new CommonProcess();	//CommonProccessの関数を利用するためのインスタンスを生成する。
		List<Infomation> masterInfo = new List<Infomation>();

		public MainForm()
		{
			InitializeComponent();
		}

		private void button_Add_Click(object sender, EventArgs e)
		{
			Infomation info = new Infomation();

			if (mfp.CheckBlank(textBox_InputID.Text, textBox_InputPass.Text))
			{
				label_error.Text = "メールアドレス/ID、またはパスワードが記入されていません。";
				return;
			}
			info.setInfomation(textBox_InputTitle.Text,
								textBox_InputID.Text,
								textBox_InputPass.Text,
								richTextBox_InputExplain.Text);

			masterInfo = mfp.AddList(masterInfo, info);
			UpdateList(masterInfo);
			ClearText_Input();
		}

		/// <summary>
		/// リストを削除する。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_Delete_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow gdvRow in dataGridView_Data.SelectedRows)
			{
				mfp.Dialog(masterInfo, gdvRow.Index);
			}
			UpdateList(masterInfo);
			ClearText_Output();
		}
		
		/// <summary>
		/// 追加したリストをセーブする。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_Save_Click(object sender, EventArgs e)
		{
			mfp.Dialog(masterInfo);
		}

		/// <summary>
		/// フォームロード時にXMLファイルをデシリアライズする。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form_Load(object sender, EventArgs e)
		{
			masterInfo = mfp.XMLDeserialize();
			UpdateList(masterInfo);
		}

		/// <summary>
		/// 入力テキスト領域を空白にする。
		/// </summary>
		private void ClearText_Input()
		{
			textBox_InputTitle.Text = "";
			textBox_InputID.Text = "";
			textBox_InputPass.Text = "";
			richTextBox_InputExplain.Text = "";
			label_error.Text = "";
		}

		/// <summary>
		/// 出力テキスト領域を空白にする。
		/// </summary>
		private void ClearText_Output()
		{
			textBox_OutputTitle.Text = "";
			textBox_OutputID.Text = "";
			textBox_OutputPass.Text = "";
			richTextBox_OutputExplain.Text = "";
			label_error.Text = "";
		}

		/// <summary>
		/// DataGridViewのリストを更新する。
		/// </summary>
		/// <param name="infoList">DataGridViewに表示するリスト</param>
		private void UpdateList(List<Infomation> infoList)
		{
			List<Infomation_Title> iotList = new List<Infomation_Title>();
			Infomation_Title iOT = new Infomation_Title();

			if (infoList == null)
			{
				iotList = null;
			}
			else
			{
				foreach (Infomation inf in infoList)
				{
					iOT = new Infomation_Title
					{
						Title = inf.getTitle()
					};
					iotList.Add(iOT);
				}
			}

			dataGridView_Data.DataSource = null;
			dataGridView_Data.DataSource = iotList;
		}

		/// <summary>
		/// クリックされたリストを出力フィールドに表示する。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DataGridView_Cell_Clicked(object sender, EventArgs e)
		{
			Infomation selectInfo = new Infomation();
			foreach (DataGridViewRow gdvRow in dataGridView_Data.SelectedRows)
			{
				selectInfo = masterInfo[gdvRow.Index];
				textBox_OutputTitle.Text = selectInfo.getTitle();
				textBox_OutputID.Text = selectInfo.getMailID();
				textBox_OutputPass.Text = selectInfo.getPassword();
				richTextBox_OutputExplain.Text = selectInfo.getExplain();
			}
		}

		/// <summary>
		/// フォームを閉じる。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Button_Close_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// 情報を表示するフォームを開く。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Button_FormOpen_Click(object sender, EventArgs e)
		{
			OutputForm outForm = new OutputForm();
			outForm.Show();
		}

		/// <summary>
		/// ファイルを開いてDataGridViewに表示する。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Button_Load_Click(object sender, EventArgs e)
		{
			masterInfo = mfp.XMLDeserialize();
		}
	}
	
}
