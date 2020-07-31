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
            
            
            var dic = new Dictionary<int,string>();
            dic.Add(2,"joaquin"); //agregando mediante funcion add, donde 2 es la llave y joaquin la definicion  
            dic[0]="tomas"; //asi agregamos al dic la llave 0 son valor "tomas" 
            Console.WriteLine("Imprimimos el Diccionario");
            foreach (var keydic in dic)
            {
                Console.WriteLine($"llave: {keydic.Key} valor: {keydic.Value}");
            
            }    
            var diccionario2= new Dictionary<string,string>(); //creamos diccionario con un string como llave 
            diccionario2.Add("Tierra","La Tierra es un planeta del sistema solar");
            diccionario2["Luna"]="La Luna es un curpo celeste que orbita al rededor de la Tierra";
            Console.WriteLine("IMPRIMIMOS OTRO DICCIONARIO");
            foreach (var keydic2 in diccionario2)
            {
                Console.WriteLine($"Llave: {keydic2.Key} Valor: {keydic2.Value}");
            }
            Console.WriteLine("OTra forma de imprimir");
            Console.WriteLine(dic[0]);         //asi tmb podemos imprimir los diccionarios
            Console.WriteLine(diccionario2["Tierra"]);//imprime el valor de la llave
        }///LOS DICCIONARIOS NO PUEDEN TENER LLAVES REPETIDAS
    }
}
           
