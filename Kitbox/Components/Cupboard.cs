using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbox.Components
{
    class Cupboard
    {
        public int Uid { get; set; } 
        public List<Box> ListeBoxes { get; set; }
        public CupboardAngle CupboardAngle { get; set; }
        public Cupboard(int uid)
        {
            this.Uid = uid;
        }

        public void AddBox(Box box)
        {
            ListeBoxes.Add(box);
        }
        public void RemoveBox(Box box)
        {
            ListeBoxes.Remove(box);
        }
        public void RemoveAll()
        {
            ListeBoxes.Clear();
        }
    }
}
