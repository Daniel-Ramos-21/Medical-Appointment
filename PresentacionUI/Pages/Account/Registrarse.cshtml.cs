using AccesoDatos;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.ComponentModel.DataAnnotations;


namespace PresentacionUI.Pages
{
    public class RegistrarseModel : PageModel
    {
        private readonly MedicalContext _context;

        public RegistrarseModel(MedicalContext context)
        {
            _context = context;
        }
        [BindProperty]
        public InputModel Input { get; set; } = null!;

        public class InputModel
        {
            [Required(ErrorMessage = "El DUI es requerido.")]
            [RegularExpression(@"^\d{8}-\d{1}$", ErrorMessage = "Formato de DUI no válido (00000000-0)")]
            [StringLength(10)]
            public string DUI { get; set; } = null!;

            [Required(ErrorMessage = "El nombre es requerido.")]
            [StringLength(30)]
            public string Nombre { get; set; } = null!;

            [Required(ErrorMessage = "El apellido es requerido.")]
            [StringLength(40)]
            public string Apellido { get; set; } = null!;

            [Required(ErrorMessage = "El correo es requerido.")]
            [EmailAddress(ErrorMessage = "Correo electrónico inválido.")]
            [StringLength(100)]
            public string Email { get; set; } = null!;

            [Required(ErrorMessage = "La contraseña es requerida.")]
            [DataType(DataType.Password)]
            [StringLength(255, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
            public string Password { get; set; } = null!;

            [Required(ErrorMessage = "Confirme la contraseña.")]
            [Compare(nameof(Password),
            ErrorMessage = "Las contraseñas no coinciden.")]
            [DataType(DataType.Password)]
            public string ConfirmPassword { get; set; } = null!;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                bool existeEmail = await _context.Usuarios.AnyAsync(u => u.Email == Input.Email);
                bool existeDUI = await _context.Usuarios.AnyAsync(u => u.DUI == Input.DUI);

                if (existeEmail)
                {
                    ModelState.AddModelError("Input.Email", "El correo electrónico ya está registrado.");
                    return Page();
                }
                if (existeDUI)
                {
                    ModelState.AddModelError("Input.DUI", "El DUI ya está registrado.");
                    return Page();
                }

                var nuevoUsuario = new Usuarios
                {
                    DUI = Input.DUI,
                    Nombre = Input.Nombre,
                    Apellido = Input.Apellido,
                    Email = Input.Email,
                    password = Input.Password,
                    IsDoctor = false
                };
                _context.Usuarios.Add(nuevoUsuario);
                await _context.SaveChangesAsync();

                TempData["Mensaje"] = "Registro realizado correctamente.";

                return RedirectToPage("/Account/Login");
            }
            return Page();
        }
    }
}
