using AccesoDatos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace PresentacionUI.Pages
{
    public class LoginModel : PageModel
    {
        private readonly MedicalContext _context;

        public LoginModel(MedicalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; } = null!;

        public class InputModel
        {
            [Required(ErrorMessage = "El correo es requerido.")]
            [EmailAddress]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessage = "La contraseña es requerida.")]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == Input.Email);

            if (usuario == null)
            {
                ModelState.AddModelError("", "Correo o contraseña incorrectos.");
                return Page();
            }

            if (usuario.password != Input.Password)
            {
                ModelState.AddModelError("", "Correo o contraseña incorrectos.");
                return Page();
            }

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier,
            usuario.Id_Usuario.ToString()),

        new Claim(ClaimTypes.Name,
            $"{usuario.Nombre} {usuario.Apellido}"),

        new Claim(ClaimTypes.Email,
            usuario.Email),

        new Claim(ClaimTypes.Role,
            usuario.IsDoctor ? "Medico" : "Paciente")
    };

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal);

            if (usuario.IsDoctor)
            {
                return RedirectToPage("/Doctor_cita/Doctor_Citas");
            }

            return RedirectToPage("/Index");
        }
    }
}