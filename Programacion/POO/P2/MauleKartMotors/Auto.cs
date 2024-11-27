using System;

namespace MauleKartMotors
{
    class Auto
    {
        //Atributos de un auto
        private string _patente;
        private string _marca;
        private string _modelo;
        private double _kilometraje;
        
        //Properties de un auto
        public string Patente
        {
            get {return this._patente;}
            set {this._patente = value;}
        }

        public string Marca
        {
            get {return this._marca;}
            set {this._marca = value;}
        }

        public string Modelo
        {
            get {return this._modelo;}
            set {this._modelo = value;}
        }

        public double Kilometraje
        {
            get {return this._kilometraje;}
            set {this._kilometraje = value;}
        }

        //Constructor por defecto
        public Auto()
        {

        }
        //Constructor con parámetros
        public Auto(string patente="", string marca = "", string modelo="", double kilometraje=0)
        {
            this._patente = patente;
            this._marca = marca;
            this._modelo = modelo;
            this._kilometraje = kilometraje;
            Console.WriteLine($"Auto creado correctamente!!!");
        }
        //Método ToString (obtener valores de atributos que toma un objeto de la clase)
        public override string ToString()
        {
            return $"Patente: {this._patente} - Marca: {this._marca} - Modelo: {this._modelo} - Kilometraje: {this._kilometraje}";
        }

    }
}