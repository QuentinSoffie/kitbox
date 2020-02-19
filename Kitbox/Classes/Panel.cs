using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbox.Classes
{
    class Panel : Specs
    {
        public string Color { get; set; }
        public Panel(string color, float height, float width, float depth) : base (height, width, depth)
        {
            this.Color = color;
        }
    }
}
