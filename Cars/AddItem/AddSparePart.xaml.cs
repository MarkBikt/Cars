using Cars.cs.Controller;
using Cars.cs.model;
using System.Windows;

namespace Cars.AddItem
{
    /// <summary>
    /// Логика взаимодействия для AddSparePart.xaml
    /// </summary>
    public partial class AddSparePart : Window
    {
        public Auto newAuto;
        
        public AddSparePart()
        {
            InitializeComponent();
            SparePart newSparePart = new SparePart();
            this.DataContext = newSparePart;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ControllerAuto.AddSparePart(name.Text, double.Parse(price.Text), newAuto);
            this.Close();
        }
    }
}
