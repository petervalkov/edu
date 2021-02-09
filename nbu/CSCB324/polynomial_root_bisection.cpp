/*Да се намери корен на уравнението f(x) = 0 в интервала (0, 10), където f(x) = x5 - 2x3 - ax2 - x - (F mod 100), а F е числото от факултетния Ви номер. Да се използва метода на разполовяването с точност 10-19 по аргумента и по стойността на функцията (виж Bisection method).
На стандартния вход се задава редица от стойности на числото a.
За всяка стойност на числото  a резултатът (решението на уравнението) да се изведе на отделен ред с точност 20 значещи цифри. Ако уравнението няма решение, да се изведе NO SOLUTION.
Проверете решението с Wolfram Alpha.*/

#include <iostream>
#include<iomanip>

using namespace std;

#define EPSILON 0.000000000000000001L 
int fN = 96402;
int a;

long double func(long double x){ 
    return x*x*x*x*x - 2*x*x*x - a*x*x - x - fN % 100; 
} 

int main(){
    while(cin >> a){
        long double low = 0.0L;
        long double high = 10.0L;
        long double mid = low;

        if (func(low) * func(high) >= 0){ 
            cout << "NO SOLUTION"; 
            continue; 
        } 
    
        while (high - low >= EPSILON){ 
            mid = (low + high) / 2;
            long double currentResult = func(mid);

            if (currentResult == 0) 
                break;

            if (currentResult * func(low) < 0) 
                high = mid;
            else 
                low = mid;
        } 
        
        cout << setprecision(19) << mid << endl; 
    }

    return 0; 
}