using System.Collections.Generic;
using System.Linq;
using Kitbox.GUI;
using Kitbox.Components;

namespace Kitbox.Order
{
    /// <summary>
    /// This is the Cupboard class. It's made of boxes.
    /// </summary>
   public  class Cupboard
    {
        public int Uid { get; set; }
        public readonly List<Box> ListeBoxes;
        public string State = "Completed ✓";
        public CupboardAngle CupboardAngle { get; set; }
       
        public Cupboard(int uid)
        {
            this.Uid = uid;
            ListeBoxes = new List<Box>();
        }

        public string CheckState()
        {
            foreach (Box box in ListeBoxes)
            {
                if (box.State == "Not completed")
                {
                    State = box.State;
                }
            }
            return State;
        }

        public Dictionary<string, string> GetSizes()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            string width = ListeBoxes[0].Width.ToString();
            string depth = ListeBoxes[0].Depth.ToString();
            int height = 0;

            foreach (Box box in ListeBoxes)
            {
                height += box.Height;
            }

            dict.Add("Height", height.ToString());
            dict.Add("Width", width);
            dict.Add("Depth", depth);
            return dict;
        }

        public Box AddBox(int uidCupboard,int uid, Door door, Slider slider, List<Panel> panels, List<Traverses> traverses, Cups cups, string state, TreeviewManager viewManager)
        {
            Box newBox = new Box(uid, door, slider, panels, traverses, cups);
            newBox.State = state;
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
