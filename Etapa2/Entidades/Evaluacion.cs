using System;

namespace CorEscuela.Entidades
{
    public class Evaluacion : ObjetoEscuelaBase
    {
       public Alumno Alumno {get; set;}
       public Materia Materia { get; set; }
       public float Nota { get; set; }
       public override string ToString()
       {
           return $"{Alumno.Nombre}, {Nota}, {Materia.Nombre}";

       } 
        
    }
}