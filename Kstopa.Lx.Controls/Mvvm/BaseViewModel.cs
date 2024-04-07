﻿using Kstopa.Lx.Core.Globals;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kstopa.Lx.Controls.Mvvm
{
    /// <summary>
    /// 使用继承链
    /// 除了将Prism的公用接口放在中间类之外，一些通用的属性，方法，接口也可以放置
    /// 而公用对象里可以放公用的service
    /// </summary>
    public class BaseViewModel : BindableBase
    {
        public IRegionNavigationJournal NavigationJournal;  //导航日志，上一页，下一页
        public IRegionManager RegionManager;                //区域管理
        public IEventAggregator EventAggregator;            //事件处理
        public IDialogService DialogService { get; set; }   //页面跳转
        public IContainerProvider Provider { get; set; }    //服务容器
        public AppData appData { get; set; } = AppData.Instance;

        public BaseViewModel(IContainerProvider provider)
        {
            Provider = provider;
            NavigationJournal = Provider.Resolve<IRegionNavigationJournal>();
            RegionManager = Provider.Resolve<IRegionManager>();
            EventAggregator = Provider.Resolve<IEventAggregator>();
            DialogService = Provider.Resolve<IDialogService>();

        }

    }
}
