﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using System.ComponentModel;
using System.Reflection;

namespace PresentR.Components;

/// <summary>
/// 枚举类型扩展方法
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// 获取 DescriptionAttribute 标签方法
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static string ToDescriptionString<TEnum>(this TEnum val) where TEnum : Enum => typeof(TEnum).ToDescriptionString(val.ToString());

    /// <summary>
    /// 通过字段名称获取 DescriptionAttribute 标签值
    /// </summary>
    /// <param name="type"></param>
    /// <param name="fieldName"></param>
    /// <returns></returns>
    public static string ToDescriptionString(this Type? type, string? fieldName)
    {
        var ret = string.Empty;
        if (type != null && !string.IsNullOrEmpty(fieldName))
        {
            var t = Nullable.GetUnderlyingType(type) ?? type;
            var attributes = t.GetField(fieldName)?.GetCustomAttribute<DescriptionAttribute>(true);
            ret = attributes?.Description ?? fieldName;
        }
        return ret;
    }

    /// <summary>
    /// 通过字段名称获取 DisplayAttribute/DescriptionAttribute 标签值
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="enum"></param>
    /// <returns></returns>
    public static string ToDisplayName<TEnum>(this TEnum @enum) where TEnum : Enum => Utility.GetDisplayName(typeof(TEnum), @enum.ToString());

    /// <summary>
    /// 获取指定枚举类型的枚举值集合，默认通过 DisplayAttribute DescriptionAttribute 标签显示 DisplayName 支持资源文件 回退机制显示字段名称
    /// </summary>
    /// <param name="type"></param>
    /// <param name="addtionalItem"></param>
    /// <returns></returns>
    public static List<SelectedItem> ToSelectList(this Type type, SelectedItem? addtionalItem = null)
    {
        var ret = new List<SelectedItem>();
        if (addtionalItem != null)
        {
            ret.Add(addtionalItem);
        }

        if (type.IsEnum())
        {
            var t = Nullable.GetUnderlyingType(type) ?? type;
            foreach (var field in Enum.GetNames(t))
            {
                var desc = Utility.GetDisplayName(t, field);
                ret.Add(new SelectedItem(field, desc));
            }
        }
        return ret;
    }

    /// <summary>
    /// 判断类型是否为枚举类型
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static bool IsEnum(this Type? type)
    {
        var ret = false;
        if (type != null)
        {
            var t = Nullable.GetUnderlyingType(type) ?? type;
            ret = t.IsEnum;
        }
        return ret;
    }
}
