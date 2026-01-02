using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using WPFBoilerPlate.Properties.Strings;

namespace WPFBoilerPlate.Utils
{
    public class LocalizationService : ObservableObject
    {
        public static LocalizationService Instance { get; } = new();

        public string this[string key]
            => Strings.ResourceManager.GetString(key, CultureInfo.CurrentUICulture) ?? key;

        public void ChangeCulture(string culture)
        {
            CultureInfo.CurrentUICulture = new CultureInfo(culture);
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            Properties.Settings.Default.AppLanguage = culture;
            Properties.Settings.Default.Save();

            OnPropertyChanged(string.Empty);
        }
    }
}
