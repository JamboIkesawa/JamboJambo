using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace パスワード管理ソフト
{
	public class JSONSerealizer<Type>
	{
		private string filename;

		public JSONSerealizer(string filename)
		{
			this.filename = filename;
		}

		public void Write(Type obj)
		{
			var json = JsonConvert.SerializeObject(obj, Formatting.Indented);

			using(var sw = new StreamWriter(filename, false, Encoding.UTF8))
			{
				sw.Write(json);
			}
		}

		public Type Read()
		{
			using (var sr = new StreamReader(filename, Encoding.UTF8))
			{
				//var data = sr.;
				//return JsonConvert.DeserializeObject<Type>(data);
			}
		}
	}

	public class JSONClass
	{
		string filename = @"data.json";

		public void WriteJson(List<Infomation> infoList)
		{
			var serializer = new JSONSerealizer<Infomation>(filename);
			foreach (Infomation inf in infoList)
			{
				serializer.Write(inf);
			}
		}
		/*
		public List<Infomation> ReadJson()
		{

		}*/
	}
}
