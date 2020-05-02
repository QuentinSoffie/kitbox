using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbox.Components
{
    public class Slider : Specs
    {
        public Slider(int height, int availableStock, int minStock, string code, string dimensionsToString) : base(height, 0, 0, availableStock, minStock,  code,  dimensionsToString)
        {
        }
        public override string ToString()
        {
            return string.Format("\n----Slider----\nHeight: {0}\nWidth: {1}\nDepth: {2}\nAvailableStock: {3}\nMinStock: {4}\n", Height, Width, Depth, AvailableStock, MinStock);
        }

        public override int CountComponents()
        {
            return 4;
        }
    }
}
