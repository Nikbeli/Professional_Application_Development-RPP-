using FurnitureAssemblyBusinessLogic.BussinessLogic;
using FurnitureAssemblyContracts.BusinessLogicsContracts;
using FurnitureAssemblyContracts.StoragesContracts;
using FurnitureAssemblyDatabaseImplement.Implements;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace FurnitureAssemblyView
{
    internal static class Program
    {
        private static ServiceProvider? _serviceProvider;

        public static ServiceProvider? ServiceProvider => _serviceProvider;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font;
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
            Application.Run(_serviceProvider.GetRequiredService<FormMain>());
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(option =>
            {
                option.SetMinimumLevel(LogLevel.Information);
                option.AddNLog("nlog.config");
            });

            services.AddTransient<IWorkPieceStorage, WorkPieceStorage>();
            services.AddTransient<IOrderStorage, OrderStorage>();
            services.AddTransient<IFurnitureStorage, FurnitureStorage>();

            services.AddTransient<IWorkPieceLogic, WorkPieceLogic>();
            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<IFurnitureLogic, FurnitureLogic>();

            services.AddTransient<FormMain>();
            services.AddTransient<FormWorkPiece>();
            services.AddTransient<FormWorkPieces>();
            services.AddTransient<FormCreateOrder>();
            services.AddTransient<FormFurniture>();
            services.AddTransient<FormFurnitures>();
            services.AddTransient<FormFurnitureWorkPiece>();
        }
    }
}