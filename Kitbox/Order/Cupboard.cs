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
        public List<Box> ListeBoxes { get; set; }
        public CupboardAngle CupboardAngle { get; set; }
        private readonly ViewCupboard View;

        public Cupboard(int uid)
        {
            this.Uid = uid;
            ListeBoxes = new List<Box>();
           
        }

        public void AddBox(int uid, Door door, Slider cleat, List<Panel> panels, List<Traverses> traverses)
        {
            ListeBoxes.Add(new Box(uid, door, cleat, panels, traverses));
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
