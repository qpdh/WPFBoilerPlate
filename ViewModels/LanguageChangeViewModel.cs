using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPFBoilerPlate.Models;
using WPFBoilerPlate.Utils;
using WPFBoilerPlate.ViewModels.Interfaces;

namespace WPFBoilerPlate.ViewModels
{
    public partial class LanguageChangeViewModel : ObservableObject, IBaseViewModel
    {
        public ObservableCollection<LanguageItem> Languages { get; } = [
            new("한국어","ko-KR"),
            new("English","en-US")
            ];

        [ObservableProperty]
        private LanguageItem selectedLanguage;

        private readonly LocalizationService localizationService;

        public LanguageChangeViewModel(LocalizationService localizationService)
        {
            SelectedLanguage = Languages.First(l => l.Culture == Properties.Settings.Default.AppLanguage);
            this.localizationService = localizationService;
        }

        [RelayCommand]
        private void ChangeLanguage(LanguageItem selectedLanguage)
        {
            localizationService.ChangeCulture(selectedLanguage.Culture);
            MessageBox.Show("언어 변경 성공", "언어 변경 성공", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
