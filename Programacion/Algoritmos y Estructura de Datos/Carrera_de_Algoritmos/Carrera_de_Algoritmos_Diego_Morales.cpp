#ifdef _WIN32
#else
#include <unistd.h>
#endif
#include <cstdlib>
#include <iostream>
#include <vector>
#include <algorithm>
#include <random>
#include <unordered_map>
#include <ctime>
#include <iomanip>
#include <set>
#include<random>
#include <limits>
#include <ratio>
#include <chrono>
#include <set>
using namespace std;
using namespace chrono;
using std::chrono::high_resolution_clock;
using std::chrono::duration;
using std::chrono::duration_cast;

//Conjuntos
vector<int> Ordenado(int rangoMin, int rangoMax)//Set de datos Ordenado
{
    vector<int> conjunto;
    for(int i = rangoMin; i <= rangoMax; i++)
    {
        conjunto.push_back(i);
    }
    return conjunto;
}

vector<int> InversamenteOrdenado(int rangoMin, int rangoMax)//Set de datos Inversamente Ordenado
{
    vector<int> conjunto;
    for(int i = rangoMax; i >= rangoMin; i--)
    {
        conjunto.push_back(i);
    }
    return conjunto;
}

vector<int> Aleatorio(int rangoMin, int rangoMax)//Set de datos Aleatorio
{
    random_device rd;
    mt19937 gen(rd());
    uniform_int_distribution<int> dis(rangoMin, rangoMax);

    int tamano = dis(gen);
    vector<int> conjunto;

    for(int i = 0; i < tamano; i++)
    {
        int elemento = dis(gen);
        conjunto.push_back(elemento);
    }

    return conjunto;
}

vector<int> AleatorioSinDuplicar(int rangoMin, int rangoMax)//Set de datos Aleatorio sin Duplicar
{
    random_device rd;
    mt19937 gen(rd());
    uniform_int_distribution<int> dis(rangoMin, rangoMax);

    int tamano = dis(gen);
    vector<int> conjunto;

    set<int> elementos_unicos;
    for(int i = rangoMin; i <= rangoMax; i++)
    {
        elementos_unicos.insert(i);
    }

    // Verificar si el tamaño total de elementos únicos es menor que el tamaño especificado
    if (elementos_unicos.size() < tamano)
    {
        // Puedes ajustar el tamaño para que sea igual al tamaño de elementos_unicos
        tamano = elementos_unicos.size();
    }

    // Tomar el tamaño de elementos aleatorios del conjunto de elementos únicos.
    while(conjunto.size() < tamano)
    {
        int elemento = *next(elementos_unicos.begin(),dis(gen) % elementos_unicos.size());
        conjunto.push_back(elemento);
        elementos_unicos.erase(elemento);
    }

    // Mezclar los elementos del conjunto para obtener un conjunto aleatorio sin duplicados
    shuffle(conjunto.begin(), conjunto.end(), gen);
    //shuffle(conjunto.begin(),conjunto.end(),gen);

    return conjunto;
    
}

//7 Algoritmos de Ordenamiento
void SelectionSort(vector<int>& arr, int op)
{
    int n = arr.size();
    for (int i = 0; i < n - 1; ++i)
    {
        int minIndex = i;
        for (int j = i + 1; j < n; ++j)
        {
            // Modificar el bucle interno de comparación
            if (op == 2 ? arr[j] > arr[minIndex] : arr[j] < arr[minIndex])
            {
                minIndex = j;
            }
        }

        // Realizar el intercambio si el minimo no es el elemento actual
        if (minIndex != i)
        {
            swap(arr[i], arr[minIndex]);
        }
    }
}

void BubbleSort(vector<int>& arr, int op)
{
    int n = arr.size();
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - i - 1; j++)
        {
            // Modificar el bucle interno de comparación
            if (op == 2 ? arr[j] < arr[j + 1] : arr[j] > arr[j + 1])
            {
                swap(arr[j], arr[j + 1]);
            }
        }
    }
}

