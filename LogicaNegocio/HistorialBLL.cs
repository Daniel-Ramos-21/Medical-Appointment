using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Azure;
using Entidades;
using Microsoft.EntityFrameworkCore;


namespace LogicaNegocio
{
    public  class HistorialBLL
    {
        private readonly MedicalContext _context;

        public HistorialBLL(MedicalContext context)
        {
            _context = context;
        }
        public List<Citas> HistorialCitas(int IdPaciente)
        {
            return _context.Citas
                .Where(c => c.Id_Paciente == IdPaciente)
                .Include(c => c.Paciente)
                .Include(c => c.Doctor)
                .ThenInclude(d => d.usuario)
                .Include(c => c.Doctor)
                .ThenInclude(d => d.Especialidad)
                .ToList();
        }

        public List<Citas> FitroCitasPorFecha(int IdPaciente, DateOnly? fecha, int? Idespecialidad)
        {
            var consulta = _context.Citas
                .Where(c => c.Id_Paciente == IdPaciente)
                .Include(c => c.Paciente)
                .Include(c => c.Doctor)
                .ThenInclude(d => d.usuario)
                .Include(c => c.Doctor)
                .ThenInclude(d => d.Especialidad)
                .AsQueryable();

            if(fecha.HasValue)
            {
                consulta = consulta.Where(
                    c => c.Fecha == fecha.Value);
            }

            if (Idespecialidad.HasValue)
            {
                consulta = consulta.Where(
                    c => c.Doctor.Id_Especialidad == Idespecialidad.Value);
            }
            return consulta.OrderByDescending(
                c => c.Fecha)
                .ToList();
               
        }

        public List<Especialidad> ObtenerEspecialidades()
        {
            return _context.Doctors
                .Select(d => d.Especialidad)
                .Distinct()
                .ToList();
        }

        public async Task<bool> EliminarCita(int id)
        {
            var cita = _context.Citas.Find(id);

            if (cita == null)
            {
                return false;
            }

            _context.Citas.Remove(cita);
            _context.SaveChanges();

            return true;
        }

        public Citas? ObtenerCitasID(int id)
        {
            return _context.Citas
                .AsTracking()
                .Include(c => c.Paciente)
                .Include(c => c.Doctor)
                .ThenInclude(d => d.usuario)
                .Include(c => c.Doctor)
                .ThenInclude(d => d.Especialidad)
                .FirstOrDefault(c => c.Id_Citas == id);
        }
    }
}