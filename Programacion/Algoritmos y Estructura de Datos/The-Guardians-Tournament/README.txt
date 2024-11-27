EL Problema Planteado fue un Torneo de Guardianes por Turnos
para el desarrollo torneo se requeria:

1-Un personaje con nombre, vida, clase, puntos de ataque y defensa(atributos). 

2-Jugador Creado.

3-Jugador Seleccionado de una lista de personajes.

4-Lista de Rivales.

5-que el torneo fuera por turnos.

6-que los rivales fueran al azar.

7-que uno se enfrente a varios y vaya derrotandolos uno por uno.

8-dependiendo de la dificultad la cantidad de rivales serian mas o menos.

9-que el ataque y la defensa tuvieran factores bonus a la defensa o ataque.

10-un dado que decidiera si uno atacaba bien o defendia bien.

11-opciones de seleccion multiple para el usuario.

12-guardar y cargar(adicional).

13-un historial con las derrotas

14-Lista de guardianes.

15-que el jugador gane o pierda.

la resolucion de estos puntos se detallaran a continuacion:

el problema general fue resuelto en su mayoria en un codigo hecho en c usando listas, estructuras y punteros

1-se creo una estructura donde se crearon los atributos para usarlos en las demas funciones.

2-para el jugador creado se usaron dos funciones, una que crea y asigna los datos y la segunda que llama a la primera y es en la segunda donde el usuario crea al jugador.

3-para esto primero se cargan los datos de los rivales a traves de un archivo.txt y despues a traves de una funcion el usuario buscara por nombre y dependiendo del nombre, el guardian seleccionado se sacara de la lista para que cuando uno se enfrente a los rivales, el seleccionado no este ahi.

4-para la seleccion de rivales estos se cargan en una funcion.

5-para que el torneo sea por turnos se hace en un bucle condicionado por la dificultad.

6-para que los rivale sean al azar se saca el tamaño de la lista de rivales y se elige uno al azar en base a un contador en cada rival de la lista.

7-para esto se creo un bucle en el cual se carga un rival al azar y dependiendo si uno selecciono o creo a un guardian se da el combate, si uno derrota a uno habra un contador que avanzara, y el derotado se sacara de la lista de rivales para que el siguiente en elegirse no sea el mismo, y en la siguiente iteracion se cargara un nuevo y comienza el combate de nuevo.

8-para esto se creo una funcion que es para seleccionar la dificultad, la funcion devuelve el valor de la dificultad, luego se llama en otro lugar donde dependiendo de la dificultad se definen los rivales a enfrentar.

9-para atacar o defender el ataque y defensa se dividieron en dos funciones que funcionan en base a un dado random, dependiendo del dado y de diferentes condicionales el factor de ataque o defensa variara.

10-para el dado se creo una funcion que genera un numero al azar entre 1 y 6 en las funciones de ataque y defensa el dado decide si uno cuando ataca falla o acierta o cuando defiende uno se cura o pierde defensas.

11-para esto se creo un menu que sirve para selecionar lo que quiere hacer el usuario y ahi se llaman a todas las funciones, luego el menu se llama en el main.

12-el guardar y cargar no se implemento.

13-el historial del torneo no se implemento

14-para la lista de guardianes, se carga un archivo externo .txt que contiene la informacion de los guardianes y posteriormente se imprime en el codigo.

15-para que el jugador gane se deben derrotar a todos los guardianes, cabe destacar que en cada nuevo rival a derrotar, los datos del usuario no se resetean, por ende el usuario tendra que pensar muy bien que accion hacer para lograr ganar, haciendo que el juego sea bastante dificil, al ganar se termina el torneo y se vuelve al menu, uno pierde al tener su vida en 0 y si pierde el torneo terminara.



