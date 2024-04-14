using Kstopa.Lx.Admin.Services;
using Kstopa.Lx.SugarDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kstopa.Lx.Admin.IServices
{
    public interface IProductDataConfigService:IBaseService<ProductDataConfig>
    {
        List<ProductDataConfig> GetAllProductDataConfig();
        ProductDataConfig GetProductDataConfig();
    }
}
