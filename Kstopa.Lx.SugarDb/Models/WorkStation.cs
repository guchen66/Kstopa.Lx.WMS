using Kstopa.Lx.SugarDb.Models.NotMapped;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kstopa.Lx.SugarDb.Models
{
    [SugarTable("WorkStation")]
    public class WorkStation : AutoIncrementEntity
    {
        [SugarColumn(IsNullable = true, Length = 200)]
        public string DisplayName { get; set; }

        [SugarColumn(Length = 200)] public string Name { get; set; }

        [SugarColumn(ColumnDescription = "工号", Length = 200)]
        public string JobNumber { get; set; }

        public string Password { get; set; }

        [SugarColumn(IsNullable = true, Length = 50)]
        public string Department { get; set; }

        public int? RoleId { get; set; }

        //默认主键模式和子表的主键Id对应
        [Navigate(NavigateType.OneToOne, nameof(RoleId))]
        public RoleInfo Role { get; set; }

        //C#12.0版本可用非主键模式
        /*  [Navigate(NavigateType.OneToOne, nameof(RoleId),nameof(Role.Sort))]
          public RoleInfo Role { get; set; }*/
    }
}
