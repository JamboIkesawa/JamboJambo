using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Launch_Soft_Together
{
	
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			LoadData();
			LoadData2();
			LoadData3();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Document2 doc = (Document2)dataGridView3.DataSource;

			//foreach(Document2 d2 in doc)
			//{

			//}
		}

		public void LoadData()
		{
			List<Car> cars = new List<Car>()
			{
				new Car() { Maker = "Subaru", Model = "Impreza", Year = 2005, Price = 1800},
				new Car() { Maker = "Ford", Model = "Mustang", Year = 1984, Price = 2100}
			};

			dataGridView1.DataSource = cars;
		}

		public void LoadData2()
		{
			List<Document> documents = new List<Document>()
			{
				new Document() { CheckBox = false, FileName = "Document1.txt", AddButton = true, DeleteButton = true },
				new Document() { CheckBox = false, FileName = "Document2.html", AddButton = true, DeleteButton = true }
			};

			dataGridView2.DataSource = documents;
		}

		public void LoadData3()
		{
			List<Document2> document2s = new List<Document2>()
			{
				new Document2() { 起動する = true, ドキュメント名 = "ドキュメント１.xlsx", 追加 = false, 削除 = false },
				new Document2() { 起動する = true, ドキュメント名 = "ソフトウェア１.exe", 追加 = false, 削除 = false }
			};

			dataGridView3.DataSource = document2s;
		}

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
