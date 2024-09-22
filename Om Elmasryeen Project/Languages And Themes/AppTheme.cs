using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Om_Elmasryeen_Project.Languages_And_Themes
{
    public class AppTheme
    {
        public static string CurrentTheme;

        private static void ChangeTheme(Uri themeuri)
        { 
            ResourceDictionary Theme = new ResourceDictionary() { Source = themeuri };
            App.Current.Resources.Clear();
            App.Current.Resources.MergedDictionaries.Add(Theme);
        }

        public static void ChangeThemeToLight()
        {
            AppTheme.ChangeTheme(new Uri("Theme/LightTheme.xaml", UriKind.Relative));
            CurrentTheme = "Light";
        }

        public static void ChangeThemeToDark()
        {
            AppTheme.ChangeTheme(new Uri("Theme/DarkTheme.xaml", UriKind.Relative));
            CurrentTheme = "Dark";
        }

        public static void ChangeThemeToGreen()
        {
            AppTheme.ChangeTheme(new Uri("Theme/GreenTheme.xaml", UriKind.Relative));
            CurrentTheme = "Green";
        }
        public static void ChangeThemeToBlue()
        {
            AppTheme.ChangeTheme(new Uri("Theme/BlueTheme.xaml", UriKind.Relative));
            CurrentTheme = "Blue";
        } 
        public static void SwitchTheme(string theme)
        {
            switch (theme)
            {
                case "Light":  AppTheme.ChangeThemeToLight();  break;
                case "Dark":  AppTheme.ChangeThemeToDark();  break;
                case "Green":  AppTheme.ChangeThemeToGreen();  break; 
                case "Blue":  AppTheme.ChangeThemeToBlue();  break; 
                default: throw new InvalidOperationException("Invalid theme");
            } 
        } 
    }
}
