using System.Diagnostics.CodeAnalysis;

namespace PresentR.Components;

public abstract class PresentrComponent : ComponentBase, IHandleEvent
{
    [Parameter(CaptureUnmatchedValues = true)]
    public IDictionary<string, object>? AdditionalAttributes { get; set; }

    [CascadingParameter]
    protected IErrorLogger? ErrorLogger { get; set; }

    [Inject]
    protected IJSRuntime? JSRuntime { get; set; }

    protected bool IsNotRender { get; set; }

    [ExcludeFromCodeCoverage]
    private async Task CallStateHasChangedOnAsyncCompletion(Task task)
    {
        try
        {
            await task;
        }
        catch (Exception ex)        
        {
            if (task.IsCanceled)
            {
                return;
            }

            if (ErrorLogger != null)
            {
                IsNotRender = true;
                await ErrorLogger.HandlerExceptionAsync(ex);
            }
            else
            {
                throw;
            }
        }

        if (!IsNotRender)
        {
            StateHasChanged();
        }
        else
        {
            IsNotRender = false;
        }
    }

    Task IHandleEvent.HandleEventAsync(EventCallbackWorkItem callback, object? arg)
    {
        var task = callback.InvokeAsync(arg);
        var shouldAwaitTask = task.Status != TaskStatus.RanToCompletion &&
            task.Status != TaskStatus.Canceled;

        if (!IsNotRender)
        {
            StateHasChanged();
        }
        else
        {
            IsNotRender = false;
        }

        return shouldAwaitTask ?
            CallStateHasChangedOnAsyncCompletion(task) :
            Task.CompletedTask;
    }
}
