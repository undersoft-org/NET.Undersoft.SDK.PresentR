﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace PresentR.Components;

/// <summary>
/// Select 组件基类
/// </summary>
public abstract class SingleSelectBase<TValue> : SelectBase<TValue>
{
    /// <summary>
    /// 当前选择项实例
    /// </summary>
    protected SelectedItem? SelectedItem { get; set; }

    /// <summary>
    /// 获得/设置 Swal 图标 默认 Question
    /// </summary>
    [Parameter]
    public SwalCategory SwalCategory { get; set; } = SwalCategory.Question;

    /// <summary>
    /// 获得/设置 Swal 标题 默认 null
    /// </summary>
    [Parameter]
    public string? SwalTitle { get; set; }

    /// <summary>
    /// 获得/设置 Swal 内容 默认 null
    /// </summary>
    [Parameter]
    public string? SwalContent { get; set; }

    /// <summary>
    /// 获得/设置 Footer 默认 null
    /// </summary>
    [Parameter]
    public string? SwalFooter { get; set; }

    /// <summary>
    /// 获得/设置 下拉框项目改变前回调委托方法 返回 true 时选项值改变，否则选项值不变
    /// </summary>
    [Parameter]
    public Func<SelectedItem, Task<bool>>? OnBeforeSelectedItemChange { get; set; }

    /// <summary>
    /// SelectedItemChanged 回调方法
    /// </summary>
    [Parameter]
    public Func<SelectedItem, Task>? OnSelectedItemChanged { get; set; }
}
