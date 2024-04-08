using Kstopa.Lx.Controls.Mvvm;
using Microsoft.VisualBasic.ApplicationServices;
using Prism.Commands;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kstopa.Lx.Controls.ViewModels
{
    public class HeaderViewModel : BaseViewModel
    {
      
        public HeaderViewModel(IContainerProvider provider) : base(provider)
        {

        }

        #region HeaderView Skin颜色修改
       /* private SkinColorInfo _selectedSkinColor;
        public SkinColorInfo SelectedSkinColor
        {
            get { return _selectedSkinColor; }
            set
            {
                *//* if (_selectedSkinColor != value)
                 {
                     _selectedSkinColor = value;
                     RaisePropertyChanged();
                 }*//*
                _selectedSkinColor = value;
                RaisePropertyChanged();

            }
        }
        public IEnumerable<SkinColorInfo> SkinColorItemsProvider
        {
            *//* get
             {
                 return Enum.GetValues(typeof(SkinColorInfo))
                            .Cast<SkinColorInfo>()
                            .ToList();
             }
 *//*
            get
            {
                var colors = new List<SkinColorInfo>();
                colors.Add(new SkinColorInfo() { Name = "Blue", Color = Brushes.Blue });
                colors.Add(new SkinColorInfo() { Name = "Green", Color = Brushes.Green });
                colors.Add(new SkinColorInfo() { Name = "Red", Color = Brushes.Red });
                colors.Add(new SkinColorInfo() { Name = "Yellow", Color = Brushes.Yellow });
                return colors;
            }

        }*/

        #endregion

        //TextBox初始为Empty
        private string search = string.Empty;

        public string Search
        {
            get { return search; }
            set { search = value; RaisePropertyChanged(); }
        }



    }
}
