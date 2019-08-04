using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/* YAMLのSerializeが出来るようになる */
using YamlDotNet.Serialization;

namespace YamlDotNet.Samples
{
	public class SerializeObjectGraph
	{
		public void Main()
		{
            /// <summary>
            /// 住所クラス
            /// </summary>
            /// <value>streat : 通り</value>
            /// <value>city : 市</value>
            /// <value>state : 州</value>
			var address = new
			{
				street = "123 Tornado Alley\nSuite 16",
				city = "East Westville",
				state = "KS"
			};

            /// <summary>
            /// 領収書クラス
            /// </summary>
            /// <value>receipt          :   領収書</value>
            /// <value>date             :   日付</value>
            /// <value>customer         :   顧客</value>
            /// <value>items            :   商品リスト</value>
            /// <value>bill_to          :   請求書送付先</value>
            /// <value>ship_to          :   送り先</value>
            /// <value>specialDelivery  :   速達</value>
			var receipt = new
			{
				receipt = "Oz-Ware Purchase Invoice",   //オズウェア購入請求書
				date = new DateTime(2007, 8, 6),        //日付(2007年8月6日)
                /// <summary>
                /// 顧客クラス
                /// </summary>
                /// <value>given    :   名</value>
                /// <value>family   :   性</value>
				customer = new
				{
					given = "Dorothy",
					family = "Gale"
				},
                /// <summary>
                /// アイテムクラス
                /// </summary>
                /// <value>part_no  :   商品コード</value>
                /// <value>descrip  :   商品名</value>
                /// <value>price    :   価格</value>
                /// <value>quantity :   量</value>
				items = new[]
                {
                    new
                    {
                        part_no = "A4786",
                        descrip = "Water Bucket (Filled)",
                        price = 1.47M,
                        quantity = 4
                    },
                    new
                    {
                        part_no = "E1628",
                        descrip = "High Heeled \"Ruby\" Slippers",
                        price = 100.27M,
                        quantity = 1
                    }
                },
				bill_to = address,                              //請求書送付先
				ship_to = address,                              //送り先
				specialDelivery = "Follow the Yellow Brick\n" +
								  "Road to the Emerald City.\n" +
								  "Pay no attention to the\n" +
								  "man behind the curtain."     //速達
			};

			var serializer = new Serializer();
			serializer.Serialize(Console.Out, receipt);
		}
	}
}