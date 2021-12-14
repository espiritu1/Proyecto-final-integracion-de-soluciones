using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeliculaService3.Models
{
    public class PeliculaDetailDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public decimal Precio { get; set; }
        public string DirectorNombre { get; set; }
        public int Anio { get; set; }


    }
}