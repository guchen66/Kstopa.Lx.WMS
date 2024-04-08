using Kstopa.Lx.Core.Common;
using Kstopa.Lx.SugarDb.Models;
using NewLife.Configuration;
using SqlSugar;
using SqlSugar.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kstopa.Lx.SugarDb.Extensions;
namespace Kstopa.Lx.WMS
{
    public static class AppStartup
    {
        public static void AddSqlSugar()
        {
            SugarIocServices.AddSqlSugar(new IocConfig()
            {
                ConnectionString = GetConnectionData("Mysql"),
                DbType = IocDbType.MySql,
                //IsAutoCloseConnection = true
            });
            //  设置全局过滤器
            SugarIocServices.ConfigurationSugar(db => 
            {
                db.GlobalFilter();
            });

            //创建数据库
            if (GeneratorDataProvider.IsAutoTable)
            {
                StaticConfig.CodeFirst_MySqlCollate = "utf8mb4_0900_ai_ci";//较高版本支持
                DbScoped.Sugar.DbMaintenance.CreateDatabase();

                ////创建表
                DbScoped.Sugar.CodeFirst.InitTables(
                    typeof(UserInfo), typeof(RoleInfo),typeof(AsideMenuControl)

                );
            }
            //生成种子数据
            if (GeneratorDataProvider.IsAutoTableData)
            {
                // AddSeedData();
            }
        }
        /// <summary>
        /// 使用NewLife读取Json
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionData(string name)
        {
            string result = "";
            var provider = new JsonConfigProvider()
            {
                FileName = "AppConfig.json"
            };
            result = provider.GetSection($"SqlConnection:{name}").Value;
            return result;
        }
    }
}
