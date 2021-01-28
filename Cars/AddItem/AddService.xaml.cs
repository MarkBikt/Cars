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
    /// Логика взаимодействия для AddService.xaml
    /// </summary>
    public partial class AddService : Window
    {
        public Auto newAuto;
        
        public AddService()
        {
            InitializeComponent();
            Service newService = new Service();
            this.DataContext = newService;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {           
            ControllerAuto.AddService(name.Text, double.Parse(price.Text), newAuto);
            this.Close();
        }
    }
}
