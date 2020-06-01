using Microsoft.Extensions.DependencyInjection;
using SchoolOlympiads.ApplicationServices.GetOlympiadListUseCase;
using SchoolOlympiads.ApplicationServices.Ports.Cache;
using SchoolOlympiads.ApplicationServices.Repositories;
using SchoolOlympiads.DesktopClient.InfrastructureServices.ViewModels;
using SchoolOlympiads.DomainObjects;
using SchoolOlympiads.DomainObjects.Ports;
using SchoolOlympiads.InfrastructureServices.Cache;
using SchoolOlympiads.InfrastructureServices.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolOlympiads.DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDomainObjectsCache<Olympiad>, DomainObjectsMemoryCache<Olympiad>>();
            services.AddSingleton<NetworkOlympiadRepository>(
                x => new NetworkOlympiadRepository("localhost", 80, useTls: false, x.GetRequiredService<IDomainObjectsCache<Olympiad>>())
            );
            services.AddSingleton<CachedReadOnlyOlympiadRepository>(
                x => new CachedReadOnlyOlympiadRepository(
                    x.GetRequiredService<NetworkOlympiadRepository>(),
                    x.GetRequiredService<IDomainObjectsCache<Olympiad>>()
                )
            );
            services.AddSingleton<IReadOnlyOlympiadRepository>(x => x.GetRequiredService<CachedReadOnlyOlympiadRepository>());
            services.AddSingleton<IGetOlympiadListUseCase, GetOlympiadListUseCase>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs args)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
