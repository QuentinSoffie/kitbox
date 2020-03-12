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
        private readonly int Height;
        private readonly int Width;
        private readonly int Depth;


        public Box(int uid, Door door, Slider slider, List<Panel> panels, List<Traverses> traverses)
        {
            this.Uid = uid;
            this.Door = door;
            this.Slider = slider;
            this.Panels = panels;
            this.Traverses = traverses;
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
            return Door.Width;
        }
        private int ComputeDepth()
        {
            return Panels[0].Depth;
        }
        public override string ToString()
        {
            return string.Format("\n----Box----\nHeight: {0}\nWidth: {1}\nDepth: {2}\n", Height, Width, Depth);
        }
    }
}
