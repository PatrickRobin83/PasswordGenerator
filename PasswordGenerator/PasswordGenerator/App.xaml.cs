﻿/*
 * -----------------------------------------------------------------------------
 *	 
 *   Filename		:   App.xaml.cs
 *   Date			:   2024-06-21
 *   All rights reserved
 * 
 * -----------------------------------------------------------------------------
 * @author Patrick Robin <support@rietrob.de>
 */

using CommunityToolkit.Mvvm.Messaging;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using System.Windows.Threading;

using PasswordGenerator.ViewModels;
using PasswordGenerator.Views;

namespace PasswordGenerator;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    [STAThread]
    private static void Main(string[] args)
    {
        MainAsync(args).GetAwaiter().GetResult();
    }

    private static async Task MainAsync(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();
        await host.StartAsync().ConfigureAwait(true);

        App app = new();
        app.InitializeComponent();
        app.MainWindow = host.Services.GetRequiredService<MainWindow>();
        app.MainWindow.Visibility = Visibility.Visible;
        app.Run();

        await host.StopAsync().ConfigureAwait(true);
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostBuilderContext, configurationBuilder)
                => configurationBuilder.AddUserSecrets(typeof(App).Assembly))
            .ConfigureServices((hostContext, services) =>
            {
                //Views
                services.AddSingleton<MainWindow>();

                // ViewModels
                services.AddScoped<BaseViewModel>();
                services.AddSingleton<MainWindowViewModel>();

                //Messenger
                services.AddSingleton<WeakReferenceMessenger>();
                services.AddSingleton<IMessenger, WeakReferenceMessenger>(provider =>
                    provider.GetRequiredService<WeakReferenceMessenger>());


                services.AddSingleton(_ => Current.Dispatcher);

                services.AddTransient<ISnackbarMessageQueue>(provider =>
                {
                    Dispatcher dispatcher = provider.GetRequiredService<Dispatcher>();
                    return new SnackbarMessageQueue(TimeSpan.FromSeconds(2.0), dispatcher);
                });

            });
}