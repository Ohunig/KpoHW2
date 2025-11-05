using KpoHW2.Application.Interactions.MainScreen;
using KpoHW2.Application.Ports;

namespace KpoHW2.Presentation;

/// <summary>
/// Абстрактный вью контроллер
/// </summary>
public abstract class ViewController
{
    protected IConsoleManager consoleManager;

    public ViewController(IConsoleManager consoleManager)
    {
        this.consoleManager = consoleManager;
    }
    
    /// <summary>
    /// Выполняется при завершении загрузки экрана
    /// </summary>
    public virtual void ViewDidLoad()
    {
        Console.Clear();
    }

    /// <summary>
    /// Обработка действий пользователя
    /// </summary>
    public abstract void HandleUserAction();
}