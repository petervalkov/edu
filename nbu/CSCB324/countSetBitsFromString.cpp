/* https://www.hackerrank.com/contests/nbu-october-2019-programming-contest/challenges/challenge-2205
Count set bits in integer
Constraints: 10^10 <= n <= 10^100; 
Input:
[n]
11111111111111111111111111111
12345678900
Output:
48
19 */

#include<string>
#include<iostream>

using namespace std; 

int main() {
    string input;

    while(getline(cin, input)){
        bool isZero = false;
        int bitCounter = 0;
        unsigned long numberSize = input.size();
        int* arr = new int[numberSize];

        for (size_t i = 0; i < numberSize; i++) arr[i] = input[i] - 48;

        while (!isZero)
        {
            isZero = true;
            int carry = 0;
            bitCounter += arr[numberSize - 1] % 2;

            for (size_t i = 0; i < numberSize; i++)
            {
                if(arr[i] != 0) isZero = false;

                int newDigit = arr[i] / 2 + carry;
                carry = (arr[i] % 2) * 5;
                arr[i] = newDigit;
            }
        }

        cout << bitCounter << endl;
    }  

    return 0;
}