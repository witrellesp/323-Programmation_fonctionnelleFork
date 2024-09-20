using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Product { Location = 1, Producer = "Bornand", ProductName = "Pommes", Quantity = 20,Unit = "kg", PricePerUnit = 5.50 },
                new Product { Location = 1, Producer = "Bornand", ProductName = "Poires", Quantity = 16,Unit = "kg", PricePerUnit = 5.50 },
                new Product { Location = 1, Producer = "Bornand", ProductName = "Pastèques", Quantity = 14,Unit = "pièce", PricePerUnit = 5.50 },
                new Product { Location = 1, Producer = "Bornand", ProductName = "Melons", Quantity = 5,Unit = "kg", PricePerUnit = 5.50 },
                new Product { Location = 2, Producer = "Dumont", ProductName = "Noix", Quantity = 20,Unit = "sac", PricePerUnit = 5.50 },
                new Product { Location = 2, Producer = "Dumont", ProductName = "Raisin", Quantity = 6,Unit = "kg", PricePerUnit = 5.50 },
                new Product { Location = 2, Producer = "Dumont", ProductName = "Pruneaux", Quantity = 13,Unit = "kg", PricePerUnit = 5.50 },
                new Product { Location = 2, Producer = "Dumont", ProductName = "Myrtilles", Quantity = 12,Unit = "kg", PricePerUnit = 5.50 },

            };
            var i18n = new Dictionary<string, string>()
            {
            { "Pommes","Apples"},
            { "Poires","Pears"},
            { "Pastèques","Watermelons"},
            { "Melons","Melons"},
            { "Noix","Nuts"},
            { "Raisin","Grapes"},
            { "Pruneaux","Plums"},
            { "Myrtilles","Blueberries"},
            { "Groseilles","Berries"},
            { "Tomates","Tomatoes"},
            { "Courges","Pumpkins"},
            { "Pêches","Peaches"},
            { "Haricots","Beans"}
            };

            //List<(string, string, double)>
            var listeCA = products
                .Select(
                    //tupple implicite
                    p => (
                        seller: p.Producer.Substring(0, Math.Min(p.Producer.Length, 3)),
                        sellerLetter: p.Producer.Substring(p.Producer.Length - 1),
                        product: p.ProductName,
                        /*.CompareTo(),*/
                        ca: p.Quantity * p.PricePerUnit
                    )
                )
                .ToList();

            Console.WriteLine("Seller  Product  CA");
            foreach (var item in listeCA)
            {

                Console.WriteLine($"{item.seller}...{item.sellerLetter} {item.product} {item.ca}");

            }
            Console.ReadLine();






        }
    }

    internal class Product
    {
        public int Location { get; set; }
        public string Producer { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public double PricePerUnit { get; set; }
    }
}
