using System.Windows;
using WPFBoilerPlate.ViewModels.Interfaces;

namespace WPFBoilerPlate.Services.Interfaces
{
    public interface IWindowService : IBaseService
    {
        /// <summary>
        /// View Type을 전달하여 Window를 표시합니다.
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        void ShowWindow<TView, TViewModel>(params object[] vmArgs) where TView : Window where TViewModel : IBaseViewModel;
        /// <summary>
        /// View Type을 전달하여 Modal를 표시합니다.
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        void ShowDialog<TView, TViewModel>(params object[] vmArgs) where TView : Window where TViewModel : IBaseViewModel;


        void CloseWindow(IBaseViewModel viewModel);


        /// <summary>
        /// View Type과 Parameter를 전달하여 Window를 표시합니다.
        /// </summary>
        /// <typeparam name="TView">Window 타입</typeparam>
        /// <typeparam name="TParam">ViewModel 생성 시 전달할 파라미터 타입</typeparam>
        /// <param name="param">파라미터</param>
        void ShowWindowWithParameter<TView, TParam>(TParam param, bool isModal = false) where TView : Window;
    }
}