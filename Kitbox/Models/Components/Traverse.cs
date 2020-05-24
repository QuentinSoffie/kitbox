namespace Kitbox.Models.Components
{
    /// <summary>
    /// Tarverse class extends specs.
    /// Represent the Traverse of the box.
    /// </summary>
    public class Traverse : Specs
    {
        public readonly string Type;

        public Traverse(string type, int height, int width, int depth, int availableStock, int minStock, string code, string dimensionsToString) : base(height, width, depth, availableStock, minStock,  code,  dimensionsToString)
        {
            this.Type = type;
        }

        public override string ToString()
        {
            return string.Format("\n----Traverses----\nHeight: {0}\nWidth: {1}\nDepth: {2}\nAvailableStock: {3}\nMinStock: {4}\nType: {5}", Height, Width, Depth, AvailableStock, MinStock, Type);
        }

        public override int CountComponents()
        {
            if(Type == "Traverse Ar" || Type == "Traverse Av")
            {
                return 2;
            }
            else if (Type == "Traverse GD")
            {
                return 4;
            }
            return 0;
        }
    }
}
