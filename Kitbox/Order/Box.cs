using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kitbox.Components;

namespace Kitbox.Order
{
    public class Box
    {
        public int Uid { get; set; }
        private readonly Door Door;
        private readonly Slider Slider;
        private readonly List<Panel> Panels;
        private readonly List<Traverses> Traverses;


        public Box(int uid, Door door, Slider slider, List<Panel> panels, List<Traverses> traverses)
        {
            this.Uid = uid;
            this.Door = door;
            this.Slider = slider;
            this.Panels = panels;
            this.Traverses = traverses;
        }

    }
}
