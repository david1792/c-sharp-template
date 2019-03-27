using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD1_3_17_19.Models
{
    public class AlumnoCE
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        [MinLength(2)]
        public string NOMBRES { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        [MinLength(2)]
        public string APELLIDOS { get; set; }
        //[Required]
        //[Display(Name = "Edad")]
        public int EDAD { get; set; }
        //[Required]
        //{Display(Name = "Sexo")]
        public string SEXO { get; set; }
     }
    [MetadataType(typeof(AlumnoCE))]
    public partial class ALUMNO
    {
        public int Estado { get; set; }
        public string NombreCompleto { get { return NOMBRES + " " + APELLIDOS; }}

    }
}