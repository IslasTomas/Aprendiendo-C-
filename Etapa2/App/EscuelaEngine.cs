using System;
using System.Collections.Generic;
using System.Linq;
using CorEscuela.Entidades;
using static System.Console;

namespace CorEscuela
{
    class EscuelaEngine
    {
        public Escuela Escuela { get; set; }
        public EscuelaEngine()
        {



        }
        public void Inicializar()
        {
            Escuela = new Escuela("Saaan cayetano", 1960,
            TiposEscuela.PreEscuela, paisE: "Argentaaina", ciudadE: "La Plata");
            CargarCursos();
            CargarMaterias();
            CargarAlumnos();
            CargarEvaluaciones();

        }

        private void CargarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var materia in curso.Materias)
                {
                    foreach (var alumno in curso.Alumnos)
                    {

                        for (int i = 0; i < 5; i++)
                        {
                            var rnd= new Random();   //numeros ramdom para la nota de las evaluaciones
                            var ev= new Evaluacion
                                {
                                    Materia= materia,
                                    Nombre= $"{materia.Nombre} Ev#{i+1}",
                                    Nota= (float) (5 * rnd.NextDouble()), //agregando float transformamos el numero en flotante
                                    Alumno= alumno
                                };
                            alumno.Evaluaciones.Add(ev);          //agregamos el examen a alumno                                     //rnd.NextDouble genera numero del 0.0 al 1.0 
                        }
                    }

                }
            }

        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombres1 = { "Tomas", "Joaquin", "Mateo", "Umma", "Renata", "Johanna" };
            string[] apellidos = { "Islas", "Gualtieri", "Rodriguez", "Casarini", "Perez" };
            string[] nombres2 = { "Rolando", "Graciela", "Blanca", "Gisele" };
            var listadoAlumnos = from n1 in nombres1
                                 from n2 in nombres2
                                 from a1 in apellidos
                                 select new Alumno() { Nombre = $"{n1} {n2} {a1}" };
            return (listadoAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList());
        }
        private void CargarAlumnos()
        {
            var rnd = new Random();

            foreach (var curso in Escuela.Cursos)
            {
                curso.Alumnos.AddRange(GenerarAlumnosAlAzar(rnd.Next(5, 20)));
            }
        }

        private void CargarMaterias()
        {
            foreach (var curso in Escuela.Cursos)
            {
                curso.Materias = new List<Materia>()
               {
                   new Materia{Nombre="Matematicas"},
                   new Materia{Nombre="Lengua"},
                   new Materia{Nombre="Ingles"},
                   new Materia{Nombre="Musica"}
               };
            }
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                  new Curso{Nombre="1001",turno=TurnoCurso.Noche},
                  new Curso{Nombre="2001",turno=TurnoCurso.Noche},
                  new Curso{Nombre="3001",turno=TurnoCurso.Mañana},
                  new Curso{Nombre="4001",turno=TurnoCurso.Mañana},
                  new Curso{Nombre="5001",turno=TurnoCurso.Noche}
            };
        }

        public void ImprimirCursosYMaterias()
        {
            WriteLine("======");
            WriteLine("CURSOS");
            WriteLine("======");
            foreach (var cursos in Escuela.Cursos)
            {
                WriteLine($"Curso: {cursos.Nombre} ID: {cursos.UniqueId} Turno: {cursos.turno}");
                foreach (var materia in cursos.Materias)
                {
                    WriteLine($"Materia: \"{materia.Nombre}\" ID: \"{materia.UniqueId}\"");
                }
            }
        }

    }
}