﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace PresentR.Components;

/// <summary>
/// LinkButton 组件
/// </summary>
public partial class LinkButton
{
    /// <summary>
    /// 获得/设置 Url 默认为 #
    /// </summary>
    [Parameter]
    public string? Url { get; set; }

    /// <summary>
    /// 获得/设置 A 标签 target 参数 默认 null
    /// </summary>
    [Parameter]
    public string? Target { get; set; }

    /// <summary>
    /// 获得/设置 显示图片地址 默认为 null
    /// </summary>
    [Parameter]
    public string? ImageUrl { get; set; }

    /// <summary>
    /// The css class of img element defualt value null
    /// </summary>
    [Parameter]
    public string? ImageCss { get; set; }

    /// <summary>
    /// 获得/设置 是否为垂直布局 默认 false
    /// </summary>
    [Parameter]
    public bool IsVertical { get; set; }

    private bool Prevent => (Url?.StartsWith('#') ?? true) || IsDisabled;

    private string TagName => IsDisabled ? "button" : "a";

    private string? UrlString => IsDisabled ? null : Url;

    private string? ClassString => CssBuilder.Default("btn link-button")
        .AddClass("btn-vertical", IsVertical)
        .AddClass($"btn-outline-{Color.ToDescriptionString()}", IsOutline)
        .AddClass($"link-{Color.ToDescriptionString()}", Color != Color.None && !IsOutline && !IsDisabled)
        .AddClass($"btn-{Size.ToDescriptionString()}", Size != Size.None)
        .AddClass("btn-block", IsBlock)
        .AddClass("btn-round", ButtonStyle == ButtonStyle.Round)
        .AddClass("btn-circle", ButtonStyle == ButtonStyle.Circle)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private bool TriggerClick => !IsDisabled || (string.IsNullOrEmpty(Url));

    private async Task OnClickButton()
    {
        if (OnClickWithoutRender != null)
        {
            await OnClickWithoutRender();
        }
        if (OnClick.HasDelegate)
        {
            await OnClick.InvokeAsync();
        }
    }
}
