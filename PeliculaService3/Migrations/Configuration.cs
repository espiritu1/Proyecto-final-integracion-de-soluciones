namespace PeliculaService3.Migrations
{
    using PeliculaService3.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PeliculaService3.Data.PeliculaService3Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PeliculaService3.Data.PeliculaService3Context context)
        {
            context.Directors.AddOrUpdate(x => x.Id,
                new Director() { Id = 1, Nombre = "Francis Ford Coppola" },
                new Director() { Id = 2, Nombre = "Peter Jackson" },
                new Director() { Id = 3, Nombre = "Christopher Nolan" }
                );
            context.Peliculas.AddOrUpdate(x => x.Id,
            new Pelicula()
            {
                Id = 1,//
                Titulo = "the godfather",//
                Genero = "Mafia, Drama, Crimen",//
                Precio = 100,
                Anio = 1972,
                DirectorId = 1,


            },
            new Pelicula()
            {
                Id = 2,
                Titulo = "The godfather II",
                Genero = "Mafia, Drama, Crimen",
                Precio = 200,
                Anio = 1972,
                DirectorId = 1


            },
            new Pelicula()
            {
                Id = 3,
                Titulo = "The godfather III ",
                Genero = "Mafia, Drama, Crimen",
                Precio = 300,
                Anio = 1990,
                DirectorId = 1


            },
            new Pelicula()
            {
                Id = 4,
                Titulo = "El Señor de los anillos: La comunidad del anillo",
                Genero = "Acción, Drama, Fantasía, aventura",
                Precio = 540M,
                Anio = 2001,
                DirectorId = 2


            },
            new Pelicula()
            {
                Id = 5,
                Titulo = "El Señor de los anillos: Las dos torres",
                Genero = "Acción, Drama, Fantasía, aventura",
                Precio = 372M,
                Anio = 2002,
                DirectorId = 2


            },
            new Pelicula()
            {
                Id = 6,
                Titulo = "El Señor de los anillos: El Retorno del Rey",
                Genero = "Acción, Drama, Fantasía, aventura",
                Precio = 1589M,
                Anio = 2003,
                DirectorId = 2


            },
            new Pelicula()
            {
                Id = 7,
                Titulo = "Batman Begins",
                Genero = "Acción, Drama, Fantasía, aventura",
                Precio = 1589M,
                Anio = 2005,
                DirectorId = 3


            },
            new Pelicula()
            {
                Id = 8,
                Titulo = "The Dark Knight",
                Genero = "Acción, Drama, Fantasía, aventura",
                Precio = 1589M,
                Anio = 2008,
                DirectorId = 3


            }, new Pelicula()
            {
                Id = 9,
                Titulo = "The Dark Knight Rises",
                Genero = "Acción, Drama, Fantasía, aventura",
                Precio = 1589M,
                Anio = 2012,
                DirectorId = 3


            }
            );

        }
    }
}
