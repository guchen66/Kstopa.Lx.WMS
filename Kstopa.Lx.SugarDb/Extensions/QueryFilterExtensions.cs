using Kstopa.Lx.SugarDb.Models;
using SqlSugar;
using SqlSugar.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kstopa.Lx.SugarDb.Extensions
{
    public static class QueryFilterExtensions
    {
        public static void GlobalFilter(this ISqlSugarClient client)
        {
           // DbScoped.Sugar.QueryFilter.AddTableFilter<UserInfo>(it => it.IsDelete == "0");
            client.QueryFilter.Add(new TableFilterItem<UserInfo>(it => it.IsDelete == "0" || it.IsDelete == null));
            client.QueryFilter.Add(new TableFilterItem<WareHouse>(it => it.IsDelete == "0" || it.IsDelete == null));
        }
    }
}
