using DataAcessLayer.Models;
using DataAcessLayer.Services;
using Om_Elmasryeen_Project.Languages_And_Themes;
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

namespace Om_Elmasryeen_Project.XAML.CreateWindows
{
    /// <summary>
    /// Interaction logic for CreateItemWindow.xaml
    /// </summary>

    public partial class CreateItemWindow : Window
    {
        private ItemsService ItemsService = new();
        private Item? Item = null;

        public CreateItemWindow()
        {
            InitializeComponent();
        }

        public CreateItemWindow(Item item)
        {
            InitializeComponent();

            item_name.Text = item.ItemName;
            Item = item;

            Header.Text = LangHelper.GetString("UpdateRecord");
            CreateButton.Content = LangHelper.GetString("Update");
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string name = item_name.Text;

            if (name == null)
            {
                new ErrorWindow(LangHelper.GetString("ErrorEmptyFields")).ShowDialog();
                return;
            }

            try
            {
                if (Item == null)
                {
                    ItemsService.Add(new Item { ItemName = name });
                    new SuccessWindow(LangHelper.GetString("SuccessCreated")).ShowDialog();
                    this.Close();
                }
                else
                {
                    Item.ItemName = name;

                    ItemsService.Update(Item);
                    new SuccessWindow(LangHelper.GetString("SuccessUpdated")).ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                new ErrorWindow(ex.Message).ShowDialog();
            }
        }
    }
}
