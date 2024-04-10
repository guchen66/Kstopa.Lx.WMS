using Kstopa.Lx.Controls.Mvvm;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kstopa.Lx.Controls.ViewModels
{
    public class WorkStepViewModel : BaseNavigationAware
    {
        public WorkStepViewModel(IContainerProvider provider) : base(provider)
        {
        }
    }
}
