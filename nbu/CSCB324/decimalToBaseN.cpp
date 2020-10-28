/* https://www.hackerrank.com/cscb324-2021
Convert decimal to base N
Constraints: 2 <= base <= 32; numbers count < 1000; 0 <= number <= 106
Input:
[base][...numbers in decimal]
2 32 100 101
16 15 14 13 12 100 101
Output:
100000 1100100 1100101
F E D C 64 65
16 15 14 13 12 100 101 */

#include<string>
#include<iostream>
#include<sstream>
#include<stack>

using namespace std; 

int main() {
    string input;
    while(getline(cin, input)){
        istringstream iss(input);
        int base;
        iss >> base;

        while (iss)
        {
            int number;
            iss >> number;
            stack<char> out;

            while(number){
                int digit = number % base;
                out.push((digit > 9 ? (char)(digit+55) : (char)(digit+48)));
                number /= base;
            }

            while (!out.empty()) {
                cout << out.top();
                out.pop();  
            }

            cout << " ";
        }
        
        cout << endl;
    }  

    return 0;
}