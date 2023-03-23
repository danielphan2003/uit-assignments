using System.Collections.Generic;

namespace winforms_intro
{
    public class GasType
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public int Price { get; set; }

        public readonly static Dictionary<string, GasType> All = new()
        {
            {"RON_92_II", new() {Id = "RON_92_II", Text = "Xăng RON 92-II", Price = 26_830}},
            {"RON_95_III", new() {Id = "RON_95_III", Text = "Xăng RON 95-III", Price = 26_070}},
            {"DO", new() {Id = "DO", Text = "Dầu DO", Price = 21_310}},
        };
    }

    public class Motorbike
    {
        public string Text { get; set; }
        public GasType[] GasTypes { get; set; }
        public double MileageConsumption { get; set; }
        public double GasCapacity { get; set; }
        public double EstimateMileage()
            => GasCapacity / MileageConsumption * 100.0;
        public override string ToString()
            => Text;
    }
}