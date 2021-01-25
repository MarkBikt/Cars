using Cars.cs.Controller;
using Cars.cs.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


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
