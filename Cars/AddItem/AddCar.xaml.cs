using Cars.cs.Controller;
using Cars.cs.model;
using System.Windows;


namespace Cars.AddItem
{
    /// <summary>
    /// Логика взаимодействия для AddCar.xaml
    /// </summary>
    public partial class AddCar : Window
    {
        Auto newCar;
        public AddCar()
        {
            InitializeComponent();
            newCar = new Auto();
            this.DataContext = newCar;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {                      
            ControllerAuto.Add(carBrand.Text, 
                carModel.Text, 
                gosNumber.Text, 
                int.Parse(autoYear.Text), 
                color.Text, 
                double.Parse(carMileage.Text), 
                double.Parse(fuelVolume.Text));
            this.Close();
        }
    }
}
