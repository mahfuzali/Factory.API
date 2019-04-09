using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Factory.API.Contexts;
using Factory.API.Services;
using Factory.API.Services.Interface;
using Factory.API.Services.Repository;

namespace Factory.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var connectionString = Configuration["ConnectionStrings:StoreConnections"];
            services.AddDbContext<CustomersContext>(o => o.UseSqlServer(connectionString));
            services.AddDbContext<SuppliersContext>(o => o.UseSqlServer(connectionString));
            services.AddDbContext<ProductsContext>(o => o.UseSqlServer(connectionString));
            services.AddDbContext<OrdersContext>(o => o.UseSqlServer(connectionString));
            services.AddDbContext<OrderItemsContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<ISuppliersRepository, SuppliersRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();

            /*
            var config = new AutoMapper.MapperConfiguration(c =>
               c.AddProfile(new OrdersProfile())
            );

            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);
            */

            services.AddAutoMapper();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
