#include <stdio.h>
#include <stdlib.h>
#include<string.h>
#include <time.h>
typedef struct guardian{
	char nombre[50];
	char tipo[50];
	int vida;
	int ataque;
	int defensa;
	struct guardian *next;
	struct guardian *prev;
}Guardian;

//FUNCIONES
//funcion destinada a crear un guardian
Guardian* createGuardian(char*nombre,char*tipo,int vida, int ataque, int defensa);
//funcion que crea un guardian por parte del jugador, llamando al createguardian
Guardian* createCharacter();
//funcion para crear una lista de guardianes usando la carga de archivo
void addGuardian(Guardian **headRef,Guardian *newGuardian);
//funcion para crear una lista aparte para el jugador 
void addplayer(Guardian **headRefe,Guardian *player);
//FUNCION SIN USAR
//funcion para crear una lista aparte para los jugadores derrotados 
void derrotados(Guardian **head, Guardian *derrotado);
//FUNCION SIN USAR
//funcion encargada de encolar
void enqueue(Guardian **headRef, Guardian **tailRef, Guardian *newGuardian); 
//funcion para sacar un personaje de una lista
void sacar_personaje(Guardian **headRef,char*nombre);
//Funcion para imprimir el estado del personaje
//o la lista de guardianes
void printCharacterStatus(Guardian *headRef);
//funcion para seleccionar un personaje de la lista de guardianes
Guardian* selectCharacter(Guardian* headRef,char*nombre);
//Funcion para usar un dado aleatorio
int getRollResult();
//funcion de atacar
void Ataque(Guardian* atacante, Guardian* rival,int dado);
//funcion de defender
void Defensa(Guardian* defender, int dado);
//funcion para seleccionar la dificultad
int selectTournament(int dif,int riv);
//funcion para iniciar la pelea
void startFight(Guardian* headRef,Guardian* headPlayer,Guardian* seleccionado,Guardian* newGuardian,Guardian* player,Guardian* oponente,Guardian* tail,int op,int riv,int dif);
//menu de opciones
void menuOptions();

int main()
{
	//variable para seleccion en el menu
	int k=0;
	//randomizer
	srand(time(NULL));
	//funcion menu
	menuOptions();
	return 0;
}
//funcion destinada a crear un guardian
Guardian* createGuardian(char*nombre,char*tipo,int vida, int ataque, int defensa) //se crean los parametros con los que sera llamada
{
	//se reserva memoria para crear al guardian y se crea una variable para crearlo
	Guardian *newGuardian = (Guardian*)malloc(sizeof(Guardian));
	//se saca el tamaño de los strings
	strcpy(newGuardian->nombre, nombre);
	strcpy(newGuardian->tipo, tipo);
	//se asignan los valores de los parametros a los atributos del newguardian
	newGuardian->vida = vida;
	newGuardian->ataque = ataque;
	newGuardian->defensa = defensa; 		
	newGuardian->next = NULL;
	return newGuardian;	// retorna los datos del guardian 
}

//funcion que crea un guardian por parte del jugador, llamando al createguardian
Guardian* createCharacter()
{
	//declaracion de variables para el nombre, tipo, vida, ataque y defensa
	char nombre[50];
	char tipo[50];
 	int vida=0;
	int ataque=0;
	int defensa=0;
	//opcion sirve para decidir cual sera el tipo de guardian a elegir
	int opcion=0;
	//se pregunta por el nombre
	printf("Introduce el nombre de tu guardian:\n");
	scanf("%s",&nombre);
	//se pregunta por el tipo de guardian
	printf("Define tu tipo de guardian\n");
	printf("1: Mago/a\n");
	printf("2: Vikingo/a\n");
	printf("3: Nigromante\n");
	printf("4: Bestia\n");
	//opcion para selecionar al tipo de guardian
	scanf("%d",&opcion);
	//condicionales para determinar el tipo de guardian
	if(opcion==1)
	{
		strcpy(tipo,"Mago/a");
	}
	if(opcion==2)
	{
		strcpy(tipo,"Vikingo/a");
	}
	if(opcion==3)
	{
		strcpy(tipo,"Nigromante");
	}
	if(opcion==4)
	{
		strcpy(tipo,"Bestia");
	}
	//se randomizan los atributos vida, ataque y defensa
	vida = rand()%(600-400+1)+400;
	ataque = rand()%(200-115+1)+115;
	defensa = rand()%(100-30 +1)+30; 
	//se crea una variable que servira para guardar los datos del jugador creado
	//y se llama a la funcion de crear guardian
	Guardian* jugador = createGuardian(nombre,tipo,vida,ataque,defensa);
	return jugador; //se retorna los datos del jugador creado
}

