

#include <cassert>
#include <cstring>
#include <iostream>
#include <sstream>
#include <vector>
#include <array>
#include "State.h"

#include <limits.h>

//numero de evaluaciones realizadas
// # evaluations performed
int evals;

// busqueda minimax (variante negamax)
// retorna el valor del estado [-WIN - WIN] en vista del JUGADOR que DEBE MOVER
// es decir, si MAX debe mover y MAX gana, retorna WIN
// si MAX debe mover y MAX pierde, retorna -WIN
// si MAX debe mover y el juego es empate, retorna 0
// si MIN debe mover y MIN gana, retorna WIN
// si MIN debe mover y MIN pierde, retorna -WIN
// si MIN debe mover y el juego es empate, retorna 0
// tambien almacena el mejor movimiento en best_x, best_y ; (-1, -1) si no hay movimientos disponibles
int negamax(const State &st, int &best_x, int &best_y, int height)
{
  evals++;

  if(st.full()==true) //si el estado de juego esta completo 
  {
    best_x = best_y = -1; //no hay movimientos validos
  }

  //si el juego esta completo, se ha alcanzado la profundidad o alguien ha ganado, retorna la evaluacion del estado
  if(st.full()==true|| height ==0|| st.win() !=0 )
  {
    return st.eval();
  }
 
  int score = -1000;//inicializa el puntaje con un valor muy bajo
  int value;
  
  //recorre todas las casillas del tablero
  for(int y=0; y<st.M; ++y)
  {
    for(int x=0; x<st.N;++x)
    {
      //si la casilla esta vacia
      if(st.getSq(x,y)==0)
      {
        State child =st;
        child.make_move(x,y);//realiza el movimiento
        value = -negamax(child,best_x,best_y,height-1);//llama recursivamente a negamax
        if(value >score)//si el valor es mayor que el puntaje actual, actualiza el puntaje y el mejor movimiento
        {
          score = value;
          best_x =x;
          best_y =y;
        }
      }
    }
  }
  
  //Retorna el puntaje del estado
  return score;
}

//busqueda alpha-beta
//retorna el valor del estado [-WIN - WIN] en vista del JUGADOR que DEBE MOVER
int alphabeta(const State &st, int &best_x, int &best_y, int height, int alpha, int beta)
{
  evals++;

  
  if(st.full()==true)//si el estado de juego esta completo 
  {
    best_x = best_y = -1; //no hay movimientos validos
  }
  
 //si el juego esta completo, se ha alcanzado la profundidad o alguien ha ganado, retorna la evaluacion del estado
  if (st.full()==true || height == 0 || st.win()!=0) {
    return st.eval();
  }

  int score = -1000; //very low value, representing -INF
  
  //recorre todas las casillas del tablero
  for(int y=0; y<st.M; y++)
  {
    for(int x=0; x<st.N; x++)
    {
      //si la casilla esta vacia
        if(st.getSq(x,y)==0)
        {
          State child = st;
          child.make_move(x,y);//realiza el movimiento
          int value = -alphabeta(child, best_x, best_y, height - 1, -beta, -alpha);//llama recursivamente a alphabeta
        
          if(value > score)//si el valor es mayor que el puntaje actual, actualiza el puntaje y el mejor movimiento
          {
            score = value;
            best_x = x;
            best_y = y; 
          }
          if(score > alpha)//actualiza alpha si el puntaje es mayor
          {   
            alpha = score;        
          }

          if(alpha >= beta)//realiza la poda beta si alpha es mayor o igual a beta
          {                
             break;
          }

        }
    }    
  }

  //retorna el puntaje del estado
  return score;

}

