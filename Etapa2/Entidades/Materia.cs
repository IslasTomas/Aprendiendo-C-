using System;
using System.Collections.Generic;

namespace CorEscuela.Entidades
{
    public class Materia : ObjetoEscuelaBase 
    {      
       public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();

        
        
    }
}