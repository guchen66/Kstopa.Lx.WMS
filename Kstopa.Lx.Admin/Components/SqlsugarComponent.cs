using Kstopa.Lx.Admin.Contexts;
using Kstopa.Lx.Admin.IRepositorys;
using Kstopa.Lx.Admin.IServices;
using Kstopa.Lx.Admin.Providers.LoginSign;
using Kstopa.Lx.Admin.Repositorys;
using Kstopa.Lx.Admin.Services;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kstopa.Lx.Admin.Components
{
    public class SqlsugarComponent : IContainerComponent
    {
        public void Load(IContainerRegistry registry, ComponentContext context)
        {
            registry.RegisterScoped(typeof(IBaseService<>), typeof(BaseService<>));
            registry.RegisterScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            registry.RegisterScoped<IProductDataConfigService,ProductDataConfigService>();
            // containerRegistry.RegisterScoped<IUserService, UserService>();
            // containerRegistry.Register<IUserRepository, UserRepository>();
        }
    }
}
