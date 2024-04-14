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

namespace praktika1_EF
{

    public partial class Theird : Page
    {
        private praktika1_datasetEntities Context = new praktika1_datasetEntities();

        public Theird()
        {
            InitializeComponent();
            SushiDataGrid.ItemsSource = Context.CLIENTS.ToList();
        }
        private void ShowMainButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void Dobavlenie_Click(object sender, RoutedEventArgs e)
        {
            string FIRST_NAME = NameTbx.Text;
            string MIDDLENAME = Prc.Text;
            string SURNAME = Quant.Text;


            CLIENTS c = new CLIENTS();
            c.FIRST_NAME = FIRST_NAME;
            c.MIDDLENAME = MIDDLENAME;
            c.SURNAME = SURNAME;
            Context.CLIENTS.Add(c);
            Context.SaveChanges();
            SushiDataGrid.ItemsSource = Context.CLIENTS.ToList();
        }

        private void Udalenie_Click(object sender, RoutedEventArgs e)
        {
            if (SushiDataGrid.SelectedItem != null)
            {
                Context.CLIENTS.Remove(SushiDataGrid.SelectedItem as CLIENTS);
            }
            Context.SaveChanges();
            SushiDataGrid.ItemsSource = Context.CLIENTS.ToList();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            string FIRST_NAME = NameTbx.Text;
            string MIDDLENAME = Prc.Text;
            string SURNAME = Quant.Text;

            var selected = SushiDataGrid.SelectedItem as CLIENTS;
            selected.FIRST_NAME = FIRST_NAME;
            selected.MIDDLENAME = MIDDLENAME;
            selected.SURNAME = SURNAME;

            Context.SaveChanges();
            SushiDataGrid.ItemsSource = Context.CLIENTS.ToList();
        }
    }
}
