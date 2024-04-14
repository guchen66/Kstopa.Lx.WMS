﻿using System;
using System.Reflection;
using Bogus;
using ControlzEx.Standard;
using Kstopa.Lx.Core.Common;
using Kstopa.Lx.Core.Helpers;
using Kstopa.Lx.SugarDb.Extensions;
using Kstopa.Lx.SugarDb.Models;
using NewLife.Configuration;
using SqlSugar;
using SqlSugar.IOC;

namespace Kstopa.Lx.Admin.Providers
{
    public static class SugarProvider
    {
        /// <summary>
        /// 获取所有实体类的集合
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="inter"></param>
        /// <returns></returns>
        public static Type[] GetSugarModels(string folder, Type inter = null)
        {
            string lib = "Kstopa.Lx.SugarDb";
            return DirectoryHelper.GetClassSelf(lib, folder, typeof(SugarTable));
        }

        public static void NativeSql()
        {
            // 编写原生 SQL 语句
            string sql = "SHOW VARIABLES LIKE 'datadir';";

            // 使用 Queryable<T> 方法执行 SQL 查询
            var result = DbScoped.Sugar.Ado.GetDataTable(sql);
            if (result != null && result.Rows.Count > 0)
            {
                // 假设查询结果的第一行第二列包含了数据库地址
                string databasePath = result.Rows[0][1].ToString();
            }
        }
    }
}
