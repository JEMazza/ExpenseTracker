using Microsoft.Extensions.DependencyInjection;
using ExpenseServices.Data;
using ExpenseServices.Services;
using ExpenseTracker.Forms;
using ExpenseServices.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Configuration;

namespace ExpenseTracker {
    internal static class Program{

        public static IServiceProvider Services;
        
        [STAThread]
        static void Main(){            
            string logPath = "ExpenseTracker-.log";
            #if DEBUG
                logPath = "logs/"+logPath;
            #else
                logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),logPath);
            #endif
            Log.Logger = new LoggerConfiguration().MinimumLevel.Warning().WriteTo.File(logPath, rollingInterval: RollingInterval.Day).CreateLogger();
            try {
                ValidateConfig();
                var services = new ServiceCollection();
                services.AddLogging(logger => {
                    logger.ClearProviders();
                    logger.AddSerilog(dispose: true);
                });
                services.AddDbContext<ExpenseContext>();
                services.AddScoped<ExpensesUnitOfWork>();
                services.AddScoped<ExpenseService>();
                services.AddScoped<ExpenseTypeService>();
                services.AddScoped<ExpensePlaceService>();
                services.AddScoped<ReportService>();
                services.AddTransient<ExpenseDataForm>();
                services.AddTransient<ExpenseListForm>();
                services.AddTransient<ExpenseReportForm>();
                services.AddTransient<SettingsForm>();
                services.AddTransient<MainForm>();
                Services = services.BuildServiceProvider();
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(ConfigurationManager.AppSettings["Language"]);
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(ConfigurationManager.AppSettings["Language"]);
                ApplicationConfiguration.Initialize();
                StartDatabase();
                Application.Run(Services.GetRequiredService<MainForm>());
            }
            catch (Exception ex) {
                Log.Fatal(ex,"APPLICATION COULD NOT START. PLEASE, CONTACT THE DEVELOPER.");
                MessageBox.Show(Resources.MessagesResource.ExpenseMessageException, Resources.MessagesResource.ExpenseMessageBoxTitleError, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally {
                Log.CloseAndFlush();
            }
        }

        static void ValidateConfig() {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            bool reset=false;
            string? language = ConfigurationManager.AppSettings["Language"];
            string[] validLangs = ["en", "es"];
            if(language == null) {
                Log.Logger.Warning("Language missing.");
                config.AppSettings.Settings.Add("Language", "en");
                reset = true;
            }else if(!validLangs.Contains(language)) {
                Log.Logger.Warning("Unkown language. Default to english.");
                config.AppSettings.Settings["Language"].Value = "en";
                reset = true;
            }
            int pageSize;
            if (ConfigurationManager.AppSettings["PageSize"] == null) {
                Log.Logger.Warning("Page size missing.");
                config.AppSettings.Settings.Add("PageSize", "25");
                reset = true;
            }else if (!int.TryParse(ConfigurationManager.AppSettings["PageSize"], out pageSize)) {
                Log.Logger.Warning("Unknown page size.");
                config.AppSettings.Settings["PageSize"].Value = "25";
                reset = true;
            }else if (pageSize < 1) {
                Log.Logger.Warning("Page size lower than 1.");
                config.AppSettings.Settings["PageSize"].Value = "25";
                reset = true;
            }
            if (reset) {
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        static void StartDatabase() {
            using (var scope = Services.CreateScope()) {
                using (var context = scope.ServiceProvider.GetRequiredService<ExpenseContext>()) {
                    context.Database.Migrate();
                }
            }
        }

    }
}