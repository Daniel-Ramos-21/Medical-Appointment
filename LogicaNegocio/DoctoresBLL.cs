using AccesoDatos;
using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicaNegocio
{
    public class DoctoresBLL
    {
        //Campo privado que nos sirva solo como lectura del context
        private readonly MedicalContext _context;

        //Constructor del medicalContext
        //y guarda la conexion en mi variable privada
        //inyeccion de dependencias.
        public DoctoresBLL(MedicalContext context)
        {
            _context = context;
        }

        public List<Doctor> ObtenerDoctores()
         {
            //retorna la lista de la entidad Doctor
            return _context.Doctors
            //Esto representaria un JOIN entre la tabla doctors y especialidad
            .Include(m => m.Especialidad)
            //Esto representaria un JOIN entre la tabla doctors y usuario
            .Include(u => u.usuario)
            //Y que lo muestre en forma de lista
            .ToList();
        }

        //Un metodo publico que obtine la entidad Doctor y que por parametro reciba un dato,
        //tipo entero que representara nuestro id
        public Doctor ObtenerInforID(int id)
        {
            //Decimos con que tabla vamos a trabajar
            return _context.Doctors
            //Esto representaria un JOIN entre la tabla doctirs y especialidades
            .Include(d => d.Especialidad)
            .Include(u => u.usuario)
            //busca el id de la tabla que coincida con el id enviado por parametro
            //el equivalente a  where Id_Doctor = id.
            .FirstOrDefault(d => d.Id_Doctor == id)!;
        }
    }
}
