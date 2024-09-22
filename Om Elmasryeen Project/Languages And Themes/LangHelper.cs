using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Om_Elmasryeen_Project.Languages_And_Themes
{
    public static class LangHelper
    {
        private static ResourceDictionary ResourceDictionary = new ResourceDictionary();
        public  static string CurrentLanguage;
        public  static event EventHandler LanguageChanged;

        private static void OnLanguageChanged()
        {
            LanguageChanged?.Invoke(null, EventArgs.Empty);
        }


        public static string GetString(string name) //LightTheme DarkTheme GreenTheme BlueTheme
        {
            if (ResourceDictionary.Contains(name))
            {
                return ResourceDictionary[name] as string;
            }
            throw new InvalidOperationException("Invalid key");
        }

        public static void SwitchLanguage(string language)
        {
            switch (language)
            {
                case "AR":
                case "ar":   ResourceDictionary.Source = new Uri("../Language/Strings.ar.xaml", UriKind.Relative);
                    CurrentLanguage = "ar"; break;

                case "EN":
                case "en":  ResourceDictionary.Source = new Uri("../Language/Strings.en.xaml", UriKind.Relative);
                    CurrentLanguage = "en";  break;
                     
                case "FR":
                case "fr":  ResourceDictionary.Source = new Uri("../Language/Strings.FR.xaml", UriKind.Relative);
                    CurrentLanguage = "Fr";  break;

                default:  throw new InvalidOperationException("Invalid language");
            }
            OnLanguageChanged();
        }

        public static ResourceDictionary GetResourceDictionary()
        {
            return ResourceDictionary;
        }

    }
}
