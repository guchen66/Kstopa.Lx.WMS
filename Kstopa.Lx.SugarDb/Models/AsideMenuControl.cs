using Kstopa.Lx.SugarDb.Models.NotMapped;
using SqlSugar;
using SqlSugar.DbConvert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kstopa.Lx.SugarDb.Models
{
    [SugarTable("AsideMenuControl")]
    public class AsideMenuControl : AutoIncrementEntity
    {
        [SugarColumn(ColumnDataType = "Nvarchar(200)", IsNullable = true)]
        public string? Icon { get; set; }

        [SugarColumn(ColumnDataType = "Nvarchar(16)", IsNullable = true,SqlParameterDbType =typeof(Nvarchar2PropertyConvert))]//Nvarchar2PropertyConvert
        public string? Content { get; set; }

        [SugarColumn(ColumnDataType = "Nvarchar(16)", IsNullable = true)]
        public string? NameSpace { get; set; }
    }

}
