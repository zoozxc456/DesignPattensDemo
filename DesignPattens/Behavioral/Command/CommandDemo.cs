namespace DesignPattens.Behavioral.Command;

public interface IUiComponentAction
{
    void Submit();
    void Cancel();
}

public interface ICommand
{
    void Execute();
}

public class SaveCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Saving...");
        Console.WriteLine("Saved...");
    }
}

public class CancelCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Canceling...");
        Console.WriteLine("Canceled...");
    }
}

public class ButtonActions(ICommand saveCommand, ICommand cancelCommand) : IUiComponentAction
{
    public void Submit()
    {
        saveCommand.Execute();
    }

    public void Cancel()
    {
        cancelCommand.Execute();
    }
}

public class Button(IUiComponentAction actions)
{
    public void OnSubmitEvent() => actions.Submit();
    public void OnCancelEvent() => actions.Cancel();
}

public static class CommandDemo
{
    public static void Main()
    {
        var actions = new ButtonActions(new SaveCommand(), new CancelCommand());
        var button = new Button(actions);

        button.OnSubmitEvent();
        button.OnCancelEvent();
    }
}