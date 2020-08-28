using System;
using System.Collections.Generic;
using System.Linq;
using CorEscuela.Entidades;
using static System.Console;

namespace CorEscuela
{
    class EscuelaEngine
    {
        public Escuela Escuela { get; set; }
        
        
        ///cargamos el diccionario
        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioDeObjetos()
        {///el IEnumerable engloba tnato listas como arreglos, asi podemos cargar listas en el diccionario
            #region Explicacion del diccionario
            ///el diccionario es una IEnumerable de objetos xq sino no puedo enviar muchos objetos con una clave
            /// y no es una lista xq los cursos al ser una lista de cursos, nos da error ya que tenemos que definir explicitamente el tipo para 
            /// que funcione el diccionario, por lo que la funcion Cast, nos deja convertirlos en tipo objeto escuela, pero lo retorna como IEnumerable
            #endregion
            var diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();
            diccionario.Add(LlaveDiccionario.Escuela, new[] { Escuela });
            diccionario.Add(LlaveDiccionario.Curso, Escuela.Cursos.Cast<ObjetoEscuelaBase>());
            var auxMaterias = new List<ObjetoEscuelaBase>();
            var auxAlumnos = new List<ObjetoEscuelaBase>();
            var auxEvaluaciones = new List<ObjetoEscuelaBase>();
            foreach (var cur in Escuela.Cursos)
            {
                auxMaterias.AddRange(cur.Materias);
                auxAlumnos.AddRange(cur.Alumnos);
                foreach (var alum in cur.Alumnos)
                {
                    auxEvaluaciones.AddRange(alum.Evaluaciones);
                }
            }
            diccionario.Add(LlaveDiccionario.Alumno, auxAlumnos);
            diccionario.Add(LlaveDiccionario.Materia, auxMaterias);
            diccionario.Add(LlaveDiccionario.Evaluaciones, auxEvaluaciones);
            return diccionario;
        }
        ///imprimimos un diccionario
        public void ImprimirDiccionario()
        {}
        public void Inicializar()
        {
            Escuela = new Escuela("Saaan cayetano", 1960,
            TiposEscuela.PreEscuela, paisE: "Argentaaina", ciudadE: "La Plata");
            CargarCursos();
            CargarMaterias();
            CargarAlumnos();
            CargarEvaluaciones();
            //  var listadoObjetos = listarObjetosEscuela();

        }
        /// Lista todos los objetos creados que heredaron ObjetoEscuelaBase
        #region listarObjetosEscuela

        public IReadOnlyList<ObjetoEscuelaBase> listarObjetosEscuela(
            out int conteoAlumnos,
            out int conteoMaterias,
            out int conteoCursos,
            out int conteoEvaluaciones,
            bool traeCursos = true,
            bool traeAlumnos = true,
            bool traeMaterias = true,
            bool traeEvaluaciones = true)
        {
            conteoAlumnos = conteoMaterias = conteoCursos = conteoEvaluaciones = 0;
            List<ObjetoEscuelaBase> listaObjetos = new List<ObjetoEscuelaBase>();
            listaObjetos.Add(Escuela);
            conteoCursos = Escuela.Cursos.Count;
            foreach (var cursos in Escuela.Cursos)
            {
                conteoMaterias = cursos.Materias.Count;
                conteoAlumnos = cursos.Alumnos.Count;
                if (traeCursos)
                { listaObjetos.Add(cursos); }
                if (traeMaterias)
                { listaObjetos.AddRange(cursos.Materias); }
                foreach (var alumnos in cursos.Alumnos)
                {
                    conteoEvaluaciones += alumnos.Evaluaciones.Count;
                    if (traeAlumnos)
                    { listaObjetos.Add(alumnos); }
                    if (traeEvaluaciones)
                    { listaObjetos.AddRange(alumnos.Evaluaciones); }
                }
            }
            return listaObjetos.AsReadOnly();
        }

