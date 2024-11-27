
#include "State.h"
#include <functional>


  // initialize empty board
  // MAX to move
  State::State()
  {
    sq = { {} };  //inicializa la matriz del tablero
    to_move = MAX;  //establece que MAX es el proximo en mover
    filled = 0;  //no hay celdas llenas al inicio
  }

  //devuelve true si el tablero esta lleno
  bool State::full() const
  {
    return filled >= SIZE; 
  }
  
  //inicializa el estado desde una cadena (MAX para mover)
  //lanza InputException cuando encuentra un error en la cadena s
  void State::set(const string & s)
  {
    //crea un flujo de entrada desde la cadena, ahora se puede usar >>, etc.
    //como se hace con cin
    istringstream is(s);
    char c;

    to_move = MAX;  //establece que MAX es el proximo en mover
    filled = 0;  //reinicia el contador de celdas llenas

    //recorre filas y columnas
    for (int y=0; y < M; ++y) {
      for (int x=0; x < N; ++x) {
        is >> c;    //lee un carácter del flujo
        
        //si hay un error en la lectura, lanza una excepcion de entrada
        if (!is) {
          throw InputException();
        }

        //si el caracter representa a MAX, establece la celda como MAX 
        //e incrementa el contador de celdas llenas
        if      (c == DISP[1+MAX]) { sq[y][x] = MAX; ++filled; }

        //si el caracter representa a MIN, establece la celda como MIN 
        //e incrementa el contador de celdas llenas
        else if (c == DISP[1+MIN]) { sq[y][x] = MIN; ++filled; }
        
        //si el caracter representa una celda vacia
        //establece la celda como vacia    
        else                         { sq[y][x] = 0; }
      }
    }

    is >> c;// Intenta leer un carácter más
   
    //si hay caracteres sobrantes
    //lanza una excepción de entrada
    if (is) {
      //trailing character(s)
      throw InputException();
    }
  }
  
  // print state to cout
  // format:
  //
  //  xox
  //  o-x
  //  xxo
  //  x (8)
  //
  // last line: player to move, number of filled squares
  // followed by new-line
  void State::print() const
  {
    for (int y=0; y < M; ++y) {
      for (int x=0; x < N; ++x) {
        cout << DISP[sq[y][x] + 1];
      }
      cout << endl;
    }
    // print player to move and #filled squares
    cout << DISP[to_move + 1]
         << " (" << filled << ")"
         << endl;
  }
  

