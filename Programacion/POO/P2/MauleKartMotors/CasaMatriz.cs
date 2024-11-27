using System;

namespace MauleKartMotors
{
    //Clase (plantilla de casa matriz)
    class CasaMatriz
    {
        //Atributos de casa matriz
        private string _calle;
        private int _numero;
        private string _direccion;
        
        //Properties de casa matriz
        public string Calle
        {
            get {return this._calle;}
            set {this._calle = value;}
        }

        public int Numero
        {
            get {return this._numero;}
            set {this._numero = value;}
        }public string Direccion
        {
            get {return this._direccion;}
            set {this._direccion = value;}
        }

        //Constructor por defecto
        public CasaMatriz()
        {

        }

        //Constructor con parámetros
        public CasaMatriz(string calle="", int numero=0, string direccion="")
        {
            this._calle = calle;
            this._numero = numero;
            this._direccion = direccion;
            Console.WriteLine($"Casa Matriz creada correctamente!!!");
        }

        //Método ToString (obtener valores de atributos que toma un objeto de la clase)
        public override string ToString()
        {
            return $"Calle: {this._calle} - Numero: {this._numero} - Direccion: {this._direccion}";
        }

    }
}