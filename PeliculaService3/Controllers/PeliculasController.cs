using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PeliculaService3.Data;
using PeliculaService3.Models;

namespace PeliculaService3.Controllers
{
    public class PeliculasController : ApiController
    {
        private PeliculaService3Context db = new PeliculaService3Context();

        public IQueryable<PeliculaDTO> GetBooks()
        {
            // GET: api/peliculas

            var peliculas = from b in db.Peliculas
                        select new PeliculaDTO()
                        {
                            Id = b.Id,
                            Titulo = b.Titulo,
                            DirectorNombre = b.Director.Nombre
                        };
            return peliculas;
        }

        // GET: api/Pelicula/5
        [ResponseType(typeof(PeliculaDetailDTO))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            var pelicula = await db.Peliculas.Include(b => b.Director).Select(b =>
            new PeliculaDetailDTO()
            {
                Id = b.Id,
                Titulo = b.Titulo,
                Anio = b.Anio,
                Precio = b.Precio,
                DirectorNombre = b.Director.Nombre,
                Genero = b.Genero
            }).SingleOrDefaultAsync(b => b.Id == id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return Ok(pelicula);
        }

        // POST: api/Books
        [ResponseType(typeof(Pelicula))]
        public async Task<IHttpActionResult> PostBook(Pelicula pelicula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Peliculas.Add(pelicula);
            await db.SaveChangesAsync();
            // New code:
            // Load author name
            db.Entry(pelicula).Reference(x => x.Director).Load();
            var dto = new PeliculaDTO()
            {
                Id = pelicula.Id,
                Titulo = pelicula.Titulo,
                DirectorNombre = pelicula.Director.Nombre
            };
            return CreatedAtRoute("DefaultApi", new { id = pelicula.Id }, dto);
        }







        // DELETE: api/Peliculas/5
        [ResponseType(typeof(Pelicula))]
        public async Task<IHttpActionResult> DeletePelicula(int id)
        {
            Pelicula pelicula = await db.Peliculas.FindAsync(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            db.Peliculas.Remove(pelicula);
            await db.SaveChangesAsync();

            return Ok(pelicula);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PeliculaExists(int id)
        {
            return db.Peliculas.Count(e => e.Id == id) > 0;
        }
    }
}