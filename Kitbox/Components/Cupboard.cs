using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kitbox.GUI;

namespace Kitbox.Components
{
    public class Cupboard
    {
        public int Uid { get; set; } 
        public List<Box> ListBoxes { get; set; }
        public List<CupboardAngle> ListCupboardAngle { get; set; }
        public CupboardAngle CupboardAngle { get; set; }
        public ViewCupboard View { get; set; }
        public Cupboard(int uid, ViewCupboard view)
        {
            this.Uid = uid;
            ListBoxes = new List<Box>();
            ListCupboardAngle = new List<CupboardAngle>();
            this.View = view;
        }
        
        public void AddBox(int uid)
        {
            ListBoxes.Add(new Box(uid));
        }
        public void RemoveBox(Box box)
        {
            ListBoxes.Remove(box);
        }
        public void RemoveAll()
        {
            ListBoxes.Clear();
        }
        public void BringToFront()
        {
            View.BringToFront();
        }
    }
}