// devuelve una estimacion de quien está ganando
// valores positivos hasta WIN significan que el jugador actual esta ganando,
// valores negativos hasta -WIN significan que el oponente está ganando, 
// 0 significa empate
int State::eval() const {
    const int WIN_SCORE = 1000; //puntaje maximo para una posicion ganadora
    const int LOSE_SCORE = -WIN_SCORE; //puntaje minimo para una posicion perdedora

    int player = get_to_move(); //el jugador actual es 1 o -1
    int opponent = -player; //el oponente es el jugador contrario

    //comprobar si el estado actual es una victoria o derrota
    if (win() == player) return WIN_SCORE;
    if (win() == opponent) return LOSE_SCORE;

    int score = 0;

    

     //lambda auxiliar para evaluar una linea de K celdas
    auto evaluate_line = [&](int line[], int length) {
        int player_count = 0, opponent_count = 0, empty_count = 0;
        for (int i = 0; i < length; ++i) {
            if (line[i] == player) player_count++;
            else if (line[i] == opponent) opponent_count++;
            else empty_count++;
        }

        //puntuar en funcion de cuan cerca esta la linea de ganar
        if (opponent_count == 0) {
            if (player_count == K - 1) score += 300; //cerca de ganar
            else if (player_count == K - 2) score += 200; //potencial fuerte
            else if (player_count == K - 3) score += 150; //potencial debil
        } else if (player_count == 0) {
            if (opponent_count == K - 1) score -= 300; //cerca de perder
            else if (opponent_count == K - 2) score -= 200; //amenaza fuerte
            else if (opponent_count == K - 3) score -= 150; //amenaza debil
        }
    };


    //evalua filas
    for (int y = 0; y < M; ++y) {
        for (int x = 0; x <= N - K; ++x) {
            int line[K];
            for (int k = 0; k < K; ++k) line[k] = sq[y][x + k];
            evaluate_line(line, K);
        }
    }

    //evalua columnas
    for (int x = 0; x < N; ++x) {
        for (int y = 0; y <= M - K; ++y) {
            int line[K];
            for (int k = 0; k < K; ++k) line[k] = sq[y + k][x];
            evaluate_line(line, K);
        }
    }

    //evaluar diagonales (de arriba a la izquierda a abajo a la derecha)
    for (int y = 0; y <= M - K; ++y) {
        for (int x = 0; x <= N - K; ++x) {
            int line[K];
            for (int k = 0; k < K; ++k) line[k] = sq[y + k][x + k];
            evaluate_line(line, K);
        }
    }

    //evaluar diagonales (de abajo a la izquierda a arriba a la derecha)
    for (int y = K - 1; y < M; ++y) {
        for (int x = 0; x <= N - K; ++x) {
            int line[K];
            for (int k = 0; k < K; ++k) line[k] = sq[y - k][x + k];
            evaluate_line(line, K);
        }
    }

    //asegurarse de que el puntaje no supere el puntaje maximo de victoria
    if(score >= WIN_SCORE)
    {
        score =999;
    }

    return score; //devuelve el puntaje ajustado por la perspectiva del jugador actual
}
  
  // retorna WIN si MAX gana, -WIN si MIN gana y 0 de lo contrario.
 int State::win() const {
    
    //verificacion de filas
    for (int y = 0; y < M; ++y) {
        for (int x = 0; x <= N - K; ++x) {
            bool win = true;
            for (int k = 1; k < K; ++k) {
                if (sq[y][x] == 0 || sq[y][x] != sq[y][x + k]) {
                    win = false;
                    break;
                }
            }
            if (win) {
                return sq[y][x];
            }
        }
    }

    //verificacion de columnas
    for (int x = 0; x < N; ++x) {
        for (int y = 0; y <= M - K; ++y) {
            bool win = true;
            for (int k = 1; k < K; ++k) {
                if (sq[y][x] == 0 || sq[y][x] != sq[y + k][x]) {
                    win = false;
                    break;
                }
            }
            if (win) {
                return sq[y][x];
            }
        }
    }

    //verificacion de diagonales (de arriba-izquierda a abajo-derecha)
    for (int y = 0; y <= M - K; ++y) {
        for (int x = 0; x <= N - K; ++x) {
            bool win = true;
            for (int k = 1; k < K; ++k) {
                if (sq[y][x] == 0 || sq[y][x] != sq[y + k][x + k]) {
                    win = false;
                    break;
                }
            }
            if (win) {
                return sq[y][x];
            }
        }
    }

    //verificacion de diagonales (de abajo-izquierda a arriba-derecha)
    for (int y = K - 1; y < M; ++y) {
        for (int x = 0; x <= N - K; ++x) {
            bool win = true;
            for (int k = 1; k < K; ++k) {
                if (sq[y][x] == 0 || sq[y][x] != sq[y - k][x + k]) {
                    win = false;
                    break;
                }
            }
            if (win) {
                return sq[y][x];
            }
        }
    }

    return 0; //ningun ganador
}

  // realiza el movimiento (x, y) para que el jugador se mueva
  // y devuelve verdadero si el movimiento es legal
  // condición previa: x, y dentro del rango
  bool State::make_move(int x, int y)
  {
    assert(x >= 0 && x < M && y >= 0 && y < N);
    auto &c = sq[y][x];
    if (c) {
      return false; // ya esta ocupado
    }
    
    c = to_move;
    to_move = - to_move;
    ++filled;
    return true;
  }

  // retorna player to move
  int State::get_to_move() const
  {
    return to_move;
  }
  // se agrego este para acceder al sq
  int State::getSq(int x, int y) const {
    return sq[y][x];
  }

// how pieces are displayed ...
// MIN, empty, MAX
const array<char, 3> State::DISP = {{ 'o', '-', 'x' }};
