namespace KpoHW2.Application.Interactions.MainScreen;

public static class MainModel
{
    public static class NextScreen
    {
        public struct Request(int index)
        {
            public int Index => index;
        }

        public enum Response
        {
            AccountsSelected,
            CategoriesSelected,
            OperationsSelected
        }
    }
}