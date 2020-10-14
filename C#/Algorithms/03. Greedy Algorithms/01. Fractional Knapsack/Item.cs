namespace _01._Fractional_Knapsack
{
    public class Item
    {
        public double Price { get; set; }
        public double Weight { get; set; }

        public double PriceWeightRatio() => Price / (double)Weight;
    }
}
