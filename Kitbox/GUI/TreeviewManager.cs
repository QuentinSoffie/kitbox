using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitbox.Components;
using KitboxEcamGUI;
using System.Windows.Forms;
namespace Kitbox.GUI
{
    public class TreeviewManager
    {
        private PepTreeView MainTreeview;
       
        private Control.ControlCollection ViewCupboardList;

        private int UidTreeview = 0;

        private Order.Order OurOrder;

        public TreeviewManager(KitboxEcamGUI.PepTreeView mainTreeview, Control.ControlCollection viewCupboardList,Order.Order ourOrder)
        {
            this.MainTreeview = mainTreeview;
            this.ViewCupboardList = viewCupboardList;
            this.OurOrder = ourOrder;
        }

        public void AddViewCupboard(int uid, Cupboard cupboard)
        {
            Kitbox.GUI.ViewCupboard view = new Kitbox.GUI.ViewCupboard(uid, cupboard, this);
            view.Dock = DockStyle.Fill;
            ViewCupboardList.Add(view);
            view.BringToFront();
        }

        public void BringToFrontView(int uid)
        {
            foreach (Kitbox.GUI.ViewCupboard view in ViewCupboardList)
            {
              if (view.Uid == uid)
                {
                    view.BringToFront();
                    break;
                }
            }
        }

        private void RemoveView(int uid)
        {
            foreach (Kitbox.GUI.ViewCupboard view in ViewCupboardList)
            {
                if (view.Uid == uid)
                {
                    ViewCupboardList.Remove(view);
                    break;
                }
            }
        }

        public void AddCupboard(Order.Order ourOrder, string Tag = "contains 0 Box")
        {
            UidTreeview += 1;
            MainTreeview.Nodes.Add(UidTreeview.ToString(), "Cupboard - Uid " + UidTreeview);
            MainTreeview.Nodes[ReturnIndexTreeview(UidTreeview)].Tag = Tag;
            MainTreeview.Nodes[ReturnIndexTreeview(UidTreeview)].ImageIndex = 1;
            ourOrder.Add(UidTreeview, this);
        }

        private int ReturnIndexTreeview(int uid)
        {
            for (int countCupboard = 0; countCupboard < MainTreeview.Nodes.Count; countCupboard++)
            {
                for (int countBox = 0; countBox < MainTreeview.Nodes[countCupboard].Nodes.Count; countBox++)
                {
                    if (MainTreeview.Nodes[countCupboard].Nodes[countBox].Name == uid.ToString())
                    {
                        return countBox;
                    }
                }
                if (MainTreeview.Nodes[countCupboard].Name == uid.ToString())
                {
                    return countCupboard;
                }
            }

            return -1;
        }

        public void RemoveCupboard(int uid)
        {
            OurOrder.RemoveAt(uid);
            MainTreeview.Nodes.RemoveAt(ReturnIndexTreeview(uid));
            RemoveView(uid);


        }
        public void AddBox( int uidCupboard ,string tag = "Completed")
        {
            UidTreeview += 1;
            MainTreeview.Nodes[ReturnIndexTreeview(uidCupboard)].Nodes.Add(UidTreeview.ToString(), "Box - UID" + UidTreeview);
            MainTreeview.Nodes[ReturnIndexTreeview(uidCupboard)].Nodes[ReturnIndexTreeview(UidTreeview)].Tag = tag;
            MainTreeview.Nodes[ReturnIndexTreeview(uidCupboard)].Nodes[ReturnIndexTreeview(UidTreeview)].ImageIndex = 0;
        }

        private void RemoveBox(int uid)
        {
           
        }
    }
}
