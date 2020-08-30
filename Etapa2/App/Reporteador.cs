using System.Collections.Generic;
using CorEscuela.Entidades;
using System;
using System.Linq;


namespace CorEscuela.App
{
    public class Reporteador
    {
        Dictionary <LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;// el _ es una convencion para indicar q es privado
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
        public IEnumerable<Evaluacion> GetListaEvaluacion()
        {
            var lista = _diccionario.GetValueOrDefault(LlaveDiccionario.Evaluaciones);//develve el valor especificado, sino lo encuentra retorna null
            var respuesta = _diccionario.TryGetValue(LlaveDiccionario.Evaluaciones, out IEnumerable<ObjetoEscuelaBase> listado);
            //TryGetValue va a devolver un booleano, si la lista existe en el dicc va a ser true y en el output (salida) nos da la lista
            // si no encontro la lista devuelve false
            //return listado.Cast<Evaluacion>(); de esta forma retornamos el output de TryGetValue

            //mejor forma de implementacion
            IEnumerable<Evaluacion> respuesta2;
            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluaciones, out IEnumerable<ObjetoEscuelaBase> listado2))
            {
                respuesta2=listado2.Cast<Evaluacion>();
            }
            else
            {
                Console.WriteLine($"la LLave {LlaveDiccionario.Evaluaciones} esta vacia");
                respuesta2=null;
            }
            return respuesta2;
        }

    }
}
