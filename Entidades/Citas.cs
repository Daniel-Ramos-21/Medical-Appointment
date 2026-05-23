using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Citas
    {
        [Key]
        public int Id_Citas { get; set; }

        public int Id_Paciente { get; set; }

        [ForeignKey("paciente")]
        public virtual Usuarios Paciente { get; set; } = null!;

        public int Id_doctor { get; set; }
        [ForeignKey("doctor")]
        public virtual Doctor Doctor { get; set; } = null!;

        [Required(ErrorMessage = "La fecha es requerida")]
        public DateOnly Fecha { get; set; }

        [Required(ErrorMessage = "La hora es requerida")]
        public TimeSpan Hora  { get; set;}

        [StringLength(50)]
        public string Motivo { get; set; } = null!;

        public string Estado { get; set; } = "Pendiente";

    }
}
