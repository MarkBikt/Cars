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
    /// Логика взаимодействия для AddRefueling.xaml
    /// </summary>
    public partial class AddRefueling : Window
    {
        public Auto newAuto;
         
        public AddRefueling()
        {
            InitializeComponent();
            Refueling newRefueling = new Refueling();
            this.DataContext = newRefueling;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ControllerAuto.AddRefueling(double.Parse(price.Text), double.Parse(volume.Text), double.Parse(carMileage.Text), newAuto);
            this.Close();
        }
    }
}
