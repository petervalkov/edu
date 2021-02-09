/*Една крайна редица от цели числа се нарича зигзаг, ако всеки елемент на редицата (без първия и последния) е или по-голям от двата му съседа или по-малък от двата съседни елемента. Да се напише програма за определяне дали дадена редица е зигзаг.
На стандартния вход се задават числови редици - всяка на отделен ред с разделител един интервал между числата.
Всички числа се представят в типа int на С++.
За всяка редица се извежда на отделен ред yes за зигзаг и no - за редица, която не е зигзаг.
Input
2 4 3 5 4 6
10 2 9 4 2 5 4
Output
yes
no
*/

#include <iostream>
#include <sstream>
#include <vector>
#include <algorithm>

using namespace std;

int main(){
    string currentCase;

    while(getline(cin, currentCase)){
        vector<int> elements;
        istringstream iss(currentCase);
        int currentElement;
        while(iss >> currentElement){
            elements.push_back(currentElement);
        }

        bool isZigZag = true;
        
        for (size_t i = 1; i < elements.size() - 1; i++){
            if((elements[i] < elements[i - 1] && elements[i] < elements[i + 1])
            || (elements[i] > elements[i - 1] && elements[i] > elements[i + 1])){
                continue;
            }

            isZigZag = false;
        }
        
        cout << (isZigZag ? "yes" : "no") << endl;
    }

    return 0;
}


