using Microsoft.Extensions.DependencyInjection;
using ExpenseServices.Data;
using ExpenseServices.Services;
using ExpenseTracker.Forms;
using ExpenseServices.Entities;
using Microsoft.EntityFrameworkCore;
namespace ExpenseTracker {
    internal static class Program{

        public static IServiceProvider Services;
        [STAThread]
        static void Main(){
            var services = new ServiceCollection();
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

        static void StartDatabase() {
            using (var scope = Services.CreateScope()) {
                using (var context = scope.ServiceProvider.GetRequiredService<ExpenseContext>()) {
                    context.Database.Migrate();
                }
            }
        }

    }
}