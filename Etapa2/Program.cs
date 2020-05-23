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
            WriteLine("hola");
            ImprimirCursos(engine);

        }

        private static void ImprimirCursos(EscuelaEngine engine)
        {
            WriteLine("======");
            WriteLine("CURSOS");
            WriteLine("======");
            foreach (var cursos in engine.escuela.colCursos)
            {
                WriteLine($"Curso: {cursos.nombre} ID: {cursos.id} Turno: {cursos.turno}");
            }
        }
    }                                  //ACA TERMINA EL MAIN



}


