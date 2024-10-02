using Ark.Infra.Core.Services.Impl;
using Ark.Infra.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Ark.Infra.Core.NG.Services;
using Ark.Infra.Core.NG.Services.Impl;

namespace Ark.Infra.Core
{
    public class ArkCore
    {
        public string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public static IConfiguration _configuration { get; private set; }

        public ArkCore(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IServiceCollection ArkCoreDependencies(IServiceCollection services)
        {

            SetConnectionConfiguration(services, _configuration);
            AddDependenciesRepository(services);
            AddDepensenciesService(services);
            AddDepencenciesMappers(services);
            AddDepencenciesSecurity(services);

            return services;
        }

        private string GetConnectionString(IConfiguration configuration, string connectionName)
        {
            var connectionString = configuration.GetConnectionString(connectionName);
            return connectionString;
        }

        private void SetConnectionConfiguration(IServiceCollection services, IConfiguration configuration)
        {

        }

        private void AddDependenciesRepository(IServiceCollection services)
        {

        }

        private void AddDepensenciesService(IServiceCollection services)
        {
            //
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // NG
            services.AddTransient<ILogRegisterNGService, LogRegisterServiceNGImpl>();
            services.AddTransient<ICadastroPessoaNGService, CadastroPessoaNGServiceImpl>();
            services.AddTransient<IExportacaoService, ExportacaoServiceImpl>();
            services.AddTransient<ICadastroMovimentoNGService, CadastroMovimentoNGServiceImpl>();
            // ARK
            services.AddTransient<IEmailSenderService, EmailSenderServiceImpl>();
            services.AddTransient<IARKFilialService, ARKFilialServiceImpl>();
            services.AddTransient<ILogRegisterService, LogRegisterServiceImpl>();
            services.AddTransient<IMovimentoService, MovimentoServiceImpl>();

        }

        private void AddDepencenciesMappers(IServiceCollection services)
        {
            // Auto Mapper Configurations
            //var mapperConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new RegistroAppProfile());

            //});
            //IMapper mapper = mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);
        }

        private void AddDepencenciesSecurity(IServiceCollection services)
        {
            //string[] urls = { Environment.GetEnvironmentVariable("ENV_POLICE_URL1"),
            //                Environment.GetEnvironmentVariable("ENV_POLICE_URL2"),
            //                Environment.GetEnvironmentVariable("ENV_POLICE_URL3")};

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: MyAllowSpecificOrigins,
            //                      policy =>
            //                      {
            //                          policy.WithOrigins(urls)
            //                          .AllowAnyHeader()
            //                          .AllowAnyMethod()
            //                          .AllowCredentials();
            //                      });
            //});
        }
    }
}