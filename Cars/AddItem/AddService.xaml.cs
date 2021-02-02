using Cars.cs.Controller;
using Cars.cs.model;
using System.Windows;

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
