﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using System.ComponentModel;

namespace PresentR.Components;

/// <summary>
/// Size 枚举类型
/// </summary>
public enum Size
{
    /// <summary>
    /// 无设置
    /// </summary>
    None,

    /// <summary>
    /// xs 超小设置小于 576px
    /// </summary>
    [Description("xs")]
    ExtraSmall,

    /// <summary>
    /// sm 小设置大于等于 576px
    /// </summary>
    [Description("sm")]
    Small,

    /// <summary>
    /// md 中等设置大于等于 768px
    /// </summary>
    [Description("md")]
    Medium,

    /// <summary>
    /// lg 大设置大于等于 992px
    /// </summary>
    [Description("lg")]
    Large,

    /// <summary>
    /// xl 超大设置大于等于 1200px
    /// </summary>
    [Description("xl")]
    ExtraLarge,

    /// <summary>
    /// xl 超大设置大于等于 1400px
    /// </summary>
    [Description("xxl")]
    ExtraExtraLarge
}
