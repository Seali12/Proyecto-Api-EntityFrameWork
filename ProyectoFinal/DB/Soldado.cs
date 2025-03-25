using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Soldado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SoldadoId { get; set; }
        
        [Required(ErrorMessage = "El nombre del soldado no fue completaod")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido no fue completado")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El Dni del soldado no fue completado correctamente")]
        [Range(10000000, 999999999, ErrorMessage = "el dni esta mal")]
        public int Dni { get; set; }

        //public virtual IEnumerable<Licencia> Licencias { get; set; }


    }
}
