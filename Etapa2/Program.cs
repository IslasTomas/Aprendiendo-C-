using System;
using CorEscuela;
using CorEscuela.Entidades;
using static System.Console;  //con esto cada vez q tenemos que usar funciones Consol no necesitamos poner Console
using System.Collections.Generic;
using System.Linq;
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
            int dummy = 0;
            ///la usamos para reemplazar algun parametro de salida q no nos interese
            var listaObjetosEscuela = engine.listarObjetosEscuela(
            out int conteoAlumnos,
            out int conteoMaterias,
            out dummy, ///con dummy descartamos esa salida
            out dummy
            );
            ///Los parametros de salida podemos verlos en el debug 
            //filtramos los objetos por medio de la interfaz que implementan
            //usamos system.LINQ para filtrar 
            var listarILugar = from obj in listaObjetosEscuela
                               where obj is Evaluacion
                               select (Evaluacion)obj;
        }
    }
}
           
