using System;
using CorEscuela.Entidades;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {  
            var escuela= new Escuela("Saaan cayetano" , 1960,
            TiposEscuela.PreEscuela, paisE:"Argentaaina",ciudadE: "La Paalata");   //con cntrl +.  agrega Escuela para tener sus metodos y mas
          /*
         !! escuela.Nombre="SanCa";
            escuela.Ciudad="la plata";!!!
            Como la adorsignacion del nombre y el año la hicimos como parametro de entrada al crear 
            el objeto esto ya no lo usamos y pasamos el nombre y año como parametro del metodo
            */
            Console.WriteLine(escuela);
        }
     }
}
