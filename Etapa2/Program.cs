using System;
using CorEscuela.App;
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
            ///EVENTOS
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            AppDomain.CurrentDomain.ProcessExit += (o,e)=> Console.Beep(2000,500); // Multicast : Se ejecutan los 2 eventos de diferente manera
            AppDomain.CurrentDomain.ProcessExit -= AccionDelEvento; // saco ese evento con el - es  decir no se ejecuta
            //Este es un evento de finalizacion del programa
            // El  EVENTO se genera en cualquier momento que termine la ejecucion
            var engine = new EscuelaEngine();
            engine.Inicializar();
            // ImprimirCursos(engine.escuela);
            WriteLine("Hola");


            var dic = new Dictionary<int, string>();
            dic.Add(2, "joaquin"); //agregando mediante funcion add, donde 2 es la llave y joaquin la definicion  
            dic[0] = "tomas"; //asi agregamos al dic la llave 0 son valor "tomas" 
            Console.WriteLine("Imprimimos el Diccionario");
           // foreach (var keydic in dic)
           // {
           //     Console.WriteLine($"llave: {keydic.Key} valor: {keydic.Value}");
           //  }
            var dicc = engine.GetDiccionarioDeObjetos();
            Console.WriteLine();
            //var dic2 = engine.GetDiccionarioDeObjetos();
            //engine.ImprimirDiccionario(dic2,true);
            var reporteardor= new Reporteador(dicc);
            var listEval= reporteardor.GetListaEvaluaciones();
            var listaMaterias= reporteardor.GetListaMaterias();
            var DiccionarioEvaluaciones= reporteardor.GetDicEvaluacionesXMateria();
            var promedio=reporteardor.GetPromedioAlumnosPorMateria();
            var newEval= new Evaluacion();
            string nombre,notaString;
            WriteLine("Ingrese nombre de la evaluacion");
            nombre=ReadLine();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("Debe ingresar un nombre");
            }
            else
            {
               newEval.Nombre=nombre.ToLower();
               WriteLine("El nombre fue ingresado correctamente"); 
            }
            WriteLine("Ingrese nota de la evaluacion");
            notaString=ReadLine();
            if (string.IsNullOrWhiteSpace(notaString))
            {
               WriteLine("Debe ingresar una nota"); 
               WriteLine("Saliendo del programa");
            }
            else
            {
                try{
                newEval.Nota=float.Parse(notaString);
                if (newEval.Nota <0 || newEval.Nota >5)
                {
                   throw new ArgumentOutOfRangeException("La nota debe estar entre 0 y 5");
                   //este throw se usa para que salga del programa y no continue
                }
                WriteLine("La nota fue ingresada correctamente");
                }
                catch(ArgumentOutOfRangeException arge)  //se le puede hacer un objeto 
                {
                    WriteLine(arge.Message);
                    WriteLine("La nota debe ser un numero entre 0 y 5");
                }
                catch(Exception)
                {
                   WriteLine("El valor de la nota no es un numero valido");
                }
                //dependiendo el tipo de exception ejecuta un catch o el otro
                // las excepciones tiene un orden en cascada, EL ORDEN ES IMPORTANTE
            }
        }

          private static void AccionDelEvento(object sender, EventArgs e)
        {
            Console.Beep(2000,1000);
        }
    }
}

