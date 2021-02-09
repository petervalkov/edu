/*Низът X е анаграма на низа Y, ако X може да бъде получен от разместването на символите на Y. Например всеки от низовете "baba", "abab", "aabb" и "abba" е анаграма на "baba", а низовете "aaab", "aab" и "aabc" не са анаграми на "baba". По зададено множество от низове S да се намери най-голямото му подмножество, в което няма два или повече низа, които да са анаграми един на друг.
Всеки тестов пример е зададен на стандартния вход с един непразен ред, съдържащ низовете от S, разделени с един или няколко интервала.
Всяко множество S съдържа между 1 и 50 низа, всеки от които е с дължина от 1 до 50.
За всеки тестов пример на стандартния изход да се изведе по едно число – броя на низовете в исканото подмножество.

Input
abcd abac aabc bacd
wlrb m bhc arz wk yhi dqs dxr mowfr sjyb
ab ba
z

Output
2
10
1
1
*/

#include <iostream>
#include <sstream>
#include <algorithm>
#include <set> 

using namespace std;

int main(){
    string input;

    while(getline(cin, input)){
        istringstream iss(input);
        string currentString;
        set<string> result;

        while (iss >> currentString){
            sort(currentString.begin(), currentString.end());
            result.insert(currentString);
        }
        
        cout << result.size() << endl;
    }

    return 0;
}