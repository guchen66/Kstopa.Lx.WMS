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

namespace Kstopa.Lx.WMS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// 
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
            //Ctrl Alt J打开对象浏览器
            //  SugarGlobal.Initialized(); //初始化数据库自动生成表
            // ThemeManager.Current.ChangeTheme(this, "Dark.Green");
            // 设置日志级别

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
            //注册MahMapps.Metro控件的对话框，方面使用
            containerRegistry.Register<IDialogCoordinator, DialogCoordinator>();
            containerRegistry.Register<IMapper, Mapper>();
            //注册对话框弹窗
            /*   containerRegistry.RegisterDialog<MyDialogView, MyDialogViewModel>();

               containerRegistry.RegisterForNavigation<UserInfoView>("User");  //用户信息
               containerRegistry.RegisterForNavigation<TotalView>("Total");  //库存总量
               containerRegistry.RegisterForNavigation<WorkStationView>();  //工位信息
               containerRegistry.RegisterForNavigation<ProcessView>();  //工序信息
               containerRegistry.RegisterForNavigation<CountView>();  //统计数据
               containerRegistry.RegisterForNavigation<AlarmView>("Alarm");  //报警信息
               containerRegistry.RegisterForNavigation<SetView>();

               containerRegistry.RegisterSingleton<ILogger, NLogLogger>();
               containerRegistry.RegisterSingleton<LoggerHelper>();*/
            containerRegistry.RegisterScoped(typeof(IBaseService<>),typeof(BaseService<>));
            containerRegistry.RegisterScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            containerRegistry.Register<ILoginService, LoginService>();
            RegisterRepository_Service(containerRegistry);


            RegisterMapper(containerRegistry);
        }

        private void RegisterRepository_Service(IContainerRegistry containerRegistry)
        {
            //containerRegistry.Register<>
           // containerRegistry.RegisterScoped<IUserService, UserService>();
           // containerRegistry.Register<IUserRepository, UserRepository>();
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
            //注册WatchDog
            //Container.Resolve<WatchLog>();
            //他妈的一个星期了，艹
            // var regionManager = containerProvider.Resolve<IRegionManager>();
            base.OnInitialized();
            var regionManager = Container.Resolve<IRegionManager>();

          //  regionManager.RequestNavigate("ContentRegion", "HomeView");
            //  regionManager.RequestNavigate("HeaderRegion", "HeaderView");
            //  regionManager.RequestNavigate("FooterRegion", "FooterView");
        }
        /* protected override IContainerExtension CreateContainerExtension()
         {
             var serviceCollection = new ServiceCollection();
             serviceCollection.AddLogging(configure =>
             {
                 configure.ClearProviders();
                 configure.SetMinimumLevel(LogLevel.Trace);
                 configure.AddNLog();
             });

             return new DryIocContainerExtension(new Container(CreateContainerRules())
                 .WithDependencyInjectionAdapter(serviceCollection));
         }*/

        /* protected override void ConfigureContainer(IContainerExtension containerBuilder)
         {
             // 使用你自己的容器实现来设置 ContainerLocator
             ContainerLocator.SetContainerExtension(() => new DryIocContainerExtension(containerBuilder));
         }*/

        protected override IContainerExtension CreateContainerExtension()
        {
            return base.CreateContainerExtension();
        }

        protected override DryIoc.Rules CreateContainerRules()
        {
            return base.CreateContainerRules();
        }

        /// <summary>
        /// 注册Mapster
        /// </summary>
        /// <param name="containerRegistry"></param>
        private void RegisterMapper(IContainerRegistry containerRegistry)
        {

            var config = new TypeAdapterConfig();
            var assembly = Assembly.Load("Kstopa.Lx.Admin");
            config.Scan(assembly);

            // 注册单例实例
            containerRegistry.RegisterInstance(typeof(TypeAdapterConfig), config);

            // 创建并注册 Mapper 实例
            var mapper = new Mapper(config);
            containerRegistry.RegisterInstance(typeof(Mapper), mapper);
        }
    }
}
