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


namespace Launch_Soft_Together
{
	
	public partial class Form1 : Form
	{
		List<Test_Document> tDoc = new List<Test_Document>();

		public Form1()
		{
			InitializeComponent();
		}

		private void button_Display_Click(object sender, EventArgs e)
		{
			LoadData();
		}

		private void button_Add_Click(object sender, EventArgs e)
		{
			Test_Document doc = new Test_Document();
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
		
		/* 保存情報があるときに使う。 */
		public void LoadData()
		{
			if(tDoc.Count < 1)
			{
				return;
			}
			UpdateData();
		}

		public void AddData(Test_Document doc)
		{
			tDoc.Add(doc);
		}

		public void UpdateData()
		{
			dataGridView1.DataSource = null;
			dataGridView1.DataSource = tDoc;
		}
	}

	public class Test_Document
	{
		public bool isLaunch { get; set; }
		public string FileName { get; set; }
		public string FilePath { get; set; }
	}

	class Car
	{
		public string Maker { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public int Price { get; set; }
	}

	class Document
	{
		public bool CheckBox { get; set; }
		public string FileName { get; set; }
		public bool AddButton { get; set; }
		public bool DeleteButton { get; set; }
	}

	class Document2
	{
		public bool 起動する { get; set; }
		public string ドキュメント名 { get; set; }
		public bool 追加 { get; set; }
		public bool 削除 { get; set; }
	}
}
