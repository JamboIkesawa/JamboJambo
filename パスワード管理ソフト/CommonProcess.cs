using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace パスワード管理ソフト
{
	public class CommonProcess
	{
		

		#region 必要ない関数
		/// <summary>
		/// 引数に指定したフォームをオープンする
		/// </summary>
		/// <param name="openForm">オープンしたいフォーム</param>
		public void OpenForm(MainForm openForm)
		{
			openForm.Show();
		}

		/// <summary>
		/// 引数に指定したフォームをオープンする
		/// </summary>
		/// <param name="openForm">オープンしたいフォーム</param>
		public void OpenForm(OutputForm openForm)
		{
			openForm.Show();
		}

		/// <summary>
		/// フォームをクローズする
		/// </summary>
		/// <param name="me">自身のフォーム</param>
		public void CloseForm(MainForm me)
		{
			me.Close();
		}

		/// <summary>
		/// フォームをクローズする
		/// </summary>
		/// <param name="me">自身のフォーム</param>
		public void CloseForm(OutputForm me)
		{
			me.Close();
		}
		#endregion

	}
}
