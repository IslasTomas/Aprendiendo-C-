using System.Collections.Generic;
using CorEscuela.Entidades;
using System;


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
        public IEnumerable<ObjetoEscuelaBase> GetListaEvaluacion()
        {
            return _diccionario[LlaveDiccionario.Evaluaciones];
        }

    }
}
