using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kstopa.Lx.Core.Dtos
{
    public class BaseDto : BindableBase
    {
        private long _id;

        public long Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

    }
}
