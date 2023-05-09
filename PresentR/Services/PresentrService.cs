namespace PresentR.Components;

public abstract class PresentrService<TOption>
{
    protected List<(ComponentBase Key, Func<TOption, Task> Callback)> Cache { get; } = new();

    protected async Task Invoke(TOption option, ComponentBase? component = null)
    {
        var (Key, Callback) = component != null
            ? Cache.FirstOrDefault(k => k.Key == component)
            : Cache.FirstOrDefault();
        if (Callback == null)
        {
            throw new InvalidOperationException($"{GetType().Name} not registerd. refer doc https://www.blazor.zone/install-server step 7 for PresentrRoot");
        }
        await Callback.Invoke(option);
    }

    internal void Register(ComponentBase key, Func<TOption, Task> callback)
    {
        Cache.Add((key, callback));
    }

    internal void UnRegister(ComponentBase key)
    {
        var item = Cache.FirstOrDefault(i => i.Key == key);
        if (item.Key != null) Cache.Remove(item);
    }
}
