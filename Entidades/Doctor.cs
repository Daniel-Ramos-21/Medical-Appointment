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

        public int Id_Usuario { get; set; }

        [ForeignKey("Id_Usuario")]
        public virtual Usuarios usuario { get; set; } = null!;

        [Required]
        [StringLength(100)]
        //Datos del estudios del doctor
        public string AlmaMater { get; set; } = null!;

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
        public virtual Especialidad Especialidad { get; set; } = null!;

        [StringLength(200)]
        public string? Foto { get; set; }

        [Display(Name = "Perfil Profesional")]
        [StringLength(500)]
        public string? Perfil { get; set; } = null!;
    }
}
