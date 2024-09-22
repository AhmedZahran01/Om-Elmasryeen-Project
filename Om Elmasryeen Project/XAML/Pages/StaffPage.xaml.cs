using DataAcessLayer.Models;
using DataAcessLayer.Services;
using Om_Elmasryeen_Project.Languages_And_Themes;
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
    /// Interaction logic for StaffPage.xaml
    /// </summary>
     public partial class StaffPage : Page
    {
        private DoctorService _doctorService = new();
        private ManagerService _managerService = new();
        private NurseService _nurseService = new NurseService();

        private UserType SelectedWindow = UserType.MANAGER;
        public StaffPage()
        {
            InitializeComponent();
            DataContext = this;
            this.Resources.MergedDictionaries.Add(LangHelper.GetResourceDictionary());

            UpdateTable();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            new Register().ShowDialog();

            UpdateTable();
        }

        private void NurseButton_Click(object sender, RoutedEventArgs e)
        {
            title_left.Text = LangHelper.GetString("Nurses");
            SelectedWindow = UserType.NURSE;
            UpdateTable();
        }

        private void DoctorButton_Click(object sender, RoutedEventArgs e)
        {
            title_left.Text = LangHelper.GetString("Doctors");
            SelectedWindow = UserType.DOCTOR;
            UpdateTable();
        }

        private void ManagerButton_Click(object sender, RoutedEventArgs e)
        {
            title_left.Text = LangHelper.GetString("Managers");
            SelectedWindow = UserType.MANAGER;
            UpdateTable();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            ModelBase person = (ModelBase)button.DataContext;

            try
            {
                if (person != null)
                {
                    if ((bool)new AreYouSureWindow().ShowDialog())
                    {
                        if (SelectedWindow == UserType.NURSE)
                        {
                            _nurseService.Delete(person.Id);
                        }
                        else if (SelectedWindow == UserType.DOCTOR)
                        {
                            _doctorService.Delete(person.Id);
                        }
                        else
                        {
                            if (ManagerWindow.CurrentManager.Id == person.Id)
                            {
                                throw new Exception();
                            }
                            _managerService.Delete(person.Id);
                        }
                        new SuccessWindow(LangHelper.GetString("SuccessDeleted")).Show();
                        UpdateTable();
                    }
                }
            } catch (Exception)
            {
                new ErrorWindow(LangHelper.GetString("ErrorCantPerformThis")).ShowDialog();
            }
        }

        private ObservableCollection<ModelBase> UpdateTable()
        {
            ObservableCollection<ModelBase> persons;
            if (SelectedWindow == UserType.NURSE)
            {
                persons = new(_nurseService.GetAll());
            }
            else if (SelectedWindow == UserType.DOCTOR)
            {
                persons = new(_doctorService.GetAll());
            }
            else
            {
                persons = new(_managerService.GetAll());
            }
            DataGrid.ItemsSource = persons;
            return persons;
        }

        private void textBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<ModelBase> newCollection = new List<ModelBase>();
            IEnumerable<ModelBase> persons = (IEnumerable<ModelBase>)UpdateTable();
            foreach (var person in persons)
            {
                string filter = textBoxFilter.Text.ToLower();
                if (person.Name.ToLower().Contains(filter) || person.Surname.ToLower().Contains(filter) || person.Contact.Contains(filter))
                    newCollection.Add(person);
            }
            DataGrid.ItemsSource = newCollection;
        }
    }
}
