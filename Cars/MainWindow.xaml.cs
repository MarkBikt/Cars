using Cars.AddItem;
using Cars.cs.Controller;
using Cars.cs.model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Cars
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Auto car;
        public AddRefueling refueling = new AddRefueling();
        public MainWindow()
        {
            InitializeComponent();
        }   
        
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (Auto)ComboBoxCars.SelectedItem;
            ButtonEnabled(true);
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
            ButtonEnabled(false);
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
            refueling = addRefueling;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AddSparePart addSparePart = new AddSparePart();
            addSparePart.newAuto = car;
            addSparePart.ShowDialog();
        }

       

        /// <summary>
        /// Включение и выключение кнопок добавления
        /// </summary>
        /// <param name="i">индикатор</param>
        private void ButtonEnabled(bool i)
        {
            B_AddRefueling.IsEnabled = i;
            B_AddService.IsEnabled = i;
            B_AddSparePart.IsEnabled = i;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            if (refueling.newAuto != null)
            {
                TB_AvFuel.Text = refueling.newAuto.AvFuel.ToString();
            }
        }
    }
}
