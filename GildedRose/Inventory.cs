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
            System.Diagnostics.Debug.WriteLine("   START of " + header);
            Stock.ForEach(i => System.Diagnostics.Debug.WriteLine(i.ToString()));
            System.Diagnostics.Debug.WriteLine("   END of " + header);
            System.Diagnostics.Debug.WriteLine(" ");
        }
    }
}
