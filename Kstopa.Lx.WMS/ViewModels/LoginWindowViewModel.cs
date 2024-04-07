using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Kstopa.Lx.Controls.Mvvm;
using Kstopa.Lx.SugarDb.Models;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using SqlSugar.IOC;
using Kstopa.Lx.Controls.Commands;
using Kstopa.Lx.Core.Events;
using NewLife.Log;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Kstopa.Lx.Core.Dtos;
using System.DirectoryServices.Protocols;
using Kstopa.Lx.Core.Consts;
using Kstopa.Lx.Admin.LoginSign;
using SqlSugar;
namespace Kstopa.Lx.WMS.ViewModels
{
    public class LoginWindowViewModel : BaseViewModel
    {
        ILoginService _loginService;

        private readonly ISimpleClient<UserInfo> _userRepository;
      
        public LoginWindowViewModel(ILoginService loginService,IContainerProvider provider) : base(provider)
        {
            _userRepository=provider.Resolve<ISimpleClient<UserInfo>>();
            _loginService = loginService;
            LoginCommand = new DelegateCommand<Window>(async (win) => await ExecuteLogin(win));
            CancelCommand = new DelegateCommand(ExecuteCancel);
        }

        private async Task ExecuteLogin(Window win)
        {
            EventAggregator.GetEvent<LoginEvent>().Publish(win);
            await Task.Delay(100); // 假设等待100毫秒，你可以根据实际情况调整
            //logger.Info($"用户进行了登录操作");
           /* var loginResult = await AuthenticateAsync(UserName, Password);
            if (loginResult.Status)
            {
                EventAggregator.GetEvent<LoginEvent>().Publish(win);
                await Task.Delay(100); // 假设等待100毫秒，你可以根据实际情况调整
            }
            else
            {
                MessageBox.Show(loginResult.Result.ToString());
            }*/
        }
        public SimpleClient<UserInfo> db = new SimpleClient<UserInfo>();
        private void ExecuteCancel()
        {
            var s=db.GetList();
            var s2 = _userRepository.AsSugarClient();//.Queryable<UserInfo>().Any(x=>x.Name=="Admin");
            
            EventAggregator.GetEvent<LogOutEvent>().Publish();
        }

        public ICommand LoginCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// 身份验证
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
       /* private async Task<ApiResponse> AuthenticateAsync(string username, string password)
        {
            // string passwordMd5= MD5Extension.GetMD5Provider(username,password);
            var result = await _loginService.LoginAsync(new LoginInputDto
            {
                UserName = username,
                Password = password
            });
            if (result)
            {
                return new ApiResponse(true, LoginConst.LoginSucess);
            }
            return new ApiResponse(false, LoginConst.LoginFailed);
        }*/
    }
}

