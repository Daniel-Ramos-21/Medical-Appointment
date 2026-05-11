using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Entidades
{
    public class Especialidad
    {
        //Primary key medico
        [Key]
        //El dato tenga la propiedad identity 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Especialidad { get; set; }

        //Dato es not null
        [Required]
        //Establece la cantidad de caracteres del campo
        [StringLength(50)]
        public string Nombre_especialidad { get; set; }
        //Indica que puede tener una relacion 1, N entre Especialidad y Medicos
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
