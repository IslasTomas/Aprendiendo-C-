using System.Collections.Generic;
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

        public void ImprimirCursos()
        {
            WriteLine("======");
            WriteLine("CURSOS");
            WriteLine("======");
            foreach (var cursos in Escuela.Cursos)
            {
                WriteLine($"Curso: {cursos.Nombre} ID: {cursos.Id} Turno: {cursos.turno}");
            }
        }

    }
}