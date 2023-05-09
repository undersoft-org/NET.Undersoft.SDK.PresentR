﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace PresentR.Components;

/// <summary>
/// Step 组件项类
/// </summary>
[ExcludeFromCodeCoverage]
public class StepItem
{
    /// <summary>
    /// 获得/设置 步骤显示文字
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// 获得/设置 步骤显示图标
    /// </summary>
    public string? Icon { get; set; }

    /// <summary>
    /// 获得/设置 步骤显示图标
    /// </summary>
    public string? ErrorIcon { get; set; }

    /// <summary>
    /// 获得/设置 步骤状态
    /// </summary>
    public StepStatus Status { get; set; }

    /// <summary>
    /// 获得/设置 描述信息
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// 获得/设置 每个 step 的间距不填写将自适应间距支持百分比
    /// </summary>
    public string? Space { get; set; }

    /// <summary>
    /// 获得/设置 每个 step 的模板
    /// </summary>
    public RenderFragment? Template { get; set; }
}
