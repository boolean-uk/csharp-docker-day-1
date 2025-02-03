using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public static class DatabaseInitializer
    {
        public async static Task<WebApplication> Seed(this WebApplication app)
        {
            
            using (var scope = app.Services.CreateScope())
            {

                using var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                try
                {
                    
                    context.Database.EnsureCreated();

                    if (!context.Offices.Any())
                    {
                        context.Offices.AddRange(
                            new List<Office>()
                            {
                                new Office(){ Location = "New York" },
                                new Office(){ Location = "London" },
                                new Office(){ Location = "Tokyo" },
                            }
                        );

                    }
                    PeopleData peopleData = new PeopleData();
                    if (!context.People.Any())
                    {
                        context.People.AddRange(peopleData.People);
                        
                    }
                    if(!context.Courses.Any())
                    {
                        CourseData courseData = new CourseData();
                        context.Courses.AddRange(courseData.Courses);
                        
                    }
                    if(!context.CoursePerson.Any())
                    {
                        context.CoursePerson.AddRange(
                            new List<CoursePerson>()
                            {
                                new CoursePerson(){ CourseId=1, PersonId=1 },
                                new CoursePerson(){ CourseId=1, PersonId=2 },
                                new CoursePerson(){ CourseId=1, PersonId=3 },
                                new CoursePerson(){ CourseId=2, PersonId=4 },
                                new CoursePerson(){ CourseId=2, PersonId=5 },

                            }
                        );
                    }
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            return app;

        }
    }
}
