using Kstopa.Lx.Admin.Contexts;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kstopa.Lx.Admin.Components
{
    /// <summary>
    /// 容器依赖组件
    /// </summary>
    public interface IContainerComponent : IPrismComponent
    {
        void Load(IContainerRegistry registry, ComponentContext context);
    }
}
