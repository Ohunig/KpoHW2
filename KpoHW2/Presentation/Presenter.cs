namespace KpoHW2.Presentation;

/// <summary>
/// Абстрактный презентер (+ координатор)
/// </summary>
public abstract class Presenter
{
    /// <summary>
    /// Так как в архитектуре SVIP подразумевается объединение
    /// презентера и координатора, храним navigationController
    /// </summary>
    private NavigationController navigationController;

    public Presenter(NavigationController navigationController)
    {
        this.navigationController = navigationController;
    }
}