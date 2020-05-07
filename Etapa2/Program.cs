using System;
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
            ImprimirCursos(engine.escuela);
        }                                  //ACA TERMINA EL MAIN

        private static void ImprimirCursos(Escuela escuela)
        {
            WriteLine($"CURSOS DE LA ESCUELA {escuela.Nombre}");
            WriteLine("=====================================");
            foreach (var cursos in escuela.colCursos)
            {
                WriteLine($"Curso: {cursos.nombre}  ID: {cursos.id}  Turno: {cursos.turno}");
            }
        }
    }
}

