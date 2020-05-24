namespace Kitbox.Components
{
    /// <summary>
    /// Represents the base of each components
    /// </summary>
    public class Specs
    {
        public readonly int Height;
        public readonly int Width;
        public readonly int Depth;
        public readonly int AvailableStock;
        public readonly int MinStock;
        public readonly string Code;
        public readonly string DimensionsToString;

        public Specs(int height, int width, int depth, int availableStock, int minStock, string code,string dimensionsToString)
        {
            this.Height = height;
            this.Width = width;
            this.Depth = depth;
            this.AvailableStock = availableStock;
            this.MinStock = minStock;
            this.Code = code;
            this.DimensionsToString = dimensionsToString;
        }

        public bool IsInStock(int quantity)
        {
            return quantity + 1 < AvailableStock;
        }

        public virtual int CountComponents()
        {
            return 1;
        }

        public override string ToString()
        {
            return string.Format("\n----Specs----\nHeight: {0}\nWidth: {1}\nDepth: {2}\nAvailableStock: {3}\nMinStock: {4}\n", Height, Width, Depth, AvailableStock, MinStock);
        }

    }
}
