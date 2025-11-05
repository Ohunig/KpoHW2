using KpoHW2.Application.Ports;

/// <summary>
/// Стандартный консольный менеджер
/// </summary>
public class StandardConsoleManager : IConsoleManager
{
    /// <summary>
    /// Вывод сообщения в консоль
    /// </summary>
    /// <param name="message">Сообщение</param>
    public void Print(String message)
    {
        Console.WriteLine(message);
    }

    /// <summary>
    /// Вывод ошибки в консоль
    /// </summary>
    /// <param name="errorMessage">Сообщение ошибки</param>
    public void PrintError(String errorMessage)
    {
        Console.WriteLine(errorMessage);
    }

    /// <summary>
    /// Выводит сообщение в консоль и получает от пользователя строку
    /// </summary>
    /// <param name="message">Текст сообщения</param>
    /// <returns>Введённая пользователем строка или null</returns>
    public String? GetStringResponse(String message = "")
    {
        Console.Write(message);
        return Console.ReadLine();
    }

    /// <summary>
    /// Выводит сообщение в консоль и получает от пользователя число
    /// </summary>
    /// <param name="message">Текст сообщения</param>
    /// <returns>Введённое пользователем число или null</returns>
    public int? GetIntResponse(String message = "")
    {
        Console.Write(message);
        String? input = Console.ReadLine();
        if (input is null) return null;
        try
        {
            return int.Parse(input);
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// Ожидает нажатия клавиши пользователем
    /// </summary>
    public void WaitButtonPress()
    {
        Console.Write("Press Enter to continue...");
        Console.ReadLine();
    }
}