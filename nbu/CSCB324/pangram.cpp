/*https://www.hackerrank.com/contests/nbu-october-2020-programming-contest/challenges/c--3
Панграм е изречение, включващо всички букви от дадена азбука.
Напишете програма, която да разпознава панграми. В конкретната задача азбуката е латинската. Едно изречение е панграм, ако съдържа поне веднъж всяка от 26-те букви ‘a’…‘z’, без значение дали е главна или малка буква.
На първия ред на стандартния вход е зададен броя на тестовите примери n. Следват n реда. На всеки от тях ще има последователност от най-много 100 символа, описващи поредния тест.
Отговорът за всеки тест извеждайте на отделен ред на стандартния изход. Ако дадено изречение е панграм, извеждайте “pangram“. В противен случай извеждайте „missing“, интервал и липсващите букви. Всички липсващи букви трябва да се малки и между тях не трябва да има интервали. Също така трябва да се подредени лексикографски.

Input
3
The quick brown fox jumps over the lazy dog.
ZYXW, vu TSR Ponm lkj ihgfd CBA.
.,?!'" 92384 abcde FGHIJ

Output
pangram
missing eq
missing klmnopqrstuvwxyz
*/

#include<iostream>
#include<string>
#include<list>
#include<set>
#include<iterator>
#include<vector>

using namespace std;

int main(){
    char alphabet[] = "abcdefghijklmnopqrstuvwxyz";
    string inputsCount;
    getline(cin, inputsCount);

    int inputsCountd = stoi(inputsCount);
    for (int i = 0; i < inputsCountd; i++)
    {
        string input;
        getline(cin, input);
        set<char> inputChars(begin(input), end(input));

        bool isPanagram = true;
        vector<char> result;

        for (int i = 0; i < 26; i++)
        {
            if(inputChars.find(alphabet[i]) == inputChars.end() && inputChars.find(alphabet[i] - 32) == inputChars.end()){
                result.push_back(alphabet[i]);
                isPanagram = false;
            }
        }
        
        vector<char>::iterator it = result.begin();
        if(isPanagram){
            cout << "pangram" << endl;
        }else{
            cout << "missing ";
             while (it != result.end())
            {
                cout << (*it);
                it++;
            }
            cout << endl;
        }
    }

    return 0;
}