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
        public Auto car;
        public MainWindow()
        {
            InitializeComponent();
                             
                      
        }
        
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (Auto)ComboBoxCars.SelectedItem;           
            MessageBox.Show(a.ToString());
            ListBoxRefueling.ItemsSource = a.Refuelings;
            ListBoxService.ItemsSource = a.Services;
            ListBoxSparePart.ItemsSource = a.SpareParts;
            car = a;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddCar addCar = new AddCar();
            addCar.ShowDialog();                               
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            ComboBoxCars.ItemsSource = ControllerAuto.Load();                  
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddService addService = new AddService();
            addService.newAuto = car;
            addService.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddRefueling addRefueling = new AddRefueling();
            addRefueling.newAuto = car;
            addRefueling.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AddSparePart addSparePart = new AddSparePart();
            addSparePart.newAuto = car;
            addSparePart.ShowDialog();
        }
    }
}
