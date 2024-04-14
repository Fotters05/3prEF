using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class Fourth : Page
    {
        private praktika1_datasetEntities Context = new praktika1_datasetEntities();

        public Fourth()
        {
            InitializeComponent();
            SushiDataGrid.ItemsSource = Context.INFOBARS.ToList();
            SUSHIBARSComboBox.DisplayMemberPath = "ID_SUSHIBARS";
            SUSHIBARSComboBox.ItemsSource = Context.SUSHIBARS.ToList();
            SUSHISETSComboBox.DisplayMemberPath = "ID_SUSHISETS";
            SUSHISETSComboBox.ItemsSource = Context.SUSHISETS.ToList();
            CLIENTSSComboBox.DisplayMemberPath = "ID_CLIENTS";
            CLIENTSSComboBox.ItemsSource = Context.CLIENTS.ToList();
        }
        private void ShowMainButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void Dobavlenie_Click(object sender, RoutedEventArgs e)
        {
            INFOBARS d = new INFOBARS();
            d.SUSHIBARS_ID = int.Parse(idbar.Text);
            d.SUSHISETS_ID = int.Parse(idset.Text);
            d.CLIENTS_ID = int.Parse(idcl.Text);
            Context.INFOBARS.Add(d);
            Context.SaveChanges();
            SushiDataGrid.ItemsSource = Context.INFOBARS.ToList();
        }

        private void Udalenie_Click(object sender, RoutedEventArgs e)
        {
            if (SushiDataGrid.SelectedItem != null)
            {
                Context.INFOBARS.Remove(SushiDataGrid.SelectedItem as INFOBARS);
            }
            Context.SaveChanges();
            SushiDataGrid.ItemsSource = Context.INFOBARS.ToList();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            Context.SaveChanges();


        }

        private void SushiDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SushiDataGrid.SelectedItem != null)
            {
                var select = SushiDataGrid.SelectedItem as INFOBARS;
                select.SUSHIBARS_ID = int.Parse(idbar.Text);
                select.SUSHISETS_ID = int.Parse(idset.Text);
                select.CLIENTS_ID = int.Parse(idcl.Text);
                Context.SaveChanges();
                SushiDataGrid.ItemsSource = Context.INFOBARS.ToList();
            }

        }
        private void SUSHIBARSComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SUSHIBARSComboBox.SelectedItem != null)
            {
                var selectedItem = SUSHIBARSComboBox.SelectedItem as SUSHIBARS;
                MessageBox.Show(selectedItem.TITLE);
            }
        }

        private void SUSHISETSComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SUSHISETSComboBox.SelectedItem != null)
            {
                var selectedItem = SUSHISETSComboBox.SelectedItem as SUSHISETS;
                MessageBox.Show(selectedItem.TITLESETS);
            }
        }

        private void CLIENTSSComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CLIENTSSComboBox.SelectedItem != null)
            {
                var selectedItem = CLIENTSSComboBox.SelectedItem as CLIENTS;
                MessageBox.Show(selectedItem.SURNAME);
            }

        }
        private void SK(object sender, RoutedEventArgs e)
        {

            SushiDataGrid.Columns[4].Visibility = Visibility.Collapsed;
            SushiDataGrid.Columns[5].Visibility = Visibility.Collapsed;
            SushiDataGrid.Columns[6].Visibility = Visibility.Collapsed;

        }
    }
}
