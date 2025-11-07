using KpoHW2.Domain.Operation;

namespace KpoHW2.Application.Interactions.OperationsLogic.Commands.Interactions.OperationsLogic;

public static class OperationsModel
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
        public struct Request(
            int? option = null,
            int? id = null,
            OperationType? type = null,
            int? bankAccountId = null,
            int? categoryId = null,
            int? amount = null,
            string? description = null)
        {
            public int? Option => option;
            public int? Id => id;
            public OperationType? Type => type;
            public int? BankAccountId => bankAccountId;
            public int? CategoryId => categoryId;
            public int? Amount => amount;
            public string? Description => description;
        }

        public struct Response(ICommand command)
        {
            public ICommand Command => command;
        }

        public struct ViewModel(ICommand command)
        {
            public ICommand Command => command;
        }
    }
}