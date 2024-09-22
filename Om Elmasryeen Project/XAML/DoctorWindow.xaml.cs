using DataAcessLayer.Models;
using DataAcessLayer.Services;
using Om_Elmasryeen_Project.Languages_And_Themes;
using Om_Elmasryeen_Project.XAML.Pages;
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

namespace Om_Elmasryeen_Project.XAML
{
    /// <summary>
    /// Interaction logic for DoctorWindow.xaml
    /// </summary>
    public partial class DoctorWindow : Window
    {
        public static Doctor CurrentDoctor;
        public static DoctorService DoctorService;
        public DoctorWindow(Doctor loggedIn)
        {
            CurrentDoctor = loggedIn;
            DoctorService = new();

            InitializeComponent();
            DataContext = this;
            this.Resources.MergedDictionaries.Add(LangHelper.GetResourceDictionary());
        }

        private void MouseClickAdmissions(object sender, MouseButtonEventArgs e)
        {
            InitSidebarColors();
            admissionsTextBlock.SetResourceReference(Control.StyleProperty, "SidebarSelectedTextBlock");
            MainPage.Content = new AdmissionsPage();
        }

        private void MouseClickAppointments(object sender, MouseButtonEventArgs e)
        {
            InitSidebarColors();
            appointmentsTextBlock.SetResourceReference(Control.StyleProperty, "SidebarSelectedTextBlock");
            MainPage.Content = new AppointmentsPage();
        }

        private void MouseClickRecords(object sender, MouseButtonEventArgs e)
        {
            InitSidebarColors();
            recordsTextBlock.SetResourceReference(Control.StyleProperty, "SidebarSelectedTextBlock");
            MainPage.Content = new RecordsPage();
        }

        private void MouseClickSurgeries(object sender, MouseButtonEventArgs e)
        {
            InitSidebarColors();
            surgeriesTextBlock.SetResourceReference(Control.StyleProperty, "SidebarSelectedTextBlock");
            MainPage.Content = new SurgeriesPage();
        }

        private void MouseClickSettings(object sender, MouseButtonEventArgs e)
        {
            InitSidebarColors();
            settingsTextBlock.SetResourceReference(Control.StyleProperty, "SidebarSelectedTextBlock");
            MainPage.Content = new SettingsPage();
        }

        private void InitSidebarColors()
        {
            admissionsTextBlock.SetResourceReference(Control.StyleProperty, "SidebarTextBlock");
            appointmentsTextBlock.SetResourceReference(Control.StyleProperty, "SidebarTextBlock");
            recordsTextBlock.SetResourceReference(Control.StyleProperty, "SidebarTextBlock");
            surgeriesTextBlock.SetResourceReference(Control.StyleProperty, "SidebarTextBlock");
            settingsTextBlock.SetResourceReference(Control.StyleProperty, "SidebarTextBlock");
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            new Login().Show();
            this.Close();
        }
    }
}
