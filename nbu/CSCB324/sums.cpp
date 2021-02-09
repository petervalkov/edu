/* Дадено е мултимножество от цели числа. Напишете програма, която да брои колко различни суми може да се получат от събиране на двойки числа от множеството.
На стандартния вход се задават много тестови примери. Всеки пример се състои от число k - брой на елементите на множеството и още k числа за самите елементи.
1 < k <= 100
Елементите на множеството са цели числа в интервала [-1000, 1000]
За всеки тестов пример на отделен ред се отпечатва отговора.
Input
3
1 1 1
4
1 2 3 4

Output
1
5
*/

#include <iostream>
#include <vector>
#include <math.h>
#include <set>

using namespace std;

bool isPrime(long long n)
{
    if (n <= 1) return false;
    for (int i = 2; i <= sqrt(n); i++)
        if (n % i == 0) return false;
    return true;
}

int main()
{
    int count;

    while(cin >> count){
        vector<int> vec;
        for(int i = 0; i < count; i++){
            int current;
            cin >> current;
            vec.push_back(current);
        }

        set<int> result;
        int counter = 0;

        for(int i = 0; i < count; i++){
            for(int j = i+1; j < count; j++){
                int currentSum = vec[i] + vec[j];

                if(result.find(currentSum) == result.end()){
                    counter++;
                    result.insert(currentSum);
                }
            }
        }

        cout << counter << endl;
    }

    return 0;
}
