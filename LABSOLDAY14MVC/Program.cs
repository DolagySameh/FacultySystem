using LABSOLDAY14MVC.Models;

namespace LABSOLDAY14MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();


            app.MapControllerRoute(
                name: "AddD",
               pattern: "/AddDepartment",
               defaults: new { controller = "Department", action = "NewDepartment" });

            app.MapControllerRoute(
                name: "AddI",
                pattern: "/AddInstructor",
                defaults: new { controller = "Instructor", action = "NewInst" });
            app.MapControllerRoute(
                 name: "AddC",
                 pattern: "/AddCourse",
                 defaults: new { controller = "Course", action = "NewCrs" });
            app.MapControllerRoute(
                 name: "AddT",
                 pattern: "/AddTrainee",
                 defaults: new { controller = "Trainee", action = "NewTrainee" });

            app.MapControllerRoute(
                name: "dept",
                pattern: "/Department",
                defaults: new { controller = "Department", action = "getAllDepartments" });

            app.MapControllerRoute(
                name: "inst",
                pattern: "/Instructor",
                defaults: new { controller = "Instructor", action = "getAllInstructor" });
            app.MapControllerRoute(
                 name: "Crs",
                 pattern: "/Course",
                 defaults: new { controller = "Course", action = "GetAllCourses" });
            app.MapControllerRoute(
                 name: "Trn",
                 pattern: "/Trainee",
                 defaults: new { controller = "Trainee", action = "GetAllTrainees" });



           


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
