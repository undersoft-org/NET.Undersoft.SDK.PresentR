﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using System.ComponentModel;

namespace PresentR.Components;

/// <summary>
/// 
/// </summary>
public enum Placement
{
    /// <summary>
    /// 
    /// </summary>
    [Description("auto")]
    Auto,

    /// <summary>
    /// 
    /// </summary>
    [Description("top")]
    Top,

    /// <summary>
    /// 
    /// </summary>
    [Description("top-start")]
    TopStart,

    /// <summary>
    /// 
    /// </summary>
    [Description("top-center")]
    TopCenter,

    /// <summary>
    /// 
    /// </summary>
    [Description("top-end")]
    TopEnd,

    /// <summary>
    /// 
    /// </summary>
    [Description("middle")]
    Middle,

    /// <summary>
    /// 
    /// </summary>
    [Description("middel-start")]
    MiddleStart,

    /// <summary>
    /// 
    /// </summary>
    [Description("middel-center")]
    MiddleCenter,

    /// <summary>
    /// 
    /// </summary>
    [Description("middle-end")]
    MiddleEnd,

    /// <summary>
    /// 
    /// </summary>
    [Description("bottom")]
    Bottom,

    /// <summary>
    /// 
    /// </summary>
    [Description("bottom-start")]
    BottomStart,

    /// <summary>
    /// 
    /// </summary>
    [Description("bottom-center")]
    BottomCenter,

    /// <summary>
    /// 
    /// </summary>
    [Description("bottom-end")]
    BottomEnd,

    /// <summary>
    /// 
    /// </summary>
    [Description("left")]
    Left,

    /// <summary>
    /// 
    /// </summary>
    [Description("left-start")]
    LeftStart,

    /// <summary>
    /// 
    /// </summary>
    [Description("left-end")]
    LeftEnd,

    /// <summary>
    /// 
    /// </summary>
    [Description("right")]
    Right,

    /// <summary>
    /// 
    /// </summary>
    [Description("right-start")]
    RightStart,

    /// <summary>
    /// 
    /// </summary>
    [Description("right-end")]
    RightEnd,
}
