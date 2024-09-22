using DataAcessLayer.Models;
using DataAcessLayer.Services;
using Om_Elmasryeen_Project.Languages_And_Themes;
using Om_Elmasryeen_Project.XAML.CreateWindows;
using Org.BouncyCastle.Asn1.IsisMtt.X509;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Om_Elmasryeen_Project.XAML.Pages
{
    /// <summary>
    /// Interaction logic for AdmissionsPage.xaml
    /// </summary>
    public partial class AdmissionsPage : Page
    {
        private AdmissionsService AdmissionsService = new();

        public AdmissionsPage()
        {
            InitializeComponent();
            DataContext = this;
            this.Resources.MergedDictionaries.Add(LangHelper.GetResourceDictionary());

            UpdateTable();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            new CreateAdmissionWindow().ShowDialog();

            UpdateTable();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            Admission admission = (Admission)button.DataContext;

            if (admission != null)
            {
                new CreateAdmissionWindow(admission).ShowDialog();

                UpdateTable();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            Admission admission = (Admission)button.DataContext;

            if (admission != null)
            {
                if ((bool)new AreYouSureWindow().ShowDialog())
                {
                    AdmissionsService.Delete(admission.Id);
                    new SuccessWindow(LangHelper.GetString("SuccessDeleted")).Show();
                    UpdateTable();
                }
            }
        }

        private ObservableCollection<Admission> UpdateTable()
        {
            ObservableCollection<Admission> admissions = new(AdmissionsService.GetAll());

            DataGrid.ItemsSource = admissions;
            return admissions;
        }

        private void textBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Admission> newCollection = new List<Admission>();
            IEnumerable<Admission> objects = (IEnumerable<Admission>)UpdateTable();
            foreach (var obj in objects)
            {
                string filter = textBoxFilter.Text.ToLower();
                if (obj.patient.Name.ToLower().Contains(filter) || obj.patient.Surname.ToLower().Contains(filter) || obj.patient.Contact.Contains(filter)
                    || obj.entryDate.ToString().ToLower().Contains(filter) || obj.exitDate.ToString().ToLower().Contains(filter))
                    newCollection.Add(obj);
            }
            DataGrid.ItemsSource = newCollection;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
