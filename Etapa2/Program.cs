using System;
using CorEscuela;
using CorEscuela.Entidades;
using static System.Console;  //con esto cada vez q tenemos que usar funciones Consol no necesitamos poner Console
using System.Collections.Generic;
namespace CorEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();
            // ImprimirCursos(engine.escuela);
            WriteLine("Hola");
            engine.ImprimirCursosYMaterias();
            engine.Escuela.LimpiarLugar();


        }

       
    }                                  //ACA TERMINA EL MAIN



}


