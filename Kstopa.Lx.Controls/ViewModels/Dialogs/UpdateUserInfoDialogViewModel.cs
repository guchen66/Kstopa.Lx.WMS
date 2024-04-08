using Kstopa.Lx.Admin.IRepositorys;
using Kstopa.Lx.Admin.Repositorys;
using Kstopa.Lx.Controls.Mvvm;
using Kstopa.Lx.Core.Consts;
using Kstopa.Lx.Core.Dtos;
using Kstopa.Lx.SugarDb.Models;
using Microsoft.VisualBasic.ApplicationServices;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kstopa.Lx.Controls.ViewModels.Dialogs
{
    public class UpdateUserInfoDialogViewModel : BaseDialogAware
    {
        #region 属性、字段

        public string Title => "修改UserInfo弹窗";

        public event Action action;
        List<UserInfo> UserInfos = null;
        public IBaseRepository<UserInfo> _userRepository;

        private int _currentId;

        public int CurrentId
        {
            get { return _currentId; }
            set { SetProperty(ref _currentId, value); }
        }

        private string _name;

        public string InputName
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _password;

        public string InputPassword
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

     
        private ObservableCollection<UserInfo> _UserInfoList;

        public ObservableCollection<UserInfo> UserInfoList
        {
            get { return _UserInfoList; }
            set { SetProperty(ref _UserInfoList, value); }
        }
        private DateTime _dateValue = DateTime.Now;
        public DateTime DateValue
        {
            get { return _dateValue; }
            set { SetProperty(ref _dateValue, value); }
        }
        #endregion

        public UpdateUserInfoDialogViewModel(IBaseRepository<UserInfo> userRepository)
        {
            _userRepository=userRepository;
            SaveCommand = new DelegateCommand<int?>(ExecuteSave);
            CancelCommand = new DelegateCommand<string>(ExecuteCancel);
        }

        #region 命令

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        #endregion

        #region 方法


        public override void OnDialogClosed()
        {
            action();
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("RefreshValue"))
            {
                action = parameters.GetValue<Action>("RefreshValue");
            }
        }

        private void ExecuteSave(int? id)
        {
            RaiseRequestClose(new DialogResult(ButtonResult.OK));
        }

        private void ExecuteCancel(string parameter)
        {
            RaiseRequestClose(new DialogResult(ButtonResult.No));
         //   RequestClose?.Invoke(new DialogResult(ButtonResult.No));      // 使用基类后失效
        }

        #endregion
    }
}
