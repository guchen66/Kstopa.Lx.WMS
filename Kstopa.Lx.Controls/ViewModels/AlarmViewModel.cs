﻿using Kstopa.Lx.Controls.Mvvm;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kstopa.Lx.Controls.ViewModels
{
    public class AlarmViewModel : BaseNavigationAware
    {
        public AlarmViewModel(IContainerProvider provider) : base(provider)
        {
        }
    }
}