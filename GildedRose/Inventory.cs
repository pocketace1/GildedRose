using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    public class Inventory
    {
        public List<NormalItem> Stock;

        public Inventory() 
        {
            Stock = new List<NormalItem>();
        }

        public void Add(NormalItem item)
        {
            Stock.Add(item);
        }

        public void Age()
        {
            Stock.ForEach(i => i.Age());
        }

        public void print(string header)
        {
            Console.WriteLine("   START of " + header);
            Stock.ForEach(i => Console.WriteLine(i.ToString()));
            Console.WriteLine("   END of " + header);
            Console.WriteLine(" ");
        }
    }
}
