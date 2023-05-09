namespace PresentR.Components;

public class ToastService : PresentrService<ToastOption>
{
    private PresentrOptions Options { get; }

    public ToastService(IOptionsMonitor<PresentrOptions> options)
    {
        Options = options.CurrentValue;
    }

    public async Task Show(ToastOption option, ToastContainer? ToastContainer = null)
    {
        if (!option.ForceDelay && Options.ToastDelay != 0)
        {
            option.Delay = Options.ToastDelay;
        }
        await Invoke(option, ToastContainer);
    }
}
