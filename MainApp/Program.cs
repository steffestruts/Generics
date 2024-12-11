using MainApp.Data;
using MainApp.Dialogs;
using MainApp.Models;
using MainApp.Services;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<DataContext<Product>>()
    .AddSingleton<DataContext<User>>()
    .AddScoped<ProductService>()
    .AddScoped<UserService>()
    .AddTransient<MenuDialog>()
    .BuildServiceProvider();

var menuDialog = serviceProvider.GetRequiredService<MenuDialog>();

menuDialog.MenuOptionsDialog();
