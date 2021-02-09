/*Да се напише програма за намиране на най-дълга ненамаляваща подредица.
На входа се задава числото n - брой на елемнтите на редицата  и след това стойностите на самите елементи - цели числа в интервала [-10, 10^5].  Входът съдържа много примери.
За всеки пример на отделен ред се отпечатва цяло число - дължината на най-дългата ненамаляваща подредица.

Пример:
6
6 6 6 2 2 7
6
1 1 1 1 1 2
15
1 2 1 2 1 2 1 2 1 2 1 2 1 2 1
3
4 3 2

Решение на примера:
4
6
8
1
*/

#include <iostream>

using namespace std;

int main(){
    int elementsCount;

    while(cin >> elementsCount){
        int best = 1;
        int* elements = new int[elementsCount];
        int* solution = new int[elementsCount];

        for (int i = 0; i < elementsCount; i++){
            cin >> elements[i];
            solution[i] = 1;

            for (int j = 0; j < i; j++){
                if(elements[i] >= elements[j] && solution[i] < solution[j] + 1){
                    solution[i] = solution[j] + 1;
                    best = best < solution[i] ? solution[i] : best;
                } 
            }
        }
        
        cout << best << endl;
        delete elements;
        delete solution;
    }

    return 0;
}