// resolver la posición dada en el estado st e imprimir el siguiente resultado en stdout:
// - primero imprime el estado
// - luego, si un jugador ya gano sin hacer un movimiento, imprime "a player already won"
// - de lo contrario, imprime "draw" si no hay movimientos disponibles
// - de lo contrario, imprime "p wins with (x,y)" para el jugador que debe mover p (x o o) y un mejor movimiento (x,y) si el jugador p gana
// - de lo contrario, imprime "p draws with (x,y)" para el jugador que debe mover p (x o o) y un mejor movimiento (x,y) si el jugador p empata
// - de lo contrario, imprime "p loses" si el jugador que debe mover p (x o o) pierde
void solve(const State & st)
{
  cout<<"**********************NEW BOARD*****************************"<<endl;
  for(int i=2;i<8;i+=2){
    cout<<"===================Depth: "<<i<<"========================"<<endl;
    evals=0;
    st.print();
    int v = st.win();
    if (v != 0) {
      cout << "a player already won";
    } else if (st.full()) {
      cout << "draw";
    } else {
      int best_x, best_y;
      char tm = State::DISP[st.get_to_move() + 1];
      int v = negamax(st, best_x, best_y,i);
      if (v > 0) {
        cout << tm << " wins with (" << best_x << "," << best_y << ")";
      } else if (v == 0) {
        cout << tm << " draws with (" << best_x << "," << best_y  << ")";
      } else {
        cout << tm << " loses";
      }
    }
    cout <<endl<< "Negamax Visited nodes: "<<evals<<endl;


    evals=0;
    //st.print();
    v = st.win();
    if (v != 0) {
      cout << "a player already won";
    } else if (st.full()) {
      cout << "draw";
    } else {
      int best_x, best_y;
      char tm = State::DISP[st.get_to_move() + 1];
      int v = alphabeta(st, best_x, best_y,i, -100000, 100000);
      if (v > 0) {
        cout << tm << " wins with (" << best_x << "," << best_y << ")";
      } else if (v == 0) {
        cout << tm << " draws with (" << best_x << "," << best_y  << ")";
      } else {
        cout << tm << " loses";
      }
    }
    cout <<endl<< "Alphabeta Visited nodes: "<<evals<<endl;
    }

}


    std::vector<string> boards3
  {
    "--- \
     --- \
     ---", // x draws with (0,0)

    "--- \
     -o- \
     ---", // x draws with (0,0)

    "--- \
     --o \
     ---", // x draws with (0,1)

    "-oo \
     ooo \
     ooo", // a player already won
  
    "xox \
     oxo \
     oxo", // draw

    "--o \
     -oo \
     ---", // x loses

    "oxo \
     xx- \
     oox", // x wins with (2,1)

    "-xo \
     oox \
     xoo", // x draws with (0,0)

    "--- \
     -x- \
     ---"  // x wins with (0,0)
};
   std::vector<string> boards4
  {
    "-x-o \
     ooxo \
     oox- \
     xoo-",

    "---- \
     ---- \
     ---- \
     ----"



  };
   std::vector<string> boards5
  {
    "----- \
     ----- \
     ----- \
     ----- \
     -----"
  };

void test(){
  for (const string & s : boards3) {
    // construct state from string
    // also catch exception and print
    // error message
    try {
      State st;
      st.set(s);
      st.print();
      cout<<st.win()<<endl;
      solve(st);
      cout << endl;
    }
    catch (InputException & e) {
      cerr << "corrupt input: " << s << endl;
    }
  }
}

void play(){
  State st;
  while(!st.full() && st.win()==0){
    st.print();cout<<endl;
    int best_x, best_y;
    int v = alphabeta(st, best_x, best_y,6,-10000,10000);
    //int v = negamax(st, best_x, best_y,4);
    cout <<"x es igual a" << best_x <<endl;
    cout <<"y es igual a" << best_y <<endl;
    assert(st.make_move(best_x,best_y));

    st.print();cout<<endl;
    if(!st.full() && st.win()==0){
      v = alphabeta(st, best_x, best_y,2,-10000,-10000);
    //  v = negamax(st, best_x, best_y,4);
      cout <<"x es igual a" << best_x <<endl;
      cout <<"y es igual a" << best_y <<endl;
      assert(st.make_move(best_x,best_y));  
    }

  }
  st.print();
}      
  
int main()
{
  test();
  play();

  return 0;

}
