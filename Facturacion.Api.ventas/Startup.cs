using Facturacion.Api.ventas.Aplicacion;
using Facturacion.Api.ventas.Persitencia;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Facturacion.Api.ventas
{
    public class Startup
    {
        private readonly IConfiguration Configuracion;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Facturacion Api ",
                    Description = "Gestiona una lista de compras",
                });
            });

            // Registra MediatR y configura su assembly
            services.AddMediatR(typeof(AgregarCliente.NuevoCliente).Assembly);
            services.AddMediatR(typeof(AgregarProductos.NuevoProducto).Assembly);
            services.AddMediatR(typeof(CrearFactura.NuevaFactura).Assembly);

            services.AddControllers().AddFluentValidation(cfg
                 => cfg.RegisterValidatorsFromAssemblyContaining<AgregarCliente>()); 

            services.AddDbContext<FacturaContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ConexionDatabase"));
            });

            //mapper
            services.AddAutoMapper(typeof(mostrarProdAgregado.ConsultarListado));
            services.AddAutoMapper(typeof(eliminarItemProduco.QuitarProducto));





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1"));
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
