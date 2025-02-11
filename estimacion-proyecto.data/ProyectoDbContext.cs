using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using estimacion_proyecto.domain.Dto;

namespace estimacion_proyecto.data
{
    public class ProyectoDbContext : DbContext
    {
        public ProyectoDbContext(DbContextOptions<ProyectoDbContext> options) : base(options) { }

        public DbSet<UsuarioDto> Usuarios { get; set; }
        public DbSet<RolDto> Roles { get; set; }
        public DbSet<EntidadDto> Entidades { get; set; }

        public DbSet<ProyectoDto> Proyectos { get; set; }

        public DbSet<ModuloDto> Modulos { get; set; }

        public DbSet<HistoriaUsuarioDto> HistoriasUsuario { get; set; }
        public DbSet<ActividadDto> Actividades { get; set; }
        public DbSet<ProyectoNavegadorDto> ProyectoNavegadores { get; set; }


        
        public class YourDbContextFactory : IDesignTimeDbContextFactory<ProyectoDbContext>
        {
            public ProyectoDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ProyectoDbContext>();
                optionsBuilder.UseSqlServer("Data Source= sql.bsite.net\\MSSQL2016;Initial Catalog=victorcuellar2025_;User ID=victorcuellar2025_;Password=gerEdit!.$;TrustServerCertificate=True;");

                return new ProyectoDbContext(optionsBuilder.Options);
            }
        }

    }
}