void InsertionSort(vector<int>& arr, int op)
{
    int n = arr.size();
    int i, key, j;
    for (i = 1; i < n; i++) 
    {
        key = arr[i];
        j = i - 1;

        // Modificar la condicion de comparacion en el bucle while
        while (j >= 0 && (op == 2 ? arr[j] < key : arr[j] > key))
        {
            arr[j + 1] = arr[j];
            j = j - 1;
        }
        arr[j + 1] = key;
    }
}

void shellSort(vector<int>& arr, int op) 
{
    int n = arr.size();
    int gap = n / 2;

    while (gap > 0) 
    {
        for (int i = gap; i < n; i++) 
        {
            int temp = arr[i];
            int j = i;
            // Modificar la condición de comparacion en el bucle while
            while (j >= gap && (op == 2 ? arr[j - gap] < temp : arr[j - gap] > temp))
            {
                arr[j] = arr[j - gap];
                j -= gap;
            }
            arr[j] = temp;
        }
        gap /= 2;
    }
}

void merge(vector<int>& arr, int left, int middle, int right, int op) //Función para combinar dos subarreglos ordenados en un solo arreglo ordenado
{
    int n1 = middle - left + 1;
    int n2 = right - middle;

    //Crear arreglos temporales para los subarreglos izquierdo y derecho
    vector<int> leftArr(n1);
    vector<int> rightArr(n2);

    //Copiar los elementos a los arreglos temporales
    for (int i = 0; i < n1; i++) 
    {
        leftArr[i] = arr[left + i];
    }
    for (int j = 0; j < n2; j++) 
    {
        rightArr[j] = arr[middle + 1 + j];
    }

    //Combinar los arreglos temporales en uno solo en el orden especificado
    int i = 0;         //indice inicial del subarreglo izquierdo
    int j = 0;        //indice inicial del subarreglo derecho
    int k = left;   //indice inicial del subarreglo combinado

    while (i < n1 && j < n2) 
    {
        if (op == 2 ? leftArr[i] > rightArr[j] : leftArr[i] < rightArr[j]) 
        {
            arr[k] = leftArr[i];
            i++;
        } 
        else 
        {
            arr[k] = rightArr[j];
            j++;
        }
        k++;
    }

    //Copiar los elementos restantes del subarreglo izquierdo (si los hay)
    while (i < n1) 
    {
        arr[k] = leftArr[i];
        i++;
        k++;
    }

    //Copiar los elementos restantes del subarreglo derecho (si los hay)
    while (j < n2) 
    {
        arr[k] = rightArr[j];
        j++;
        k++;
    }
}

void MergeSort(vector<int>& arr, int op, int left = 0, int right = -1) //Función recursiva para dividir y ordenar el arreglo en subarreglos más pequeños
{
    if (right == -1) 
    {
        right = arr.size() - 1;
    }
    if (left < right) 
    {
        int middle = left + (right - left) / 2;

        // Ordenar el subarreglo izquierdo
        MergeSort(arr, op, left, middle);

        // Ordenar el subarreglo derecho
        MergeSort(arr, op, middle + 1, right);

        // Combinar los subarreglos ordenados
        merge(arr, left, middle, right, op);
    }
}

int medianOfThree(vector<int>& arr, int start, int end)//funcion auxiliar que sirve para el pivote
{
    int mid = start + (end - start) / 2;
    if (arr[start] > arr[mid])
    {
        swap(arr[start], arr[mid]);
    }
    if (arr[start] > arr[end])
    {
        swap(arr[start], arr[end]);
    }
    if (arr[mid] > arr[end])
    {
        swap(arr[mid], arr[end]);
    }
        
    
    // El pivote ahora está en la posición del elemento central
    return mid;
}

