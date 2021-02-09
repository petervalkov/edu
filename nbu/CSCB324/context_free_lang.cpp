/*Да се напише програма за автоматична проверка на синтактичната коректност на думи от контекстно свободния език Хе. Думите в този език се образуват според следните правила:
0. Символите в езика са p, q, r, s, t, u, v, w, x, y, z и N, C, D, E, I.
1. Всеки символ измежду p, q, r, s, t, u, v, w, x, y, z е дума от езика Хе.
2. Ако S е дума, то NS също е дума от езика.
3. Ако S и T са думи от езика, то такива са и CST, DST, EST и IST.
4. Няма други думи в езика Хе, освен тези, получени по правилата 0, 1, 2 и 3.
На стандартния вход са зададени много низове, състоящи се от малки и главни букви на латинската азбука.
За всеки низ от входа на стандартния изход на отделен ред да се отпечати ""correct", ако низът е дума от езика Хе, или "incorrect", ако не е.

Input
v NN
 Czz a INtp

Output
correct
incorrect
correct
incorrect
correct
*/

#include <iostream>

unsigned char solution[1000][1000];

using namespace std;

unsigned char solve(unsigned start, unsigned end, string currentCase){
    unsigned k;
    if (2 != solution[start][end]){
        return solution[start][end];
    }
    else{
        if (start == end){
            solution[start][end] = (currentCase[start] >= 'p' && currentCase[start] <= 'z');
        }else if ('N' == currentCase[start]){
            solution[start][end] = solve(start + 1, end, currentCase);
        }else if ('C' == currentCase[start] || 'D' == currentCase[start] || 'E' == currentCase[start] || 'I' == currentCase[start]){
            k = start + 1;
            while (k < end && !(solve(start + 1, k, currentCase) && solve(k + 1, end, currentCase))){
                k++;
            }
             
            solution[start][end] = (k != end);
        }
        else{
            solution[start][end] = 0;
        }

        return solution[start][end];
    }
}

int main(){
    string currentCase;
    while (cin >> currentCase){
        int n = currentCase.length();
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                solution[i][j] = 2;

        cout << (solve(0, n - 1, currentCase) ? "correct" : "incorrect") << endl;
    }

    return 0;
}
