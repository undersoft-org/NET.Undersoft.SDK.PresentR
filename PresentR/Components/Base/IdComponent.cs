using System.Diagnostics.CodeAnalysis;

namespace PresentR.Components;

public abstract class IdComponent : PresentrComponent
{
    [Parameter]
    [NotNull]
    public virtual string? Id { get; set; }

    [Inject]
    [NotNull]
    protected IComponentIdGenerator? ComponentIdGenerator { get; set; }

    protected virtual string? RetrieveId() => Id;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Id ??= ComponentIdGenerator.Generate(this);
    }
}
