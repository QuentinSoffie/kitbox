using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbox.Components
{
    public class Panel : Specs
    {
        public readonly string Color;
        public readonly string Type; 
        public Panel(string color, string type, int height, int width, int depth, int availableStock, int minStock, string code, string dimensionsToString) : base (height, width, depth, availableStock, minStock,  code,  dimensionsToString)
        {
            this.Color = color;
            this.Type = type;
        }
        public override string ToString()
        {
            return string.Format("\n----Panel----\nColor: {0}Height: {1}\nWidth: {2}\nDepth: {3}\nAvailableStock: {4}\nMinStock: {5}\nType: {6}", Color, Height, Width, Depth, AvailableStock, MinStock, Type) ;
        }

        public override int CountComponents()
        {
            if (Type == "Ar" )
            {
                return 1;
            }
            else if (Type == "GD" || Type == "HB")
            {
                return 2;
            }
            return 0;

        }
    }
}
