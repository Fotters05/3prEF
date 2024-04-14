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

    public partial class Second : Page
    {
        private praktika1_datasetEntities Context = new praktika1_datasetEntities();

        public Second()
        {
            InitializeComponent();
            SushiDataGrid.ItemsSource = Context.SUSHISETS.ToList();
        }
        private void ShowMainButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void Dobavlenie_Click(object sender, RoutedEventArgs e)
        {
            string TITLESETS = NameTbx.Text;
            int PRICESETS = int.Parse(Prc.Text);
            int QUANTITY = int.Parse(Quant.Text);

            SUSHISETS b = new SUSHISETS();
            b.TITLESETS = TITLESETS;
            b.PRICESETS = PRICESETS;
            b.QUANTITY = QUANTITY;
            Context.SUSHISETS.Add(b);
            Context.SaveChanges();
            SushiDataGrid.ItemsSource = Context.SUSHISETS.ToList();
        }

        private void Udalenie_Click(object sender, RoutedEventArgs e)
        {
            if (SushiDataGrid.SelectedItem != null)
            {
                Context.SUSHISETS.Remove(SushiDataGrid.SelectedItem as SUSHISETS);
            }
            Context.SaveChanges();
            SushiDataGrid.ItemsSource = Context.SUSHISETS.ToList();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            if (SushiDataGrid.SelectedItem != null)
            {
                string TITLESETS = NameTbx.Text;
                int PRICESETS = int.Parse(Prc.Text);
                int QUANTITY = int.Parse(Quant.Text);

                var selected = SushiDataGrid.SelectedItem as SUSHISETS;
                selected.TITLESETS = TITLESETS;
                selected.PRICESETS = PRICESETS;
                selected.QUANTITY = QUANTITY;

                Context.SaveChanges();
                SushiDataGrid.ItemsSource = Context.SUSHISETS.ToList();
            }
        }
    }
}
