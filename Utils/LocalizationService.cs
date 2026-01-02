using System.ComponentModel;
using System.Globalization;
using WPFBoilerPlate.Properties.Strings;

namespace WPFBoilerPlate.Utils
{
    public class LocalizationService : INotifyPropertyChanged
    {
        public string this[string key]
            => Strings.ResourceManager.GetString(key, CultureInfo.CurrentUICulture) ?? key;

        public event PropertyChangedEventHandler? PropertyChanged;

        public void ChangeCulture(string culture)
        {
            var ci = new CultureInfo(culture);
            CultureInfo.CurrentUICulture = ci;
            CultureInfo.CurrentCulture = ci;

            Properties.Settings.Default.AppLanguage = culture;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }
    }
}
