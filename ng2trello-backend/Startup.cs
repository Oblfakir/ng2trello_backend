using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ng2trello_backend.Database.Contexts;
using ng2trello_backend.Database.Interfaces;
using ng2trello_backend.Database.Repositories;
using ng2trello_backend.Services.Implementations;
using ng2trello_backend.Services.Interfaces;

namespace ng2trello_backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.RequireHttpsMetadata = false;
                  options.TokenValidationParameters = AuthOptions.GetValidationParameters();
              });

            services.AddAuthorization(opts => {
                opts.AddPolicy("admin", policy => {
                    policy.RequireClaim(ClaimsIdentity.DefaultRoleClaimType, "admin");
                });
                opts.AddPolicy("user", policy => {
                    policy.RequireClaim(ClaimsIdentity.DefaultRoleClaimType, "user");
                });
                opts.AddPolicy("registered", policy =>
                {
                    policy.RequireAssertion(context =>
                    {
                        return context.User.HasClaim(c => c.Value == "admin" || c.Value == "user");
                    });
                });
            });
            services.AddDbContext<UserContext>(SqliteConfiguration);
            services.AddDbContext<CardContext>(SqliteConfiguration);
            services.AddDbContext<BoardContext>(SqliteConfiguration);
            services.AddDbContext<TodolistContext>(SqliteConfiguration);
            services.AddDbContext<CardActionContext>(SqliteConfiguration);
            services.AddDbContext<ContentContext>(SqliteConfiguration);
            services.AddDbContext<CommentContext>(SqliteConfiguration);
            services.AddDbContext<ColumnContext>(SqliteConfiguration);
            services.AddDbContext<TeamContext>(SqliteConfiguration);

            services.AddScoped<ITodolistRepository, TodolistRepository>();
            services.AddScoped<ITodolistService, TodolistService>();
            services.AddScoped<ITodoService, TodoService>();

            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ICardRepository, CardRepository>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IBoardService, BoardService>();
            services.AddScoped<IBoardRepository, BoardRepository>();

            services.AddScoped<IContentService, ContentService>();
            services.AddScoped<IContentRepository, ContentRepository>();

            services.AddScoped<ICardActionService, CardActionService>();
            services.AddScoped<ICardActionRepository, CardActionRepository>();

            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            services.AddScoped<IColumnService, ColumnService>();
            services.AddScoped<IColumnRepository, ColumnRepository>();

            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<ITeamRepository, TeamRepository>();

            services.AddCors();
            services.AddMvc();
        }

        private void SqliteConfiguration(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration["Production:SqliteConnectionString"]);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
