using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace パスワード管理ソフト
{
	public class MainFormProcess
	{

		const int savable_num = 100;    /* 保存可能な数 */
		const string filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";

		/// <summary>
		/// 空白をチェックする。
		/// </summary>
		/// <param name="mailID">メールアドレス/ID</param>
		/// <param name="password">パスワード</param>
		/// <returns></returns>
		public bool CheckBlank(string mailID, string password)
		{
			bool isBlank = false;
			if((mailID == "") || (password == ""))
			{
				isBlank = true;
			}
			return isBlank;
		}

		public List<Infomation> AddList(List<Infomation> mList, Infomation addInfo)
		{
			try
			{
				mList.Add(addInfo);
			}
			catch(NullReferenceException nre)
			{
				MessageBox.Show(nre.ToString(), "エラー発生", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			return mList;
		}

		#region #ダイアログ
		/// <summary>
		/// ダイアログで保存するかを確認して保存する。
		/// </summary>
		/// <param name="saveList">保存したいリスト</param>
		public void Dialog(List<Infomation> saveList)
		{
			DialogResult result = MessageBox.Show(
										"保存しますか？",
										"保存",
										MessageBoxButtons.YesNoCancel,
										MessageBoxIcon.Exclamation,
										MessageBoxDefaultButton.Button1);

			/* 保存するなら */
			if(result == DialogResult.Yes)
			{
				XMLSerialize(saveList);
			}
			else
			{
				// 処理なし
			}
		}

		/// <summary>
		/// ダイアログで削除するかを確認して削除する。
		/// </summary>
		/// <param name="mList">削除する元のリスト</param>
		/// <param name="deleteIndex">リスト内の削除するインデックス</param>
		public void Dialog(List<Infomation> mList, int deleteIndex)
		{
			DialogResult reslut = MessageBox.Show(
											"削除しますか？",
											"削除",
											MessageBoxButtons.YesNoCancel,
											MessageBoxIcon.Exclamation,
											MessageBoxDefaultButton.Button1);

			if (reslut == DialogResult.Yes)
			{
				mList.RemoveRange(deleteIndex, 1);
			}
		}

		#endregion

		#region #ファイル保存
		/// <summary>
		/// リストをXML形式で保存する
		/// </summary>
		/// <param name="infoList">パスワードリスト</param>
		public void XMLSerialize(List<Infomation> infoList)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.DefaultExt = "xml";
			dlg.InitialDirectory = @"xmlfile";
			dlg.Filter = filter;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var se = new XmlSerializer(typeof(List<Infomation>));
				using (var fs = new FileStream(dlg.FileName, FileMode.Create))
				{
					se.Serialize(fs, infoList);
				}
				MessageBox.Show("保存しました");
			}
		}

		/// <summary>
		/// XML形式のファイルをデシリアライズしてリストに格納する
		/// </summary>
		/// <returns>デシリアライズしたXML形式のファイル</returns>
		public List<Infomation> XMLDeserialize()
		{
			List<Infomation> infoList = new List<Infomation>();
			string thisdirectory = Directory.GetCurrentDirectory() + "\\xmlfile\\";
			string[] files = Directory.GetFiles(thisdirectory, "*.xml", SearchOption.AllDirectories);

			//フォルダが存在しなければフォルダを作成
			if (!Directory.Exists(thisdirectory))
			{
				Directory.CreateDirectory(thisdirectory);
				infoList = null;
			}
			//フォルダ内にファイルが存在しなければ
			//if (File.Exists(thisdirectory) == false)
			if (files.Length < 1)
			{
				MessageBox.Show("ファイルが存在しません", "ファイル存在エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				infoList = new List<Infomation>();
			}
			else
			{
				infoList = Dialog_FileOpen();
			}
			return infoList;
		}

		/// <summary>
		/// ダイアログを開いて
		/// </summary>
		/// <returns></returns>
		public List<Infomation> Dialog_FileOpen()
		{
			List<Infomation> iList = null;
			OpenFileDialog dlg = null;
			string thisdirectory = Directory.GetCurrentDirectory() + "\\xmlfile\\";

			dlg = new OpenFileDialog();
			dlg.DefaultExt = "xml";
			dlg.InitialDirectory = @"xmlfile";
			dlg.Filter = filter;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var se = new XmlSerializer(typeof(List<Infomation>));
				using (var fs = new FileStream(dlg.FileName, FileMode.Open))
				{
					iList = (List<Infomation>)se.Deserialize(fs);
				}
			}
			else
			{
				iList = null;
			}

			return iList;
		}
		#endregion
	}

	/// <summary>
	/// パスワード情報を管理するクラス
	/// </summary>
	public class Infomation
	{
		string Title;
		string MailID;
		string Password;
		string Explain;

		public void setInfomation(string title, string mailID, string password, string explain)
		{
			this.Title = title;
			this.MailID = mailID;
			this.Password = password;
			this.Explain = explain;
		}

		public string getTitle()
		{
			return this.Title;
		}

		public string getMailID()
		{
			return this.MailID;
		}

		public string getPassword()
		{
			return this.Password;
		}

		public string getExplain()
		{
			return this.Explain;
		}

	}

	/// <summary>
	/// タイトルを表示するのみのクラス
	/// </summary>
	public class Infomation_Title
	{
		public string Title { get; set; }
	}
}
