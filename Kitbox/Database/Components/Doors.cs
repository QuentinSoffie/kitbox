using Kitbox.Components;
using System.Collections.Generic;
using System.Linq;

namespace Kitbox.Database.Components
{
    /// <summary>
    /// This class contains all the doors.
    /// </summary>
    public class Doors
    {
        private readonly static List<Door> DoorList = new List<Door>();

        #region Door methods
        public static void AddDoor(string color, int height, int width, int depth, int availableStock, int minStock, string code,string dimensionsToString)
        {
            DoorList.Add(new Door(color, height, width, depth, availableStock, minStock,code,dimensionsToString));
        }

        public static int CountDoor()
        {
            return DoorList.Count();
        }

        public static string GetColorDoor(int index)
        {
            return DoorList[index].Color;
        }

        public static int GetHeightDoor(int index)
        {
            return DoorList[index].Height;
        }

        public static int GetWidthDoor(int index)
        {
            return DoorList[index].Width;
        }

        public static int GetDepthDoor(int index)
        {
            return DoorList[index].Depth;
        }

        public static void ClearDoor()
        {
            DoorList.Clear();
        }
        #endregion
    }
}
