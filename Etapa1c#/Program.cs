using System;
using corEscuelaEntidades;

namespace Etapa1c_
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela1= new Escuela("Sancalletano",1994,TiposEscuelas.Primaria,"Argentina","La Plata");
            Console.WriteLine (escuela1);
        }
    }
}
