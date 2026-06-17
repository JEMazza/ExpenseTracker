using Microsoft.Extensions.DependencyInjection;
using ExpenseServices.Data;
using ExpenseServices.Services;
using ExpenseTracker.Forms;
using ExpenseServices.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Microsoft.Extensions.Logging;

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
            Log.Logger = new LoggerConfiguration().MinimumLevel.Error().WriteTo.File(logPath, rollingInterval: RollingInterval.Day).CreateLogger();
            try {
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
                services.AddTransient<MainForm>();
                Services = services.BuildServiceProvider();
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

        static void StartDatabase() {
            using (var scope = Services.CreateScope()) {
                using (var context = scope.ServiceProvider.GetRequiredService<ExpenseContext>()) {
                    context.Database.Migrate();
                }
            }
        }

    }
}