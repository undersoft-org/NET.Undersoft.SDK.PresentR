﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace PresentR.Components;

/// <summary>
/// ISpeechService 服务接口定义
/// </summary>
public interface IRecognizerProvider
{
    /// <summary>
    /// 识别语音回调方法
    /// </summary>
    /// <returns></returns>
    Task InvokeAsync(RecognizerOption option);
}