//funcion para crear una lista de guardianes usando la carga de archivo
//en los parametros se hace referencia a la cabeza de la lista y al nombre de la variable
//que se usara para asignar los datos de los guardianes
void addGuardian(Guardian **headRef,Guardian *newGuardian)
{
	//si la cabeza de la lista es nula el primer guardian creado toma el puesto
    if (*headRef == NULL)
	{
        *headRef = newGuardian;
    }
    //si no se iran agregando, si el siguiente en la lista es nulo se creara un nuevo guardian
    else 
	{
        Guardian *current = *headRef;
        while ( current->next != NULL )
		{
            current = current->next;
        }
        current->next = newGuardian;
    }
}

//funcion para crear una lista aparte para el jugador 
//en los parametros se hace referencia a la cabeza de la lista y al nombre de la variable
//que se usara para asignar los datos del guardian
void addplayer(Guardian **headRefe,Guardian *player)
{
	//si la cabeza de la lista es nula el primer guardian creado toma el puesto
    if (*headRefe == NULL)
	{
        *headRefe = player;
    }
    //si no se iran agregando, si el siguiente en la lista es nulo se creara un nuevo guardian
    else 
	{
        Guardian *current = *headRefe;
        while ( current->next != NULL )
		{
            current = current->next;
        }
        current->next = player;
    }
}
//FUNCION SIN USAR
//funcion para crear una lista aparte para los jugadores derrotados 
//en los parametros se hace referencia a la cabeza de la lista y al nombre de la variable
//que se usara para asignar los datos de los derrotados que iran a una lista aparte
void derrotados(Guardian **head, Guardian *derrotado)
{
	//si la cabeza de la lista es nula el primer guardian creado toma el puesto
	if(*head == NULL)
	{
		*head = derrotado;
	}
	//si no se iran agregando, si el siguiente en la lista es nulo se creara un nuevo guardian
	else
	{
		Guardian *current = *head;
		while(current->next != NULL)
		{
			current= current->next;
		}
		current->next = derrotado;
	}
}
//FUNCION SIN USAR
//funcion encargada de encolar
void enqueue(Guardian **headRef, Guardian **tailRef, Guardian *newGuardian) 
{
    if (*headRef == NULL) 
	{
        *headRef = newGuardian;
    } 
	else 
	{
        (*tailRef)->next = newGuardian;
    }
    *tailRef = newGuardian;
}

//funcion para sacar un personaje de la lista de rivales en caso de derrota
//tambien sirve para sacar al personaje seleccionado de la lista de guardianes
// y asi no luchar contra aquel que uno selecciona
//en los parametros estan la cabeza de la lista y el nombre de aquel que se sacara
void sacar_personaje(Guardian **headRef,char*nombre)
{
	//se hace referencia a la cabeza de la lista
	Guardian *current=*headRef;
	Guardian *prev = NULL;
	//se busca en la lista en base al nombre con el que fue creado
	while(current != NULL && strcmp(current->nombre, nombre)!= 0)
	{
		prev = current;
		current = current->next;
	}
	//en caso de que el nombre no exista mandara un mensaje
	if(current == NULL)
	{
		printf("no hay guardian ingresado con el nombre: %s\n",nombre);
		printf("\n");
		return;
	}
	//si el previo es nulo se seguira buscando en el siguiente nodo, en caso de que no se econtrara y lo dira
	if(prev == NULL)
	{
		*headRef = current->next;
	}
	else
	{
		prev->next=current->next;
	}
	printf("Guardian:%s\n",current->nombre);
	printf("guardian seleccionado y sacado de la lista\n");
	printf("\n");
	free(current);
}

