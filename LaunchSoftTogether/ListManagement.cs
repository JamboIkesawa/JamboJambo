using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Launch_Soft_Together;

namespace Launch_Soft_Together
{
	public partial class ListManagement : Form
	{
		List<LaunchSoft> lList = new List<LaunchSoft>();

		public ListManagement()
		{
			InitializeComponent();
			//
			
		}

		private void button_Close_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
