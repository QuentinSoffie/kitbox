namespace Kitbox.Models.Components
{
    /// <summary>
    /// Cups class extends specs
    /// Represents the Cups of the door.
    /// </summary>
    public class Cups : Specs
    {
        public Cups(int availableStock, int minStock, string code, string dimensionsToString) : base(0, 0, 0, availableStock, minStock, code, dimensionsToString){}

        public override int CountComponents()
        {
            return 2;
        }
    }
}
