using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using casomira.BL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using casomira.BL.Repositories.Interfaces;
using casomira.BL.Services;
using casomira.BL.Services.Interfaces;
using casomira.DAL.Factories;
using casomira.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace casomira.APP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("cs");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("cs");

            _host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(ConfigureAppConfiguration)
                .ConfigureServices((context, services) => { ConfigureServices(context.Configuration, services); })
                .Build();
        }
        private static void ConfigureAppConfiguration(HostBuilderContext context, IConfigurationBuilder builder)
        {
            builder.AddJsonFile(@"AppSettings.json", false, true);
        }

        private static void ConfigureServices(IConfiguration configuration,
            IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();

            services.AddSingleton<IPersonRepository, PersonRepository>();
            services.AddSingleton<ITeamRepository, TeamRepository>();

            //services.AddSingleton<IMessageDialogService, MessageDialogService>();
            services.AddSingleton<IMediator, Mediator>();

           /* services.AddSingleton<MainViewModel>();
            services.AddSingleton<IPersonListViewModel, PersonListViewModel>();
            services.AddFactory<IPersonDetailViewModel, PersonDetailViewModel>();
            services.AddSingleton<IFilmListViewModel, FilmListViewModel>();
            services.AddFactory<IFilmDetailViewModel, FilmDetailViewModel>();
            services.AddFactory<IPersonRoleDetailViewModel, PersonRoleDetailViewModel>();
           */
            services.AddSingleton<IDbContextFactory>(provider => new SqlServerDbContextFactory(configuration.GetConnectionString("DefaultConnection")));

        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            var dbContextFactory = _host.Services.GetRequiredService<IDbContextFactory>();


            await using (var dbx = dbContextFactory.CreateDbContext())
            {
                await dbx.Database.MigrateAsync();
            }

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }

            base.OnExit(e);
        }
    }
}
