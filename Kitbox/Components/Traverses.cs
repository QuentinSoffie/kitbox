using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbox.Components
{
    public class Traverses : Specs
    {
        private readonly string Type;
        public Traverses(string type, int height, int width, int depth, int availableStock, int minStock) : base(height, width, depth, availableStock, minStock)
        {
            this.Type = type;
        }
        public override string ToString()
        {
            return string.Format("\n----Traverses----\nHeight: {0}\nWidth: {1}\nDepth: {2}\nAvailableStock: {3}\nMinStock: {4}\nType: {5}", Height, Width, Depth, AvailableStock, MinStock, Type);
        }
    }
}
