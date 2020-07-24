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
            var listaObjetosEscuela = engine.listarObjetosEscuela();

            //filtramos los objetos por medio de la interfaz que implementan
            //usamos system.LINQ para filtrar 
            var listarILugar = from obj in listaObjetosEscuela
                                where obj is ILugar
                                select (ILugar) obj; 


        }

       
    }                                  //ACA TERMINA EL MAIN



}


