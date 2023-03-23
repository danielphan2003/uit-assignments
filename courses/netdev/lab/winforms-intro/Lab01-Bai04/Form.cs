using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace winforms_intro
{
    public partial class Lab01_Bai04 : Panel
    {
        private readonly Motorbike[] motorbikes;

        public Lab01_Bai04()
        {
            motorbikes = new[]
            {
                new Motorbike
                {
                    Text = "Wave Alpha",
                    MileageConsumption = 1.6,
                    GasCapacity = 3.7,
                    GasTypes = new[] {GasType.All["RON_95_III"], GasType.All["RON_92_II"]},
                },
                new Motorbike
                {
                    Text = "Sirius",
                    MileageConsumption = 1.99,
                    GasCapacity = 3.8,
                    GasTypes = new[] {GasType.All["RON_95_III"], GasType.All["RON_92_II"]},
                },
                new Motorbike
                {
                    Text = "Vision",
                    MileageConsumption = 1.87,
                    GasCapacity = 5.2,
                    GasTypes = new[] {GasType.All["RON_95_III"], GasType.All["RON_92_II"]},
                },
                new Motorbike
                {
                    Text = "Lead",
                    MileageConsumption = 2.02,
                    GasCapacity = 6,
                    GasTypes = new[] {GasType.All["RON_95_III"]},
                },
                new Motorbike
                {
                    Text = "Winner",
                    MileageConsumption = 1.7,
                    GasCapacity = 4.5,
                    GasTypes = new[] {GasType.All["RON_95_III"]},
                },
                new Motorbike
                {
                    Text = "AirBlade 150",
                    MileageConsumption = 2.17,
                    GasCapacity = 4.4,
                    GasTypes = new[] {GasType.All["RON_95_III"]},
                },
                new Motorbike
                {
                    Text = "Xe tải 9 tấn",
                    MileageConsumption = 13,
                    GasCapacity = 70,
                    GasTypes = new[] {GasType.All["DO"]},
                },
            };

            InitializeComponent();

            bindingSource = new()
            {
                DataSource = motorbikes,
            };

            comboBox.DataSource = bindingSource.DataSource;
            comboBox.DisplayMember = "Text";
            comboBox.ValueMember = "Text";

            OnComboBoxChange(null, EventArgs.Empty);
        }

        public static string FormatKm(double km)
            => string.Format("Số km đi được : {0:F}km", km);
        
        public static string FormatPrice(double price)
            => $"Số tiền cần trả : {price}đ";

        public Motorbike GetMotorbike()
            => motorbikes[comboBox.SelectedIndex > 0 ? comboBox.SelectedIndex : 0];

        public void OnComboBoxChange(object? sender, EventArgs e)
        {
            var gasTypes = gasPanel.Controls.OfType<RadioButton>();
            foreach (var gasType in gasTypes)
            {
                gasType.Enabled = GetMotorbike().GasTypes.Where(g => g.Id == gasType.Name).Any();
            }
            var enabledGasTypes = gasTypes.Where(g => g.Enabled);
            if (enabledGasTypes.Count() == 1)
            {
                enabledGasTypes.ElementAt(0).Checked = true;
            }
            else
            {
                gasTypes.ElementAt(0).Checked = true;
            }
        }

        public void OnGasTypeChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton.Enabled && radioButton.Checked)
            {
                var gasType = GasType.All[radioButton.Name];
                var motorbike = GetMotorbike();
                kmLabel.Text = FormatKm(motorbike.EstimateMileage());
                priceLabel.Text = FormatPrice(motorbike.GasCapacity * gasType.Price);
            }
        }
    }
}
