using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launch_Soft_Together
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			try
			{
				Application.Run(new FileSelection());
				Application.Run(new Main());
			}
			catch(InvalidOperationException ioe)
			{
				MessageBox.Show(ioe.Message);
			}
		}
	}
}
