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
using static System.Net.Mime.MediaTypeNames;

namespace praktika1_EF
{

    public partial class First : Page
    {
        private praktika1_datasetEntities Context = new praktika1_datasetEntities();

        public First()
        {
            InitializeComponent();
            SushiDataGrid.ItemsSource = Context.SUSHIBARS.ToList();
        }
        private void ShowMainButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void Dobavlenie_Click(object sender, RoutedEventArgs e)
        {
            string TITLE = NameTbx.Text;
            int WORKINGHOURSE = int.Parse(WorkingHourse.Text);

            SUSHIBARS a = new SUSHIBARS();
            a.TITLE = TITLE;
            a.WORKINGHOURSE = WORKINGHOURSE;
            Context.SUSHIBARS.Add(a);
            Context.SaveChanges();
            SushiDataGrid.ItemsSource = Context.SUSHIBARS.ToList();
        }

        private void Udalenie_Click(object sender, RoutedEventArgs e)
        {
            if (SushiDataGrid.SelectedItem != null)
            {
                Context.SUSHIBARS.Remove(SushiDataGrid.SelectedItem as SUSHIBARS);
            }
            Context.SaveChanges();
            SushiDataGrid.ItemsSource = Context.SUSHIBARS.ToList();

        }

        private void Update(object sender, RoutedEventArgs e)
        {
            if (SushiDataGrid.SelectedItem != null)
            {
                string TITLE = TitleTbx.Text;
                int WORKINGHOURSE = int.Parse(WH.Text);

                var selected = SushiDataGrid.SelectedItem as SUSHIBARS;
                selected.TITLE = TITLE;
                selected.WORKINGHOURSE = WORKINGHOURSE;

                Context.SaveChanges();
                SushiDataGrid.ItemsSource = Context.SUSHIBARS.ToList();
            }
        }

    }
}
