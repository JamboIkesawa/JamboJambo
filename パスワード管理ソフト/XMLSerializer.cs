using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace パスワード管理ソフト
{
    public class Infomation
    {
        public string Title { get; set; }
        public string MailID { get; set; }
        public string Password { get; set; }
        public string Explain { get; set; }
    }

    public class XML
	{
        static string filename = @"\xmlfile\Data.xml";

		private void CreateFile()
		{
			if (!Directory.Exists(filename))
			{
				Directory.CreateDirectory(filename);
			}
			else
			{
				if(!File.Exists(filename))
				{
					File.Create(filename);
				}
			}
		}

        public static void SerializeXML(List<Infomation> infolist)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Infomation>));
			using (StreamWriter sw = new StreamWriter(filename, false, Encoding.UTF8))
			{
				serializer.Serialize(sw, infolist);
				sw.Flush();
			}

			//try
			//{
			//	StreamWriter sw = new StreamWriter(filename, false, new UTF8Encoding(false));
			//	serializer.Serialize(sw, infolist);
			//	sw.Close();
			//}
			//catch(UnauthorizedAccessException uae)
			//{
			//	uae.ToString();
			//}
			
        }

        public static List<Infomation> DeserializeXML()
        {
            List<Infomation> infoList = new List<Infomation>();
			XmlSerializer serializer = new XmlSerializer(typeof(List<Infomation>));

			var xmlSettings = new System.Xml.XmlReaderSettings()
			{
				CheckCharacters = false
			};
			using (StreamReader sr = new StreamReader(filename, Encoding.UTF8))
			using(var xmlReader = System.Xml.XmlReader.Create(sr, xmlSettings))
			{
				infoList = (List<Infomation>)serializer.Deserialize(xmlReader);
			}

				//try
				//{
				//	StreamReader sr = new StreamReader(filename, new UTF8Encoding(false));
				//	infoList = (List<Infomation>)serializer.Deserialize(sr);
				//	sr.Close();
				//}
				//catch(UnauthorizedAccessException uae)
				//{
				//	uae.ToString();
				//}

			return infoList;
        }
    }


}