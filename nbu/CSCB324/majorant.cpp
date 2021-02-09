/*Да се намери мажорантът на множество от n низа.
На стандартния вход се задава числото n (1 < n < 105) - брой на елементите на множеството и стойностите на самите елементи. Входът съдържа много примери. Низовете не съдържат интервали.
За всеки пример на отделен ред се отпечатва низа, мажорант на множеството или  "-", ако множеството няма мажорант.

Вход
6 abc abc               aaaa
bbbb        abc
            abc
   12
qwerty a a a a

a qwerty qwerty a a a a

2
A
ZZZ
 
Изход
abc
a
-
*/

#include <iostream>
#include <map>

using namespace std;

int main()
{
    int elementsCount;

    while(cin >> elementsCount){
        map<string, int> elements;
        bool hasMajorant = false;
        string majorant;

        for (int i = 0; i < elementsCount; i++){
            string currentElement;
            cin >> currentElement;
            elements[currentElement]++;
            
            if(!hasMajorant && elements[currentElement] > elementsCount / 2){
                hasMajorant = true;
                majorant = currentElement;
            }
        }

        if(hasMajorant) cout << majorant << endl;
        else cout << "-" << endl;
    }
}