//Funcion para imprimir el estado del personaje
//o la lista de guardianes
void printCharacterStatus(Guardian *headRef)
{
    Guardian *current = headRef;
    while (current != NULL)
	{
        printf("Nombre: %s\n",current->nombre);
        printf("Tipo: %s\n",current->tipo);
        printf("Vida: %d\n",current->vida);
        printf("Ataque: %d\n",current->ataque);
        printf("Defensa: %d\n",current->defensa);
        current = current->next;
        printf("----------------------------------------------\n");
    }
}
//funcion para seleccionar un personaje de la lista de guardianes
//y que se usara para pelear
Guardian* selectCharacter(Guardian* headRef,char*nombre)
{
		//se referenciara al inicio de la lista
		Guardian* current = headRef;
		//se buscara en la lista en base al nombre ingresado en los parametros
		while(current != NULL)
		{
			if(strcmp(current->nombre, nombre)==0)
			{
				return current;
			}
			current = current->next;
		}
		return NULL; 
}
//Funcion para usar un dado aleatorio
int getRollResult()
{
	//srand(time(NULL));
	int dado=rand() % 6 + 1;
	return dado; //se retorna el resultado del dado
}

//funcion de atacar
//guardian atacante y guardian rival se llama en el starfight
//con el nombre del atacante y del que sera atacado
//lo mismo con el dado
void Ataque(Guardian* atacante, Guardian* rival,int dado)
{
	// si los dados son impares se atacara y dependiendo de su numero
	//se multiplicara el ataque por el factor obtenido
	//atacar quita vida al oponente
	if(dado == 1 || dado == 3 || dado == 5)
	{
		if(dado==1)
		{
			atacante->ataque = atacante->ataque *0.8;
			printf("factor ataque 0.8\n");
			printf("ataque actual: %d\n",atacante->ataque);
		}
		else if(dado==3)
		{
			atacante->ataque = atacante->ataque *1;
			printf("factor ataque 1\n");
			printf("ataque actual: %d\n",atacante->ataque);
		}
		else if(dado==5)
		{
			atacante->ataque = atacante->ataque *1.3;
			printf("factor ataque 1.3\n");
			printf("ataque actual: %d\n",atacante->ataque);
		}
		rival->vida=rival->vida-atacante->ataque;
		printf("Vida restante de %s: %d\n",rival->nombre, rival->vida);
	}
	//en caso de ser pares el ataque no se dara
	else if(dado == 2 || dado == 4 || dado == 6)
	{
		printf("ataque bloqueado por el rival\n");
		printf("Vida restante de %s: %d\n",rival->nombre, rival->vida);	
	}	
}
//funcion de defender
//guardian defender se llama en el starfight con el nombre de aquel que se defendera
//lo mismo con el dado
void Defensa(Guardian* defender, int dado)
{
	//si el dado sale par se hara la defensa y dependiendo del numero
	//se multiplicara la defensa por el factor obtenido
	//defensa cura la vida de aquel que la use
	if(dado == 2 || dado == 4 || dado == 6)
	{
		if(dado == 2)
		{
			defender->defensa=defender->defensa*0.5;
			printf("factor defensa 0.5\n");
			printf("defensa actual: %d\n",defender->defensa);
		}
		else if(dado == 4)
		{
			defender->defensa=defender->defensa*1;
			printf("factor defensa 1\n");
			printf("defensa actual: %d\n",defender->defensa);
		}
		else if(dado == 6)
		{
			defender->defensa=defender->defensa*1.2;
			printf("factor defensa 1.2\n");
			printf("defensa actual: %d\n",defender->defensa);
		}
		defender->vida = defender->vida + defender->defensa;
		printf("vida restante de %s: %d\n",defender->nombre,defender->vida);
	}
	//si el dado es impar la defensa sera incompleta y se restara un 5 porciento de las defensas
	else if(dado == 1 || dado == 3 || dado == 5)
	{
		printf("defensa incompleta\n");
		defender->defensa = defender->defensa-(defender->defensa*5/100);
		printf("desgaste en puntos de defensa\n");
		printf("defensa restante de %s: %d\n",defender->nombre,defender->defensa);				
	}			
}
//funcion para seleccionar la dificultad
//sus variables de sus parametros se llamaran desde el menu de opciones
int selectTournament(int dif,int riv)
{
	printf("Seleccione el nivel de dificulta del troneo\n");
	printf("1: Principiante: Derrotar a tres guardianes\n");
	printf("2: Intermedio: Derrotar a cinco guardianes\n");
	printf("3: Experto: Derrotar a siete guardianes\n");
	scanf("%d",&dif);
	return dif;	
	//retorna el valor de la dificultad
}

