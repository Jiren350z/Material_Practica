using System;
using System.Collections.Generic;

namespace MauleKartMotors
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("==============AUTOMOTORA MAULE KART MOTORS=============");
            Console.WriteLine();
            Console.WriteLine();
            //Crear la lista de autos vacia
            List<Auto> autos = new List<Auto>(){};
            //Creando una automotora
            Automotora a = new Automotora("Maule Kart Motors",autos,"18 norte",1234,"Av Lircay");
            //Datos de la casa matriz
            Console.WriteLine("\n=====Datos Casa Matriz====");
            Console.WriteLine($"Calle: {a.casamatriz.Calle}");
            Console.WriteLine($"Numero: {a.casamatriz.Numero}");
            Console.WriteLine($"Direccion: {a.casamatriz.Direccion}");
            Console.WriteLine();
            //Creando objetos autos
            Auto auto1 = new Auto("JFGF-33","KIA","MORNING",0.0);
            Auto auto2 = new Auto("ASDF-12","CHEVROLET","SAIL",123.4);
            Auto auto3 = new Auto("XCVB-45","FORD","MUSTANG",12.5);
            Auto auto4 = new Auto("ASKJ-11","KIA","CERATTO",100.5);
            Auto auto5 = new Auto("DFFFG-99","VOLKSWAGEN","GOLF",200.6);
            //Agregando objetos autos a la automotora
            Console.WriteLine();
            a.agregarAuto(auto1);
            a.agregarAuto(auto2);
            a.agregarAuto(auto3);
            a.agregarAuto(auto4);
            a.agregarAuto(auto5);
            Console.WriteLine();
            //Mostrar autos de la automotora
            Console.WriteLine($"=====Autos disponibles en {a.Nombre}====");
            a.verAutos();
            //Buscar un auto por patente determinada
            Console.WriteLine();
            string patente;
            Console.WriteLine("====Buscar por patente====");
            Console.Write("Indique la patente a buscar: ");
            patente = "" + Console.ReadLine().ToUpper();
            Auto auto = a.buscarPorPatente(patente);
            //Validar si se encuentra el auto
            if (auto!=null){
                Console.WriteLine(auto.ToString());
            }
            else{
                Console.WriteLine($"Auto con patente {patente} no encontrado!!!");
            }
            //Obtener lista de autos de la automotora de una marca determinada
            Console.WriteLine();
            string marca;
            Console.WriteLine("====Buscar por marca====");
            Console.Write("Indique la marca a buscar: ");
            marca = "" + Console.ReadLine().ToUpper();
            //Crear lista para guardar valor que retorna el metodo
            List<Auto> listaPorMarca = a.buscarPorMarca(marca);
            Console.WriteLine();
            Console.WriteLine("====Lista Obtenida====");
            //Si la lista no esta vacia
            if (listaPorMarca.Count>0){
                foreach (Auto aux in listaPorMarca){
                    Console.WriteLine(aux.ToString());
                }
            }
            else{
                Console.WriteLine("No se encontraron resultados");
            }
            //Obtener lista de autos de la automotora de un modelo determinado
            Console.WriteLine();
            string modelo;
            Console.WriteLine("====Buscar por modelo====");
            Console.Write("Indique modelo a buscar: ");
            modelo = "" + Console.ReadLine().ToUpper();
            //Crear lista para guardar valor que retorna el metodo
            List<Auto> listaPorModelo = a.buscarPorModelo(modelo);
            Console.WriteLine();
            //Si la lista no esta vacia
            if (listaPorModelo.Count>0){
                Console.WriteLine("====Lista Obtenida====");
                foreach (Auto aux in listaPorModelo){
                    Console.WriteLine(aux.ToString());
                }
            }
            else{
                Console.WriteLine("No se encontraron resultados");
            }
            //Obtener lista de autos de la automotora de un rango de kilometraje
            Console.WriteLine();
            double kil_min, kil_max;
            Console.WriteLine("====Buscar por kilometraje====");
            Console.Write("Indique valor kilometraje minimo a buscar: ");
            kil_min = Convert.ToInt32(Console.ReadLine());
            Console.Write("Indique valor kilometraje maximo a buscar: ");
            kil_max = Convert.ToInt32(Console.ReadLine());
            //Crear lista para guardar valor que retorna el metodo
            List<Auto> listaPorKilometraje = a.buscarPorKilometraje(kil_min,kil_max);
            Console.WriteLine();
            //Si la lista no esta vacia
            if (listaPorKilometraje.Count>0){
                Console.WriteLine("====Lista Obtenida====");
                foreach (Auto aux in listaPorKilometraje){
                    Console.WriteLine(aux.ToString());
                }
            }
            else{
                Console.WriteLine("No se encontraron resultados");
            }
            Console.WriteLine();
        }
    }
}