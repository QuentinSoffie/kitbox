using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitbox.GUI;

namespace Kitbox.Components
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

        public void AddBox(int uid, Door door, Slider cleat, Panel panel, Traverses traverses)
        {
            ListeBoxes.Add(new Box(uid,door,cleat,panel,traverses));
        }
      
        public void RemoveAt(int uid)
        {
            ListeBoxes.Clear();
        }
    }
}
