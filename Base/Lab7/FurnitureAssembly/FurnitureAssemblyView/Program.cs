using FurnitureAssemblyBusinessLogic.BussinessLogic;
using FurnitureAssemblyBusinessLogic.OfficePackage.Implements;
using FurnitureAssemblyBusinessLogic.OfficePackage;
using FurnitureAssemblyContracts.BusinessLogicsContracts;
using FurnitureAssemblyContracts.StoragesContracts;
using FurnitureAssemblyDatabaseImplement.Implements;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using FurnitureAssemblyBusinessLogic.MailWorker;
using FurnitureAssemblyContracts.BindingModels;

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

            try
            {
                var mailSender = _serviceProvider.GetService<AbstractMailWorker>();
                    mailSender?.MailConfig(new MailConfigBindingModel
                    {
                        MailLogin = System.Configuration.ConfigurationManager.AppSettings["MailLogin"] ?? string.Empty,
                        MailPassword = System.Configuration.ConfigurationManager.AppSettings["MailPassword"] ?? string.Empty,
                        SmtpClientHost = System.Configuration.ConfigurationManager.AppSettings["SmtpClientHost"] ?? string.Empty,
                        SmtpClientPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SmtpClientPort"]),
                        PopHost = System.Configuration.ConfigurationManager.AppSettings["PopHost"] ?? string.Empty,
                        PopPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PopPort"])
                    });

                // Создаём таймер
                var timer = new System.Threading.Timer(new TimerCallback(MailCheck!), null, 0, 100000);
            }
            catch (Exception ex)
            {
                var logger = _serviceProvider.GetService<ILogger>();

                logger?.LogError(ex, "Ошибка работы с почтой");
            }

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
            services.AddTransient<IClientStorage, ClientStorage>();
            services.AddTransient<IImplementerStorage, ImplementerStorage>();
            services.AddTransient<IMessageInfoStorage, MessageInfoStorage>();

            services.AddTransient<IWorkPieceLogic, WorkPieceLogic>();
            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<IFurnitureLogic, FurnitureLogic>();
            services.AddTransient<IReportLogic, ReportLogic>();
            services.AddTransient<IClientLogic, ClientLogic>();
            services.AddTransient<IImplementerLogic, ImplementerLogic>();
            services.AddTransient<IMessageInfoLogic, MessageInfoLogic>();
            
            services.AddTransient<IWorkProcess, WorkModeling>();
            services.AddSingleton<AbstractMailWorker, MailKitWorker>();

            services.AddTransient<AbstractSaveToExcel, SaveToExcel>();
            services.AddTransient<AbstractSaveToWord, SaveToWord>();
            services.AddTransient<AbstractSaveToPdf, SaveToPdf>();

            services.AddTransient<FormMain>();
            services.AddTransient<FormWorkPiece>();
            services.AddTransient<FormWorkPieces>();
            services.AddTransient<FormCreateOrder>();
            services.AddTransient<FormFurniture>();
            services.AddTransient<FormFurnitures>();
            services.AddTransient<FormFurnitureWorkPiece>(); 
            services.AddTransient<FormReportFurnitureWorkPieces>();
            services.AddTransient<FormReportOrders>();
            services.AddTransient<FormClients>();
            services.AddTransient<FormImplementers>();
            services.AddTransient<FormImplementer>();
            services.AddTransient<FormMails>();
        }

        private static void MailCheck(object obj) => ServiceProvider?.GetService<AbstractMailWorker>()?.MailCheck();
    }
}