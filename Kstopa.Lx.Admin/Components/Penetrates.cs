using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Kstopa.Lx.Admin.Components
{
    internal static class Penetrates
    {
        /// <summary>
        /// 创建组件依赖链表
        /// </summary>
        /// <returns></returns>
        internal static List<ComponentContext> CreateDependLinkList(
            Type componentType,
            object options = default
        )
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

        //internal static void CreateDependLinkList(Type componentType, ref List<Type> dependLinkList, ref List<ComponentContext> componentContextLinkList)
        //{
        //    // 获取 [DependsOn] 特性
        //    var dependsOnAttribute = componentType.GetCustomAttribute<DependsOnAttribute>(true);

        //    // 获取依赖组件列表
        //    var dependComponents = dependsOnAttribute?.DependComponents?.Distinct()?.ToArray() ?? Array.Empty<Type>();

        //    // 获取链接组件列表
        //    var linkComponents = dependsOnAttribute?.LinkComponents?.Distinct()?.ToArray() ?? Array.Empty<Type>();

        //    // 检查自引用
        //    if (dependComponents.Contains(componentType) || linkComponents.Contains(componentType))
        //    {
        //        throw new InvalidOperationException("A component cannot reference itself.");
        //    }

        //    // 找出当前组件的序号
        //    var index = dependLinkList.IndexOf(componentType);

        //    // 获取根组件上下文并设置依赖
        //    var rootComponentContext = componentContextLinkList.First(u => u.IsRoot);

        //    // 设置当前组件依赖
        //    var calledContext = index > -1 ? componentContextLinkList[index] : rootComponentContext;
        //    calledContext.DependComponents = dependComponents;
        //    calledContext.LinkComponents = linkComponents;

        //    // 处理链接组件
        //    if (index == -1)
        //    {
        //        index = dependLinkList.Count;

        //        // 将链接的依赖的组件插入链表指定位置中
        //        dependLinkList.Add(componentType);

        //        // 记录组件上下文调用链
        //        componentContextLinkList.Add(new ComponentContext
        //        {
        //            CalledContext = calledContext,
        //            RootContext = rootComponentContext,
        //            ComponentType = componentType,
        //            DependComponents = dependComponents,
        //            LinkComponents = linkComponents
        //        });
        //    }

        //    // 遍历当前组件依赖的组件集合
        //    foreach (var dependComponent in dependComponents)
        //    {
        //        // 如果还未插入组件链，则插入
        //        if (!dependLinkList.Contains(dependComponent))
        //        {
        //            // 将被依赖的组件插入链表指定位置中
        //            dependLinkList.Insert(index, dependComponent);

        //            // 记录组件上下文调用链
        //            componentContextLinkList.Insert(index, new ComponentContext
        //            {
        //                CalledContext = calledContext,
        //                RootContext = rootComponentContext,
        //                ComponentType = dependComponent,
        //                DependComponents = dependComponents,
        //                LinkComponents = linkComponents
        //            });

        //            // 递增序号
        //            index++;
        //        }
        //        // 处理组件循环引用情况
        //        else
        //        {
        //            if (dependLinkList.IndexOf(dependComponent) > index)
        //            {
        //                throw new InvalidOperationException("There is a circular reference problem between components.");
        //            }
        //        }

        //        // 进行下一层依赖递归链查找
        //        CreateDependLinkList(dependComponent, ref dependLinkList, ref componentContextLinkList);
        //    }

        //    if (linkComponents == null || linkComponents.Length == 0) return;

        //    // 遍历链接组件
        //    foreach (var linkComponent in linkComponents)
        //    {
        //        // 不能链接根节点
        //        if (linkComponent == rootComponentContext.ComponentType)
        //        {
        //            throw new InvalidOperationException("There is a circular reference problem between components.");
        //        }

        //        CreateDependLinkList(linkComponent, ref dependLinkList, ref componentContextLinkList);
        //    }
        //}
    }
}
