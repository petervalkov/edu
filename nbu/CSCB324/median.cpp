/*https://www.hackerrank.com/contests/nbu-october-2020-programming-contest/challenges/mediana-17
Дадено се множество от N цели положителни числа. Да се напише програма, която да намира медианата на множеството. Медиана е средния елемент в нареденото множество.
Най-напред на входа се задава броя на примерите. За всеки пример на отделен ред е даден броя N на елементите на множеството. Следват самите елементи, които са числа, по-малки от 10^20.
За всеки пример на изхода на отделен ред се отпечатва отговора. Ако има два средни елементи, да се отпечати по-малкия.

Constraints
N < 10^11 

Input
2
5
12 4 22 31 32
8
22 33 44 11 55 66 88 99

Output 
22
44
*/

#include <iostream>
#include <bits/stdc++.h>

using namespace std;

int main()
{
    int inputsCount;
    cin >> inputsCount;
    while (inputsCount--)
    {
        long long n;
        cin >> n;
        vector<unsigned long long> data;
        for (long long i = 0; i < n; i++)
        {
            unsigned long long currentNum;
            cin >> currentNum;
            data.push_back(currentNum);
        }

        sort(data.begin(), data.end());

        cout << (n % 2 == 1 ? data[n / 2] : data[n / 2 - 1]) << endl;
    }
    return 0;
}