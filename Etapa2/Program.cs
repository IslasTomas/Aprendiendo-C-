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
            foreach (var item in promedio)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine(item.Key.ToUpper());
                Console.WriteLine("---------------------");
                foreach (var alum in item.Value)
                {
                    Console.WriteLine($"Alumno: {alum.alumnoNombre} Promedio: {alum.promedio}");
                }
            }
        }

          private static void AccionDelEvento(object sender, EventArgs e)
        {
            Console.Beep(2000,1000);
        }
    }
}

