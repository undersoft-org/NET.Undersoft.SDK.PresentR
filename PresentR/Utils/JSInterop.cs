﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace PresentR.Components;

/// <summary>
/// JSInterop 类
/// </summary>
public class JSInterop<TValue> : IDisposable where TValue : class
{
    private IJSRuntime JSRuntime { get; }

    private DotNetObjectReference<TValue>? _objRef;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="jsRuntime"></param>
    public JSInterop(IJSRuntime jsRuntime)
    {
        JSRuntime = jsRuntime;
    }

    /// <summary>
    /// Invoke 方法
    /// </summary>
    /// <param name="identifier"></param>
    /// <param name="value"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public async ValueTask InvokeVoidAsync(string identifier, TValue value, params object?[]? args)
    {
        _objRef = DotNetObjectReference.Create(value);
#if NET5_0
        var paras = new List<object>()
        {
            _objRef
        };
#else
        var paras = new List<object?>()
        {
            _objRef
        };
#endif
        if (args != null)
        {
            paras.AddRange(args!);
        }
        await JSRuntime.InvokeVoidAsync(identifier: identifier, paras.ToArray());
    }

    /// <summary>
    /// Invoke 方法
    /// </summary>
    /// <param name="value"></param>
    /// <param name="el"></param>
    /// <param name="func"></param>
    /// <param name="args"></param>
    public async ValueTask InvokeVoidAsync(TValue value, object? el, string func, params object[] args)
    {
        _objRef = DotNetObjectReference.Create(value);
        var paras = new List<object>()
        {
            _objRef
        };
        paras.AddRange(args);
        await JSRuntime.InvokeVoidAsync(el, func, paras.ToArray());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    internal ValueTask<bool> GetGeolocationItemAsync(TValue value, string callbackMethodName)
    {
        _objRef = DotNetObjectReference.Create(value);
        return JSRuntime.InvokeAsync<bool>("$.bb_geo_getCurrnetPosition", _objRef, callbackMethodName);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    internal ValueTask<long> GetWatchPositionItemAsync(TValue value, string callbackMethodName)
    {
        _objRef = DotNetObjectReference.Create(value);
        return JSRuntime.InvokeAsync<long>("$.bb_geo_watchPosition", _objRef, callbackMethodName);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    internal ValueTask<bool> SetClearWatchPositionAsync(long watchid)
    {
        return JSRuntime.InvokeAsync<bool>("$.bb_geo_clearWatchLocation", watchid);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    internal ValueTask CheckNotifyPermissionAsync(TValue value, string? callbackMethodName = null, bool requestPermission = true)
    {
        _objRef = DotNetObjectReference.Create(value);
        return JSRuntime.InvokeVoidAsync("$.bb_notify_checkPermission", _objRef, callbackMethodName ?? "", requestPermission);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    internal ValueTask<bool> Dispatch(TValue value, NotificationItem model, string? callbackMethodName = null)
    {
        _objRef = DotNetObjectReference.Create(value);
        return JSRuntime.InvokeAsync<bool>("$.bb_notify_display", _objRef, callbackMethodName, model);
    }

    /// <summary>
    /// Dispose 方法
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_objRef != null)
            {
                _objRef.Dispose();
                _objRef = null;
            }
        }
    }

    /// <summary>
    /// Dispose 方法
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
