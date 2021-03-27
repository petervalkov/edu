#include <bits/stdc++.h>

using namespace std;

#define MAX 30

int values[MAX];

int solve(int n){
    int sum = accumulate(values, values + n, 0);
    sum += ((n - 3) * values[0] * (n > 1));

    for (int i = 0; i < n/2; i++)
        sum += min(0, 2*values[1] - values[0] - values[n-(i+1)*2]); 

    return sum;
}

int main(void) {
    ios_base::sync_with_stdio(false);
    
    string input;
    while (getline(cin, input)){
        int value, n = 0;

        istringstream iss(input);
        while (iss >> value)
            values[n++] = value;

        sort(values, values + n);
        cout << solve(n) << endl;
    }

    return 0;
}