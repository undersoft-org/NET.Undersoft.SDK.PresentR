namespace PresentR.Components;

public class DialogService : PresentrService<DialogOption>
{
    public Task Show(DialogOption option, Dialog? dialog = null) => Invoke(option, dialog);
}