        public IReadOnlyList<ObjetoEscuelaBase> listarObjetosEscuela(
            bool traeCursos = true,
            bool traeAlumnos = true,
            bool traeMaterias = true,
            bool traeEvaluaciones = true
        )
        {
            return listarObjetosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }


        public IReadOnlyList<ObjetoEscuelaBase> listarObjetosEscuela(
            out int conteoAlumnos,
            bool traeCursos = true,
            bool traeAlumnos = true,
            bool traeMaterias = true,
            bool traeEvaluaciones = true
        )
        {
            return listarObjetosEscuela(out conteoAlumnos, out int dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> listarObjetosEscuela(
            out int conteoAlumnos,
            out int conteoMaterias,
            bool traeCursos = true,
            bool traeAlumnos = true,
            bool traeMaterias = true,
            bool traeEvaluaciones = true
        )
        {
            return listarObjetosEscuela(out conteoAlumnos, out conteoMaterias, out int dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> listarObjetosEscuela(
            out int conteoAlumnos,
            out int conteoMaterias,
            out int conteoCursos,
            bool traeCursos = true,
            bool traeAlumnos = true,
            bool traeMaterias = true,
            bool traeEvaluaciones = true
        )
        {
            return listarObjetosEscuela(out conteoAlumnos, out conteoMaterias, out conteoCursos, out int dummy);
        }
        #endregion
        private void CargarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var materia in curso.Materias)
                {
                    foreach (var alumno in curso.Alumnos)
                    {

                        for (int i = 0; i < 5; i++)
                        {
                            var rnd = new Random();   //numeros ramdom para la nota de las evaluaciones
                            var ev = new Evaluacion
                            {
                                Materia = materia,
                                Nombre = $"{materia.Nombre} Ev#{i + 1}",
                                Nota = (float)(5 * rnd.NextDouble()), //agregando float transformamos el numero en flotante
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);          //agregamos el examen a alumno                                     //rnd.NextDouble genera numero del 0.0 al 1.0 
                        }
                    }

                }
            }

        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombres1 = { "Tomas", "Joaquin", "Mateo", "Umma", "Renata", "Johanna", "pepito" };
            string[] apellidos = { "Islas", "Gualtieri", "Rodriguez", "Casarini", "Perez" };
            string[] nombres2 = { "Rolando", "Graciela", "Blanca", "Gisele" };
            var listadoAlumnos = from n1 in nombres1
                                 from n2 in nombres2
                                 from a1 in apellidos
                                 select new Alumno() { Nombre = $"{n1} {n2} {a1}" };
            return (listadoAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList());
        }
        private void CargarAlumnos()
        {
            var rnd = new Random();

            foreach (var curso in Escuela.Cursos)
            {
                curso.Alumnos.AddRange(GenerarAlumnosAlAzar(rnd.Next(5, 20)));
            }
        }

        private void CargarMaterias()
        {
            foreach (var curso in Escuela.Cursos)
            {
                curso.Materias = new List<Materia>()
               {
                   new Materia{Nombre="Matematicas"},
                   new Materia{Nombre="Lengua"},
                   new Materia{Nombre="Ingles"},
                   new Materia{Nombre="Musica"}
               };
            }
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                  new Curso{Nombre="1001",turno=TurnoCurso.Noche},
                  new Curso{Nombre="2001",turno=TurnoCurso.Noche},
                  new Curso{Nombre="3001",turno=TurnoCurso.Mañana},
                  new Curso{Nombre="4001",turno=TurnoCurso.Mañana},
                  new Curso{Nombre="5001",turno=TurnoCurso.Noche}
            };
        }

        public void ImprimirCursosYMaterias()
        {
            WriteLine("======");
            WriteLine("CURSOS");
            WriteLine("======");
            foreach (var cursos in Escuela.Cursos)
            {
                WriteLine($"Curso: {cursos.Nombre} ID: {cursos.UniqueId} Turno: {cursos.turno}");
                foreach (var materia in cursos.Materias)
                {
                    WriteLine($"Materia: \"{materia.Nombre}\" ID: \"{materia.UniqueId}\"");
                }
            }
        }

    }
}