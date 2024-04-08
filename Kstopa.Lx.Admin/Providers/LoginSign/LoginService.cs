using Kstopa.Lx.Core.Dtos;
using Kstopa.Lx.Core.Events;
using Kstopa.Lx.SugarDb.Models;
using Newtonsoft.Json;
using Prism.Events;
using Prism.Ioc;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kstopa.Lx.Admin.Providers.LoginSign
{
    public class LoginService : ILoginService
    {
        public SimpleClient<UserInfo> db = new SimpleClient<UserInfo>();
        private readonly IEventAggregator _eventAggregator;
        //  private readonly ILogger _logger;
        private readonly IContainerProvider _container;
        public LoginService(IEventAggregator eventAggregator, IContainerProvider container)
        {
            //  this._logger = logger;
            _eventAggregator = eventAggregator;
            _container = container;
            _eventAggregator.GetEvent<LoginEvent>().Subscribe(LoginExecute);
            _eventAggregator.GetEvent<LogOutEvent>().Subscribe(async () => await LogoutAsync());
        }

        public void LoginExecute(Window win)
        {
            win.DialogResult = true;    //Window.DialogResult 属性表示对话框的返回值=true表示APp.xaml.cs中的MainWindow已经成功登录，                                        //  win.Close();             //然后关闭LoginView
            // 关闭当前登录界面
            LogoutAsync();
        }

        public Task LogoutAsync()
        {
            // 查找当前活动窗口并关闭
            var activeWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            activeWindow?.Close();
            return Task.CompletedTask;
        }

        public async Task<bool> LoginAsync(LoginInputDto loginDto)
        {
            if (loginDto == null) return false;
            LoginInputDto canLoginDto = await IsCanLoginAsync(); // 调用异步的IsCanLoginAsync方法获取登录参数
            var result = canLoginDto.UserName == loginDto.UserName && canLoginDto.Password == loginDto.Password;
            return result;

        }

        public Task<bool> RegisterAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<LoginInputDto> IsCanLoginAsync()
        {
            LoginInputDto loginInputDto = new LoginInputDto();
            var userInfo = await db.GetFirstAsync(x => x.Name == "Admin" && x.Password == "123456");
            userInfo.Name = loginInputDto.UserName;
            userInfo.Password = loginInputDto.Password;
            return loginInputDto;
        }
    }
}
