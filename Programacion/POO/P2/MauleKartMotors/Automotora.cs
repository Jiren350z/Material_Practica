using System;
using System.Collections.Generic;

namespace MauleKartMotors
{
    
    //Clase (plantilla de automotora)
    class Automotora
    {
        //Atributos de automotora
        private string _nombre;
        private List<Auto> _autos;
        private CasaMatriz _casamatriz;

        //Properties de automotora
        public string Nombre{
            get{return this._nombre;}
            set{this._nombre = value;}
        }

        public List<Auto> Autos{
            get{return this._autos;}
            set{this._autos = value;}
        }

        public CasaMatriz casamatriz{
            get{return this._casamatriz;}
            set{this._casamatriz = value;}
        }

        //Constructor por defecto
        public Automotora()
        {
            this._nombre = "";
            //Declararar lista vacía (nunca incializarla como null, solo vacía)
            this._autos = new List<Auto>(){};
            this._casamatriz = null;
        }

        //Constructor con parámetros
        public Automotora(string nombre,List<Auto> autos, string calle, int numero, string direccion)
        {
            this._nombre = nombre;
            this._autos = new List<Auto>(){};
            this._casamatriz = new CasaMatriz(calle,numero,direccion);
            Console.WriteLine("Automotora creada correctamente!!!");
        }

        //Método ToString (obtener valores de atributos que toma un objeto de la clase)
        public override string ToString()
        {
            return $"Automotora: {this._nombre}";
        }

        //Método para buscar si un auto ya existe en base a una patente
        public Auto buscarPorPatente(string patente){
            //Recorrer la lista de autos
            foreach (Auto aux in this._autos){
                //Si la patente coincide con una de los objetos autos de la lista
                if (aux.Patente == patente){
                    //Se retorna el auto encontrado
                    return aux;
                }
            }
            //Si no se encuentra un auto con la patente indicada se retorna null
            return null;
        }

        //Método para agregar un nuevo auto en la automotora
        public void agregarAuto(Auto auto){
            //Se determina antes de agregarlo si no existe con ya uno con la misma patente 
            if (buscarPorPatente(auto.Patente)==null){
                this._autos.Add(auto);
                Console.WriteLine("Auto agregado correctamente a la Automotora");
            }
            else
            {
                Console.WriteLine($"Auto con patente {auto.Patente} ya existe");
            }
        }

        //Metodo para obtener la lista completa de autos agregados a la automotora
        public void verAutos()
        {
             foreach (Auto aux in this._autos){
                Console.WriteLine(aux.ToString());
            }
        }

        //Metodo para eliminar un auto existente en la automotora
        public void eliminarAuto(Auto auto)
        {
            //Se determina antes de eliminarlo si existe la patente 
            if (buscarPorPatente(auto.Patente)!=null){
                this._autos.Remove(auto);
                Console.WriteLine("Auto eliminado correctamente a la Automotora");
            }
            else
            {
                Console.WriteLine($"Auto con patente {auto.Patente} no existe en la automotora");
            }
        }

        //Metodo para buscar una serie de autos por marca en la automotora
        public List<Auto> buscarPorMarca(string marca)
        {
            //Se crea una nueva lista vacia (no nula) para guardar los autos de una marca especifica
            List<Auto> autosPorMarca = new List<Auto>(){};
            //Ciclo para buscar en la lista de autos de la automotora los de una marca especifica
            foreach (Auto aux in this._autos){
                //Si la patente coincide con una de los objetos autos de la lista
                if (aux.Marca == marca){
                    //Se agrega a la lista de autos de la marca buscada
                    autosPorMarca.Add(aux);
                }
            }
            //Retorna la nueva lista filtrada
            return autosPorMarca;
        }

        //Metodo para buscar una serie de autos por rango de kilometraje
        public List<Auto> buscarPorKilometraje(double min, double max)
        {
            //Se crea una nueva lista vacia (no nula) para guardar los autos de kilometraje en rango solicitado
            List<Auto> autosPorKilometraje = new List<Auto>(){};
            //Ciclo para buscar en la lista de autos de la automotora los de un kilometraje en rango especifico
            if (min<=max){
                foreach (Auto aux in this._autos){
                    //Si la patente coincide con una de los objetos autos de la lista
                    if (aux.Kilometraje>=min && aux.Kilometraje<=max){
                        //Se agrega a la lista de autos de kilometraje esperado
                        autosPorKilometraje.Add(aux);
                    }
                }
            }
            else{
                Console.WriteLine("Valor minimo debe ser menor o igual al maximo");
            }
            //Retorna la nueva lista filtrada
            return autosPorKilometraje;
        }        

        //Metodo para buscar una serie de autos por modelo en la automotora
        public List<Auto> buscarPorModelo(string modelo)
        {
            //Se crea una nueva lista vacia (no nula) para guardar los autos de un modelo especifico
            List<Auto> autosPorModelo = new List<Auto>(){};
            //Ciclo para buscar en la lista de autos de la automotora los de una marca especifica
            foreach (Auto aux in this._autos){
                //Si la patente coincide con una de los objetos autos de la lista
                if (aux.Modelo == modelo){
                    //Se agrega a la lista de autos del modelo buscado
                    autosPorModelo.Add(aux);
                }
            }
            //Retorna la nueva lista filtrada
            return autosPorModelo;
        }
    }
}