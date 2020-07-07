using System;
using System.Collections.Generic;

namespace CorEscuela.Entidades
{
    public class Alumno
    {
        public string Nombre { get; set;} 
        public string UniqueId {get; private set;}
        public Alumno(){
            UniqueId = Guid.NewGuid().ToString();
        } 
        public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();

    }
}