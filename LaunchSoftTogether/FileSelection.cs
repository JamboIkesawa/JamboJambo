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
	public partial class FileSelection : Form
	{
		CommonClass cc = new CommonClass();
		Config config = new Config();
		List<LaunchSoft> liSoft = new List<LaunchSoft>();
		List<XmlFiles> xmlFile = new List<XmlFiles>();
		XmlFiles selectedXmlFile = new XmlFiles();

		public FileSelection()
		{
			InitializeComponent();
			cc.OpenConfig();
			xmlFile = cc.OpenXmlFile();
			dataGridView_FileList.DataSource = xmlFile;
			checkBox_LaunchConfirm.Checked = config.PrevData;
		}

		private void button_ListOpen_Click(object sender, EventArgs e)
		{
			liSoft = cc.DeserializeXML(selectedXmlFile.Path);
		}

		private void dataGridView_FileList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			liSoft = cc.DeserializeXML(selectedXmlFile.Path);
		}

		private void dataGridView_FileList_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			foreach(DataGridViewRow dgvRow in dataGridView_FileList.SelectedRows)
			{
				selectedXmlFile = xmlFile[dgvRow.Index];
			}
		}

		private void FileSelection_FormClosing(object sender, FormClosingEventArgs e)
		{
			config.PrevData = checkBox_LaunchConfirm.Checked;
		}
	}
}
