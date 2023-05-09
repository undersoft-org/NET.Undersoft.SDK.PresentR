﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace PresentR.Components;

/// <summary>
/// 
/// </summary>
public class MessageService : PresentrService<MessageOption>
{
    private PresentrOptions Options { get; }

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="option"></param>
    public MessageService(IOptionsMonitor<PresentrOptions> option)
    {
        Options = option.CurrentValue;
    }

    /// <summary>
    /// Show 方法
    /// </summary>
    /// <param name="option"></param>
    /// <param name="message">指定弹窗组件 默认为 null 使用 <see cref="PresentrRoot"/> 组件内置弹窗组件</param>
    public async Task Show(MessageOption option, Message? message = null)
    {
        if (!option.ForceDelay)
        {
            if (Options.MessageDelay != 0)
            {
                option.Delay = Options.MessageDelay;
            }
        }
        await Invoke(option, message);
    }
}
