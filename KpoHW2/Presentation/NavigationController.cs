namespace KpoHW2.Presentation;

/// <summary>
/// Контролирует открытые экраны
/// </summary>
public class NavigationController
{
    private class Constants
    {
        public static readonly string PopError = "Can not pop current screen";
    }

    /// <summary>
    /// Стек контроллеров
    /// </summary>
    private Stack<ViewController> controllersStack = new Stack<ViewController>();

    /// <summary>
    /// Добавление нового экрана
    /// </summary>
    /// <param name="viewController">Контроллер нового экрана</param>
    public void Push(ViewController viewController)
    {
        controllersStack.Push(viewController);
        controllersStack.Peek().ViewDidLoad();
    }

    /// <summary>
    /// Удаление последнего экрана со стека
    /// </summary>
    /// <exception cref="Exception">При пустом стеке, или если остаётся только один экран</exception>
    public void Pop()
    {
        if (controllersStack.Count < 2) throw new Exception("Can not pop current screen");
        controllersStack.Pop();
        controllersStack.Peek().ViewDidLoad();
    }

    /// <summary>
    /// Оставляет только один начальный экран на стеке
    /// </summary>
    public void ToStart()
    {
        while (controllersStack.Count > 1) controllersStack.Pop();
        controllersStack.Peek().ViewDidLoad();
    }
}