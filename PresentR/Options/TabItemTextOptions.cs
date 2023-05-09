﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace PresentR.Components;

/// <summary>
/// 菜单与标签捆绑配置类
/// </summary>
internal class TabItemTextOptions
{
    /// <summary>
    /// 获得/设置 Tab 标签文本
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// 获得/设置 图标字符串
    /// </summary>
    public string? Icon { get; set; }

    /// <summary>
    /// 获得/设置 是否激活 默认为 true
    /// </summary>
    /// <value></value>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// 获得/设置 当前 TabItem 是否可关闭 默认为 true
    /// </summary>
    public bool Closable { get; set; } = true;

    /// <summary>
    /// 重置方法
    /// </summary>
    public void Reset()
    {
        Text = null;
        Icon = null;
        IsActive = true;
        Closable = true;
    }

    /// <summary>
    /// 是否可用方法
    /// </summary>
    /// <returns></returns>
    public bool Valid() => Text != null;
}
