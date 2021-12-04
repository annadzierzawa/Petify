using System;
using System.Data;
using System.Reflection;
using Autofac;
using EnsureThat;
using Microsoft.EntityFrameworkCore;
using Petify.Api.Controllers;
using Petify.ApplicationServices.UseCases.Users;
using Petify.Common.Auth;
using Petify.Domain.Services;
using Petify.FilesStorage.Context;
using Petify.FilesStorage.Repositories.PetImages;
using Petify.Infrastructure.DataModel.Context;
using Petify.Infrastructure.Domain;
using Petify.Infrastructure.Factories;
using Petify.Infrastructure.Queries;
using SRW_CRM.Infrastructure.QueryBuilder;
using Module = Autofac.Module;

namespace Petify.Api.Infrastructure
{
    public class DefaultModule : Module
    {
        private readonly string _connectionString;
        private readonly MongoDbSettings _mongoDbSettings;

        public DefaultModule(string connectionString, MongoDbSettings mongoDbSettings)
        {
            Ensure.String.IsNotNullOrWhiteSpace(connectionString, nameof(connectionString));

            _connectionString = connectionString;
            _mongoDbSettings = mongoDbSettings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<QueryDispatcher>().AsImplementedInterfaces();
            builder.RegisterType<CommandDispatcher>().AsImplementedInterfaces();

            RegisterContext(builder);
            RegisterDatabaseAccess(builder);
            RegisterServices(builder);
            RegisterControllers(builder);
            RegisterUseCases(builder);
            RegisterQueries(builder);
            RegisterRepositories(builder);
            RegisterMongoDBServices(builder);
        }

        private static void RegisterTransientDependenciesAutomatically(
             ContainerBuilder builder,
             Assembly assembly,
             string nameSpace)
        {
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => !string.IsNullOrEmpty(t.Namespace) && t.Namespace.StartsWith(nameSpace, StringComparison.InvariantCulture))
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerDependency();
        }

        private void RegisterContext(ContainerBuilder builder)
        {
            var options = new DbContextOptionsBuilder<PetifyContext>();
            options.UseSqlServer(_connectionString);

            builder.Register(container => new PetifyContext(options.Options, container.Resolve<ICurrentUserService>())).InstancePerLifetimeScope();
        }

        private void RegisterDatabaseAccess(ContainerBuilder builder)
        {
            builder
                .RegisterType<SqlQueryBuilder>()
                .InstancePerDependency();

            builder.Register(ctx => new DbConnectionFactory(_connectionString))
                .Named<DbConnectionFactory>(nameof(DbConnectionFactory))
                .InstancePerDependency();

            builder.Register<Func<DbConnectionFactory>>(c =>
            {
                var cc = c.Resolve<IComponentContext>();
                return () => cc.ResolveNamed<DbConnectionFactory>(nameof(DbConnectionFactory));
            });
        }

        private void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<CurrentUserService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<AdvertisementDatesService>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }

        private static void RegisterControllers(ContainerBuilder builder)
        {
            RegisterTransientDependenciesAutomatically(
                builder,
                typeof(UsersController).Assembly,
                "Petify.Api.Controllers");
        }

        private static void RegisterUseCases(ContainerBuilder builder)
        {
            RegisterTransientDependenciesAutomatically(
                builder,
                typeof(InitUserUseCase).Assembly,
                "Petify.ApplicationServices.UseCases");
        }

        private static void RegisterQueries(ContainerBuilder builder)
        {
            RegisterTransientDependenciesAutomatically(
                builder,
                typeof(PetsQuery).Assembly,
                "Petify.Infrastructure.Queries");
        }

        private void RegisterRepositories(ContainerBuilder builder)
        {
            RegisterTransientDependenciesAutomatically(
                builder,
                typeof(UsersRepository).Assembly,
                "Petify.Infrastructure.Domain");

            RegisterTransientDependenciesAutomatically(
               builder,
               typeof(PetImagesMongoRepository).Assembly,
               "Petify.FilesStorage.Repositories");
        }

        private void RegisterMongoDBServices(ContainerBuilder builder)
        {
            builder.Register(ctx => new MongoDbContext(_mongoDbSettings)).InstancePerLifetimeScope();
        }
    }
}
