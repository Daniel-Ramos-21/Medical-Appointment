using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Entidades
{
    public class Doctor
    {
        //Primary key medico
        [Key]
        //El dato tenga la propiedad identity 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Doctor { get; set; }

        //Dato es not null
        [Required]
        //Establece la cantidad de caracteres del campo
        [StringLength(50)]
        public string Nombre { get; set; }

        //Dato es not null
        [Required]
        //Establece la cantidad de caracteres del campo
        [StringLength(60)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(100)]
        //Datos del estudios del doctor
        public string AlmaMater { get; set; }

        [Required]
        //Hora de entrada del doctor
        public TimeSpan HoraEntrada { get; set; }

        [Required]
        //Hora de salida del doctor
        public TimeSpan HoraSalida { get; set; }

        //especialidad del doctor
        public int Id_Especialidad { get; set; }

        //llave foreanea de la tabla y hace referencia a la tabla especialidad
        [ForeignKey("Id_Especialidad")]
        public virtual Especialidad Especialidad { get; set; }

        [StringLength(200)]
        public string Foto { get; set; }
    }
}
