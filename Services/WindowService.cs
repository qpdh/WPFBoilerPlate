using System.Collections.Concurrent;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WPFBoilerPlate.Services.Interfaces;
using WPFBoilerPlate.ViewModels.Interfaces;

namespace WPFBoilerPlate.Services
{
    public class WindowService : IWindowService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ConcurrentDictionary<Type, Window> _opennedWindows;

        public WindowService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _opennedWindows = new ConcurrentDictionary<Type, Window>();
        }

        public void ShowWindow<TView, TViewModel>(params object[] vmArgs) where TView : Window where TViewModel : IBaseViewModel
        {
            var viewType = typeof(TView);

            // 이미 열려 있으면 활성화만
            if (TryActivateExistingWindow(viewType))
            {
                return;
            }

            try
            {
                // View 생성
                var window = _serviceProvider.GetRequiredService<TView>();

                var viewModel = ActivatorUtilities.CreateInstance<TViewModel>(
                    _serviceProvider, vmArgs);

                window.DataContext = viewModel;

                // 닫힐 때 Dictionary에서 제거
                window.Closed += (s, e) => _opennedWindows.TryRemove(viewType, out _);

                // 등록
                _opennedWindows[viewType] = window;

                // Show Dialog
                window.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Modal 생성 실패: {ex}");
                throw;
            }
        }

        public void ShowDialog<TView, TViewModel>(params object[] vmArgs) where TView : Window where TViewModel : IBaseViewModel
        {
            var viewType = typeof(TView);

            // 이미 열려 있으면 활성화만
            if (TryActivateExistingWindow(viewType))
            {
                return;
            }

            try
            {
                // View 생성
                var window = _serviceProvider.GetRequiredService<TView>();

                var viewModel = ActivatorUtilities.CreateInstance<TViewModel>(
                    _serviceProvider, vmArgs);

                window.DataContext = viewModel;

                // 닫힐 때 Dictionary에서 제거
                window.Closed += (s, e) => _opennedWindows.TryRemove(viewType, out _);

                // 등록
                _opennedWindows[viewType] = window;
                // Modal / Non-Modal
                window.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Window 생성 실패: {ex}");
                throw;
            }
        }

        public void CloseWindow(IBaseViewModel viewModel)
        {
            var entry = _opennedWindows.FirstOrDefault(x => x.Value.DataContext == viewModel);

            if (entry.Value != null)
            {
                entry.Value.Close();
            }
        }

        public void ShowWindowWithParameter<TView, TParam>(TParam param, bool isModal = false) where TView : Window
        {
            throw new NotImplementedException();
        }

        private bool TryActivateExistingWindow(Type windowType)
        {
            if (_opennedWindows.TryGetValue(windowType, out var openedWindow))
            {
                if (openedWindow.WindowState == WindowState.Minimized)
                    openedWindow.WindowState = WindowState.Normal;

                openedWindow.Activate();
                return true;
            }
            return false;
        }
    }
}