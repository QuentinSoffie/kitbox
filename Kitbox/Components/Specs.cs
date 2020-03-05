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

        public Specs(int height, int width, int depth)
        {
            this.Height = height;
            this.Width = width;
            this.Depth = depth;
        }

        public void Show()
        {
            Console.WriteLine(string.Format("Height: {0}, Width: {1}, Depth: {2}", Height, Width, Depth));
        }

    }
}
