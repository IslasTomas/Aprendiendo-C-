using System;
using System.Collections.Generic;

namespace CorEscuela.Entidades
{
    public class Curso
    {
        public string Nombre {get;set;}
        public string Id {get; private set;}    // lo definimos privado por lo que solo se puede asignar desde la clase
                                                //lo asignamos con el constructur 
        public TurnoCurso turno {get;set;}
        public List<Alumno> Alumnos { get; set; } = new List<Alumno>();
        public List<Materia> Materias { get; set; } = new List<Materia>();
        public Curso()                       //constructor donde asignamos el id automatico
        {
            Id = Guid.NewGuid().ToString();  
        }
    }
}       