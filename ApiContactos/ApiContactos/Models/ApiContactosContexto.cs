using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApiContactos.Models
{
    public class ApiContactosContexto : DbContext
    {
        public ApiContactosContexto(DbContextOptions<ApiContactosContexto> options)
        : base(options)
        {
        }
        public DbSet<Contacto>? Contactos { get; set; }
    }
}
