using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AccesoDatos
{        
    //La clase heredara las capacida de hacer consultas.
    public  class MedicalContext : DbContext
    {
       
            //Constructor que permite pasar la configuacion del DbContext
            //Es como una cadena de conexion al servidor de la base de datos
            public MedicalContext(DbContextOptions<MedicalContext> options) : base(options)
            {

            }

            //Esto es ver la lista de tablas que tenemos en la base datos
            //y dice que cree las tablas a partir de la clases que tenemos en la 
            //bibloteca entidades.
            public DbSet<Doctor> Doctors { get; set; }

            public DbSet<Especialidad> Especialidades { get; set; }

            public DbSet<Usuarios> Usuarios { get; set;  }

            public DbSet<Citas> Citas { get; set; }

        //
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);//Llamamos a la configuracion base de entity framework

            modelBuilder.Entity<Citas>() //Seleccionamos la entidad
                .HasOne(c => c.Paciente) //Definimos que cita tiene objeto Paciente
                .WithMany(u => u.CitasPaciente) //Un paciente tiene muchas citas (1---*)
                .HasForeignKey(c => c.Id_Paciente) //Especificamos la propiedad que es su llave foranea
                .OnDelete(DeleteBehavior.Restrict); // Esta linea establece que las tablas es tan conectadas y si se intenta borrar
                                                    //la tabla padre lanzara una execepcion.

            modelBuilder.Entity<Citas>()
                .HasOne(c => c.Doctor)
                .WithMany(u => u.CitasRegistradas)
                .HasForeignKey(c => c.Id_doctor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.usuario)
                .WithMany()
                .HasForeignKey(d => d.Id_Usuario)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de la (Seed Data) para la tabla Especialidad.
            modelBuilder.Entity<Especialidad>().HasData(
                new List<Especialidad>
                {
                    // Se definen los registros iniciales que se insertarán en la base de datos.
                    new Especialidad { Id_Especialidad = 1, Nombre_especialidad = "Medicina General"},
                    new Especialidad { Id_Especialidad = 2, Nombre_especialidad = "Odontología"},
                    new Especialidad { Id_Especialidad = 3, Nombre_especialidad = "Pediatría"},
                    new Especialidad { Id_Especialidad = 4, Nombre_especialidad = "Ginecología"},
                    new Especialidad { Id_Especialidad = 5, Nombre_especialidad = "Psicología"},
                    new Especialidad { Id_Especialidad = 6, Nombre_especialidad = "Oftalmología"}
                }
                );

            string passwordHas = "$2a$12$cyyvGxCZnMpifroR0sUy4uvTZb5rh9ojoyD8jDozLjpXI9zGc5FBG";
            //Configuracion de la (Seed Data) para la  tabla usuarios
            modelBuilder.Entity<Usuarios>().HasData(
                new List<Usuarios>
                {
                    new Usuarios {
                        Id_Usuario = 1,
                        DUI = "10000000-1",
                        Nombre= "Carlos",
                        Apellido="Martínez",
                        IsDoctor = true,
                        Email= "carlos.martinez@clinica.com",
                        password = passwordHas
                    },
                    new Usuarios {
                        Id_Usuario = 2,
                        DUI = "10000001-2",
                        Nombre = "Lucía",
                        Apellido = "Fernández",
                        IsDoctor = true,
                        Email = "lucia.fernandez@clinica.com",
                        password = passwordHas
                    },

                    new Usuarios
                    {
                        Id_Usuario = 3,
                        DUI = "10000002-3",
                        Nombre = "Elena",
                        Apellido = "Rivas",
                        IsDoctor = true,
                        Email = "elena.rivas@clinica.com",
                        password = passwordHas
                    },

                    new Usuarios
                    {
                        Id_Usuario = 4,
                        DUI = "10000003-4",
                        Nombre = "Samuel",
                        Apellido = "Orellana",
                        IsDoctor = true,
                        Email = "samuel.orellana@clinica.com",
                        password = passwordHas
                    },

                    new Usuarios
                    {
                        Id_Usuario = 5,
                        DUI = "10000004-5",
                        Nombre = "Beatriz",
                        Apellido = "Zelaya",
                        IsDoctor = true,
                        Email = "beatriz.zelaya@clinica.com",
                        password = passwordHas
                    },

                    new Usuarios
                    {
                        Id_Usuario = 6,
                        DUI = "10000005-6",
                        Nombre = "Patricia",
                        Apellido = "Arias",
                        IsDoctor = true,
                        Email = "patricia.arias@clinica.com",
                        password = passwordHas
                    },

                    new Usuarios
                    {
                        Id_Usuario = 7,
                        DUI = "10000006-7",
                        Nombre = "Gustavo",
                        Apellido = "Méndez",
                        IsDoctor = true,
                        Email = "gustavo.mendez@clinica.com",
                        password = passwordHas
                    },

                    new Usuarios
                    {
                        Id_Usuario = 8,
                        DUI = "10000007-8",
                        Nombre = "Ricardo",
                        Apellido = "Valle",
                        IsDoctor = true,
                        Email = "ricardo.valle@clinica.com",
                        password = passwordHas
                    }
                }
                );

            // Configuración de la (Seed Data) para la tabla Doctor.
            modelBuilder.Entity<Doctor>().HasData(
                new List<Doctor>                {
                    // Se definen los registros iniciales que se insertarán en la base de datos.
                    //ID 1
                    new Doctor{
                        Id_Doctor = 1,
                        Id_Usuario = 1,
                        AlmaMater="Universidad de El Salvador",
                        HoraEntrada = new TimeSpan(08, 00, 00),
                        HoraSalida = new TimeSpan(15,00,00),
                        Id_Especialidad = 1,
                        Foto = "/img/doctores/doc1.png",
                        Perfil= "Médico general con enfoque en atención primaria y medicina preventiva. Graduado de la Universidad de El Salvador, cuenta con amplia experiencia en el manejo de enfermedades crónicas y seguimiento integral del paciente adulto."
                    },
                    //ID 2
                    new Doctor {
                        Id_Doctor = 2,
                        Id_Usuario = 2,
                        AlmaMater="Universidad Dr. José Matías Delgado",
                        HoraEntrada = new TimeSpan(08, 00, 00),
                        HoraSalida = new TimeSpan(16,00,00),
                        Id_Especialidad = 1,
                        Foto = "/img/doctores/doc2.png",
                        Perfil= "Especialista en medicina comunitaria con formación en la Universidad Dr. José Matías Delgado. Experta en diagnósticos clínicos tempranos, promoción de la salud y atención de urgencias menores en el ámbito clínico privado."
                    },
                    //ID 3
                    new Doctor {
                        Id_Doctor = 3,
                        Id_Usuario = 3,
                        AlmaMater="Universidad Evangélica",
                        HoraEntrada = new TimeSpan(09, 00, 00),
                        HoraSalida = new TimeSpan(17,00,00),
                        Id_Especialidad = 5,
                        Foto = "/img/doctores/doc3.png",
                        Perfil = "Psicóloga clínica con maestría en terapia cognitivo-conductual. Se especializa en el tratamiento de trastornos de ansiedad, depresión y manejo del estrés, brindando un enfoque humano y empático en cada sesión terapéutica."
                    },
                    //ID 4
                    new Doctor
                    {
                        Id_Doctor = 4,
                        Id_Usuario = 4,
                        AlmaMater = "Universidad de El Salvador",
                        HoraEntrada = new TimeSpan(11, 0, 0),
                        HoraSalida = new TimeSpan(19, 0, 0),
                        Id_Especialidad = 5,
                        Foto = "/img/doctores/doc4.png",
                        Perfil = "Profesional de la salud mental graduado de la UES, con experticia en psicología organizacional y apoyo psicopedagógico. Enfocado en el desarrollo de resiliencia y salud mental en entornos laborales y académicos."
                    },
                    //ID 5
                    new Doctor
                    {
                    Id_Doctor = 5,
                    Id_Usuario = 5,
                    AlmaMater = "Universidad de El Salvador",
                    HoraEntrada = new TimeSpan(10, 0, 0),
                    HoraSalida = new TimeSpan(18, 0, 0),
                    Id_Especialidad = 2,
                    Foto = "/img/doctores/doc6.png",
                    Perfil = "Odontóloga integral con énfasis en rehabilitación oral y estética dental. Graduada de la Universidad de El Salvador, es experta en tratamientos preventivos y restaurativos, enfocada en devolver la funcionalidad y armonía estética a la sonrisa."
                    },
                    //ID 6
                    new Doctor
                    {
                        Id_Doctor = 6,
                        Id_Usuario = 6,
                        AlmaMater="Universidad Dr. José Matías Delgado",
                        HoraEntrada = new TimeSpan(07,30,0),
                        HoraSalida = new TimeSpan(15,30,0),
                        Id_Especialidad = 3,
                        Foto = "/img/doctores/doc7.png",
                        Perfil = "Especialista en el cuidado integral de la infancia y adolescencia. Con formación en la Universidad Dr. José Matías Delgado, destaca por su paciencia y precisión en el control de niño sano y desarrollo infantil."
                    },
                    //ID 7
                    new Doctor
                    {
                        Id_Doctor = 7,
                        Id_Usuario = 7,
                        AlmaMater = "Universidad de El Salvador",
                        HoraEntrada = new TimeSpan(08,30,0),
                        HoraSalida = new TimeSpan(16,30,0),
                        Id_Especialidad = 4,
                        Foto = "/img/doctores/doc8.png",
                        Perfil = "Ginecólogo y obstetra dedicado a la salud integral de la mujer en todas sus etapas. Experto en control prenatal, planificación familiar y cirugía ginecológica mínimamente invasiva."
                    },
                    //ID 8
                    new Doctor
                    {
                        Id_Doctor = 8,
                        Id_Usuario = 8,
                        AlmaMater = "Universidad Alberto Masferrer",
                        HoraEntrada = new TimeSpan(08,00,0),
                        HoraSalida = new TimeSpan(12,00,0),
                        Id_Especialidad = 6,
                        Foto = "/img/doctores/doc5.png",
                        Perfil = "Médico cirujano oftalmólogo con especialización en el diagnóstico de patologías oculares, corrección de errores refractivos y prevención del glaucoma. Comprometido con la salud visual de sus pacientes."
                    }

                }
                );

            

        }

    }
}

