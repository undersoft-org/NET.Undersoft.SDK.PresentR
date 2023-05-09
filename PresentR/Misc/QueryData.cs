﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace PresentR.Components;

/// <summary>
/// 表格查询数据类
/// </summary>
/// <typeparam name="TItem"></typeparam>
public class QueryData<TItem>
{
    /// <summary>
    /// 获得/设置 要显示页码的数据集合
    /// </summary>
    public IEnumerable<TItem>? Items { get; set; }

    /// <summary>
    /// 获得/设置 数据集合总数
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// 获得/设置 数据是否被过滤 默认为 false 未被过滤
    /// </summary>
    /// <remarks>组件内部通过此属性判断，如果外部未进行数据过滤，内部将进行数据过滤操作</remarks>
    public bool IsFiltered { get; set; }

    /// <summary>
    /// 获得/设置 数据是否被排序 默认为 false 未被排序
    /// </summary>
    public bool IsSorted { get; set; }

    /// <summary>
    /// 获得/设置 数据是否已处理 SearcText <see cref="Table{TItem}.SearchText"/> 默认为 false
    /// </summary>
    /// <remarks>设置本属性为 true 时，Table 组件的高级搜索按钮改变颜色</remarks>
    public bool IsSearch { get; set; }

    /// <summary>
    /// 获得/设置 数据是否为已处理自定义高级搜索 <see cref="Table{TItem}.CustomerSearchTemplate"/> 默认为 false
    /// </summary>
    /// <remarks>设置本属性为 true 时，Table 组件的高级搜索按钮改变颜色</remarks>
    public bool IsAdvanceSearch { get; set; }
}
