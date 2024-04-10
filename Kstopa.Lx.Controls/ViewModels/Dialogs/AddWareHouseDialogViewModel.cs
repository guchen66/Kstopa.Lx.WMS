using Kstopa.Lx.Admin.IRepositorys;
using Kstopa.Lx.Controls.Mvvm;
using Kstopa.Lx.Core.Consts;
using Kstopa.Lx.Core.Dtos;
using Kstopa.Lx.SugarDb.Models;
using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kstopa.Lx.Controls.ViewModels.Dialogs
{
   public class AddWareHouseDialogViewModel : BaseDialogAware
    {
        #region 字段、属性

        public string Title => "添加仓库弹窗";
        public event Action action;
        private IBaseRepository<WareHouse> _wareHouseRepository;

        private WareHouseDto _wareHouseDto;

        public WareHouseDto WareHouseDto
        {
            get => _wareHouseDto??(_wareHouseDto=new WareHouseDto());
            set => SetProperty(ref _wareHouseDto, value);
        }

        #endregion

        public AddWareHouseDialogViewModel(IBaseRepository<WareHouse> wareHouseRepository)
        {
            _wareHouseRepository = wareHouseRepository;
            SaveCommand = new DelegateCommand<string>(ExecuteSave);
            CancelCommand = new DelegateCommand<string>(ExecuteCancel);
        }

        #region 命令

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        #endregion

        #region 方法

      /*  public override void OnDialogClosed()
        {
            action();
        }*/

    /*    public override void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("RefreshValue"))
            {
                action = parameters.GetValue<Action>("RefreshValue");
            }
        }
*/
        private void ExecuteSave(string parameter)
        {
            WareHouse wareHouse = new WareHouse()
            {
               WareHouseId=WareHouseDto.Id,
               WareHouseName=WareHouseDto.WareHouseName,
               ItemTotal=WareHouseDto.ItemTotal,
               ItemType=WareHouseDto.ItemType,
               Price=WareHouseDto.Price,
               UpdateTime=WareHouseDto.UpdateTime,
               AssociatedPerson=WareHouseDto.AssociatedPerson,
            };
            _wareHouseRepository.Context.Insertable<WareHouse>(wareHouse).ExecuteCommand();//.AddAsync(userInfo);
            RaiseRequestClose(new DialogResult(ButtonResult.OK));
        }

        private void ExecuteCancel(string parameter)
        {

            //  RequestClose?.Invoke(new DialogResult(ButtonResult.No));
            RaiseRequestClose(new DialogResult(ButtonResult.No));
        }



        #endregion
    }
}
