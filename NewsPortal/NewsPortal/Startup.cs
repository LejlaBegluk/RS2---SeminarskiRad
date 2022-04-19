using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewsPortal.Services;
using Microsoft.EntityFrameworkCore;
using NewsPortal.WebAPI.Services;
using Microsoft.AspNetCore.Authentication;
using NewsPortal.WebAPI.Security;
using NewsPortal.WebAPI.Database;
using NewsPortal.WebAPI.Model;
using NewsPortal.Model.Request;

namespace NewsPortal
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
            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.ToString());
            });
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICRUDService<MCategory, CategorySearchRequest, CategoryUpsertRequest, CategoryUpsertRequest>, CategoryService>();
           // services.AddScoped<IBaseService, BaseService>();
            services.AddScoped<ICRUDService<MPoll, PollSearchRequest, PollUpsertRequest, PollUpsertRequest>, PollService>();
            services.AddScoped<ICRUDService<MPollAnswer, PollAnswerSearchRequest, PollAnswerUpsertRequest, PollAnswerUpsertRequest>, PollAnswerService>();
            services.AddScoped<ICRUDService<MComment, CommentSearchRequest, CommentUpsertRequest, CommentUpsertRequest>, CommentService>();
            services.AddScoped<ICRUDService<MUser, UserSearchRequest, UserUpsertRequest, UserUpsertRequest>, UserService>();
            services.AddScoped<ICRUDService<MUserRole, UserRoleSearchRequest, UserRoleUpsertRequest, UserRoleUpsertRequest>, UserRoleService>();
            services.AddScoped<ICRUDService<MRole, RoleSearchRequest, RoleUpsertRequest, RoleUpsertRequest>, RoleService>();
            services.AddScoped<ICRUDService<MArticle, ArticleSearchRequest, ArticleUpsertRequest, ArticleUpsertRequest>, ArticleService>();


            services.AddDbContext<PortalDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(IUserService));
            services.AddScoped<IUserService, UserService>();

            services.AddAuthentication("BasicAuthentication")
            .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
