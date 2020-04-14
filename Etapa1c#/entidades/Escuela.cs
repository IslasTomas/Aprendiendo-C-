namespace corEscuelaEntidades
{
    class Escuela
    {
        string nombre;       
        public string Nombre {
            get{return nombre;}
            set{nombre=value.ToUpper();}
        }
        public int añoCreacion{get;set;}
        public string pais{get;set;} 
        public string ciudad { get; set; }
        public TiposEscuelas tipoEscuela {get;set;}

        public Escuela(string nombreE, int añoE, TiposEscuelas tipo,string paisE="",string ciudadE="")
        {
            (Nombre,añoCreacion,tipoEscuela)=(nombreE,añoE,tipo);
            pais=paisE;
            ciudad=ciudadE;
        }
        public override string ToString()
        {
            return $"Nombre: {Nombre},Año de Creacion: {añoCreacion}\nTipo de Escuela: {tipoEscuela}\nPais: {pais}, Ciudad: {ciudad}";
        }

    }
    
}