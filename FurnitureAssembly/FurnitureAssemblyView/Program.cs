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
using FurnitureAssemblyContracts.DI;

namespace FurnitureAssemblyView
{
    internal static class Program
    {
        /// The main entry point for the application.
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font;
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var services = new ServiceCollection();
            InitDependency();

            try
            {
                var mailSender = DependencyManager.Instance.Resolve<AbstractMailWorker>();
                mailSender?.MailConfig(new MailConfigBindingModel
                {
                    MailLogin = System.Configuration.ConfigurationManager.AppSettings["MailLogin"] ?? string.Empty,
                    MailPassword = System.Configuration.ConfigurationManager.AppSettings["MailPassword"] ?? string.Empty,
                    SmtpClientHost = System.Configuration.ConfigurationManager.AppSettings["SmtpClientHost"] ?? string.Empty,
                    SmtpClientPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SmtpClientPort"]),
                    PopHost = System.Configuration.ConfigurationManager.AppSettings["PopHost"] ?? string.Empty,
                    PopPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PopPort"])
                });

                // Создание таймера
                var timer = new System.Threading.Timer(new TimerCallback(MailCheck!), null, 0, 100000);
            }
            catch (Exception ex)
            {
                var logger = DependencyManager.Instance.Resolve<ILogger>();

                logger?.LogError(ex, "Ошибка работы с почтой");
            }

            Application.Run(DependencyManager.Instance.Resolve<FormMain>());
        }

        private static void InitDependency()
        {
            DependencyManager.InitDependency();

            DependencyManager.Instance.AddLogging(option =>
            {
                option.SetMinimumLevel(LogLevel.Information);
                option.AddNLog("nlog.config");
            });

            DependencyManager.Instance.RegisterType<FormMain>();

            DependencyManager.Instance.RegisterType<FormWorkPiece>();
            DependencyManager.Instance.RegisterType<FormWorkPieces>();
            DependencyManager.Instance.RegisterType<FormCreateOrder>();

            DependencyManager.Instance.RegisterType<FormFurniture>();
            DependencyManager.Instance.RegisterType<FormFurnitures>();
            DependencyManager.Instance.RegisterType<FormFurnitureWorkPiece>();

            DependencyManager.Instance.RegisterType<FormReportOrders>();
            DependencyManager.Instance.RegisterType<FormReportFurnitureWorkPieces>();
            DependencyManager.Instance.RegisterType<FormReportGroupedOrders>();
            DependencyManager.Instance.RegisterType<FormReportShopFurnitures>();

            DependencyManager.Instance.RegisterType<FormShop>();
            DependencyManager.Instance.RegisterType<FormShops>();
            DependencyManager.Instance.RegisterType<FormSellFurniture>();

            DependencyManager.Instance.RegisterType<FormClients>();
            DependencyManager.Instance.RegisterType<FormImplementer>();
            DependencyManager.Instance.RegisterType<FormImplementers>();

            DependencyManager.Instance.RegisterType<FormMails>();
            DependencyManager.Instance.RegisterType<FormAnswerMail>();
            DependencyManager.Instance.RegisterType<FormMails>();
        }

        private static void MailCheck(object obj) => DependencyManager.Instance.Resolve<AbstractMailWorker>()?.MailCheck();
    }
}