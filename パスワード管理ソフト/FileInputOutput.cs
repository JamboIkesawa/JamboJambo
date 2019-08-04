using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace パスワード管理ソフト
{
	public class FileInputOutput
	{
		const string filepath = @"file/file.txt";
		const char splitChar = ',';
		
		/*
		 セーブ時はリストが存在していたら
		 そのリストが入っているから
		 内容をすべて上書きする感じになる予定。
			 */
		public void Save(List<Infomation> info_list)
		{
			string infStr = "";
			if(File.Exists(filepath))
			{
				using (FileStream fs = File.Open(filepath, FileMode.Open))
				{
					foreach (Infomation inf in info_list)
					{
						infStr = inf.Title + splitChar + inf.MailID + splitChar + inf.Password + splitChar + inf.Explain;
						AddText(fs, Convert.ToChar(infStr).ToString());
					}
					fs.Close();
				}
			}
			else
			{
				// Create File
				using (FileStream fs = File.Create(filepath))
				{
					foreach(Infomation inf in info_list)
					{
						AddText(fs, Convert.ToChar(inf).ToString());
					}
					fs.Close();
				}
			}
		}

		public List<Infomation> Road()
		{
			List<Infomation> infos = new List<Infomation>();
			Infomation inf = new Infomation();
			string[] array = { };
			if(!File.Exists(filepath))
			{
				infos = null;
			}
			else
			{
				using (FileStream fs = File.OpenRead(filepath))
				{
					byte[] b = new byte[1024];
					UTF8Encoding temp = new UTF8Encoding(true);
					while(fs.Read(b, 0, b.Length) > 0)
					{
						array = temp.GetString(b).Split(splitChar);
						inf.Title = array[0];
						inf.MailID = array[1];
						inf.Password = array[2];
						inf.Explain = array[3];
						infos.Add(inf);
					}
				}
			}

			return infos;
		}

		static void AddText(FileStream fs, string value)
		{
			byte[] info = new UTF8Encoding(true).GetBytes(value);
			fs.Write(info, 0, info.Length);
		}
	}
}
