namespace KpoHW2.Application.Interactions.AccountsLogic.Commands.Interactions.AccountsLogic;

public static class AccountsModel
{
    /// <summary>
    /// Цикл выхода из ветки взаимодействия
    /// </summary>
    public static class EndAction
    {
        public struct Request;
        
        public struct Response;
    }
    
    /// <summary>
    /// Цикл получения команды
    /// </summary>
    public static class GettingCommand
    {
        public struct Request(int? option = null, int? id = null, string? name = null, int? balance = null)
        {
            public int? Option => option;
            public int? Id => id;
            public string? Name => name;
            public int? Balance => balance;
        }

        public struct Response(ICommand command)
        {
            public ICommand Command =>  command;
        }
        
        public struct ViewModel(ICommand command)
        {
            public ICommand Command =>  command;
        }
    }
}