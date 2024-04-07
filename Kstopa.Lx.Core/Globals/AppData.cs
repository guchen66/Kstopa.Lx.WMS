using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kstopa.Lx.Core.Globals
{
    public class AppData : BindableBase
    {
        public static readonly AppData Instance = new Lazy<AppData>(() => new AppData()).Value;
    }
}
