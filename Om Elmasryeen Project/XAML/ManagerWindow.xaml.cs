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
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public static Manager CurrentManager;
        public static ManagerService ManagerService;
        public ManagerWindow(Manager loggedIn)
        {
            CurrentManager = loggedIn;
            ManagerService = new();

            InitializeComponent();
            DataContext = this;
            this.Resources.MergedDictionaries.Add(LangHelper.GetResourceDictionary());
        }

        private void MouseClickDoctors(object sender, MouseButtonEventArgs e)
        {
            HideWelcomeMessage();
            InitSidebarColors();
            doctorsTextBlock.SetResourceReference(Control.StyleProperty, "SidebarSelectedTextBlock");
            MainPage.Content = new StaffPage();
        }

        #region MyRegion

        //       <Window x:Class="Hospital.XAML.ManagerWindow"
        //        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        //        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        //        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        //        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        //        xmlns:local="clr-namespace:Hospital.XAML"
        //        mc:Ignorable="d"
        //        Title="{DynamicResource Hospital}"
        //        MinHeight="600" MinWidth="1000"
        //        WindowState="Maximized"
        //        Background="{DynamicResource BackgroundColor}"
        //        Foreground="{DynamicResource TextColor}"
        //        FontFamily="{DynamicResource MainFont}"
        //        WindowStartupLocation="CenterScreen"
        //        Icon="../Assets/Manager.ico">

        //    <Window.Resources>
        //        <ResourceDictionary>
        //            <ResourceDictionary.MergedDictionaries>
        //                <ResourceDictionary Source = "../Styles/BorderStyles.xaml" />
        //                < ResourceDictionary Source="../Styles/ButtonStyles.xaml"/>
        //                <ResourceDictionary Source = "../Styles/TextBoxStyles.xaml" />
        //                < ResourceDictionary Source="../Styles/TextBlockStyles.xaml"/>
        //                <ResourceDictionary Source = "../Language/Strings.en.xaml" />
        //                < ResourceDictionary Source="../Language/Strings.sr.xaml"/>
        //            </ResourceDictionary.MergedDictionaries>
        //        </ResourceDictionary>
        //    </Window.Resources>

        //    <Grid>
        //        <Grid.ColumnDefinitions>
        //            <ColumnDefinition Width = "240" />
        //            < ColumnDefinition Width="*" />
        //        </Grid.ColumnDefinitions>

        //        <Border BorderThickness = "4" BorderBrush="{DynamicResource SelectedColor}" />

        //        <Grid Grid.Column="0" VerticalAlignment= "Center" Margin= "0,0,0,80" >
        //            < Grid.RowDefinitions >
        //                < RowDefinition Height= "80" />
        //                < RowDefinition Height= "80" />
        //                < RowDefinition Height= "80" />
        //                < RowDefinition Height= "380" />
        //            </ Grid.RowDefinitions >

        //            < TextBlock x:Name= "doctorsTextBlock" Grid.Row= "1" Text= "Staff"
        //                       MouseLeftButtonDown= "MouseClickDoctors" Style= "{StaticResource SidebarTextBlock}" />
        //            < TextBlock x:Name= "itemsTextBlock" Grid.Row= "2" Text= "Inventory"
        //                       MouseLeftButtonDown= "MouseClickItems" Style= "{StaticResource SidebarTextBlock}" />
        //            < TextBlock x:Name= "settingsTextBlock" Grid.Row= "3" Text= "Settings"
        //                       MouseLeftButtonDown= "MouseClickSettings" Style= "{StaticResource SidebarTextBlock}" />
        //            < TextBlock x:Name= "settingsTextBlock" Grid.Row= "3" Text= "Settings"
        //            MouseLeftButtonDown= "MouseClickSettings" Style= "{StaticResource SidebarTextBlock}" />

        //        </ Grid >

        //        < Button x:Name= "Log_out_Btn"
        //                Content= "Log out"
        //                Click= "LogoutBtn_Click"
        //                ClickMode= "Press"
        //                VerticalAlignment= "Top"
        //                Margin= "35,560,5,0"
        //                Style= "{StaticResource LogoutButtonStyle}" />

        //        < !--Frame with welcome message -->
        //        <Frame Grid.Column= "1" x:Name= "MainPage" NavigationUIVisibility= "Hidden" >
        //            < Frame.Content >
        //                < Grid >
        //                    < TextBlock x:Name= "welcomeTextBlock" Text= "Welcome to the Manager's Dashboard"
        //                               HorizontalAlignment= "Center" VerticalAlignment= "Center"
        //                               FontSize= "36" FontWeight= "Bold" Height= "299" Foreground= "#FFEFEDED" FontFamily= "Arial" />
        //                </ Grid >
        //            </ Frame.Content >
        //        </ Frame >
        //    </ Grid >
        //</ Window >

        #endregion

        private void MouseClickItems(object sender, MouseButtonEventArgs e)
        {
            HideWelcomeMessage();
            InitSidebarColors();
            itemsTextBlock.SetResourceReference(Control.StyleProperty, "SidebarSelectedTextBlock");
            MainPage.Content = new ItemsPage();
        }

        private void HideWelcomeMessage()
        {
            welcomeTextBlock.Visibility = Visibility.Collapsed;
        }

        private void MouseClickSettings(object sender, MouseButtonEventArgs e)
        {
            HideWelcomeMessage();
            InitSidebarColors();
            settingsTextBlock.SetResourceReference(Control.StyleProperty, "SidebarSelectedTextBlock");
            MainPage.Content = new SettingsPage();
        }

        private void InitSidebarColors()
        {
            itemsTextBlock.SetResourceReference(Control.StyleProperty, "SidebarTextBlock");
            doctorsTextBlock.SetResourceReference(Control.StyleProperty, "SidebarTextBlock");
            settingsTextBlock.SetResourceReference(Control.StyleProperty, "SidebarTextBlock");
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            new Login().Show();
            this.Close();
        }
    }
}
