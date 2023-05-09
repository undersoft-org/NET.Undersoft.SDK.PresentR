using System.ComponentModel;

namespace PresentR.Components;

public enum TableRenderMode
{
    [Description("自动")]
    Auto,

    [Description("表格布局")]
    Table,

    [Description("卡片布局")]
    CardView
}
