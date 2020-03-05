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
        public Panel(string color,string type, int height, int width, int depth) : base (height, width, depth)
        {
            this.Color = color;
            this.Type = type;
        }
    }
}
