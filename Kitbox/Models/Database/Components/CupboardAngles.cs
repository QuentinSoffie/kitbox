using Kitbox.Models.Components;
using System.Collections.Generic;
using System.Linq;

namespace Kitbox.Models.Database.Components
{
    /// <summary>
    /// This class contains all the cupboard angles.
    /// </summary>
    public class CupboardAngles
    {
        private readonly static List<CupboardAngle> CupboardAngleList = new List<CupboardAngle>();

        #region CupboardAngle methods
        public static void AddCupboardAngle(string color, int height, int width, int depth, int availableStock, int minStock, string code, string dimensionsToString)
        {
            CupboardAngleList.Add(new CupboardAngle(color, height, width, depth, availableStock, minStock, code, dimensionsToString));
        }

        public static List<CupboardAngle> SortCupboardAngle()
        {
            return CupboardAngleList.OrderBy(o => o.Height).ToList();
        }

        public static int CountCupboardAngle()
        {
            return CupboardAngleList.Count();
        }

        public static string GetColorCupboardAngle(int index)
        {
            return CupboardAngleList[index].Color;
        }

        public static int GetHeightCupboardAngle(int index)
        {
            return CupboardAngleList[index].Height;
        }

        public static int GetWidthCupboardAngle(int index)
        {
            return CupboardAngleList[index].Width;
        }
        public static int GetDepthCupboardAngle(int index)
        {
            return CupboardAngleList[index].Depth;
        }

        public static void ClearCupboardAngle()
        {
            CupboardAngleList.Clear();
        }
        #endregion
    }
}
