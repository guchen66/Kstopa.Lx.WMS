﻿using Kstopa.Lx.Admin.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kstopa.Lx.Admin.Providers
{
    internal class ManualDependProvider
    {
        internal static List<ComponentContext> CreateDependLinkList(Type componentType, object options = default)
        {
            // 根组件上下文
            var rootComponentContext = new ComponentContext
            {
                ComponentType = componentType,
                IsRoot = true
            };
            rootComponentContext.SetProperty(componentType, options);

            // 初始化组件依赖链
            var dependLinkList = new List<Type> { componentType };
            var componentContextLinkList = new List<ComponentContext> { rootComponentContext };

            // 创建组件依赖链
            //  CreateDependLinkList(componentType, ref dependLinkList, ref componentContextLinkList);

            return componentContextLinkList;
        }
    }

    internal class AutoDependProvider
    {
        internal static List<ComponentContext> CreateDependLinkList(Type componentType, object options = default)
        {
            // 根组件上下文
            var rootComponentContext = new ComponentContext
            {
                ComponentType = componentType,
                IsRoot = true
            };
            rootComponentContext.SetProperty(componentType, options);

            // 初始化组件依赖链
            var dependLinkList = new List<Type> { componentType };
            var componentContextLinkList = new List<ComponentContext> { rootComponentContext };

            // 创建组件依赖链
            //  CreateDependLinkList(componentType, ref dependLinkList, ref componentContextLinkList);

            return componentContextLinkList;
        }
    }
}
