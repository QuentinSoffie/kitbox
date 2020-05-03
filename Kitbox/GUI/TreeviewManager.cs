using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitbox.Components;
using KitboxEcamGUI;
using System.Windows.Forms;
using Kitbox.Order;
using MySql.Data.MySqlClient;
using Kitbox.Database;
using Panel = Kitbox.Components.Panel;

namespace Kitbox.GUI
{
    public class TreeviewManager
    {
        private PepTreeView MainTreeview;
       
        private Control.ControlCollection ViewList;

        private int UidTreeview = 0;

        private Order.Order OurOrder;

        private MySqlConnection Database;

        public TreeviewManager(KitboxEcamGUI.PepTreeView mainTreeview, Control.ControlCollection viewCupboardList, Order.Order ourOrder, MySqlConnection database)
        {
            this.MainTreeview = mainTreeview;
            this.ViewList = viewCupboardList;
            this.OurOrder = ourOrder;
            this.Database = database;
        }

        public void AddViewCupboard(int uid, Cupboard cupboard)
        {
            Kitbox.GUI.ViewCupboard view = new Kitbox.GUI.ViewCupboard(uid, cupboard, this);
            view.Dock = DockStyle.Fill;
            ViewList.Add(view);
            view.BringToFront();
        }

        public void AddViewBox(int uidCupboard,int uid, Box box)
        {
            ViewBox viewBox = new ViewBox(uidCupboard, uid, box, this);
            viewBox.Dock = DockStyle.Fill;
            ViewList.Add(viewBox);
            viewBox.BringToFront();
        }

        public void BringToFrontView(int uid)
        {
            foreach (Object view in ViewList)
            {
                if (view is Kitbox.GUI.ViewBox)
                {
                    ViewBox viewType = (ViewBox)view;

                    if (viewType.Uid == uid)
                    {
                        viewType.BringToFront();
                        break;
                    }

                }
                if (view is Kitbox.GUI.ViewCupboard)
                {
                    ViewCupboard viewType = (ViewCupboard)view;

                    if (viewType.Uid == uid)
                    {
                        viewType.BringToFront();
                        break;
                    }
                }

              
            }

        }

        private void RemoveView(int uid)
        {
            foreach (Object view in ViewList)
            {
                if (view is Kitbox.GUI.ViewBox)
                {
                    ViewBox viewType = (ViewBox)view;

                    if (viewType.Uid == uid)
                    {
                        ViewList.Remove(viewType);
                        break;
                    }
                }

                else if (view is Kitbox.GUI.ViewCupboard)
                {
                    ViewCupboard viewType = (ViewCupboard)view;

                    if (viewType.Uid == uid)
                    {
                        ViewList.Remove(viewType);
                        break;
                    }
                }
            }
        }

        public void AddCupboard(Order.Order ourOrder, string Tag = "contains 0 Box")
        {
            UidTreeview += 1;
            MainTreeview.Nodes.Add(UidTreeview.ToString(), "Cupboard - Uid " + UidTreeview);
            MainTreeview.Nodes[ReturnIndexTreeview(UidTreeview)[0]].Tag = Tag;
            MainTreeview.Nodes[ReturnIndexTreeview(UidTreeview)[0]].ImageIndex = 1;
            ourOrder.Add(UidTreeview, this);
        }

        private int[] ReturnIndexTreeview(int uid)
        {
            for (int countCupboard = 0; countCupboard < MainTreeview.Nodes.Count; countCupboard++)
            {
                for (int countBox = 0; countBox < MainTreeview.Nodes[countCupboard].Nodes.Count; countBox++)
                {
                    if (MainTreeview.Nodes[countCupboard].Nodes[countBox].Name == uid.ToString())
                    {
                        return new int[] {countCupboard, countBox};
                    }
                }
                if (MainTreeview.Nodes[countCupboard].Name == uid.ToString())
                {
                    return new int[] { countCupboard, 0 };
                }
            }

            return new int[] { -1, -1 };
        }

        public void RemoveCupboard(int uid, Cupboard cupboard)
        {
            foreach (Box box in cupboard.ListeBoxes)
            {
                RemoveView(box.Uid);
            }
            OurOrder.RemoveAt(uid);
            MainTreeview.Nodes.RemoveAt(ReturnIndexTreeview(uid)[0]);
            RemoveView(uid);

        }
        public Specs AddBox(int uidCupboard, string width, string depth, string height, string colorDoor, string colorPanel, Cupboard cupboard, string tag = "Completed")
        {
            UidTreeview += 1;
            List<Specs> components = Reader.SearchComponent(UidTreeview, width, depth, height, colorDoor, colorPanel, cupboard, Database);
            foreach (Specs component in components)
            {
                if (!(component is null) && component.IsInStock(OurOrder.GetQuantityCode(component.Code) + component.CountComponents()) == false  )
                {
                    return component;
                }
            }

            MainTreeview.Nodes[ReturnIndexTreeview(uidCupboard)[0]].Nodes.Add(UidTreeview.ToString(), "Box - Uid " + UidTreeview);
            MainTreeview.Nodes[ReturnIndexTreeview(uidCupboard)[0]].Nodes[ReturnIndexTreeview(UidTreeview)[1]].Tag = tag;
            MainTreeview.Nodes[ReturnIndexTreeview(uidCupboard)[0]].Nodes[ReturnIndexTreeview(UidTreeview)[1]].ImageIndex = 0;
          

            cupboard.AddBox(uidCupboard, UidTreeview, (Components.Door)components[0], (Components.Slider)components[1], new List<Panel>() { (Panel)components[2], (Panel)components[3], (Panel)components[4]}, new List<Traverses>() { (Traverses)components[5], (Traverses)components[6], (Traverses)components[7] }, (Cups)components[8], this);
            return null;
        }

        public void RemoveBox(int uid)
        {
            Console.WriteLine(uid);
            MainTreeview.Nodes[ReturnIndexTreeview(uid)[0]].Nodes.RemoveAt(ReturnIndexTreeview(uid)[1]);
            RemoveView(uid);
            OurOrder.RemoveAt(uid);
        }
    }
}
