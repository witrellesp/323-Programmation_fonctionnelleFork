using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Linq;
using System.IO;

namespace marché2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Place du marché");
            ISheet sheet;
            using (var stream = new FileStream("Place du marché.xlsx", FileMode.Open))
            {
                stream.Position = 0;
                XSSFWorkbook xssWorkbook = new XSSFWorkbook(stream);
                sheet = xssWorkbook.GetSheetAt(1);//select 2nd sheet

                var data = new List<MarketInfo>();


                //Va crear un objeto con cada celula que se encuentra en la misma fila
                for (int i = (sheet.FirstRowNum + 1/*skip header*/); i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    int j = 0;
                    data.Add(new MarketInfo(
                        row.GetCell(0).NumericCellValue.ToString(),
                        row.GetCell(1).StringCellValue,
                        row.GetCell(2).ToString(),
                        row.GetCell(3).ToString(),
                        row.GetCell(4).ToString(),
                        row.GetCell(5).ToString()
                        ));
                }
                //Console.WriteLine(data);
                /*
                MarketInfo maxWatermelon = null;
                var peachSellers = new Dictionary<string, bool>();
                foreach (var item in data)
                {
                    if (item.Product == "Pêches")
                    {
                        if (!peachSellers.ContainsKey(item.Seller))
                        {
                            peachSellers.Add(item.Seller, true);
                        }
                    }
                    if (item.Product == "Pastèques")
                    {
                        if (maxWatermelon == null)
                        {
                            maxWatermelon = item;
                        }
                        else if (item.Quantity > maxWatermelon.Quantity)
                        {
                            maxWatermelon = item;
                        }
                    }
                }*/

                //VERSION LINQ
                var peachProducersLINQ = (from item in data where item.Product == "Pêches" select item).Count();
                var productorPastequeMaxLINQ = (from item in data where item.Product == "Pastèques")

                            Console.Write($"Il y {peachProducersLINQ} producteurs de pêches");






                Console.ReadLine();




            }
        }
    }
    class MarketInfo
    {
        public MarketInfo(string place, string seller, string product, string quantity, string unit, string pricPerUnit)
        {
            Place = place;
            Seller = seller;
            Product = product;
            Quantity = Convert.ToInt32(quantity);
            Unit = UnitConverter.fromString(unit);


            PricPerUnit = Convert.ToSingle(pricPerUnit);
        }

        public string Place { get; private set; }
        public string Seller { get; private set; }
        public string Product { get; private set; }
        public int Quantity { get; private set; }

        public Unit Unit { get; private set; }

        public float PricPerUnit { get; private set; }
    }
    enum Unit
    {
        kg, unit
    }
    static class UnitConverter
    {
        public static Unit fromString(string unit)
        {
            switch (unit)
            {
                case "kg": return Unit.kg;
                case "pièce": return Unit.unit;

                default: return Unit.kg;
            }
        }
    }

}
