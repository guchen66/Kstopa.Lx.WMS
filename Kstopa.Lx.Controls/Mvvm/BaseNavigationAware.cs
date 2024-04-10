using MahApps.Metro.Controls.Dialogs;
using MapsterMapper;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kstopa.Lx.Controls.Mvvm
{
    /// <summary>
    /// 中继层，导航的基类
    /// </summary>
    public abstract class BaseNavigationAware :BaseViewModel,  INavigationAware
    {
        public IDialogCoordinator DialogCoordinator { get; set; }
        public IMapper DefaultMapper { get; set; }
        protected BaseNavigationAware(IContainerProvider provider) : base(provider)
        {
            DialogCoordinator = provider.Resolve<IDialogCoordinator>();
            DefaultMapper = provider.Resolve<IMapper>();
        }

        //省去了string.Empty的操作，视图初始化
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
           
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }
    }
}
