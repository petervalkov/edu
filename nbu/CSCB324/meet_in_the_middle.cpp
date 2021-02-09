/*Дадена е редица от цели числа. Да се провери дали дадено число може да се получи като сума на числа от редицата.
На стандартния вход за всеки пример са зададени: дължината на редицата, числата от тази редица, броя на числата за проверка и самите числа за проверка.
За всеки пример на стандартния изход на отделен ред да се изведе редица, състояща се от низовете "yes" и "no", съответстваща на проверката дали съответното число за проверка може иле не може да се получи като сума на числа от редицата.

4
2 4 5 9
2
15 10
2
10 20
1
25

yes no 
no
*/


#include <algorithm>
#include <iostream>
using namespace std;

const int N = 1000000;
int X[N], Y[N];

void Subsets(int elements[], int arr[], int n, int c){
    for (int i = 0; i < (1 << n); i++){
        int s = 0;
        for (int j = 0; j < n; j++)
            if (i & (1 << j))
                s += elements[j + c];
        arr[i] = s;
    }
}

bool isPossible(int elements[], int elementsCount, int Sum){
    Subsets(elements, X, elementsCount / 2, 0);
    Subsets(elements, Y, elementsCount - elementsCount / 2, elementsCount / 2);

    int size_X = 1 << (elementsCount / 2);
    int size_Y = 1 << (elementsCount - elementsCount / 2);

    sort(Y, Y + size_Y);

    for (int i = 0; i < size_X; i++){
        if (X[i] <= Sum){
            int p = lower_bound(Y, Y + size_Y, Sum - X[i]) - Y;
            if (p != size_Y && Y[p] == (Sum - X[i])) return true;
        }
    }
    return false;
}

int main(){
    int elementsCount;

    while (cin >> elementsCount){
        int *elements = new int[elementsCount];
        for (int i = 0; i < elementsCount; i++) 
            cin >> elements[i];

        int sumsCount;
        cin >> sumsCount;
        for (int i = 0; i < sumsCount; i++){
            int currentSum;
            cin >> currentSum;

            if (isPossible(elements, elementsCount, currentSum)) cout << "yes ";
            else cout << "no ";
        }

        cout << endl;
        delete elements;
    }
}