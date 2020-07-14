using System;

namespace CorEscuela.Entidades
{
    public abstract class ObjetoEscuelaBase
    {
        public string UniqueId{ get; private set; } = Guid.NewGuid().ToString(); // // lo definimos privado por lo que solo se puede asignar desde la clase
                                                //lo asignamos con el constructur 
   
        public string Nombre { get; set;}
    }
}