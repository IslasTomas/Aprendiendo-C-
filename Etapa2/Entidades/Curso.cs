using System;
namespace CorEscuela.Entidades
{
    public class Curso
    {
        public string nombre {get;set;}
        public string id {get; private set;}    // lo definimos privado por lo que solo se puede asignar desde la clase
                                                //lo asignamos con el constructur 
        public TurnoCurso turno {get;set;}
        public Curso()                       //constructor donde asignamos el id automatico
        {
            id = Guid.NewGuid().ToString();  
        }
    }
}       