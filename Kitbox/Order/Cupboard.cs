using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitbox.GUI;
using Kitbox.Components;

namespace Kitbox.Order
{
   public  class Cupboard
    {
        public int Uid { get; set; }
        public readonly List<Box> ListeBoxes;
        public CupboardAngle CupboardAngle { get; set; }
        private readonly ViewCupboard View;

        public Cupboard(int uid)
        {
            this.Uid = uid;
            ListeBoxes = new List<Box>();
        }

        public Box AddBox(int uidCupboard,int uid, Door door, Slider slider, List<Panel> panels, List<Traverses> traverses, TreeviewManager viewManager)
        {
            Box newBox = new Box(uid, door, slider, panels, traverses);
            viewManager.AddViewBox(uidCupboard,uid, newBox);
            ListeBoxes.Add(newBox);
            return newBox;
        }
      
        public void RemoveAt(int uid)
        {
            ListeBoxes.Clear();
        }

        public int CountBox()
        {
            return ListeBoxes.Count();
        }
    }
}
