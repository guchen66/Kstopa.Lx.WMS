using Kstopa.Lx.Core.Common;
using Kstopa.Lx.SugarDb.Models;
using NewLife.Configuration;
using SqlSugar.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //创建数据库
            if (GeneratorDataProvider.IsAutoTable)
            {
                DbScoped.Sugar.DbMaintenance.CreateDatabase();

                ////创建表
                DbScoped.Sugar.CodeFirst.InitTables(
                    typeof(UserInfo), typeof(RoleInfo)
                /*  typeof(AsideCreateController),
                  typeof(MusicInfo),
                  typeof(PlayListUiInfo),
                  typeof(PlayListInfo),
                  typeof(AsideMenu), typeof(MusicSourceInfo), typeof(SysUser)*/
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
