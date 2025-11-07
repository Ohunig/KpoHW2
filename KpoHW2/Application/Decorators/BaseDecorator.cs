public abstract class BaseDecorator(ICommand wrappee) : ICommand
{
    private ICommand wrappee = wrappee;
    
    public virtual string Execute()
    {
        return wrappee.Execute();
    }
}