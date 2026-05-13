using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Especialidad>().HasData(
                new List<Especialidad>
                {
                    new Especialidad { Id_Especialidad = 1, Nombre_especialidad = "Medicina General"},
                    new Especialidad { Id_Especialidad = 2, Nombre_especialidad = "Odontología"},
                    new Especialidad { Id_Especialidad = 3, Nombre_especialidad = "Pedriatría"},
                    new Especialidad { Id_Especialidad = 4, Nombre_especialidad = "Ginecología"},
                    new Especialidad { Id_Especialidad = 5, Nombre_especialidad = "Psicología"},
                    new Especialidad { Id_Especialidad = 6, Nombre_especialidad = "Oftalmologia"}
                }
                );

            modelBuilder.Entity<Doctor>().HasData(
                new List<Doctor>
                {
                    //ID 1
                    new Doctor {
                        Id_Doctor = 1, 
                        Nombre= "Carlos", Apellido="Martínez", 
                        AlmaMater="Universidad de El Salvador",
                        HoraEntrada = new TimeSpan(08, 00, 00), 
                        HoraSalida = new TimeSpan(03,00,00), 
                        Id_Especialidad = 1,
                        Foto = "/img/doctores/doc1.png", 
                        Perfil= "Médico general con enfoque en atención primaria y medicina preventiva. Graduado de la Universidad de El Salvador, cuenta con amplia experiencia en el manejo de enfermedades crónicas y seguimiento integral del paciente adulto."
                    },
                    //ID 2
                    new Doctor {
                        Id_Doctor = 2, 
                        Nombre= "Lucía", 
                        Apellido="Fernández", 
                        AlmaMater="Universidad Dr. José Matías Delgado",
                        HoraEntrada = new TimeSpan(08, 00, 00), 
                        HoraSalida = new TimeSpan(04,00,00), 
                        Id_Especialidad = 1,
                        Foto = "/img/doctores/doc2.png", 
                        Perfil= "Especialista en medicina comunitaria con formación en la Universidad Dr. José Matías Delgado. Experta en diagnósticos clínicos tempranos, promoción de la salud y atención de urgencias menores en el ámbito clínico privado."
                    },
                    //ID 3
                    new Doctor {
                        Id_Doctor = 3, 
                        Nombre= "Elena", 
                        Apellido="Rivas", 
                        AlmaMater="Universidad Evangélica",
                        HoraEntrada = new TimeSpan(09, 00, 00), 
                        HoraSalida = new TimeSpan(05,00,00), 
                        Id_Especialidad = 5,
                        Foto = "/img/doctores/doc3.png", 
                        Perfil = "Psicóloga clínica con maestría en terapia cognitivo-conductual. Se especializa en el tratamiento de trastornos de ansiedad, depresión y manejo del estrés, brindando un enfoque humano y empático en cada sesión terapéutica."
                    },
                    //ID 4
                    new Doctor
                    {
                        Id_Doctor = 4,
                        Nombre = "Samuel",
                        Apellido = "Orellana",
                        AlmaMater = "Universidad de El Salvador",
                        HoraEntrada = new TimeSpan(11, 0, 0),
                        HoraSalida = new TimeSpan(07, 0, 0),
                        Id_Especialidad = 5,
                        Foto = "/img/doctores/doc4.png",
                        Perfil = "Profesional de la salud mental graduado de la UES, con experticia en psicología organizacional y apoyo psicopedagógico. Enfocado en el desarrollo de resiliencia y salud mental en entornos laborales y académicos."
                    },
                    //ID 5
                    new Doctor
                    {
                    Id_Doctor = 5,
                    Nombre = "Beatriz",
                    Apellido = "Zelaya",
                    AlmaMater = "Universidad de El Salvador",
                    HoraEntrada = new TimeSpan(10, 0, 0),
                    HoraSalida = new TimeSpan(07, 0, 0),
                    Id_Especialidad = 2,
                    Foto = "/img/doctores/doc6.png",
                    Perfil = "Odontóloga integral con énfasis en rehabilitación oral y estética dental. Graduada de la Universidad de El Salvador, es experta en tratamientos preventivos y restaurativos, enfocada en devolver la funcionalidad y armonía estética a la sonrisa."
                    },
                    //ID 6
                    new Doctor
                    {
                        Id_Doctor = 6,
                        Nombre = "Patricia",
                        Apellido = "Arias",
                        AlmaMater="Universidad Dr. José Matías Delgado",
                        HoraEntrada = new TimeSpan(07,30,0),
                        HoraSalida = new TimeSpan(03,30,0),
                        Id_Especialidad = 3,
                        Foto = "/img/doctores/doc7.png",
                        Perfil = "Especialista en el cuidado integral de la infancia y adolescencia. Con formación en la Universidad Dr. José Matías Delgado, destaca por su paciencia y precisión en el control de niño sano y desarrollo infantil."
                    },
                    //ID 7
                    new Doctor
                    {
                        Id_Doctor = 7,
                        Nombre = "Gustavo",
                        Apellido = "Méndez",
                        AlmaMater = "Universidad de El Salvador",
                        HoraEntrada = new TimeSpan(08,30,0),
                        HoraSalida = new TimeSpan(04,30,0),
                        Id_Especialidad = 4,
                        Foto = "/img/doctores/doc8.png",
                        Perfil = "Ginecólogo y obstetra dedicado a la salud integral de la mujer en todas sus etapas. Experto en control prenatal, planificación familiar y cirugía ginecológica mínimamente invasiva."
                    },
                    //ID 8
                    new Doctor
                    {
                        Id_Doctor = 8,
                        Nombre = "Ricardo",
                        Apellido = "Valle",
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

