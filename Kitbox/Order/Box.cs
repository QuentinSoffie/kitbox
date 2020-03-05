using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbox.Components
{
    public class Box
    {
        public int Uid { get; set; }
        private readonly Door Door;
        private readonly Slider Cleat;
        private readonly Panel Panel;
        private readonly Traverses Traverses;


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
