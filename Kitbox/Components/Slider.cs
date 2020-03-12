using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbox.Components
{
    public class Slider : Specs
    {
        public Slider(int height, int availableStock, int minStock) : base(height, 0, 0, availableStock, minStock)
        {
        }
    }
}
