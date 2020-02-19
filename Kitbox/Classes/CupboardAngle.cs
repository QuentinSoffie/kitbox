using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbox.Classes
{
    class CupboardAngle : Specs
    {
        public string Color { get; set; }
        public CupboardAngle(string color, float height, float width, float depth) : base(height, width, depth)
        {
            this.Color = color;
        }
    }
}
