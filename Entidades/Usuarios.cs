using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel;
using System.ComponentModel.Design;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Entidades
{
    [Index(nameof(DUI), IsUnique =true)]
    [Index(nameof(Email), IsUnique =true)]
    public class Usuarios 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Usuario { get; set; }

        [Required(ErrorMessage = "El Dui es requerido.")]
        [RegularExpression(@"^\d{8}-\d{1}$", ErrorMessage ="Formato de Dui no valido 00000000-0")]
        [StringLength(10)]
        public string DUI { get; set; } = null!;

        [Required(ErrorMessage = "El nombre es requerido.")]
        [StringLength(30)]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El apellido es requerido.")]
        [StringLength(40)]
        public string Apellido { get; set; } = null!;

        public bool IsDoctor { get; set; } = false;

        [Required(ErrorMessage = "El correo es requerido.")]
        [EmailAddress(ErrorMessage = "El correo es invalido.")]
        [StringLength(100)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "La constraseña es requerida.")]
        [StringLength(255)]
        public string password { get; set; } = null!;

        public virtual ICollection<Citas> CitasPaciente { get; set; } = new List<Citas>();

        
    }
}
