using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace YamlDotNet.Samples
{
	public class DeserializeObjectGraph
	{
		public void Main()
		{
			//inputにDocumentを格納する
			var input = new StringReader(Document);
			
			//キャメル記法で書かれたものを読めるインスタンスを生成
			var deserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention());
			
			//DocumentをOrderクラスに変換してorderに格納する
			var order = deserializer.Deserialize<Order>(input);
			
			Console.WriteLine("Order");
			Console.WriteLine("-----");
			Console.WriteLine();
			foreach(var item in order.Items)
			{
				Console.WriteLine("{0}\t{1}\t{2}\t{3}", item.PartNo, item.Quantity, item.Price, item.Descrip);
			}
			Console.WriteLine();
			
			Console.WriteLine("Shipping");
			Console.WriteLine("--------");
			Console.WriteLine();
			Console.WriteLine(order.ShipTo.Street);
			Console.WriteLine(order.ShipTo.City);
			Console.WriteLine(order.ShipTo.State);
			Console.WriteLine();
			
			Console.WriteLine("Billing");
			Console.WriteLine("-------");
			Console.WriteLine();
			if(order.BillTo == order.ShipTo) {
				Console.WriteLine("*same as shipping address*");
			} else {
				Console.WriteLine(order.ShipTo.Street);
				Console.WriteLine(order.ShipTo.City);
				Console.WriteLine(order.ShipTo.State);
			}
			Console.WriteLine();
			
			Console.WriteLine("Delivery instructions");
			Console.WriteLine("---------------------");
			Console.WriteLine();
			Console.WriteLine(order.SpecialDelivery);
		}
		
		/// <summary>
		/// 注文クラス
		/// </summary>
		/// <value>Receipt			: 領収書(文字列型)</value>
		/// <value>Date				: 日付(DateTime型)</value>
		/// <value>Customer			: 顧客(Customer型)</value>
		/// <value>Items			: 商品リスト(List<OrderItem>型)</value>
		/// <value>BillTo			: 請求書送付先(Address型, エイリアス;bill-to)</value>
		/// <value>ShipTo			: 送り先(Address型, エイリアス;ship-to</value>
		/// <value>SpecialDelivery	: 速達(文字列型)</value>
		public class Order
		{
			public string Receipt { get; set; }
			public DateTime Date { get; set; }
			public Customer Customer { get; set; }
			public List<OrderItem> Items { get; set; }
			
			[YamlAlias("bill-to")]
			public Address BillTo { get; set; }
			
			[YamlAlias("ship-to")]
			public Address ShipTo { get; set; }
			
			public string SpecialDelivery { get; set; }
		}
		
		/// <summary>
		/// 顧客クラス
		/// </summary>
		/// <value>Given	: 名(文字列型)</value>
		/// <value>Family	: 性(文字列型)</value>
		public class Customer
		{
			public string Given { get; set; }
			public string Family { get; set; }
		}
		
		/// <summary>
		/// 商品リストクラス
		/// </summary>
		/// <value>PrtNo	: 商品コード(文字列コード, エイリアス;part_no)</value>
		/// <value>Descrip	: 商品名(文字列型)</value>
		/// <value>Price	: 価格(decimal型：数値、浮動小数点数)</value>
		/// <value>Quantity	: 量(int型：整数型)</value>
		public class OrderItem
		{
			[YamlAlias("part_no")]
			public string PartNo { get; set; }
			public string Descrip { get; set; }
			public decimal Price { get; set; }
			public int Quantity { get; set; }
		}
		
		/// <summary>
		/// 住所クラス
		/// </summary>
		/// <value>Street	: 通り</value>
		/// <value>City		: 市</value>
		/// <value>State	: 州</value>
		public class Address
		{
			public string Street { get; set; }
			public string City { get; set; }
			public string State { get; set; }
		}
		
		/* ここを文字列を結合したりして可変にできるようにしたい */
		private const string Document = @"---
            receipt:    Oz-Ware Purchase Invoice
            date:        2007-08-06
            customer:
                given:   Dorothy
                family:  Gale

            items:
                - part_no:   A4786
                  descrip:   Water Bucket (Filled)
                  price:     1.47
                  quantity:  4

                - part_no:   E1628
                  descrip:   High Heeled ""Ruby"" Slippers
                  price:     100.27
                  quantity:  1

            bill-to:  &id001
                street: |-
                        123 Tornado Alley
                        Suite 16
                city:   East Westville
                state:  KS

            ship-to:  *id001

            specialDelivery: >
                Follow the Yellow Brick
                Road to the Emerald City.
                Pay no attention to the
                man behind the curtain.
		...";
	}
}