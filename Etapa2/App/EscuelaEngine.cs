using System.Collections.Generic;
using CorEscuela.Entidades;

namespace CorEscuela
{
    class EscuelaEngine
    {
        public Escuela escuela { get; set; }
        public EscuelaEngine()
        {
            


        }
        public void Inicializar()
        {
            escuela = new Escuela("Saaan cayetano", 1960,
            TiposEscuela.PreEscuela, paisE: "Argentaaina", ciudadE: "La Plata");
            escuela.colCursos=new List<Curso>()
            {
                  new Curso{nombre="1001",turno=TurnoCurso.Noche},
                  new Curso{nombre="2001",turno=TurnoCurso.Noche},
                  new Curso{nombre="3001",turno=TurnoCurso.Mañana},
                  new Curso{nombre="4001",turno=TurnoCurso.Mañana},
                  new Curso{nombre="5001",turno=TurnoCurso.Noche}
            };
        }

    }
}