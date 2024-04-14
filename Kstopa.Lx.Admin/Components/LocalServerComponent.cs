using Kstopa.Lx.Admin.Contexts;
using Kstopa.Lx.Admin.Providers.LoginSign;
using Mapster;
using MapsterMapper;
using MySqlConnector.Logging;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kstopa.Lx.Admin.Components
{
    public class LocalServerComponent : IContainerComponent
    {
        public void Load(IContainerRegistry registry, ComponentContext context)
        {
            registry.Register<ILoginService, LoginService>();
         //   registry.RegisterSingleton<ILogger, NLogLogger>();
        }
    }
}
