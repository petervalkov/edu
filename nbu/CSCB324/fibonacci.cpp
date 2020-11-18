/*https://www.hackerrank.com/contests/cscb324-2021/challenges/2021-2/problem
Обобщена редица на Фибоначи F(n) дефинираме по следния начин:
F(n) = (aF(n-p) + bF(n-q)) mod 1000000
където a, b, p, q и k са положителни цели числа при дадени
N(n) = 1 при n < 0,
F(0) = F(1) = 1,
F(n) = n при 1 < n < k
Да се намери броя на простите чсла в множеството от първите 1000 члена на редицата.
За всеки пример на отделен ред са дадени числата a, b, p, q и k.
a, b, p, q и k са по-малки от 100.
За всеки пример на отделен ред да се отпечати търсения брой.

Input
1 1 1 2 2
1 2 3 4 5

Output
118
53
*/

#include <iostream>
#include <sstream>
#include <math.h>

using namespace std;

int res[1000];

bool isPrime(int n)
{
    if (n <= 1) return false;
    for (int i = 2; i <= sqrt(n); i++)
        if (n % i == 0) return false;
    return true;
}

int main()
{
    string input;

    while (getline(cin, input)) {
        int a, b, p, q, k, counter = 0;

        istringstream iss(input);
        iss >> a >> b >> p >> q >> k;

        for (int i = 0; i < 1000; i++) {
            int current;

            if (i < 2) {
                current = 1;
            } else if (i < k) {
                current = i;
            } else {
                int firstIndex = (i - p) < 2 ? 1 : i - p;
                int secondIndex = (i - q) < 2 ? 1 : i - q;
                current = (a * res[firstIndex] + b * res[secondIndex]) % 1000000;
            }

            if (isPrime(current)) {
                counter++;
            }

            res[i] = current;
        }

        cout << counter << endl;
    }

    return 0;
}
