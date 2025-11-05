namespace KpoHW2.Application.Ports;

/// <summary>
/// Определяет функционал для взаимодействия с пользователем через консоль
/// </summary>
public interface IConsoleManager
{
    /// <summary>
    /// Вывод сообщения в консоль
    /// </summary>
    /// <param name="message">Текст сообщения</param>
    public void Print(String message);
    
    /// <summary>
    /// Вывод сообщения об ошибке в консоль
    /// </summary>
    /// <param name="errorMessage">Текст ошибки</param>
    public void PrintError(String errorMessage);

    /// <summary>
    /// Выводит сообщение в консоль и получает от пользователя строку
    /// </summary>
    /// <param name="message">Текст сообщения</param>
    /// <returns>Введённая пользователем строка или null</returns>
    public String? GetStringResponse(String message);
    
    /// <summary>
    /// Выводит сообщение в консоль и получает от пользователя число
    /// </summary>
    /// <param name="message">Текст сообщения</param>
    /// <returns>Введённое пользователем число или null</returns>
    public int? GetIntResponse(String message);

    /// <summary>
    /// Ожидает нажатия клавиши пользователем
    /// </summary>
    public void WaitButtonPress();
}