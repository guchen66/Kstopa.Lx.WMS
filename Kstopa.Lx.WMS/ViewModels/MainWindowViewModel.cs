using Kstopa.Lx.Controls.Mvvm;
using Prism.Ioc;
using Prism.Mvvm;

namespace Kstopa.Lx.WMS.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IContainerProvider provider) : base(provider)
        {

        }
    }
}
