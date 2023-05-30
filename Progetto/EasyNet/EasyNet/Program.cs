using EasyNet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using EasyNet.DataAccess.Repository.IRepository;
using EasyNet.DataAccess.Repository;
using Microsoft.AspNetCore.Identity.UI.Services;
using Easy.Utility;
namespace EasyNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.Configure<EmailSenderoptions>(builder.Configuration.GetSection("EmailSender"));
            //per impostare la verifica dell'account prima di poter effettuare il login
            //occorre inserire come argomento del metodo AddDefaultIdentity l'espressione
            //options => options.SignIn.RequireConfirmedAccount = true
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddDefaultTokenProviders()
      .AddEntityFrameworkStores<AppDbContext>().AddDefaultUI();


            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDbContext>();
            //builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            //UnitOfWork si occupa della gestione di tutti i repository
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<IEmailSender, EmailSender>();
            //serve per gestire i casi in cui l'utente prova ad accedere a funzioni che richiedono autenticazione e/o autorizzazione
            //https://learn.microsoft.com/en-us/answers/questions/963681/asp-net-mvc-how-unauthorize-access-redirect-user-t
            builder.Services.ConfigureApplicationCookie(options =>
            {

                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.LogoutPath = "/Identity/Account/Logout";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
            builder.Services.AddTransient<IEmailSender, EmailSender>();
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
            //middleware for Authentication
            //l'autenticazione deve sempre precedere l'autorizzazione
            app.UseAuthentication();

            app.UseAuthorization();
            app.MapRazorPages();


            app.MapControllerRoute(
                name: "default",
                pattern: "{area=User}/{controller=Home}/{action=Index}/{id?}");



            app.Run();
        }
    }
}