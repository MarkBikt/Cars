using Cars.AddItem;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cars
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            

            ControllerAuto.Add("Mazda", "RX-8", "X20KC18", 2007, "Red", 43800, 60);
            ControllerAuto.Add("Mazda", "CX-7", "P231EP716", 2011, "White", 123897, 63);
            ControllerAuto.Add("Lada", "Priora", "H762OX116", 2008, "Silver", 222800, 40);
           
            ComboBoxCars.ItemsSource = ControllerAuto.Cars;          
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Auto a = (Auto)ComboBoxCars.SelectedItem;
            MessageBox.Show(a.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddCar addCar = new AddCar();
            addCar.ShowDialog();                               
        }
    }
}
