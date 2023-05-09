﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace PresentR.Components;

[ExcludeFromCodeCoverage]
internal class RouteContext
{
    public string[]? Segments { get; set; }

    public Type? Handler { get; set; }

    public IReadOnlyDictionary<string, object>? Parameters { get; set; }
}
