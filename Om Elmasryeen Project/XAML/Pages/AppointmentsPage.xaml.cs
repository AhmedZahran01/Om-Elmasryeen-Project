using DataAcessLayer.Models;
using DataAcessLayer.Services;
using Om_Elmasryeen_Project.Languages_And_Themes;
using Om_Elmasryeen_Project.XAML.CreateWindows;
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
    /// Interaction logic for AppointmentsPage.xaml
    /// </summary>
    public partial class AppointmentsPage : Page
    {
        private AppointmentsService AppointmentsService = new();

        public AppointmentsPage()
        {
            InitializeComponent();
            DataContext = this;
            this.Resources.MergedDictionaries.Add(LangHelper.GetResourceDictionary());

            UpdateTable();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            new CreateAppointmentWindow().ShowDialog();
            UpdateTable();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            Appointment appointment = (Appointment)button.DataContext;

            if (appointment != null)
            {
                new CreateAppointmentWindow(appointment).ShowDialog();
                UpdateTable();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            Appointment appointment = (Appointment)button.DataContext;

            if (appointment != null)
            {
                if ((bool)new AreYouSureWindow().ShowDialog())
                {
                    AppointmentsService.Delete(appointment.Id);
                    new SuccessWindow(LangHelper.GetString("SuccessDeleted")).Show();
                    UpdateTable();
                }
            }
        }

        private ObservableCollection<Appointment> UpdateTable()
        {
            ObservableCollection<Appointment> appointments;
            if (UserContext.CurrentUserType == UserType.NURSE)
            {
                appointments = new(AppointmentsService.GetAll());
            }
            else
            {
                appointments = new(AppointmentsService.GetAllByDoctor(DoctorWindow.CurrentDoctor.Id));
            }
            DataGrid.ItemsSource = appointments;
            return appointments;
        }

        private void textBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Appointment> newCollection = new List<Appointment>();
            IEnumerable<Appointment> objects = (IEnumerable<Appointment>)UpdateTable();
            foreach (var obj in objects)
            {
                string filter = textBoxFilter.Text.ToLower();
                if (obj.Patient.Name.ToLower().Contains(filter) || obj.Patient.Surname.ToLower().Contains(filter) || obj.Patient.Contact.Contains(filter)
                    || obj.Date.ToString().ToLower().Contains(filter))
                    newCollection.Add(obj);
            }
            DataGrid.ItemsSource = newCollection;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
