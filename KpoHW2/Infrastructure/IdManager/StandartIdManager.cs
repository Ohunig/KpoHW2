namespace KpoHW2.Infrastructure;

public class StandartIdManager : IIdManager
{
    private int currentId = 0;

    public int getUniqueId()
    {
        return currentId++;
    }
}