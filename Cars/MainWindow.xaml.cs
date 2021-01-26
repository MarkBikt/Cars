using Cars.AddItem;
using Cars.cs.Controller;
using Cars.cs.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

        private void Window_Initialized(object sender, EventArgs e)
        {
            ControllerAuto.Load();
        }
    }
}
