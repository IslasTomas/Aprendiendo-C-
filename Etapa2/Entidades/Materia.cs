using System;

namespace CorEscuela.Entidades
{
    public class Materia        
    {
        public string Nombre { get; set;} 
        public string UniqueId {get; private set;}
        public Materia(){
            UniqueId = Guid.NewGuid().ToString();
        } 
        
    }
}