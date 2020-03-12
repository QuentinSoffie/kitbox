using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbox.Components
{
    public class CupboardAngle : Specs
    {
        public readonly string Color;
        public CupboardAngle(string color, int height, int width, int depth, int availableStock, int minStock) : base(height, width, depth, availableStock, minStock)
        {
            this.Color = color;
        }
    }
}
