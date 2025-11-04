using KpoHW2;
using KpoHW2.Application.Facades;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = CompositionRoot.Services;

BankAccountFacade facade = serviceProvider.GetRequiredService<BankAccountFacade>();

facade.CreateNewAccount("biba");
facade.ChangeAccount(facade.IdList[0], "aboba");
Console.WriteLine(facade.GetAccount(facade.IdList[0]).Name);
Console.WriteLine(facade.GetAccount(facade.IdList[0]).Balance);
