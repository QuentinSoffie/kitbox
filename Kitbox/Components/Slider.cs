namespace Kitbox.Components
{
    /// <summary>
    /// Slider class extends specs.
    /// Represents the Slider of the box.
    /// </summary>
    public class Slider : Specs
    {
        public Slider(int height, int availableStock, int minStock, string code, string dimensionsToString) : base(height, 0, 0, availableStock, minStock,  code,  dimensionsToString){}

        public override string ToString()
        {
            return string.Format("\n----Slider----\nHeight: {0}\nWidth: {1}\nDepth: {2}\nAvailableStock: {3}\nMinStock: {4}\n", Height, Width, Depth, AvailableStock, MinStock);
        }

        public override int CountComponents()
        {
            return 4;
        }
    }
}
