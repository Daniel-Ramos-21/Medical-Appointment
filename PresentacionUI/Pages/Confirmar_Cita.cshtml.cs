using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AccesoDatos;
using System.IO;
using SkiaSharp;
using Entidades;

namespace PresentacionUI.Pages
{
    public class Confirmar_CitaModel : PageModel
    {
        private readonly CitaBLL _citaBll;

        public Confirmar_CitaModel(CitaBLL citaBLL)
        {
            _citaBll = citaBLL;
        }

        public Citas CitaReciente { get; set; }

        public IActionResult OnGet()
        {
            if (TempData["CitaReciente"] is int id_Cita)
            {
                TempData.Keep("CitaReciente");

                CitaReciente = _citaBll.ObtenerCitasID(id_Cita);

                if (CitaReciente == null)
                {
                    return RedirectToPage("./Index");
                }
                return Page();
            }
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetDescargarImagen()
        {
            if (TempData["CitaReciente"] is int id_cita)
            {
                TempData.Keep("CitaReciente");
                var cita = _citaBll.ObtenerCitasID(id_cita);
                if (cita == null)
                {
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

                    canvas.DrawRect(new SKRect(0, 0, width, 15), paintBarra);

                    canvas.DrawText("DETALLE DE LA CITA MÉDICA", 40, 60, SKTextAlign.Left, fontTitulo, paintTituloColor);

                    canvas.DrawText($"Paciente: {(cita.Paciente.Nombre)}", 40, 120, SKTextAlign.Left, fontTexto, paintTextoColor);
                    canvas.DrawText($"Médico: {(cita.Doctor.usuario.Nombre)}", 40, 160, SKTextAlign.Left, fontTexto, paintTextoColor);
                    canvas.DrawText($"Especialidad: {(cita.Doctor.Especialidad.Nombre_especialidad)}", 40, 200, SKTextAlign.Left, fontTexto, paintTextoColor);
                    canvas.DrawText($"Fecha: {cita.Fecha:dd/MM/yyyy} - {cita.Hora}", 40, 240, SKTextAlign.Left, fontTexto, paintTextoColor);
                    canvas.DrawText($"Motivo: {cita.Motivo}", 40, 280, SKTextAlign.Left, fontTexto, paintTextoColor);

                    using (var image = SKImage.FromBitmap(bitmap))
                    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                    {
                        var stream = new MemoryStream(data.ToArray());
                        return File(stream, "image/png", $"Cita_{id_cita}.png");
                    }
                }
            }

            return RedirectToPage("./Index");
        }
    }
}