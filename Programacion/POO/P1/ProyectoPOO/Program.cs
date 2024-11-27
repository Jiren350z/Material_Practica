using System;
namespace ProyectoPOO
{
    class MarioBrother
    {
       //Atributos
        private string _nombre;

        private DateTime _fechaNacimiento;

        private int _vidas;

        private int _monedas;

        private string _estado;

        private string _color;

        //Propiedades
        public string Nombre
        {
            get{return this._nombre;}
            set{this._nombre = value;}
        }
      public DateTime FechaNacimiento
        {
            get{return this._fechaNacimiento;}
            set{this._fechaNacimiento = value;}
        }        
      public int Vidas
        {
            get{return this._vidas;}
            set{this._vidas = value;}
        }
      public int Monedas
        {
            get{return this._monedas;}
            set{this._monedas = value;}
        }
      public string Estado
        {
            get{return this._estado;}
            set{this._estado = value;}
        }    
        public string Color
        {
            get{return this._color;}
            set{this._color = value;}
        }              
        //Metodos
        //Constructor Por defecto
        public MarioBrother()
        {
            _nombre = "wario";
            _fechaNacimiento = DateTime.Now;
            _vidas = 3;
            _monedas = 0;
            _estado = "Pequeño";
            _color = "Morado";
            
        }           
        //constructo por parametros 
        public MarioBrother( string _nombre, DateTime _fechaNacimiento,int _vidas, int _monedas, string _estado, string _color)
        {
            this._nombre = Nombre;
            this._fechaNacimiento = FechaNacimiento;
            this._vidas = Vidas;
            this._monedas = Monedas;
            this._estado = Estado;
            this._color = Color;
        }
 /*       public override string ToString()
        {
            return "Alumno: "+ this._nombre + "/n" + "Nota: " + this._nota;
        }
 */       
     // public comer(string textoObjeto)
        public string comer(string comida)
        {
        //validar vidas (que no sean menores a cero y que no sumen mas de 100)
        //devuelve situacion de wario
        if(0 < this._vidas)
        {
        
   //     var comida = Console.ReadLine();
            if(comida == "a")
            {
                return "La opcion ingresada no es valida";
                
            }
            if(comida == "HongoRojo")
            {
                this._estado= "MARIOBROTHER GRANDE";
                return "Has Consumido un Hongo Rojo";
                
            }
            if(comida == "Pluma")
            {
                this._estado= "MARIOBROTHER CON CAPA";
                return"Has Consumido una Pluma";
                
            }
            if(comida == "Flor")
            {
                this._estado= "MARIOBROTHER DE FUEGO";
                return"Has Consumido una Flor";
                
            }    
            if(comida == "HongoVerde" && this._vidas<99)
            {
                this._vidas++;
                return "Su personaje ha comido un Hongo Verde";
                
            }else{
                return "No puedes tener mas de 99 vidas";
            }                            
        }else{
            return "No puede realizar esta accion porque sus vidas son menores que cero";
        }
        
 
        }    
        public void perder()
        {
        //devuelve el texto perder 
        //si wario recibe daño lo hace chiquito/perder power up   
        if(this._estado=="MARIOBROTHER GRANDE")
        {
        Console.WriteLine("Te has hecho pequeño!!!");
        this._estado = "Pequeño";
        }
        if(this._estado=="MARIOBROTHER CON CAPA")
        {
        Console.WriteLine("Te has hecho pequeño Y has perdido tu capa!!!");
        this._estado = "Pequeño";
        }
        if(this._estado=="MARIOBROTHER DE FUEGO")
        {
        Console.WriteLine("Te has hecho pequeño Y has perdido la flor!!!");
        this._estado = "Pequeño";
        } 
      if(this._estado=="Pequeño" && 0 < this._vidas)
        {
        Console.WriteLine("Has perdido una vida!!!");
        this._vidas--;
        }else{
            Console.WriteLine("No puedes perder mas vidas");
        }       
        }
        
