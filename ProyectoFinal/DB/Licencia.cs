using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Licencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LicenciaId { get; set; }


        public int SoldadoId { get; set; }
        [ForeignKey("SoldadoId")]
        public virtual Soldado soldado {get;set;}

        [Required(ErrorMessage = "El dni del soldado no fue completado")]
        public int SoldadoDni { get; set; }

        [Required(ErrorMessage = "La fecha de inicio no fue completada")]
        public DateTime fechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha fin no fue completada")]
        public DateTime fechaFin { get; set; }

        [Required(ErrorMessage = "El tipo no fue completado")]
        public string tipo { get; set; }

        [Required(ErrorMessage = "La provincia no fue completada")]
        public string provincia { get; set; }

        [Required(ErrorMessage = "La localidad no fue completada")]
        public string localidad { get; set; }

        [Required(ErrorMessage = "La direccion no fue completada")]
        public string direccion { get; set; }


        [Required(ErrorMessage = "La orden del dia no fue completada")]
        [StringLength(10, MinimumLength = 6)]
        public string ordenDelDia { get; set; }
    }


    
}
