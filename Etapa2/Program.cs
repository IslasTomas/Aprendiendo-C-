using System;
using CorEscuela.Entidades;
using static System.Console;  //con esto cada vez q tenemos que usar funciones Consol no necesitamos poner Console

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            console.writeline("Esto lo hice desde Github");
            var escuela = new Escuela("Saaan cayetano", 1960,
            TiposEscuela.PreEscuela, paisE: "Argentaaina", ciudadE: "La Paalata");   //con cntrl +.  agrega Escuela para tener sus metodos y mas
            /*
           !! escuela.Nombre="SanCa";
              escuela.Ciudad="la plata";!!!
              Como la adorsignacion del nombre y el año la hicimos como parametro de entrada al crear 
              el objeto esto ya no lo usamos y pasamos el nombre y año como parametro del metodo
              */

            var curso1 = new Curso();
            curso1.nombre = "101";
            var curso2 = new Curso();
            curso2.nombre = "201";
            var curso3 = new Curso();
            curso3.nombre = "301";
            var arreglo = new Curso[3];   // asi tmb podemos agregar obetos al arreglo
            arreglo[0] = curso1;
            arreglo[1] = curso2;
            arreglo[2] = curso3;
            escuela.cursos = new Curso[]{
                new Curso{nombre="303"},
                new Curso{nombre="391"}
            };
            Curso[] arreglo2 =        //esta es la forma mas optima de crear un arreglo y cargarlo
            {
                new Curso(){nombre="102"},
                new Curso(){nombre="202"},
                new Curso(){nombre="302"}

             };
            

            curso1.turno = TurnoCurso.Tarde;
            WriteLine(escuela);
            WriteLine("Nombre de  cuerso" + curso1.nombre + "\n" + " ,\n " + curso1.id + "," + curso1.turno);
            WriteLine($"Nombre de curso: {curso1.nombre}, ID: {curso1.id}\nTurno: {curso1.turno}");
            WriteLine($"Nombre de curso: {curso2.nombre}, ID: {curso2.id}\nTurno: {curso2.turno}");
            ImprimirCursos(escuela);
            ImprimirCursosForEach(escuela);
            WriteLine("=================\nARREGLO2");
            ImprimirCursosForEach(escuela);

            ImprimirCursosForEach(escuela);

        }    //aca termina el main
        //FUNCIONES DEFINIDAS

        public static void ImprimirCursos(Escuela escuelaEntrada)  //definimos las funciones fuera del main
        {

            int contador = 0;
            WriteLine("======================================\nCURSOS de la funcion ImprimirCursos");
            if (escuelaEntrada?.cursos != null) //ASI HACEMOS LA MISMA COMPROBACION QUE EN EL OTRO IMPRIMIR
            {
                while (contador < escuelaEntrada.cursos.Length)
                {

                    WriteLine($"Nombre: {escuelaEntrada.cursos[contador].nombre}, Id {escuelaEntrada.cursos[contador].id}, Turno {escuelaEntrada.cursos[contador].turno}");
                    contador++;
                }

            }
            else
            {
                WriteLine("No hay cursos cargados");

            }
        }
        public static void ImprimirCursosForEach(Escuela escuelaEntrada)   //solo paso la escuela y dentro entro a cursos
        {
            WriteLine("======================================\nCURSOS Funcion imprimirCursosForEach");
            if (escuelaEntrada == null || escuelaEntrada.cursos == null)
            {
                WriteLine("No hay cursos en la escuela");
                return;
            }
            else
            {
                foreach (var curso in escuelaEntrada.cursos)       //con foreach entramos en cada curso por eso corremos menos riesgo de errores y es mas eficiente
                {
                    WriteLine($"Nombre: {curso.nombre}, Id {curso.id}, Turno {curso.turno}");
                }
            }

        }

    }
}
