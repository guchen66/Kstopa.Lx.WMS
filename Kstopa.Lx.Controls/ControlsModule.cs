﻿using Kstopa.Lx.Controls.ViewModels.Dialogs;
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
            containerRegistry.RegisterForNavigation<HomeView>();                //首页
            containerRegistry.RegisterForNavigation<UserInfoView>();            //用户界面
            containerRegistry.RegisterForNavigation<WareHouseView>();           //仓库界面
            containerRegistry.RegisterForNavigation<WorkStationView>();         //工站界面
            containerRegistry.RegisterForNavigation<WorkStepView>();             //工站具体步骤

            //注册弹窗
            containerRegistry.RegisterDialog<AddUserInfoDialog,AddUserInfoDialogViewModel>();
            containerRegistry.RegisterDialog<AddWareHouseDialog, AddWareHouseDialogViewModel>();
            containerRegistry.RegisterDialog<UpdateUserInfoDialog, UpdateUserInfoDialogViewModel>();
            containerRegistry.RegisterDialog<UpdateWareHouseDialog, UpdateWareHouseDialogViewModel>();
        }
    }
}