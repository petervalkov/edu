/*https://www.hackerrank.com/contests/cscb324-2021/challenges/2021-3/problem
Да се напише програма за пресмятане на аритметични изрази, съдържащи събиране и изваждане на прости дроби. Резултатът да се представи като несъкратима дроб.
Всеки пример се задава със суми и разлики на дроби на отделен ред (виж примера по-долу). Входът съдържа няколко примера.
Всички числа в израза са цели положителни числа и по-малки от 10000.
За всеки пример на изхода се записва резултата като несъкратимата дроб по същия начин, както зададените на входа дроби. Когато решението е цяло число, то се записва по нормалния начин.

Input
1/2 + 1/3 - 1/6
10/4 - 2/4

Output 0
2/3
2
*/

#include <iostream>
#include <sstream>

using namespace std;

long long gcd(long long a, long long b){
    long long temp;
    while (b > 0){
        temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

int main()
{
    string input;
    while (getline(cin, input)){
        istringstream iss(input);
        long long  num, den, secNum, secDen;
        char slash, sign;

        iss >> num >> slash >> den;

        while (iss >> sign >> secNum >> slash >> secDen){
            if (sign == '+') num = (num * secDen) + (secNum * den);
            else if (sign == '-') num = (num * secDen) - (secNum * den);
            den = den * secDen;  
        }

        long long div;

        if(num < 0) div = gcd(-num, den);
        else div = gcd(num, den);

        num /= div;
        den /= div;

        cout << num;
        if (den != 1 && num != 0) cout << '/' << den;
        cout << endl;
    }

    return 0;
}