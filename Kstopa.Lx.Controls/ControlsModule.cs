using Kstopa.Lx.Controls.ViewModels.Dialogs;
using Kstopa.Lx.Controls.Views;
using Kstopa.Lx.Controls.Views.Dialogs;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Kstopa.Lx.Controls
{
    public class ControlsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HomeView>();  
            containerRegistry.RegisterForNavigation<UserInfoView>();  
            containerRegistry.RegisterForNavigation<WorkStationView>();


            //注册弹窗
            containerRegistry.RegisterDialog<AddUserInfoDialog,AddUserInfoDialogViewModel>();
            containerRegistry.RegisterDialog<UpdateUserInfoDialog, UpdateUserInfoDialogViewModel>();
        }
    }
}