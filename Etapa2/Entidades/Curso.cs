using System;
using System.Collections.Generic;

namespace CorEscuela.Entidades
{
    public class Curso: ObjetoEscuelaBase
    {
         public TurnoCurso turno {get;set;}
        public List<Alumno> Alumnos { get; set; } = new List<Alumno>();
        public List<Materia> Materias { get; set; } = new List<Materia>();
       
    }
}       