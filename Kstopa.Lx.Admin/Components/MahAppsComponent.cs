using Kstopa.Lx.Admin.IRepositorys;
using Kstopa.Lx.Admin.IServices;
using Kstopa.Lx.Admin.Providers.LoginSign;
using Kstopa.Lx.Admin.Repositorys;
using Kstopa.Lx.Admin.Services;
using MahApps.Metro.Controls.Dialogs;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kstopa.Lx.Admin.Components
{
    public class MahAppsComponent : IContainerComponent
    {
        public void Load(IContainerRegistry registry, ComponentContext context)
        {
            //注册Mahapps.Metro控件的对话框，方面使用
            registry.Register<IDialogCoordinator, DialogCoordinator>();
        }
    }
}
