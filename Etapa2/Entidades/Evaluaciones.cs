using System;

namespace CorEscuela.Entidades
{
    public class Evaluacion
    {
        public string Nombre { get; set;} 
        public string UniqueId{get; private set;} = Guid.NewGuid().ToString();
       public Alumno Alumno {get; set;}
       public Materia Materia { get; set; }
       public float Nota { get; set; }
        
    }
}