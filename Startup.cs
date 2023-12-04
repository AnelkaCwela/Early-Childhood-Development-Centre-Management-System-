using Algorithm_3rd_Year_Project.Models;
using Algorithm_3rd_Year_Project.Models.DataModel;
using Algorithm_3rd_Year_Project.Models.Interface;
using Algorithm_3rd_Year_Project.Models.Resptory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm_3rd_Year_Project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DBCONTEX>(options => options.UseSqlServer(Configuration["ELDC:ConnectionString"]));
            services.AddIdentity<UserModel, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
               options.SignIn.RequireConfirmedEmail = false;
            })
                .AddEntityFrameworkStores<DBCONTEX>()
                .AddDefaultTokenProviders();               
            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                   .RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddXmlDataContractSerializerFormatters();
            services.AddTransient<ITeacher, TeacherResp>();
            services.AddTransient<ITask, TaskResp>();
            services.AddTransient<ISuburb, SuburbResp>();
            services.AddTransient<IPrograme, ProgrameResp>();
            services.AddTransient<IGander, GanderResp>();
            services.AddTransient<IRegion, RegionResp>();
            services.AddTransient<IPupil, PupilResp>();
            services.AddTransient<IStatus, StatusResp>();
            services.AddTransient<ICoodinator, CoodinatorResp>();
            services.AddTransient<IProvince, ProvinceResp>();
            services.AddTransient<IParent, ParentResp>();
            services.AddTransient<ILiaison, LiaisonResp>();
            services.AddTransient<IEnrole, EnroleResp>();
            services.AddTransient<ICentreSerViceType, CentreSerViceTypeResp>();
            services.AddTransient<ICentreService, CentreServiceResp>();
            services.AddTransient<ICentre, CentreResp>();
            services.AddTransient<ICentreProgram, CentreProgramResp>();
            services.AddTransient<ICentreManage, CentreManageResp>();
            services.AddTransient<IAttendance, AttendanceResp>();
            services.AddTransient<IQualification, QualificationResp>();
            services.AddTransient<IProvince, ProvinceResp>();
            services.AddTransient<IMarks, MarksResp>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
