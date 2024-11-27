LINK AL VIDEO:https://www.youtube.com/watch?v=fadIKeutDmE&ab_channel=DiegoMorales


Problematica a resolver:
en un hipotetico escenario parecido al de "The Guardians Journey" se esperaba optimizar la lógica
implementada dentro del juego para lo cual se esta evaluación la utilización de algoritmos
ya debidamente documentados con el propósito de optimizar el rendimiento.

para esto se considero la creacion de una carrera de algoritmos que se desarrollara a traves de la implementacion de:

1)-Definicion de un Modo de ordenamiento inicial que afectara al comportamiento de los 7 algoritmos.
-modo ascendente.
-modo descendente.

2)
-3 areas de prueba, donde se consideran 3 rangos para las 3 carreras.

-Tablero de puntaje: Se espera tener hasta un rango de 90.000 a 100.000 de
jugadores en la primera versión.

-Determinación de camino entre aldeas: Al ser un mundo abierto se considera
dentro de las combinaciones posible tener entre 50.000 a 70.000 posibles caminos.

-Dibujo o renderizado de objetos: Aquí se considera mantener una variación de
objetos totales disponibles entre 500 y 1000 por cada categoría. Al día de hoy se
cuenta con 15 categorías en total que conforman la vestimenta completa de los
guardianes

3)-4 sets de datos homogeneo de prueba:

-Ordenado.
-Inversamente Ordenado.
-Aleatorio.
-Aleatorio sin duplicar.

4)-7 algoritmos de ordenamiento que se deben poner a prueba con los 4 sets de datos y obtener el que menos tiempo tomo para ordenarse.

-Selection Sort.
-Bubble Sort.
-Insertion Sort.
-Shell Sort.
-Merge Sort.
-Quick Sort.
-Heap Sort.

-Solucion del problema:

1): para este apartado se creo una variable local llamada op y que sirve para definir el modo de ordenamiento inicial que afectara al comportamiento de
los 7 algoritmos.

2): las 3 areas de prueba se definieron a traves de 3 rangos declarados de forma local, dentro de la funcion que ejecuta la carrera, con un rango de 1-maximo especificado por el problema.

-1-100k para la carrera 1.
-1-70k para la carrera 2.
-1-15k para la carrera 3.

3): para los 4 sets de pruebas se considero la utilizacion de funciones que retornan un vector, cada funcion toma como parametro los rangos minimo y 
maximo definidos posteriormente por el usuario y construye un set de datos en forma de arreglo.

4): los 7 algoritmos se trabajaron como funciones, en sus parametros recibe la opcion que definira el modo de ordenamiento que afectara al codigo en general, esto se aplica a los 7 algoritmos, posteriormente para su funcionamiento se hizo a traves de una gran funcion que por cada algoritmo toma el tiempo
que se demora en ordenar el arreglo que le es dado como parametro(para la medicion de tiempo se utilizan funciones de la biblioteca chronos),los resultados se guardan en un unordered_map, por ultimo se imprimen los resultados de tiempo de los 7 algoritmos a traves de un for.

5): posteriormente el funcionamiento de todo el codigo esta dentro de una funcion global que llama a todas las demas, esta funcion es la unica que se llama en el main.

CONSIDERACIONES:
+Para la estructura se considero la implementación de:

-Biblioteca chronos para obtener de forma mas precisa el tiempo de los 7 algoritmos.

-El uso de 2 funciones principales:
-7 algoritmos 
-carrera_general: esta es la principal que llama a los algoritmos, modos y en la cual se definen los rangos que se utilizaran, es la que se llama en el main.

-Los 4 Modos de ordenamiento, los cuales están definidos a través de funciones que devuelven un vector, como parámetro tienen los rangos máximos y mínimos de cada situación.

-Los 7 algoritmos trabajan con una copia individual del arreglo que toman como parámetro, los 7 algoritmos están dentro de una función que se encarga de llamarlos y que estos cumplan con su procedimiento establecido, se considero ademas guardar los resultados en un unordered_map.

-Cada vez que se hace una copia de un vector, tras su uso se libera la memoria ocupada por dicho vector a través de el método clear(), de esa forma se evitan errores por desbordamiento y se optimiza la velocidad y funcionamiento del código.

-Para la situación de renderizado de objetos(invetario), debido a que son 15 categorías con 500 a 1000 elementos, se opto por simplificar esta información y considerar un arreglo de entre 7500-15k de elementos.

-Para la declaración de cada set de datos se considero un rango desde 1 hasta el máximo permitido en cada caso.

-En la función que se encarga del funcionamiento de los 7 algoritmos se tiene declarado como parámetro la variable op que afecta al orden de ordenamiento de cada algoritmo(ascendente o descendente).

-Para la definición de los rangos se usaron variables locales declaradas dentro de la función, en lugar de cargarlos por externo.
