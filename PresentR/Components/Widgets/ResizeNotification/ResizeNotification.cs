﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace PresentR.Components;

/// <summary>
/// 网页尺寸变化通知组件
/// </summary>
[JSModuleAutoLoader("./_content/BootstrapBlazor/modules/responsive.js", JSObjectReference = true, Relative = false)]
public class ResizeNotification : PresentrModule
{
    [Inject]
    [NotNull]
    private ResizeNotificationService? ResizeService { get; set; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns></returns>
    protected override Task InvokeInitAsync() => InvokeVoidAsync("init", Id, Interop, nameof(OnResize));

    /// <summary>
    /// JSInvoke 回调方法
    /// </summary>
    /// <param name="point"></param>
    /// <returns></returns>
    [JSInvokable]
    public Task OnResize(BreakPoint point) => ResizeService.InvokeAsync(point);
}
