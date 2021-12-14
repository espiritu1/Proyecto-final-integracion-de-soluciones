using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PeliculaService3.Data
{
    public class PeliculaService3Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PeliculaService3Context() : base("name=PeliculaService3Context")
        {
        }

        public System.Data.Entity.DbSet<PeliculaService3.Models.Director> Directors { get; set; }

        public System.Data.Entity.DbSet<PeliculaService3.Models.Pelicula> Peliculas { get; set; }
    }
}
