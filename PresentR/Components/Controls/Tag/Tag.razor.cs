﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace PresentR.Components;

/// <summary>
/// Tag 组件类
/// </summary>
public partial class Tag
{
    /// <summary>
    /// 获得 样式集合
    /// </summary>
    /// <returns></returns>
    protected override string? ClassName => CssBuilder.Default("tag fade show")
        .AddClass($"alert-{Color.ToDescriptionString()}", Color != Color.None)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private async Task OnClick()
    {
        if (OnDismiss != null) await OnDismiss();
    }
}
