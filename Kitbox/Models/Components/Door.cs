namespace Kitbox.Models.Components
{
    /// <summary>
    /// Doors class extends specs.
    /// Represents the Door of the box.
    /// </summary>
    public class Door : Specs
    {
        public readonly string Color;

        public Door(string color, int height, int width, int depth, int availableStock, int minStock, string code, string dimensionsToString) : base(height, width, depth, availableStock, minStock,  code,  dimensionsToString)
        {
            this.Color = color;
        }

        public override string ToString()
        {
            return string.Format("\n----Door----\nColor: {0}Height: {1}\nWidth: {2}\nDepth: {3}\nAvailableStock: {4}\nMinStock: {5}\n", Color, Height, Width, Depth, AvailableStock, MinStock);
        }

        public override int CountComponents()
        {
            return 2;
        }
    }
}
