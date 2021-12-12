using System.Security.Claims;
using Autofac;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Petify.Api.Infrastructure;
using Petify.Common.Auth;
using Petify.Common.Auth.Access;
using Petify.Common.Configuration;
using Petify.FilesStorage.Context;
using Serilog;

namespace Petify.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddHttpContextAccessor();

            ConfigureAuth(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var serilog = new LoggerConfiguration()
                  .MinimumLevel.Verbose()
                  .Enrich.FromLogContext()
                  .WriteTo.File(@"api_log.txt");

            loggerFactory.WithFilter(new FilterLoggerSettings
            {
                {"Microsoft", LogLevel.Warning},
                {"System", LogLevel.Warning}
            }).AddSerilog(serilog.CreateLogger());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseApiSecurityHttpHeaders();
            app.UseBlockingContentSecurityPolicyHttpHeader();
            app.RemoveServerHeader();
            app.UseNoCacheHttpHeaders();
            app.UseStrictTransportSecurityHttpHeader(env);
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(b => b.WithOrigins(Configuration["AppConfig:ClientUrl"]).AllowAnyHeader().AllowAnyMethod());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        public virtual void ConfigureAuth(IServiceCollection services)
        {
            services
                .AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = Configuration["AppConfig:IdentityUrl"];
                    options.RequireHttpsMetadata = true;
                    options.ApiName = Instances.PetifyApi;
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.ApiReader, policy => policy.RequireClaim("scope", Scopes.PetifyApi));
                options.AddPolicy(Policies.Consumer, policy => policy.RequireClaim(ClaimTypes.Role, Roles.Consumer));
            });

            services.AddMvcCore(options =>
            {
                options.Filters.Add(new AuthorizeFilter(Policies.ApiReader));
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DefaultModule(Configuration.GetConnectionString("Petify"), GetMongoSettings()));

            builder.RegisterType<RequireAccessLevelHandler>()
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();

            builder.RegisterType<AuthorizationPolicyProvider>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }

        private MongoDbSettings GetMongoSettings()
        {
            return new MongoDbSettings()
            {
                ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value,
                Database = Configuration.GetSection("MongoConnection:Database").Value
            };
        }
    }
}
