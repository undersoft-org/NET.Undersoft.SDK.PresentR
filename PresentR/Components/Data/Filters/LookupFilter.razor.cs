﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using Microsoft.Extensions.Localization;

namespace PresentR.Components;

/// <summary>
/// 枚举类型过滤组件
/// </summary>
public partial class LookupFilter
{
    private string? Value { get; set; }

    private List<SelectedItem> Items { get; } = new List<SelectedItem>();

    /// <summary>
    /// 获得/设置 相关枚举类型
    /// </summary>
#if NET6_0_OR_GREATER
    [EditorRequired]
#endif
    [Parameter]
    [NotNull]
    public IEnumerable<SelectedItem>? Lookup { get; set; }

    /// <summary>
    /// 获得/设置 字典数据源字符串比较规则 默认 StringComparison.OrdinalIgnoreCase 大小写不敏感 
    /// </summary>
    [Parameter]
    public StringComparison LookupStringComparison { get; set; } = StringComparison.OrdinalIgnoreCase;

    /// <summary>
    /// 获得/设置 相关枚举类型
    /// </summary>
#if NET6_0_OR_GREATER
    [EditorRequired]
#endif
    [Parameter]
    [NotNull]
    public Type? Type { get; set; }

    [Inject]
    [NotNull]
    private IStringLocalizer<TableFilter>? Localizer { get; set; }

    /// <summary>
    /// OnInitialized 方法
    /// </summary>
    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (Lookup == null)
        {
            throw new InvalidOperationException("the Parameter Lookup must be set.");
        }

        if (Type == null)
        {
            throw new InvalidOperationException("the Parameter Type must be set.");
        }

        if (TableFilter != null)
        {
            TableFilter.ShowMoreButton = false;
        }
        Items.Add(new SelectedItem("", Localizer["EnumFilter.AllText"].Value));
        Items.AddRange(Lookup);
    }

    /// <summary>
    /// 
    /// </summary>
    public override void Reset()
    {
        Value = "";
        StateHasChanged();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override IEnumerable<FilterKeyValueAction> GetFilterConditions()
    {
        var filters = new List<FilterKeyValueAction>();
        if (!string.IsNullOrEmpty(Value))
        {
            var type = Nullable.GetUnderlyingType(Type) ?? Type;
            var val = Convert.ChangeType(Value, type);
            filters.Add(new FilterKeyValueAction()
            {
                FieldKey = FieldKey,
                FieldValue = val,
                FilterAction = FilterAction.Equal
            });
        }
        return filters;
    }

    /// <summary>
    /// Override existing filter conditions
    /// </summary>
    public override async Task SetFilterConditionsAsync(IEnumerable<FilterKeyValueAction> conditions)
    {
        if (conditions.Any())
        {
            var type = Nullable.GetUnderlyingType(Type) ?? Type;
            FilterKeyValueAction first = conditions.First();
            if (first.FieldValue != null && first.FieldValue.GetType() == type)
            {
                Value = first.FieldValue.ToString();
            }
            else
            {
                Value = "";
            }
        }
        await base.SetFilterConditionsAsync(conditions);
    }
}