//funcion para iniciar la pelea
//las variables de los parametros hacen referencia a la cabeza de la lista de guardianes y a la lista exclusiva para el jugador
//ademas de variables que hacen referencia al rival a enfrentar, al juador seleccionado o creado, ademas de tomar las variables
//de la cantidad de rivales y la dificultad
void startFight(Guardian* headRef,Guardian* headPlayer,Guardian* seleccionado,Guardian* newGuardian,Guardian* player,Guardian* oponente,Guardian* tail,int op,int riv,int dif)
{

	//dado exclusivo del jugador
	int dado=0;
	//dado exclusivo del rival
	int dado_rival=0;
	
	//variable para recorrer el arreglo de rivales al azar
	int i=0;
	
	//variable para sacar el tamaño total de la lista de rivales
	int count=0;
	
	//variable que servira para aumentar el contador que sera menor a la cantidad de rivales
	//seleccionados por la dificultad y asi enfrentar a los rivales al azar uno por uno
	int c=0;

	//variable que sirve para salirse del torneo si es que el jugador seleccionado o creado pierde
	int perder=0;
	
	//verificacion si la cabeza de la lista de rivales es null y el jugador creado
	//o seleccionado sea null 
	if(headRef!=NULL && (headPlayer!=NULL||seleccionado!=NULL))
	{
			//si el guardian seleccionado no es nulo
			//se imprimen sus atributos
			if(seleccionado!= NULL)
			{
				printf("Guardian seleccionado:\n");
				printf("Nombre: %s\n",seleccionado->nombre);
				printf("Tipo: %s\n",seleccionado->tipo);
				printf("Vida: %d\n",seleccionado->vida);
				printf("Ataque: %d\n",seleccionado->ataque);
				printf("Defensa: %d\n",seleccionado->defensa);
			}
			//en caso de que sea nulo se muestra un mensaje
			else
			{
				printf("no hay guardian seleccionado\n");
			}
			//se crea una variable que hace referencia a la cabeza del jugador creado
			player=headPlayer;
			//si el jugador creado es distinto de nulo se imprimen sus datos
			if(player != NULL)
			{
				printf("Jugador creado:\n");
				printf("Nombre: %s\n",player->nombre);
				printf("Tipo: %s\n",player->tipo);
				printf("Vida: %d\n",player->vida);
				printf("Ataque: %d\n",player->ataque);
				printf("Defensa: %d\n",player->defensa);
			}
			//en caso de no haber ningun jugador creado muestra un mensaje
			else
			{
				printf("no hay ningun jugador creado\n");
			}
		//variable oponente que apunta a la cabeza de la lista de guardianes
		//y servira para imprimirlos
		//esto con el fin de usar los datos del oponente para seleccionarlo al azar 
		//para el enfrentamiento	
		oponente=headRef;
		printf("----------------lista rival----------------\n");
		while(oponente!=NULL)
		{
			printf("nombre del rival: %s\n",oponente->nombre);
			printf("tipo del rival: %s\n",oponente->tipo);
			printf("vida del rival: %d\n",oponente->vida);
			printf("ataque del rival: %d\n",oponente->ataque);
			printf("defensa del rival: %d\n",oponente->defensa);
			count++; //contador que sirve para sacar el tamaño de la lista de oponentes
			oponente = oponente->next;
			printf("count: %d\n",count);	
			printf("-------------------------------------------\n");
		}
		//si la dificultad no se ha elegido aun no se podra empezar el combate
		if(riv==0)
		{
			printf("no hay dificultad seleccionada, seleccione una para continuar\n");
		}
		//si no empezara el combate
		else
		{
			//cantidad de rivales a enfrentar basado en la seleccion de dificultad
			printf("Rivales a Enfrentar: %d\n",riv);
			printf("------------------------------\n");
			
			//ciclo que sirve para pelear contra una cantidad de rivales al azar 
			//dependiendo de la dificultad elegida
			//si la variable perder es uno significa que el usuario perdio y el torneo se terminara
			//el ciclo carga un rival al azar y si es derrotado c se suma y se selecciona al siguiente rival
			while(c<riv && perder!=1)
			{		
					//numero que randomiza la variable del tamaño de la lista de rivales
					int num = rand()%count+1;
					//la variable rival se iguala a oponente y apunta a la cabeza de la lista
					Guardian *rival = oponente;
					rival = headRef;
					//en base al numero seleccionado al azar de la lista de oponentes se busca a ese numero
					//y se imprime por ende al rival al azar a enfrentar 
					for(i=1;i<num;i++)
					{
						rival=rival->next;
					}
					printf("------------------------------\n");
					printf("rival al azar es: %s\n",rival->nombre);
					printf("Tipo: %s\n",rival->tipo);
					printf("Vida: %d\n",rival->vida);
					printf("Ataque: %d\n",rival->ataque);
					printf("Defensa: %d\n",rival->defensa);	
					printf("------------------------------\n");
					printf("QUE COMIENCE EL COMBATE\n");
					
				//ciclo que servira para pelear contra el rival al azar en cada iteracion de la cantidad de rivales	
				//si perder es igual a 1 se saldra del ciclo y se termina el torneo
				while(rival->vida>0 && perder!=1)
				{
					//se verifica que en efecto se selecciono o se creo a un jugador
					//ademas se condiciona que si la vida del seleccionado o creado es mayor que cero
					//el turno puede seguir
					if((seleccionado != NULL && seleccionado->vida > 0) || (player != NULL && player->vida > 0))
					{
						//se pregunta al usuario que quiere hacer
						printf("------------------------------\n");
						printf("Turno del Usuario\n");
						printf("Que quieres hacer?\n");
						printf("opcion 1: atacar\n");
						printf("opcion 2: defender\n");
						scanf("%d",&op);
						//opcion de ataque
						if(op==1)
						{
								
							printf("Opcion elegida por el usuario: Atacar\n");
							if(player != NULL) //verificacion si player no es nulo
							{
								dado = getRollResult(); //lanzamiento de dados
								printf("Resultado del lanzamiento de dados: %d\n",dado);
								Ataque(player,rival,dado); //se llama a la funcion atacar y ataca el jugador creado
							}
							if(seleccionado!=NULL) //verificacion si el seleccionado no es nulo
							{
								dado = getRollResult(); //lanzamiento de dados
								printf("Resultado del lanzamiento de dados: %d\n",dado);
								Ataque(seleccionado,rival,dado); //se llama a la funcion atacar y ataca el jugador seleccionado
							}
			
						}
						//defensa
						if(op==2)
						{
							printf("Opcion elegida por el usuario: Defender\n");
							if(player!=NULL) //verificacion si player no es nulo
							{
								dado = getRollResult(); //lanzamiento de dados
								printf("Resultado del lanzamiento de dados: %d\n",dado);
								Defensa(player,dado); //se llama a la funcion de defender y defiende el juagdor creado
									
							}
							if(seleccionado!=NULL) //verificacion si el seleccionado no es nulo
							{
								dado = getRollResult(); //lanzamiento de dados
								printf("Resultado del lanzamiento de dados: %d\n",dado);
								Defensa(seleccionado,dado);	//se llama a la funcion de defender y defiende el jugador seleccionado
								
							}		
						}
					}
					//si la vida del seleccionado o del creado es 0 el usuario pierde y se temina el torneo
					//perder se hace 1 y el ciclo se termina
					else
					{
						
						//NOTA
						//se intento hacer una cola o lista de derrotados para el historial pero
						//por temas de tiempo no se alcanzo a completar
						
						//if(seleccionado != NULL && seleccionado->vida < 0) 
						//{
							//enqueue(&front,&tail,seleccionado);
							//derrotados(&headderrotados,seleccionado);	
						//	printf("jugador seleccionado agregado a la lista de derrotados\n");
						//}
						//if(player!=NULL && player->vida<0)
						//{
							//enqueue(&front,&tail,player);
							//derrotados(&headderrotados,player);
							
							printf("HAS PERDIDO\n");
							sacar_personaje(&headPlayer,player->nombre); //se saca solo al jugador creado de la lista pues el seleccionado ya fue sacado en el menu de opciones cuando se selecciona
						//}		
						perder=1;	
					}
					//si la vida del rival es mayor que cero su turno es valido
					if(rival->vida>0)
					{
						printf("------------------------------\n");
						printf("Turno del rival\n");
						printf("Rival: %s\n",rival->nombre);
						printf("1: atacar\n");
						printf("2: defender\n");
						//variable para que la eleccion del rival sea random
						int randop=0;
						randop=rand()%2+1;
						printf("Seleccion del rival: %d\n",randop);
						//atacar
						if(randop==1)
						{
							printf("Opcion elegida por el rival: Atacar\n");
							if(player!=NULL) //verificacion si player no es nulo
							{
							dado_rival = getRollResult(); //lanzamiento de dados
							printf("Resultado del lanzamiento de dados: %d\n",dado_rival);
							Ataque(rival,player,dado_rival); //se llama a la funcion de atacar y ataca el rival
							}
							if(seleccionado!=NULL) //verificacion si el seleccionado no es nulo
							{
							dado_rival = getRollResult(); //lanzamiento de dados
							printf("Resultado del lanzamiento de dados: %d\n",dado_rival);
							Ataque(rival,seleccionado,dado_rival); //se llama a la funcion de atacar y ataca el rival
							}
						}
						//defender
						if(randop==2)
						{
							printf("Opcion elegida por el rival: Defender\n");
							dado_rival = getRollResult(); //lanzamiento de dados
							printf("Resultado del lanzamiento de dados: %d\n",dado_rival);
							Defensa(rival,dado_rival); //se llama a la funcion defender y el rival se defiende
						}
					}
					else
					{
						//si la vida del rival es cero se derrota se suma el c para pasar al siguiente rival y se saca al rival de la lista
						//para que el rival no se repita
						printf("RIVAL DERROTADO\n");
						
						//codigo sin terminar para agregar al rival derotado al historial de derrotas
						//enqueue(&front,&tail,rival);          
						//derrotados(&headderrotados,rival);
						   
						sacar_personaje(&headRef,rival->nombre);
						c++;
						printf("------------------------------\n");
						printf("rivales derrotados: %d\n",c);
					}
				}
			}
			printf("Torneo Terminado\n");	
		}
	}
	//en caso de que no haya una lista de guardianes ingresada o un guardian creado o seleccionado 
	//arrojara un mensaje 
	else
	{
		printf("No hay ninguna lista de guardianes ingresado o no hay ningun guardian seleccionado o creado\n");
	}	
}
//menu de opciones
void menuOptions()
{
		Guardian *headRef=NULL;
		Guardian *headPlayer=NULL;
		//Guardian *front=NULL;
		//Guardian *headerrota=NULL;
    	Guardian *tail = NULL;
    	Guardian *seleccion=NULL;
    	Guardian *jugador=NULL;
		Guardian *newGuardian; 
		Guardian *oponente;
		//Guardian *derrotados;
		int k=0;
		//variable para limitar la seleccion de guardianes a 1
		int sle=0;
 		//variable para seleccionar un jugador
 		char sel[50];
 		//dificultad
 		int dificultad=0;
 		//rivales
 		int rivales=0;
 		//opcion para elegir
 		int op=0;
 		//dado
 		int dado=0;
 		//variable que sirve o para crear o seleccionar pero no las dos, no se alcanzo a completar
 		//int eleccion=0;
		printf("Bienvenido a The Guardians Tournament\n");
 		while(k!=9)
 		{
		printf("----------------Menu de Opciones---------------------\n");
		printf("Seleccione la opcion para continuar\n");
		printf("1: Seleccionar un personaje\n");
		printf("2: Crear un Personaje\n");
		printf("3: Seleccionar nivel de dificultad\n");
		printf("4: Ver el Estado de los Personajes\n");
		printf("5: Comenzar Pelea\n");
		printf("6: Saber el resultado del lanzamiento de dados\n");
		printf("7: Conocer el historial del jugador\n");
		printf("8: Cargar Datos Externos de los Personajes\n");
		printf("9: Salir\n");
		scanf("%d",&k);
		if(k==1)
		{
			if(headRef == NULL)
			{
				printf("No hay ningun guardian ingresado\n");
			}
			else
			{
				while(sle!=1)
				{
					printf("Elige a tu guardian\n");
					scanf("%s",&sel);
					seleccion = selectCharacter(headRef,sel);
					if(seleccion != NULL)
					{
						printf("jugador %s seleccionado esta en la lista:\n", seleccion->nombre);
						printf("\n");
						printf("Nombre: %s\n",seleccion->nombre);
						printf("Tipo: %s\n",seleccion->tipo);
						printf("Vida: %d\n",seleccion->vida);
						printf("Ataque: %d\n",seleccion->ataque);
						printf("Defensa: %d\n",seleccion->defensa);
						sacar_personaje(&headRef,sel);
						sle=sle+1;
					}
					else
					{
						printf("%s no encontrado\n",sel);
						sle=0;
					}	
				}
				if(sle==1)
				{
					printf("Solo puedes seleccionar a un guardian\n");
				}
			}
		}
		else if(k==2)
		{
			jugador=createCharacter();
			addplayer(&headPlayer,jugador);
			printCharacterStatus(headPlayer);		
		}
		else if(k==3)
		{
			//en dependiendo de la dificultad se decidira la cantidad de rivales
			dificultad=selectTournament(dificultad,rivales);
			if(dificultad==1)
			{
				printf("has escogido el nivel principiante\n");
				rivales=3;
				printf("cantidad de guardianes a enfrentar: %d\n",rivales);
			}
			if(dificultad==2)
			{
				printf("has escogido el nivel intermedio\n");
				rivales=5;
				printf("cantidad de guardianes a enfrentar: %d\n",rivales);
			}
			if(dificultad==3)
			{
				printf("has escogido el nivel experto\n");
				rivales=7;
				printf("cantidad de guardianes a enfrentar: %d\n",rivales);
			}
		}
		else if(k==4)
		{
			//se imprimen a los guardianes
			printf("----------------GUARDIANES---------------------\n");
			printCharacterStatus(headRef);
			printCharacterStatus(headPlayer);
		}
		else if(k==5)
		{
			//funcion de pelea con las variables del menu
			startFight(headRef,headPlayer,seleccion,newGuardian,jugador,oponente,tail,op,rivales,dificultad);	
		}
		else if(k==6)
		{
			//saber datos del dado
			dado = getRollResult();
			printf("resultado del dado: %d\n",dado);
		}
		else if(k==7)
		{
			//guardianes derrotados
			printf("Lista de derrotados\n");
			//printCharacterStatus(front);
		}
		else if(k==8)
		{
			//carga de archivo	
			FILE *fp;
	    	char line[100];
	    	fp = fopen("Guardianes.txt","r");
	    	if (fp == NULL) 
			{
	        	printf("Error: No se puede abrir el archivo\n");
	        	//return 1;
	        	return;
	    	}
	    	while (fgets(line, 100, fp)) 
			{
	        	Guardian *newGuardian = (Guardian*)malloc(sizeof(Guardian));
	        	if (newGuardian == NULL) 
				{
	            	printf("Error: No se puede asignar memoria\n");
	            	//return 1;
	            	return;
	        	}
	        	char *token;
	        	token = strtok(line, ",");
	        	strcpy(newGuardian->nombre, token);
	        	token = strtok(NULL,",");
	        	strcpy(newGuardian->tipo, token);
	        	newGuardian->vida = atoi(strtok(NULL, ","));
	        	newGuardian->ataque = atoi(strtok(NULL, ","));
	        	newGuardian->defensa = atoi(strtok(NULL, ","));
	        	newGuardian->next = NULL;
	        	newGuardian->prev = NULL;
	        	addGuardian(&headRef,newGuardian);
	    }
		printf("Datos cargados exitosamente\n");
		printf("\n");
	    fclose(fp);
		}
		else if(k==9)
		{
		//salir del programa	
		exit(-1);
		}
	}
		
}





/*
switch(k)
{
	case 1:
	
	break;
}
*/



