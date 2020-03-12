using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbox.Components
{
    public class Specs
    {
        public readonly int Height;
        public readonly int Width;
        public readonly int Depth;
        public readonly int AvailableStock;
        public readonly int MinStock;


        public Specs(int height, int width, int depth, int availableStock, int minStock)
        {
            this.Height = height;
            this.Width = width;
            this.Depth = depth;
            this.AvailableStock = availableStock;
            this.MinStock = minStock;
        }

        public void Show()
        {
            Console.WriteLine(string.Format("Height: {0}, Width: {1}, Depth: {2}", Height, Width, Depth));
        }
        public override string ToString()
        {
            return string.Format("\n----Specs----\nHeight: {0}\nWidth: {1}\nDepth: {2}\nAvailableStock: {3}\nMinStock: {4}\n", Height, Width, Depth, AvailableStock, MinStock);
        }

    }
}
