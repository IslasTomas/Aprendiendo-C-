using System;
using System.Collections.Generic;

namespace CorEscuela.Entidades
{
    public class Materia        
    {
        public string Nombre { get; set;} 
        public string UniqueId {get; private set;}
        public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
        public Materia(){
            UniqueId = Guid.NewGuid().ToString();
        } 
        
    }
}