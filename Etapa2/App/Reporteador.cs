using System.Collections.Generic;
using CorEscuela.Entidades;
using System;
using System.Linq;


namespace CorEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;// el _ es una convencion para indicar q es privado
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObjEsc)
        {
            if (dicObjEsc == null) // comprobamos q el parametro no sea null
            {
                Console.WriteLine("--------------------\nInforma  por medio de un error que el diccionario es NULL");
                throw new ArgumentNullException(nameof(dicObjEsc));
                //throw da una informe de error
            }

            _diccionario = dicObjEsc;
        }
        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {
            var lista = _diccionario.GetValueOrDefault(LlaveDiccionario.Evaluaciones);//develve el valor especificado, sino lo encuentra retorna null
            var respuesta = _diccionario.TryGetValue(LlaveDiccionario.Evaluaciones, out IEnumerable<ObjetoEscuelaBase> listado);
            //TryGetValue va a devolver un booleano, si la lista existe en el dicc va a ser true y en el output (salida) nos da la lista
            // si no encontro la lista devuelve false
            //return listado.Cast<Evaluacion>(); de esta forma retornamos el output de TryGetValue

            //mejor forma de implementacion
            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluaciones, out IEnumerable<ObjetoEscuelaBase> listado2))
            {
                return listado2.Cast<Evaluacion>();
            }
            else
            {
                Console.WriteLine($"la LLave {LlaveDiccionario.Evaluaciones} esta vacia");
                return new List<Evaluacion>();
            }

        }
        public IEnumerable<string> GetListaMaterias()  //sobrecargadel metoro GetListaMaterias de esta forma podemos usar el metodo sin un parametrp de salida
        {
            return GetListaMaterias(out var dummy);
        }
        public IEnumerable<string> GetListaMaterias(out IEnumerable<Evaluacion> listaEvaluaciones)// salida la lista de evaluaciones
        {
            listaEvaluaciones = GetListaEvaluaciones();
            //   return (from ev in listaEvaluaciones  //esto lo hacemos con Linq(nos permite hacer consultas similares a un query)
            //          select ev.Materia.Nombre);    //esto de cada "ev" selecciona el nombre de la materia q corresponde
            return (from ev in listaEvaluaciones
                        //Where  ev.Nota > 3.0f  (con ese where podemos filtrar em cada parametro de "ev" 
                    select ev.Materia.Nombre).Distinct(); // con el funcion Distinct solo va a devolver "ev.materia.nombre" que sean distintos

        }
        public Dictionary<string, IEnumerable<Evaluacion>> GetDicEvaluacionesXMateria()
        {
            var dic = new Dictionary<string, IEnumerable<Evaluacion>>();
            var materias = GetListaMaterias(out var evalus);
            foreach (var mat in materias)
            {
                var evls = (from ev in evalus
                            where ev.Materia.Nombre == mat
                            select ev);
                dic.Add(mat, evls);
            }
            return dic;
        }

        public Dictionary<string, IEnumerable<AlumnoPromedio>> GetPromedioAlumnosPorMateria()
        {
            var rta = new Dictionary<string, IEnumerable<AlumnoPromedio>>();
            var dicEvalXMaterias = GetDicEvaluacionesXMateria();
            foreach (var asigConEval in dicEvalXMaterias)
            {
                var promedioAlumnos = from eval in asigConEval.Value
                            group eval by new {eval.Alumno.UniqueId,//agrupa todos los objetos eval que tengan el mismo UniqueId
                            eval.Alumno.Nombre}
                            into grupoEvalsAlumno             //"into" agrupa todos los objetos eval del mismo ID en "grupoEvalsAlumno"
                            
                            select new AlumnoPromedio          
                            {                           
                                alumnoid = grupoEvalsAlumno.Key.UniqueId,   //la llave es el atributo por el cual agrupamos, en este caso el UniqueID de cada eval
                                promedio = grupoEvalsAlumno.Average(evaluacion=> evaluacion.Nota),
                                alumnoNombre = grupoEvalsAlumno.Key.Nombre                                
                                //promedio es un atributo del objeto anonimo que creamos
                                //a promedio le asignamos, el promedio de las notas que tenia cada objeto eval
                                //el promedio lo obtuvimos de la funcion "Average()" que calcula el promedio del grupo que definimos anteriormente
                                //linq no ofrece muchas mas funciones para el grupo
                            };
                rta.Add(asigConEval.Key,promedioAlumnos);
            }


            
            return rta;

        }

    }
}
