using KpoHW2;
using KpoHW2.Presentation;
using KpoHW2.Presentation.MainScreen;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = CompositionRoot.Services;

NavigationController controller = serviceProvider.GetRequiredService<NavigationController>();
controller.Push(MainScreenBuilder.Build());
