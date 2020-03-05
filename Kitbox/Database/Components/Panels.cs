using Kitbox.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbox.Database.Components
{
    public class Panels
    {
        private readonly static List<Panel> panelList = new List<Panel>();
        #region Panel methods
        public static void AddPanel(string color, string type, int height, int width, int depth)
        {
            panelList.Add(new Panel(color, type, height, width, depth));
        }

        public static int CountPanel()
        {
            return panelList.Count();
        }

        public static string GetColorPanel(int index, string type)
        {
            if (panelList[index].Type == type)
            {
                return panelList[index].Color;
            }
            return "none";

        }

        public static int GetHeightPanel(int index, string type)
        {
            if (panelList[index].Type == type)
            {
                return panelList[index].Height;
            }
            return -1;

        }

        public static int GetWidthPanel(int index, string type)
        {
            if (panelList[index].Type == type)
            {
                return panelList[index].Width;
            }
            return -1;

        }

        public static int GetDepthPanel(int index, string type)
        {
            if (panelList[index].Type == type)
            {
                return panelList[index].Depth;
            }
            return -1;
        }
        public static string GetTypePanel(int index)
        {
            return panelList[index].Type;
        }

        public static void ClearPanel()
        {
            panelList.Clear();
        }
        #endregion
    }
}