        public string tomarMonedas(int coin)
        {
        //verificar vidas (mayores que cero, menores que 100)
        // si monedas es == a 100;
        //monedas =0 y vidas +1;    
        // devuelve situacion de wario
        if(coin < 100 ) 

    {  
        if( coin + this._monedas < 100 && 0 < this._vidas)
        {
            this._monedas = this._monedas + coin;
            return $"Ha ganado {coin} monedas";
        }else if( 100 <= coin + this._monedas && 0 < this._vidas && this._vidas < 99)
        {
            this._monedas = coin + this._monedas -100;
            this._vidas++;
            return $"Ha ganado {coin} monedas";
        }else if(coin < 0)
        {
            return "no se admiten monedas negativas, porfavor vuelva a ingresar una opcion";
        }else{
            return "Nose si se pueda llegar a esta opcion xd";
        }
        
    }
        else
        {
            //Console.WriteLine("las monedas no pueden ser mayores a 100");
            return "las monedas no pueden ser mayores a 100";
        }
        //return "las monedas no pueden ser mayores a 100";
    }
        public string realizarTruco(string textoTruco)
        {
            var v = 0;
            var i = 0;
            var d = 0;
            var a = 0;
            var txt = textoTruco.ToCharArray();

            foreach ( char gta in txt)
            {
                Console.WriteLine(gta);
                if(gta == 'v')
                {
                    v++;
                }
               if(gta == 'i')
                {
                    i++;
                }
               if(gta == 'd')
                {
                    d++;
                }
               if(gta == 'a')
                {
                    a++;
                }
                if( 1 <= v && 1 <= i && 1 <= d && 1 <= a && this._vidas<99)
                {
                    this._vidas++;
                    v--;
                    i--;
                    d--;
                    a--;
                    Console.WriteLine("Ganaste una vida");

                }
            }
//        comparar el codigo ingresado y sumar vidas dependiendo del truco 
//        if(textoTruco=="vffiadxx" && this._vidas < 99)
//        else if(textoTruco=="vffiadxx" && this._vidas == 99)
//        if(textoTruco=="xxxvbbdjdjijdminxajjannv" && this._vidas < 98 )
//        else if(textoTruco=="xxxvbbdjdjijdminxajjannv" && 100 < this._vidas +2)
//        if(textoTruco=="xvidavid"&& this._vidas < 99)
//        else if(textoTruco=="xvidavid" && this._vidas == 99)
           return "_";

        }
        

        public string MostrarDetalles()
        {
        //printf a todo
        //Console.WriteLine("Usted ha mostrado detalles ");
        return $"Nombre: {this._nombre} Fecha:{this._fechaNacimiento } Vidas:{this._vidas} Monedas:{this._monedas} Estado {this._estado} Color {this._color}";
        }
        
    }
    class Program
    {
        public static void Main(string[] args)
        {
            //Crear los dos Objetos
            MarioBrother jugador1 = new MarioBrother();
            MarioBrother jugador2 = new MarioBrother();

            var end = 0; 
            var op = 0;

            Console.WriteLine("Bienvedido al prototipo de Super Mario Bros Vintage");

            while(end != 1)
            {
                op = 0;
                var food ="aaa";
                Console.WriteLine("Por favor ingresa una opcion");
                Console.WriteLine("op 1= Comer ");
                Console.WriteLine("op 2= Perder ");
                Console.WriteLine("op 3= Tomar Monedas ");
                Console.WriteLine("op 4= Realizar Truco ");
                Console.WriteLine("op 5= Terminar la simulacion ");

                op = Convert.ToInt32(Console.ReadLine());

                if(op ==1)
                {
                    Console.WriteLine("Que es lo que vas a Comer?");
                    Console.WriteLine("las opciones son:");
                    Console.WriteLine("HongoRojo");
                    Console.WriteLine("Pluma");
                    Console.WriteLine("Flor");
                    Console.WriteLine("HongoVerde");
                    food = Console.ReadLine();
                    if(food==null)
                    {
                        food="a";
                    }
                    Console.WriteLine(jugador1.comer(food));
//                    jugador2.comer();
 //                   jugador1.mostarDetalles();
                    Console.WriteLine(jugador1.MostrarDetalles());
                }
                if(op ==2)
                {
                    jugador1.perder();
//                   jugador2.perder();
                    Console.WriteLine(jugador1.MostrarDetalles());
                }
                if(op ==3)
                {
                Console.WriteLine("ingrese la Cantidad de monedas a sumar");
                 var money = Convert.ToInt32(Console.ReadLine());                    
                    Console.WriteLine(jugador1.tomarMonedas(money));
//                    jugador2.tomarMonedas();
                    Console.WriteLine(jugador1.MostrarDetalles());
                }
                if(op ==4)
                {
                    Console.WriteLine("Ingrese una cadena de texto ");                
                    var texto = Console.ReadLine();
                    if(texto==null)
                    {
                        texto="b";
                    }
                    Console.WriteLine(jugador1.realizarTruco(texto));
//                    jugador2.realizarTruco();
                    Console.WriteLine(jugador1.MostrarDetalles());
                }
              if(op == 5)
                {
                    end = 1;
                }
            }
  
        }
    }
}
