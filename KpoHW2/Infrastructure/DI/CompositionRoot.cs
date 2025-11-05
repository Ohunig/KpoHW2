using KpoHW2.Application.Facades;
using KpoHW2.Application.Ports;
using KpoHW2.Infrastructure;
using KpoHW2.Infrastructure.Factories;
using KpoHW2.Infrastructure.Persistence;
using KpoHW2.Presentation;
using Microsoft.Extensions.DependencyInjection;

namespace KpoHW2;

public static class CompositionRoot
{
    private static IServiceProvider? _services;

    public static IServiceProvider Services => _services ??= CreateServiceProvider();
    
    private static IServiceProvider CreateServiceProvider()
    {
        var services = new ServiceCollection();

        services.AddTransient<IIdManager, StandartIdManager>();

        services.AddTransient<IAccountFactory, StandartBankAccountFactory>();
        services.AddTransient<ICategoryFactory, StandartCategoryFactory>();
        services.AddTransient<IOperationFactory, StandartOperationFactory>();

        services.AddSingleton<IBankAccountRepository, StandartBankAccountRepository>();
        services.AddSingleton<ICategoryRepository, StandartCategoryRepository>();
        services.AddSingleton<IOperationRepository, StandartOperationRepository>();

        services.AddSingleton<BankAccountFacade>();
        services.AddSingleton<CategoryFacade>();
        services.AddSingleton<OperationFacade>();

        services.AddTransient<IConsoleManager, StandardConsoleManager>();

        services.AddSingleton<NavigationController>();
        
        return services.BuildServiceProvider();
    }
}