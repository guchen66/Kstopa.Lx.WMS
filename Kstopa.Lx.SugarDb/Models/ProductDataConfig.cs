using Kstopa.Lx.SugarDb.Models.NotMapped;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kstopa.Lx.SugarDb.Models
{
    [SugarTable("Product_Data_Config")]
    public class ProductDataConfig : AutoIncrementEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Batch { get; set; }
    }
}
