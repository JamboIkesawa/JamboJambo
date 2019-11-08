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

		public FileSelection()
		{
			InitializeComponent();

		}

		private void button_ListOpen_Click(object sender, EventArgs e)
		{
			
		}

		private void dataGridView_FileList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			cc.changebool();
		}
	}
}
