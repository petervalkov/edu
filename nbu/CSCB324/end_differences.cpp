/*https://www.hackerrank.com/contests/nbu-october-2020-programming-contest/challenges/challenge-2673/problem
Дадена е редица a1, a2, ..., an от n=2^n цели числа. От нея може да се получи друга редица b1, b2,..., bn/2 по следното правило:

b1 = a2 - a1
b2 = a4 - a3
...
b(k) = a(2k) - a(2k-1)
...
b(n/2) = a(n) - a(n-1)
Прилагаме същото правило за новата редица. Да се намери числото, получено след m стъпки.
За всеки пример на един ред се задава число n - дължината на редицата. На следващия ред са записани n цели числа с разделител интервал. Входът съдържа много примери.
За всеки пример от входа да се отпечати намереното число на отделен ред.

Constraints
1 <= m <= 10
Числата в редицата са в интервала [-100, 100].

Input
4
12 10 22 11
8
-2 2 -3 4 1 -2 3 2
Output
-9
-1
*/

#include<iostream>
#include<queue>

using namespace std;

int main(){
    int n;
    while(cin >> n){
        queue<int> data;
        while(n--){
            int currentNum;
            cin >> currentNum;
            data.push(currentNum);
        }

        while (data.size() > 1)
        {
            int value = data.front();
            data.pop();
            value = data.front() - value;
            data.pop();
            data.push(value);
        }
        cout << data.front() << endl;
    }
    return 0;
}