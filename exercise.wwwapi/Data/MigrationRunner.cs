using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public static class MigrationRunner
    {
        public static void ApplyProjectMigrations(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                DataContext db = scope.ServiceProvider.GetRequiredService<DataContext>();

                db.Database.Migrate();
            }
        }
    }
}
