using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronXL;

namespace MarchéWilliam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WorkBook workBook = WorkBook.Load(@"D:\3emeAnnee\i323\Module\exos\marché\Place du marché.xlsx");
            WorkSheet sheet = workBook.GetWorkSheet("Produits");

            string produit = "Pêches";
            string produit2 = "Pastèques";

            int stand = 0;

            string unité = "";
            string producteurMax = "";
            int valueCell;
           
            int count = 0;
            int valeurmax = 0;

            for (int i = 2; i <= 75; i++)
            {
                string produitCell = sheet[$"C{i}"].Value.ToString();
                if (produitCell == produit)
                {
                    count++;
                }

                if (produitCell == produit2)
                {
                    valueCell = Convert.ToInt32(sheet[$"D{i}"].Value);
                    if (valueCell > valeurmax)
                    {
                        valeurmax = valueCell;
                        producteurMax = sheet[$"B{i}"].ToString();
                        stand = Convert.ToInt32(sheet[$"A{i}"].Value);
                        unité = sheet[$"E{i}"].ToString();
                    }
                }
            }

            Console.WriteLine($"Il y a  {count} vendeurs de {produit}");
            Console.WriteLine($"C'est {producteurMax} qui a le plus de pastèques (stand {stand},{valeurmax} {unité})");

            Console.ReadLine();
        }
       
    }
    
}
