using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbox.Classes
{
    class Specs
    {
        public float Height { get; set; }
        public float Width { get; set; }
        public float Depth { get; set; }

        public Specs(float height, float width, float depth)
        {
            this.Height = height;
            this.Width = width;
            this.Depth = depth;
        }

    }
}
