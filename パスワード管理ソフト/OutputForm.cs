using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace パスワード管理ソフト
{
	public partial class OutputForm : Form
	{
		CommonProcess com = new CommonProcess();
		public OutputForm()
		{
			InitializeComponent();
		}

		private void Button_Close_Click(object sender, EventArgs e)
		{
			com.CloseForm(this);
		}
	}
}
