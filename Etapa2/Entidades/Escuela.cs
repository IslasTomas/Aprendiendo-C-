using System.Collections.Generic;
using System;

namespace CorEscuela.Entidades
{
    public class Escuela : ObjetoEscuelaBase, ILugar
    {
        //.ToUpper()  esta funcion lo combiertte en mayuscula                
        //las propiedades Son de los atributos q tiene atras
        public int AñoDeCreacion { get; set; } //esto crea otro atributo con q no sabemos el nombre pero n
                                               //nos vamos a referir a el por el nombre de la propiedad
                                               //Y UTILIZA LAS FUNCIONES GET Y SET Q YA DEFINIMOS  
        public Escuela(string pais, string ciudad, TiposEscuela tipoEscuela)
        {
            this.Pais = pais;
            this.Ciudad = ciudad;
            this.TipoEscuela = tipoEscuela;

        }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public List<Curso> Cursos { get; set; }

        #region comentariosUtiles
        // public Curso[] cursos { get; set; }

        /* public Escuela(string nombreEntrada){    //aca le que hacemos es que al crear el objeto se le tenga 
                                               // q pasar el nombre como parametro
           nombre=nombreEntrada; 

           public Escuela(string nombre,int año){   aca lo hacemos con 2 entradas por parametro
               this.nombre=nombre;       //El this.nombre es el que referencia a la clase, el otro es el de entrada
               AñoDeCreacion=año;  */
        #endregion
        public TiposEscuela TipoEscuela { get; set; }
        string ILugar.Direccion { get; set;} 
        public void LimpiarLugar()
        {
            Console.WriteLine("LIMPIANDO ESCUELA");
            foreach (var curso in Cursos)
            {
                curso.LimpiarLugar();
            }
            Console.WriteLine($"ESCUELA {Nombre} Limpia");
        }

        #region Contructores y Tostring
        public Escuela(string nombreE, int añoE) => (Nombre, AñoDeCreacion) = (nombreE, añoE);


        //Esta es la forma correcta de hacer la creacion del objeto con parametros de entrada 
        // la asignacion la hacemos a travez de las propiedades.
        public Escuela(string nombreE, int añoE, TiposEscuela tipos,
                string paisE = "", string ciudadE = "")     //al poner "" en la asignacion decimos q es opcional
        {
            (Nombre, AñoDeCreacion, TipoEscuela) = (nombreE, añoE, tipos);

            Pais = paisE;
            Ciudad = ciudadE;
        }
        //        podemos definir tantos constructores como qeremos(los public Escuela q hicimos)
        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela}\nPais: {Pais}, Ciudad: {Ciudad}";
            //el \n lo podemos reemplazar por {System.Environment.NewLine} ya q \n no funciona en todos los sistemas operativos
        }

        void ILugar.LimpiarLugar()
        {
            throw new System.NotImplementedException();
        }
        #endregion

    }
}
