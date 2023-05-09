﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace PresentR.Components;

internal class ReconnectorProvider : IReconnectorProvider
{
    private Action<RenderFragment?, RenderFragment?, RenderFragment?>? _action;

    public void NotifyContentChanged(IReconnector reconnector)
    {
        _action?.Invoke(reconnector.ReconnectingTemplate, reconnector.ReconnectFailedTemplate, reconnector.ReconnectRejectedTemplate);
    }

    public void Register(Action<RenderFragment?, RenderFragment?, RenderFragment?> action) => _action = action;
}
