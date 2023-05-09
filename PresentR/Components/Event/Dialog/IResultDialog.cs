﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace PresentR.Components;

/// <summary>
/// 
/// </summary>
public interface IResultDialog
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<bool> OnClosing(DialogResult result) => Task.FromResult(true);

    /// <summary>
    /// 
    /// </summary>
    Task OnClose(DialogResult result);
}
