#include<stdio.h>
#include<stdlib.h>
int main(){	
	srand(time(NULL));	
	int contador=12, apuesta, intento=1, toques=0, famas=0, n1, n2, n3, n4, n5 ,num1, num2, num3, num4, num5, trampa=0, rut, dv, apuestaf;
	n1 = rand()%(9+1);//todos estos bloques randomizan la secuencia numerica numero por numero
	n2 = rand()%(9+1);
	n3 = rand()%(9+1);
	n4 = rand()%(9+1);
	n5 = rand()%(9+1);
	//esta variable define la victoria y se inicia en 0
	int win = 0;
	//esta parte se encargara de randomizar los numeros aleatorios en caso de que al comparar uno con otro estos sean iguales y asi que no se repitan numeros en la secuencia
	while(n1==n2){ //se compara el primer digito con el segundo 
		n2=rand()%(9+1); //si son iguales se randomiza el segundo
	}
		while(n1==n3||n2==n3){ //se compara el primero y el segundo con el tercero 
		n3=rand()%(9+1); //si uno de ellos es igual al tercero se randomiza el tercero 
	}
		while(n1==n4 || n2==n4 || n3==n4){ //se compara el primero, segundo y tercero con el cuarto
		n4=rand()%(9+1); //si uno de ellos es igual al cuarto se randomiza el cuarto
	}
		while(n1==n5 || n2==n5 || n3==n5 || n4==n5){ //y se compara el primer, segundo, tercero y cuarto con el quinto digito
		n5=rand()%(9+1); //si uno de ellos es igual al quinto se randomizara el quinto
	}
	//esta parte servira para revelar la secuencia secreta o ocultarla al usuario
	printf("si quiere revelar la secuencia secreta escriba 1 y si no quiere revelarla escriba otro numero: ");
	scanf("%d",&trampa);	
	if(trampa==1){ //si el digito ingresado es igual a 1 se imprimira la secuencia secreta
	printf("%d %d %d %d %d\n",n1,n2,n3,n4,n5);	
	}
	printf("**********BIENVENIDO A TOQUE Y FAMA**********\n");
	printf("Instrucciones: \n"); //aqui se explica en que consta el juego
	printf("este juego consiste en que una persona piensa en una secuencia de 5 numeros enteros positivos del 1 al 9\n");
	printf("y la mantiene en secreto a su contrincante, el juego consiste en que el contrincante\n");
	printf("debe adivinar la secuencia de numeros en el menor de los intentos\n");
	printf("En este contexto, a modo de entregar pistas al jugador\n");
	printf("se le llama toque a si el numero propuesto por el jugador sencuentra en la secuencia a adivinar\n");
	printf("Las famas corresponden a el numero de digitos que calzan en la posicion de la secuencia a adivinar versus la secuencia objetivo\n");
	printf("El juego contara con un sistema de apuesta, donde al iniciar el juego el usuario debera ingresar un monto a apostar\n");
	printf("este no puede ser menor o igual al ultimo digito de su Rut y tampoco puede superar los 500 pesos\n");
	printf("ingrese el rut de usuario sin puntos ni guion y sin digito verificador: "); //aqui se tiene que ingresar el rut y su digito verificador por separado
	scanf("%d",&rut);
	printf("ingrese el digito verificador del rut: ");//se ingresa el digito verificador aparte para que luego se condicione la apuesta
	scanf("%d",&dv);
	printf("ingrese el monto a apostar, este monto no puede ser menor o igual al digito verificador y no puede superar los 500 pesos:");
	scanf("%d",&apuesta);
	//este bloque condicionara la apuesta y se asegurara de que se considere si el monto no supera los 500 pesos y no es menor o igual al digito verificador del rut
	if(dv<apuesta && apuesta<=500){
		printf("el monto a apostar es: %d\n", apuesta);
	}
	//este bloque hara que el monto a apostar no se considere en caso de que el monto sea mayor a 500 pesos
	if(apuesta>500){
		apuesta=0;
		printf("el monto de apuesta ingresado no corresponde a las condiciones dadas y no se considerara\n");
	}   //aqui empieza el while
		while(intento<=contador && win == 0){
		famas=0; //inicio las famas y los toque en cero para que no se sumen infinitamente tras terminar el ciclo y volverlo a empezar
		toques=0; 	
		printf("intento numero : %d\n", intento); //se indica el numero del intento y este se acumulara hasta perder o ganar
		printf("ingrese numero de cinco digitos uno a uno(separados) para adivinar la secuencia numerica:");
		scanf("%d %d %d %d %d",&num1,&num2,&num3,&num4,&num5); 
		printf("%d %d %d %d %d\n",num1,num2,num3,num4,num5); //esta parte mostrara los numeros ingresados, los cuales estaran separados por espacios
	//este bloque se encargara de generar la cantidad de famas y compara cada numero ingresado con su respectivo numero aleatorio y comprueba que sea igual
		if(num1==n1){	
		famas++;
		}
		if(num2==n2){
		famas++;
		}
		if(num3==n3){
		 famas++;
		 }
		if(num4==n4){
		famas++;
		}
		if(num5==n5){
		famas++;
		 }
	//este bloque se encargara se entregar los toques y comparara el numero ingresado con cada uno de los numeros aleatorios, esto se repite 5 veces
		if(num1==n1||num1==n2||num1==n3||num1==n4||num1==n5){
			toques++;
		}
		if(num2==n1||num2==n2||num2==n3||num2==n4||num2==n5){
			toques++;
		}
		if(num3==n1||num3==n2||num3==n3||num3==n4||num3==n5){
			toques++;
		}
		if(num4==n1||num4==n2||num4==n3||num4==n4||num4==n5){
			toques++;
		}
		if(num5==n1||num5==n2||num5==n3||num5==n4||num5==n5){
			toques++;
		}
		toques = toques - famas; //esta linea sirve para que las famas no se cuenten como toques
		
		if(toques <0) //esta condicion sirve para que los toques no sean negativos y se mantengan en ceros
		{
			toques = 0;
			
		}
		
		printf("toques:%d\n",toques); //aqui se imprimen la cantidad de toques
		if(famas == 5) //esta condicion sirve para determinar cuando el jugador gana al tener 5 famas
		{
			win = 1; //la condicion win 1 determina la victoria del usuario
		}
		else //en caso de no obtener las 5 famas el juego continuara con el siguiente intento
		{
			intento++;
			printf("famas:%d\n", famas); //aqui se imprimen la cantidad de famas
		}
   		if(intento>12){ //esta condicion se encargara de determinar el limite de intentos
   			win = 2; //la condicion win 2 determina cuando el usuario supera los 12 intentos e indica la derrota
		   }
   		
	}
		if(famas==5 && win== 1){ //si las famas son 5 y la condicion win 1 se cumplen imprime la victoria del jugador
			printf("felicidades usted a adivinado el numero secreto que era: %d %d %d %d %d\n", n1,n2,n3,n4,n5);
			printf("en: %d intento(s)\n",intento); //esta linea indica la cantidad de intentos tomados hasta llegar a la victoria
			if(apuesta>500){ //esta condicion se encarga de dejar la apuesta en cero si esta supera los 500 pesos, por lo que no se considera
			apuesta=0;
			printf("el monto de apuesta ingresado no corresponde a las condiciones dadas y no se considerara\n");
			}//esta parte del codigo se encargara de verificar si el monto de apuesta ingresado cumple las condiciones
			if(intento<=5 && dv<apuesta && apuesta<=500){
				apuestaf = apuesta*4; //si las condiciones de apuesta se cumplen la apuesta se multiplica por 4 en caso de ganar en 5 intentos o menos
			}
			if(intento>6 && intento<=12 && dv<apuesta && apuesta<=500){
				apuestaf = apuesta*2; //si las condiciones de apuesta se cumplen la apuesta se multiplica por 2 en caso de ganar en 12 intentos o menos
			}
			printf("el monto final es: %d\n",apuestaf);//se imprime el monto final de la apuesta
			}
		
			if(win==2){ //si el numero de intentos supera los 12 se dara la codicion win 2 y el usuario perdera
				printf("lo siento usted perdio por exceder el maximo de intentos(%d)\n", intento-1);
				if(apuesta>500){ //esta parte dejara la apuesta en cero si el monto ingresado supera los 500 pesos
					apuesta=0;
				printf("el monto final no se considero");
			}
				printf("el monto final sin acumular es: %d\n",apuesta); //si el monto final cumple las condiciones pero se pierde el juego el monto no se acumula y se queda igual
				printf("el codigo secreto era: %d %d %d %d %d\n",n1,n2,n3,n4,n5);//se revela el codigo secreto
			}
			return 0;	
	

}

			
			
			
			
		
	
	
	
	
	
	
	
	
	
	
	
	
