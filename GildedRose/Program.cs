using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFileName = ".\\StartingInventory.txt";
            var outputFileName = ".\\AgedInventory.txt";
            Console.Write(@"\nPress SPACE bar + ENTER to pick default file and location: .\\StartingInventory.txt 
                            \nOr type in the Inventory File name and hit the 'Enter' Key");
            var inputLine = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(inputLine))
            {
                inputFileName = inputLine;
            }
            List<string> lines = System.IO.File.ReadAllLines(inputFileName).ToList();

            Inventory inventory = new Inventory();

            lines.ForEach(l =>
            {
                inventory.Add(ItemMethods.createItemObject(l));
            });
            inventory.print("Starting Inventory:");
            inventory.Age();
            inventory.print("Ending Inventory:");

            Console.Write(@"To exit, hit the 'Enter' Key");
            inputLine = Console.ReadLine();
        }  
    }
}
