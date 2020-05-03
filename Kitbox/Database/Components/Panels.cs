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
        private readonly static List<Panel> PanelList = new List<Panel>();
        #region Panel methods
        public static void AddPanel(string color, string type, int height, int width, int depth, int availableStock, int minStock,string code,string dimensionsToString)
        {
            PanelList.Add(new Panel(color, type, height, width, depth, availableStock, minStock,code, dimensionsToString));
        }

        public static int CountPanel()
        {
            return PanelList.Count();
        }

        public static string GetColorPanel(int index, string type)
        {
            if (PanelList[index].Type == type)
            {
                return PanelList[index].Color;
            }
            return "none";

        }

        public static int GetHeightPanel(int index, string type)
        {
            if (PanelList[index].Type == type)
            {
                return PanelList[index].Height;
            }
            return -1;

        }

        public static int GetWidthPanel(int index, string type)
        {
            if (PanelList[index].Type == type)
            {
                return PanelList[index].Width;
            }
            return -1;

        }

        public static int GetDepthPanel(int index, string type)
        {
            if (PanelList[index].Type == type)
            {
                return PanelList[index].Depth;
            }
            return -1;
        }
        public static string GetTypePanel(int index)
        {
            return PanelList[index].Type;
        }

        public static void ClearPanel()
        {
            PanelList.Clear();
        }
        #endregion
    }
}