int partition(vector<int>& arr, int start, int end, int op)
{
    int pivotIndex = medianOfThree(arr, start, end);
    int pivot = arr[pivotIndex];
    swap(arr[pivotIndex], arr[end]);

    int i = start - 1;

    for (int j = start; j < end; j++)
    {
        if (op == 1 ? arr[j] <= pivot : arr[j] > pivot)
        {
            i++;
            swap(arr[i], arr[j]);
        }
    }

    swap(arr[i + 1], arr[end]);

    return i + 1;
}

void quickSort(vector<int>& arr, int start, int end, int op)
{
    if (start >= end)
    {
        return;
    }

    int p = partition(arr, start, end, op);

    quickSort(arr, start, p - 1, op);
    quickSort(arr, p + 1, end, op);
}

void QuickSort(vector<int>& arr, int op)
{
    int start = 0;
    int end = arr.size() - 1;

    // Ajuste del valor del parámetro op al invertirlo (1->2, 2->1) al llamar quickSort
    int adjustedOp = (op == 1) ? 2 : 1;
    // Llamada a la función auxiliar quickSort con los índices iniciales
    quickSort(arr, start, end, op);
}

void siftDown(vector<int>& arr, int n, int i, int op)
{
    int largest = i;
    int left = 2 * i + 1;
    int right = 2 * i + 2;

    if (op == 1) // Ascendente
    {
        if (left < n && arr[left] > arr[largest])
        {
            largest = left;
        }

        if (right < n && arr[right] > arr[largest])
        {
            largest = right;
        }
    }
    else if (op == 2) // Descendente
    {
        if (left < n && arr[left] < arr[largest])
        {
            largest = left;
        }

        if (right < n && arr[right] < arr[largest])
        {
            largest = right;
        }
    }

    if (largest != i)
    {
        swap(arr[i], arr[largest]);
        siftDown(arr, n, largest, op);
    }
}

void HeapSort(vector<int>& arr, int op)
{
    int n = arr.size();

    // Construir el heap (reorganizar el arreglo)
    for (int i = n / 2 - 1; i >= 0; i--)
    {
        siftDown(arr, n, i, op);
    }

    // Extraer elementos uno por uno desde el heap y colocarlos al final del arreglo ordenado
    for (int i = n - 1; i > 0; i--)
    {
        swap(arr[0], arr[i]);
        siftDown(arr, i, 0, op);
    }
}

