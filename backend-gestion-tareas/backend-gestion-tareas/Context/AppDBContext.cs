using back_gestion_tareas.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace back_gestion_tareas.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Tarea> Tareas { get; set; }
    }

}
