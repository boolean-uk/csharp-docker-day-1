using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public static class MigrationRunner
    {
        public static void ApplyProjectMigrations(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                db.Database.Migrate();
            }

            /*
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            using DataContext db = scope.ServiceProvider.GetService<DataContext>();
            db.Database.Migrate();
            */

        }
    }
}