void ejecutarCarreraAlgoritmos(const vector<int>& arr, int op)//Función para ejecutar una carrera de algoritmos en un conjunto de datos
{
    //IMPORTANTE: parte que se encarga de almacenar los resultados
    unordered_map<string, double> results;

            //en cada algoritmo se hace una copia del vector original,
           //exclusivo para cada algoritmo para que todos trabajen con el mismo arreglo
          //usando high_resolution_clock::time_point t1s = high_resolution_clock::now();
         //se saca tanto el timepo inicial como el final de la demora de cada algoritmo
        //luego la diferencia se almacena en: 
       //duration<double> "variable tiempo de cada algoritmo" = duration_cast<duration<double>>(t2s - t1s);
      //y por ultimo se guardan los resultados en el mapa usando: 
     //results["Algorritmo Sort"] = "variable tiempo de cada algoritmo".count();
    //despues se libera el espacio ocupado por la copia del algoritmo usando arrcopia.clear();
   //esto se repite en los 7 algoritmos.

   //Selection
   vector <int> arr1(arr.begin(),arr.end());
   high_resolution_clock::time_point t1s = high_resolution_clock::now();
   SelectionSort(arr1,op);
   high_resolution_clock::time_point t2s = high_resolution_clock::now();
   duration<double> time_spans = duration_cast<duration<double>>(t2s - t1s);
   results["Selection Sort"] = time_spans.count();
   cout << endl; 
   arr1.clear();

   //Bubble 
   vector <int> arr2(arr.begin(),arr.end());
   high_resolution_clock::time_point t1b = high_resolution_clock::now();
   BubbleSort(arr2,op);
   high_resolution_clock::time_point t2b = high_resolution_clock::now();
   duration<double> time_spanb = duration_cast<duration<double>>(t2b - t1b);
   results["Bubble Sort"] = time_spanb.count();
   cout << endl; 
   arr2.clear();

   //Insertion 
   vector <int> arr3(arr.begin(),arr.end());
   high_resolution_clock::time_point t1i = high_resolution_clock::now();
   InsertionSort(arr3,op);    
   high_resolution_clock::time_point t2i = high_resolution_clock::now();
   duration<double> time_spani = duration_cast<duration<double>>(t2i - t1i);
   results["Insertion Sort"] = time_spani.count();
   cout << endl; 
   arr3.clear();

   //Shell
   vector <int> arr4(arr.begin(),arr.end());
   high_resolution_clock::time_point t1sh = high_resolution_clock::now();
   shellSort(arr4,op);
   high_resolution_clock::time_point t2sh = high_resolution_clock::now();
   duration<double> time_spansh = duration_cast<duration<double>>(t2sh - t1sh);
   results["Shell Sort"] = time_spansh.count();
   cout << endl; 
   arr4.clear();

   //Merge 
   vector <int> arr5(arr.begin(),arr.end());
   high_resolution_clock::time_point t1m = high_resolution_clock::now();
   MergeSort(arr5,op);
   high_resolution_clock::time_point t2m = high_resolution_clock::now();
   duration<double> time_spanm = duration_cast<duration<double>>(t2m - t1m);
   results["Merge Sort"] = time_spanm.count();
   cout << endl; 
   arr5.clear();
   
   //Quick
   vector <int> arr6(arr.begin(),arr.end());
   high_resolution_clock::time_point t1q = high_resolution_clock::now();
   QuickSort(arr6,op);
   high_resolution_clock::time_point t2q = high_resolution_clock::now();
   duration<double> time_spanq = duration_cast<duration<double>>(t2q - t1q);
   results["Quick Sort"] = time_spanq.count();
   cout << endl; 
   arr6.clear();
   
   //Heap
   vector <int> arr7(arr.begin(),arr.end());
   high_resolution_clock::time_point t1h = high_resolution_clock::now();
   HeapSort(arr7,op);
   high_resolution_clock::time_point t2h = high_resolution_clock::now();
   duration<double> time_spanh = duration_cast<duration<double>>(t2h - t1h);
   results["Heap Sort"] = time_spanh.count();
   cout << endl; 
   arr7.clear();
   
   int id = 1;
   double minTime = numeric_limits<double>::max();
   string winnerAlgorithm;

    // Resultados del algoritmo en cuanto al tiempo
    for (const auto& pair : results) 
    {
        const string& key = pair.first;
        double value = pair.second;

        if (value < minTime) 
        {
            minTime = value;
            winnerAlgorithm = key;
        }
        cout << id << ". " << key << ", " << fixed << setprecision(7) << value << endl;
        id++;
    }

    cout << "El algoritmo ganador es: " << winnerAlgorithm << endl; 
    

}

