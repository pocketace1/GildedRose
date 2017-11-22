using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    public class NormalItem
    {
        public string Name { get; set; }
        public int Sellin { get; set; }
        public int Quality { get; set; }
        public int QualityIncrement { get; set; }
        
        public NormalItem(string name, int sellin, int quality)
        {
            Name = name;
            Sellin = sellin;
            Quality = quality;
            QualityIncrement = 1;
        }

        public virtual void Age()
        {
            --Sellin;
            int decrement = (Sellin < 0 ? 2 : 1) * QualityIncrement;

            Quality -= decrement;
            Quality = (Quality < 0) ? 0 : (Quality > 50 ? 50 : Quality);

        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Name, Sellin, Quality);
        }
    }


    public class Sulfuras : NormalItem
    {
        public Sulfuras(string name, int sellin, int quality) : base(name, sellin, quality)
        {
        }

        public override void Age()
        {
        }
    }


    public class AgedBrie : NormalItem
    {
        public AgedBrie(string name, int sellin, int quality) : base(name, sellin, quality)
        {
            QualityIncrement = 1;
        }

        public override void Age()
        {
            --Sellin;
            Quality = (Quality < 50) ? Quality + QualityIncrement : 50;
        }
    }


    public class BackstagePasses : AgedBrie
    {
        public BackstagePasses(string name, int sellin, int quality) : base(name, sellin, quality)
        {
            setQualityChange(sellin);
        }

        public override void Age()
        {
            --Sellin;
            setQualityChange(Sellin);
            Quality = (Quality + QualityIncrement < 50) ? Quality + QualityIncrement : 50;
        }

        protected void setQualityChange(int sellin)
        {
            if (sellin < 0)
            {
                QualityIncrement = 0;
                Quality = 0;
            }
            else if (sellin <= 5)
            {
                QualityIncrement = 3;
            }
            else if (sellin <= 10)
            {
                QualityIncrement = 2;
            }
            else
            {
                QualityIncrement = 1;
            }
        }
    }


    public class Conjured : NormalItem
    {
        public Conjured(string name, int sellin, int quality) : base(name, sellin, quality)
        {
            QualityIncrement = 2;
        }
    }

    public class INVALIDITEM : NormalItem
    {
        public INVALIDITEM(string name, int sellin, int quality) : base(name, sellin, quality)
        {
        }

        public override void Age()
        {
        }
        public override string ToString()
        {
            return "NO SUCH ITEM";
        }
    }
}
