using Cars.cs.Controller;
using Cars.cs.model;
using System.Windows;
using System.Windows.Controls;

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
            bool check = (bool)CheckBoxFullFuel.IsChecked;
            newAuto = ControllerAuto.AddRefueling(double.Parse(price.Text), double.Parse(volume.Text), double.Parse(carMileage.Text), newAuto, check);
           
            this.Close();           
        }

        
    }
}
