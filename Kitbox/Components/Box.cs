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
        public Slider Slider { get; set; }
        public Panel Panel { get; set; }
        public Traverses Traverses { get; set; }

        public Box(int uid)
        {
            this.Uid = uid;
        }

        public void AddSpecs(int height, int width, int depth, int panelColor, int doorColor)
        {

        }
        public void AddDoor(int height, int width, string color)
        {
            Door = new Door(color, height, width, 0);
        }
        public void AddSlider(int height)
        {

        }
        public void AddPanel(int height, int width, int depth, string color)
        {

        }
        public void AddTraverses(int width, int depth)
        {

        }
    }
}