void ejecutarCarreras()//Función principal para ejecutar todas las carreras de algoritmos en diferentes modos y rangos
{
    
    int op; //variable que permite elegir el modo de ordenamiento de los 7 algoritmos
    cout << "Carreras de algoritmos" << endl;
    cout << "1. Ascendente." << endl;
    cout << "2. Descendente." << endl;
    cout<<"Opcion elegida:"<<endl;
    cin >> op;
          
          //Explicacion global del funcinamiento general de la funcion   
         //inicio de la carrera de algoritmos
        //primero se definen los rangos
       //despues se crea un vector copia para cada set de datos
      //despues ese vector se pasa a la funcion con los 7 algoritmos
     //se limpia la memoria utilizada por el vector copia
    //se repite el proceso hasta 3 veces

    int rangoMin = 1;
    int rangoMax = 100000;

    cout<<"Carrera por el tablero:"<<endl;
    //Modo 1: Ordenado
    cout<<"Modo 1: Ordenado"<<endl;
    vector<int> arrOrd = Ordenado(rangoMin,rangoMax);
    ejecutarCarreraAlgoritmos(arrOrd,op);
    arrOrd.clear();

    //Modo 2: Inversamente Ordenado
    cout<<"Modo 2: Inversamente Ordenado"<<endl;
    vector<int> arrInvOrd = InversamenteOrdenado(rangoMin,rangoMax);
    ejecutarCarreraAlgoritmos(arrInvOrd,op);
    arrInvOrd.clear();

    //Modo 3: Aleatorio
    cout<<"Modo 3: Aleatorio"<<endl;
    vector<int> arrRand = Aleatorio(rangoMin,rangoMax);
    ejecutarCarreraAlgoritmos(arrRand,op);
    arrRand.clear();

    //Modo 4: Aleatorio Sin Duplicar
    cout<<"Modo 4: Aleatorio Sin Duplicar"<<endl;
    vector<int> arrRandSinD = AleatorioSinDuplicar(rangoMin,rangoMax);
    ejecutarCarreraAlgoritmos(arrRandSinD,op);
    arrRandSinD.clear();
    
    /////////////////////////////////////////

    int rangoMin2 = 1;
    int rangoMax2 = 70000;

    cout<<"Carrera por los Caminos"<<endl; 
    //Modo 1: Ordenado
    cout<<"Modo 1: Ordenado"<<endl;
    vector<int> arrOrd2 = Ordenado(rangoMin2,rangoMax2);
    ejecutarCarreraAlgoritmos(arrOrd2,op);
    arrOrd2.clear();

    //Modo 2: Inversamente Ordenado
    cout<<"Modo 2: Inversamente Ordenado"<<endl;
    vector<int> arrInvOrd2 = InversamenteOrdenado(rangoMin2,rangoMax2);
    ejecutarCarreraAlgoritmos(arrInvOrd2,op);
    arrInvOrd2.clear();
    
    //Modo 3: Aleatorio
    cout<<"Modo 3: Aleatorio"<<endl;
    vector<int> arrRand2 = Aleatorio(rangoMin2,rangoMax2);
    ejecutarCarreraAlgoritmos(arrRand2,op);
    arrRand2.clear();

    //Modo 4: Aleatorio Sin Duplicar
    cout<<"Modo 4: Aleatorio Sin Duplicar"<<endl;
    vector<int> arrRandSinD2 = AleatorioSinDuplicar(rangoMin2,rangoMax2);
    ejecutarCarreraAlgoritmos(arrRandSinD2,op);
    arrRandSinD2.clear();
    
    /////////////////////////////////////////

    int rangoMin3 = 1;
    int rangoMax3 = 15000;

    cout<<"Carrera por el Inventario"<<endl; 
    //Modo 1: Ordenado
    cout<<"Modo 1: Ordenado"<<endl;
    vector<int> arrOrd3 = Ordenado(rangoMin3,rangoMax3);
    ejecutarCarreraAlgoritmos(arrOrd3,op);
    arrOrd3.clear();

    //Modo 2: Inversamente Ordenado
    cout<<"Modo 2: Inversamente Ordenado"<<endl;
    vector<int> arrInvOrd3 = InversamenteOrdenado(rangoMin3,rangoMax3);
    ejecutarCarreraAlgoritmos(arrInvOrd3,op);
    arrInvOrd3.clear();
    
    //Modo 3: Aleatorio
    cout<<"Modo 3: Aleatorio"<<endl;
    vector<int> arrRand3 = Aleatorio(rangoMin3,rangoMax3);
    ejecutarCarreraAlgoritmos(arrRand3,op);
    arrRand3.clear();

    //Modo 4: Aleatorio Sin Duplicar
    cout<<"Modo 4: Aleatorio Sin Duplicar"<<endl;
    vector<int> arrRandSinD3 = AleatorioSinDuplicar(rangoMin3,rangoMax3);
    ejecutarCarreraAlgoritmos(arrRandSinD3,op);
    arrRandSinD3.clear();
    



}

int main()
{
    ejecutarCarreras();
    return 0;
}
