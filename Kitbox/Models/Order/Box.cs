using System.Collections.Generic;
using Kitbox.Models.Components;

namespace Kitbox.Models.Order
{
    /// <summary>
    /// This is the box class. It's made of Specs.
    /// </summary>
    public class Box
    {
        public int Uid { get; set; }
        public readonly Door Door;
        public readonly Cups Cups;
        public readonly Slider Slider;
        public readonly List<Panel> Panels;
        public readonly List<Traverse> Traverse;
        public readonly int Height;
        public readonly int Width;
        public readonly int Depth;
        public string State { get; set; }

        public Box(int uid, Door door, Slider slider, List<Panel> panels, List<Traverse> traverse, Cups cups)
        {
            this.Uid = uid;
            this.Door = door;
            this.Slider = slider;
            this.Panels = panels;
            this.Traverse = traverse;
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
