using Kstopa.Lx.WMS.Views;
using MahApps.Metro.Controls.Dialogs;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.Threading;
using System;
using System.Windows;
using Kstopa.Lx.Controls;
using Prism.Events;
using SqlSugar;
using Kstopa.Lx.Admin.IServices;
using Kstopa.Lx.Admin.Services;
using Kstopa.Lx.Admin.IRepositorys;
using Kstopa.Lx.Admin.Repositorys;
using Mapster;
using MapsterMapper;
using System.Reflection;
using Kstopa.Lx.Admin.Providers.LoginSign;
using Kstopa.Lx.Core.Extensions;
using Kstopa.Lx.Admin.Components;
using ControlzEx.Theming;

namespace Kstopa.Lx.WMS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// Prism的运行步骤，
    /// InitializeShell在创建Shell之后运行，用来确保Shell可以显示，将其设为主窗口
    /// </summary>
    public partial class App : PrismApplication
    {
        Mutex mutex;
        //  private static readonly Cargo.Core.Loggers.ILogger logger = LogManager.GetCurrentClassLogger();
        protected override void OnStartup(StartupEventArgs e)
        {
            mutex = new Mutex(true, "WMS系统");
            if (!mutex.WaitOne(TimeSpan.Zero, true))
            {
                MessageBox.Show("警告，已重复打开软件！", "WMS系统", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(0);
            }
            AppStartup.AddSqlSugar();                 //注册SqlSugar
            base.OnStartup(e);
          
        }

        protected override void OnExit(ExitEventArgs e)
        {
            mutex.ReleaseMutex();
            mutex.Close();

            base.OnExit(e);

        }
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();

        }

        protected override void InitializeShell(Window shell)
        {
            if (Container.Resolve<LoginWindow>().ShowDialog() == false)
            {
                Application.Current?.Shutdown();
            }
            else
            {
                base.InitializeShell(shell);
            }

        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IEventAggregator, EventAggregator>();
            containerRegistry.RegisterComponent<LocalServerComponent>();      //注册本地服务
            containerRegistry.RegisterComponent<SqlsugarComponent>();         //注册Sqlsugar组件
            containerRegistry.RegisterComponent<MahAppsComponent>();          //注册MahApps组件库
            containerRegistry.RegisterComponent<MapsterComponent>();          //注册Mapster映射
        }

        //新建类库，通过模块化传入用户控件
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //注册模块就行
            moduleCatalog.AddModule<ControlsModule>();
            base.ConfigureModuleCatalog(moduleCatalog);
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            var regionManager = Container.Resolve<IRegionManager>();
        }
/*
        protected override IContainerExtension CreateContainerExtension()
        {
            return base.CreateContainerExtension();
        }

        protected override DryIoc.Rules CreateContainerRules()
        {
            return base.CreateContainerRules();
        }*/
    }
}
