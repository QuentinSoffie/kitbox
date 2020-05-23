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
        public readonly Door Door;
        public readonly Cups Cups;
        public readonly Slider Slider;
        public readonly List<Panel> Panels;
        public readonly List<Traverses> Traverses;
        public readonly int Height;
        public readonly int Width;
        public readonly int Depth;
        public string State { get; set; }

        public Box(int uid, Door door, Slider slider, List<Panel> panels, List<Traverses> traverses, Cups cups)
        {
            this.Uid = uid;
            this.Door = door;
            this.Slider = slider;
            this.Panels = panels;
            this.Traverses = traverses;
            this.Cups = cups;
            this.Height = ComputeHeight();
            this.Width = ComputeWidth();
            this.Depth = ComputeDepth();
        }
        private int ComputeHeight()
        {
            return 4 + Slider.Height;
        }
        private int ComputeWidth()
        {
            return Panels[0].Width;
        }
        private int ComputeDepth()
        {
            return Panels[1].Depth;
        }
        public override string ToString()
        {
            return string.Format("\n----Box----\nHeight: {0}\nWidth: {1}\nDepth: {2}\n", Height, Width, Depth);
        }
    }
}
