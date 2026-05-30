using Entidades;
using LogicaNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkiaSharp;
using System.Security.Claims;

namespace PresentacionUI.Pages
{
    [Authorize]
    public class HistorialPacienteModel : PageModel
    {
        private readonly HistorialBLL _historialbll;

        public HistorialPacienteModel(HistorialBLL historialBLL)
        {
            _historialbll = historialBLL;
        }

        public List<Citas> Cita { get; set; }
        public List<Especialidad> Especialidades { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateOnly? FechaFiltro { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? EspecialidadFiltro { get; set; }

        public void OnGet()
        {
            int idUsuario = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            Especialidades = _historialbll.ObtenerEspecialidades();

            if (FechaFiltro.HasValue || EspecialidadFiltro.HasValue)
            {
                Cita = _historialbll.FitroCitasPorFecha(
                    idUsuario,
                    FechaFiltro,
                    EspecialidadFiltro
                );
            }
            else
            {
                Cita = _historialbll.HistorialCitas(idUsuario);
            }
        }
        public async Task<IActionResult> OnPostEliminarAsync(int id)
        {
            await _historialbll.EliminarCita(id);

            return RedirectToPage();
        }

        public IActionResult OnGetDescargarImagen(int id)
        {
            var cita = _historialbll.ObtenerCitasID(id);

            if (cita == null) {
                return NotFound();
            }
            

                int width = 600;
                int height = 350;
                using (var bitmap = new SKBitmap(width, height))
                using (var canvas = new SKCanvas(bitmap))
                {

                    canvas.Clear(SKColors.WhiteSmoke);

                    using var typefaceBold = SKTypeface.FromFamilyName("Arial", SKFontStyleWeight.Bold, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright);
                    using var typefaceRegular = SKTypeface.FromFamilyName("Arial", SKFontStyleWeight.Normal, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright);
                    using var fontTitulo = new SKFont(typefaceBold, 26);
                    using var fontTexto = new SKFont(typefaceRegular, 18);
                    using var paintTituloColor = new SKPaint { Color = SKColors.Navy, IsAntialias = true };
                    using var paintTextoColor = new SKPaint { Color = SKColors.Black, IsAntialias = true };
                    using var paintBarra = new SKPaint { Color = SKColors.Navy };

                    canvas.DrawText("DETALLES DE LA CITA MÉDICA", 40, 60, SKTextAlign.Left, fontTitulo, paintTituloColor);
                    canvas.DrawText($"Paciente: {cita.Paciente.Nombre} {cita.Paciente.Apellido}", 40, 120, SKTextAlign.Left, fontTexto, paintTextoColor);
                    canvas.DrawText($"Médico: Dr.{cita.Doctor.usuario.Nombre} {cita.Doctor.usuario.Apellido}", 40, 160, SKTextAlign.Left, fontTexto, paintTextoColor);
                    canvas.DrawText($"Especialidad: {(cita.Doctor.Especialidad.Nombre_especialidad)}", 40, 200, SKTextAlign.Left, fontTexto, paintTextoColor);
                    canvas.DrawText($"Fecha: {cita.Fecha:dd/MM/yyyy} - {cita.Hora}", 40, 240, SKTextAlign.Left, fontTexto, paintTextoColor);
                    canvas.DrawText($"Motivo: {cita.Motivo}", 40, 280, SKTextAlign.Left, fontTexto, paintTextoColor);
                    using (var logo = System.IO.File.OpenRead("wwwroot\\img\\Logo\\logo.png"))
                    {
                        using (var bitmaplogo = SKBitmap.Decode(logo))
                        {
                            var tamaño = new SKRect(450, 40, 550, 130);
                            canvas.DrawBitmap(bitmaplogo, tamaño);
                        }
                    }


                    canvas.Flush();

                    using (var image = SKImage.FromBitmap(bitmap))
                    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                    {
                        var stream = new MemoryStream(data.ToArray());
                        return File(stream, "image/png", $"Cita.png");
                    }
                }
        }
    }
}
