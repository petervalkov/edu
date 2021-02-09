/*Дадено е естествено число n и обобщена шахматна дъска с размери n x n клетки. Да се намери обхождане на дъската с хода на коня. Всяка клетка трябва да бъде посетена точно веднаж, като обиколката започва от произволна предварително зададена клетка от дъската.
На входа се задава числото n (2 < n < 8) и координатите на началната клетка (положението на коня върху дъската). Долният ляв ъгъл е с координати (1,1). Входът съдържа много тестови примери.
За всеки тест се отпечатва таблица (матрица n x n) с елементи - поредните номера на ходовете на коня. Примерите се отделят с един празен ред. Ако задачата няма решение, да се отпечати нулева таблица.
Пример:
6 1 1

10 27  6 19 16 25
 7 20  9 26  5 18
28 11  4 17 24 15
21  8 23 32  3 34
12 29  2 35 14 31
 1 22 13 30 33 36
*/

#include <iostream>
#include <cstring>
using namespace std;
 
int n;
bool successfull;
int rowMove[] = { 2, 1, -1, -2, -2, -1,  1,  2};
int colMove[] = { 1, 2,  2,  1, -1, -2, -2, -1};
 
void solve(int** board, int x, int y, int counter){
    if(successfull) return;

    board[x][y] = counter;
    if (counter >= n * n){
        successfull = true;
        for (int i = 0; i < n; i++){
            for (int j = 0; j < n; j++){
                cout << board[i][j] << " ";
            }
            cout << endl;
        }
        return;
    }

    for (int k = 0; k < 8; k++){
        int newX = x + rowMove[k];
        int newY = y + colMove[k];

        if ((newX >= 0 && newY >= 0 && newX < n && newY < n) && !board[newX][newY]){
            solve(board, newX, newY, counter + 1);
        }
    }

    board[x][y] = 0;
}
 
 
int main(){
    int row, col;

    while(cin >> n >> row >> col){
        successfull = false;
        int** board;
        board = new int*[n];

        for(int i = 0; i <n; i++){
            board[i] = new int[n]{0};
        }

        solve(board, n - row, col - 1, 1);

        if(!successfull){
            for (int i = 0; i < n; i++){
                for (int j = 0; j < n; j++){
                    cout << 0 << " ";
                }
                cout << endl;
            }
        }

        delete board;
    }

    return 0;
}