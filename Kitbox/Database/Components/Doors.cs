using Kitbox.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbox.Database.Components
{
    public class Doors
    {
        private readonly static List<Door> doorList = new List<Door>();

        #region Door methods
        public static void AddDoor(string color, int height, int width, int depth)
        {
            doorList.Add(new Door(color, height, width, depth));
        }

        public static int CountDoor()
        {
            return doorList.Count();
        }

        public static string GetColorDoor(int index)
        {
            return doorList[index].Color;
        }

        public static int GetHeightDoor(int index)
        {
            return doorList[index].Height;
        }

        public static int GetWidthDoor(int index)
        {
            return doorList[index].Width;
        }

        public static int GetDepthDoor(int index)
        {
            return doorList[index].Depth;
        }

        public static void ClearDoor()
        {
            doorList.Clear();
        }
        #endregion
    }
}
