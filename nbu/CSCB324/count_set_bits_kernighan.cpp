#include<iostream>

using namespace std; 

int main() {
    long n;
    while (cin >> n)
    {
        int counter = 0;
        while (n)
        {
            n = n & (n -1);
            counter++;
        }
        cout << counter << endl;
    }
    return 0;
}