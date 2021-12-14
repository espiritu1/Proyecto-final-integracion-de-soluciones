using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PeliculaService3.Models
{
    public class Director
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}