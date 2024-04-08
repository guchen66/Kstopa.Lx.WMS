using Kstopa.Lx.Controls.Mvvm;
using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kstopa.Lx.Controls.ViewModels
{
    public class HomeViewModel : BaseViewModel, INavigationAware
    {
        #region  属性、字段

        private readonly IRegionManager _regionManager;
        private readonly IRegionNavigationJournal _journal;
        private readonly IRegionNavigationService _navigationService;
        #endregion

        #region  命令

        public ICommand BackDeskTopCommand { get; set; }
        #endregion

        public HomeViewModel(IContainerProvider provider) : base(provider)
        {
            _navigationService = provider.Resolve<IRegionNavigationService>();
            BackDeskTopCommand = new DelegateCommand(ShowDesktop);
        }

        #region  方法

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // Do nothing
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _navigationService.Journal.GoBack();
            /* _journal = navigationContext.NavigationService.Journal;
             if (_journal != null && _journal.CanGoBack)
            {
                _journal.GoBack();
            }
            */
        }

        private void ShowDesktop()
        {
            // 执行显示桌面的逻辑，例如使用 Shell
            var shell = new Shell32.Shell();
            shell.MinimizeAll();
        }
        #endregion
    }
}
