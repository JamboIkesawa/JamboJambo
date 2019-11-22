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
		LaunchSoft lisoft = new LaunchSoft();
		Config config = new Config();
		List<XmlFiles> xmlFile = new List<XmlFiles>();

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
			
		}

		private void dataGridView_FileList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			
		}

		private void FileSelection_FormClosing(object sender, FormClosingEventArgs e)
		{
			config.PrevData = checkBox_LaunchConfirm.Checked;
		}
	}
}
