using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbox.Components
{
    public class Cups : Specs
    {
        public Cups(int availableStock, int minStock, string code, string dimensionsToString) : base(0, 0, 0, availableStock, minStock, code, dimensionsToString)
        {
        }

        public override int CountComponents()
        {
            return 2;
        }
    }
}
