﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using Microsoft.Extensions.Localization;

namespace PresentR.Components;

/// <summary>
/// 
/// </summary>
public partial class LogoutLink
{
    [Inject]
    [NotNull]
    private IStringLocalizer<LogoutLink>? Localizer { get; set; }

    /// <summary>
    /// 获得/设置 图标
    /// </summary>
    [Parameter]
    public string? Icon { get; set; }

    /// <summary>
    /// 获得/设置 按钮文字
    /// </summary>
    [Parameter]
    [NotNull]
    public string? Text { get; set; }

    /// <summary>
    /// 获得/设置 按钮文字
    /// </summary>
    [Parameter]
    [NotNull]
    public string? Url { get; set; }

    [Inject]
    [NotNull]
    private IIconTheme? IconTheme { get; set; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        Text ??= Localizer[nameof(Text)];
        Icon ??= IconTheme.GetIconByKey(ComponentIcons.LogoutLinkIcon);

        Url ??= "/Account/Logout";
    }
}
