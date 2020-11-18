/*https://www.hackerrank.com/contests/nbu-october-2020-programming-contest/challenges/e--8/problem
Имате число 0 <= x0 <= 2^70. Ако числото е по-голямо или равно на 10, събирате цифрите му и ще получите ново число x1 . Ако x1 е по-голямо или равно на 10 събирате цифрите му и получавате ново число x2. Продължете тази процедура докато получите едноцифрено число. Това число се нарича "цифров корен" на x0. Напишете програма, която намира цифровия корен на дадено число x.
На всеки отделен ред на стандартния вход е зададено цяло число . Краят на входа е маркиран с -1.
За всеки тест извеждайте на отделен ред, на стандартния изход цифровия корен на даденото число x, спазвайки изходния формат, показан в примера.

Input
65536
8
2035
10
24675
1244
1180591620717411303424
22
-1

Output
Digital root of 65536 is 7
Digital root of 8 is 8
Digital root of 2035 is 1
Digital root of 10 is 1
Digital root of 24675 is 6
Digital root of 1244 is 2
Digital root of 1180591620717411303424 is 7
Digital root of 22 is 4
*/

#include<iostream>
#include<string>

using namespace std;

int main(){
    string input;
    getline(cin, input);

    while(input != "-1"){

        int number = 0;
        if(input.size() > 10){
            for (size_t i = 0; i < input.size(); i++)
            {
                number += input[i] - 48;
            }
        } else {
            number = stoi(input);
        }

        while(number >= 10){
            int sum = 0;
            while(number){
                sum += number % 10;
                number = number /10;
            }
            number = sum;
        }

        cout << "Digital root of " << input << " is " << number << endl;
        
        getline(cin, input);
    }

    return 0;
}