using MahApps.Metro.Controls.Dialogs;
using Mapster;
using MapsterMapper;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kstopa.Lx.Admin.Components
{
    public class MapsterComponent : IContainerComponent
    {
        public void Load(IContainerRegistry registry, ComponentContext context)
        {
            var config = new TypeAdapterConfig();
            var assembly = Assembly.Load("Kstopa.Lx.Admin");
            config.Scan(assembly);

            // 注册单例实例
            registry.RegisterInstance(typeof(TypeAdapterConfig), config);

            // 创建并注册 Mapper 实例
            var mapper = new Mapper(config);
            registry.RegisterInstance(typeof(Mapper), mapper);
            registry.Register<IMapper, Mapper>();
        }
    }
}
