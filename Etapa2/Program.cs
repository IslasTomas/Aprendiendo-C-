﻿using System;
using CorEscuela.Entidades;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {  

            var escuela= new Escuela("Saaan cayetano" , 1960,
            TiposEscuela.PreEscuela, paisE:"Argentaaina",ciudadE: "La Paalata");   //con cntrl +.  agrega Escuela para tener sus metodos y mas
          /*
         !! escuela.Nombre="SanCa";
            escuela.Ciudad="la plata";!!!
            Como la adorsignacion del nombre y el año la hicimos como parametro de entrada al crear 
            el objeto esto ya no lo usamos y pasamos el nombre y año como parametro del metodo
            */

            var curso1=new Curso();
            curso1.nombre="101";
            var curso2=new Curso();
            curso2.nombre="201";
            var curso3=new Curso();
            curso3.nombre="301";
            var arreglo = new Curso[3];
            arreglo[0]=curso1;
            arreglo[1]=curso2;
            arreglo[2]=curso3;
            
            curso1.turno=TurnoCurso.Tarde;
            Console.WriteLine(escuela);
            Console.WriteLine("Nombre de  cuerso"+curso1.nombre +"\n"+" ,\n "+curso1.id +"," + curso1.turno );
            Console.WriteLine($"Nombre de curso: {curso1.nombre}, ID: {curso1.id}\nTurno: {curso1.turno}" );
            Console.WriteLine($"Nombre de curso: {curso2.nombre}, ID: {curso2.id}\nTurno: {curso2.turno}" );
            ImprimirCursos(arreglo);
        }    //aca termina el main

            public static void ImprimirCursos(Curso[] arregloEntrada)  //definimos las funciones fuera del main
            {
       
                int contador=0;
                System.Console.WriteLine("======================================\nCURSOS");
                while (contador <arregloEntrada.Length)
                {
                    
                    System.Console.WriteLine($"Nombre: {arregloEntrada[contador].nombre}, Id {arregloEntrada[contador].id}, Turno {arregloEntrada[contador].turno}");
                    contador++;
                }

            }
        
    }
}