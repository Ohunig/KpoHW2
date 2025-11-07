using KpoHW2.Application.Interactions.AccountsLogic.Commands;
using KpoHW2.Domain.Category;

namespace KpoHW2.Application.Interactions.CategoriesLogic.Commands.Interactions.CategoriesLogic;

public static class CategoriesModel
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
        public struct Request(int? option = null, int? id = null, string? name = null, CategoryType? categoryType = null)
        {
            public int? Option => option;
            public int? Id => id;
            public string? Name => name;
            public CategoryType? CategoryType => categoryType;
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