using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbox.Components
{
    class Box
    {
        public int Uid { get; set; }
        public Door Door { get; set; }
        public Slider Cleat { get; set; }
        public Panel Panel { get; set; }
        public Traverses Traverses { get; set; }

        public Box(int uid, Door door, Slider cleat, Panel panel, Traverses traverses)
        {
            this.Uid = uid;
            this.Door = door;
            this.Cleat = cleat;
            this.Panel = panel;
            this.Traverses = traverses;
        }
    }
}
