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


            var dic = new Dictionary<int, string>();
            dic.Add(2, "joaquin"); //agregando mediante funcion add, donde 2 es la llave y joaquin la definicion  
            dic[0] = "tomas"; //asi agregamos al dic la llave 0 son valor "tomas" 
            Console.WriteLine("Imprimimos el Diccionario");
            foreach (var keydic in dic)
            {
                Console.WriteLine($"llave: {keydic.Key} valor: {keydic.Value}");

            }
            var dicc = engine.GetDiccionarioDeObjetos();
            Console.WriteLine();

        }
    }
}

