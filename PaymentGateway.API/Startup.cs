using App.Metrics.Formatters.Prometheus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PaymentGateway.Application;
using PaymentGateway.Application.Interfaces;
using PaymentGateway.Application.Interfaces.Bank;
using PaymentGateway.Application.Managers;
using PaymentGateway.Application.Repositories;
using PaymentGateway.Banks.BankAPIClients;
using PaymentGateway.Banks.BankClients;
using PaymentGateway.Persistence.EFConfiguration;
using PaymentGateway.Persistence.Repository;

namespace PaymentGateway.API
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
            services.AddPersistence(Configuration);
            services.AddControllers();
            services.AddMvc(options =>
            {
                options.Filters.Add(new ValidationFilter());
            }).AddMetrics();

            services.AddMetricsTrackingMiddleware();
            services.AddMetricsEndpoints(m => m.MetricsEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter());

            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentService, PaymentService>();

            if (Configuration.GetValue<bool>("app:bank:mock"))
            {
                services.AddScoped<IBankClient, MockBank>();
            }
            else
            {
                services.AddScoped<IBankClient, RealBank>();
            }

            services.AddScoped<IEncryption, AESEncryption>();
            services.AddScoped(services => new AESEncryption.Options
            {
                Key = Configuration.GetValue<string>("app:encryption:key")
            });
            services.AddScoped<IMerchantRepository, MerchantRepository>();
            // Authentication to use IdentityServer
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:44335";
                    options.RequireHttpsMetadata = false;
                    options.Audience = "payment-gateway";
                });

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Payment-Gateway API",
                    Description = "Payment-Gateway ASP.NET Core Web API"
                });
            });
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
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PaymentGateway API V1");
            });

            app.UseMetricsAllMiddleware();
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
