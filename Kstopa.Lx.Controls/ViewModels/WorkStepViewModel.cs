using Kstopa.Lx.Admin.IRepositorys;
using Kstopa.Lx.Controls.Mvvm;
using Kstopa.Lx.Core.Extensions;
using Kstopa.Lx.SugarDb.Models;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kstopa.Lx.Controls.ViewModels
{
    public class WorkStepViewModel : BaseNavigationAware
    {
        private readonly IBaseRepository<WorkStep> _workStepRepository;
        private string _search;

        public string Search
        {
            get => _search;
            set => SetProperty(ref _search, value);
        }
        private ObservableCollection<WorkStep> _workSteps;

        public ObservableCollection<WorkStep> WorkSteps
        {
            get => _workSteps;
            set => SetProperty(ref _workSteps, value);
        }

        public WorkStepViewModel(IBaseRepository<WorkStep> workStepRepository,IContainerProvider provider) : base(provider)
        {
            _workStepRepository = workStepRepository;
            var  models=_workStepRepository.Context.Queryable<WorkStep>().Includes(x => x.WorkStationInfo).ToList();
            WorkSteps=models.ToObservableCollection();
        }

        #region 命令

        public ICommand QueryWorkStepCommand { get; set; }
        public ICommand AddWorkStepCommand { get; set; }
        public ICommand UpdateWorkStepCommand { get; set; }
        public ICommand DelWorkStepCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        #endregion
    }
}
