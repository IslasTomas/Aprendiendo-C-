using System;
using System.Collections.Generic;

namespace CorEscuela.Entidades
{
    public class Curso: ObjetoEscuelaBase, ILugar
    {
         public TurnoCurso turno {get;set;}
        public List<Alumno> Alumnos { get; set; } = new List<Alumno>();
        public List<Materia> Materias { get; set; } = new List<Materia>();
        public string Direccion { get; set; }

        public void LimpiarLugar()
        {
            Console.WriteLine($"Curso {Nombre} Limpiado");
        }
    }
}       