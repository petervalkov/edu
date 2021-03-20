//count ways to represent n as sum of powers of 2
#include <bits/stdc++.h>

using namespace std;

#define MAX 3001

long long S[MAX][MAX];

long long solve(int n, int k) {
    if (S[n][k]) 
        return S[n][k];
 
    if (n == 0) 
        return 1;
 
    if (k == 0) 
        return 1;
        
    if (n >= pow(2, k)) {
        S[n][k] = solve(n - pow(2, k), k) + solve(n, k - 1);
        return S[n][k];
    } else {
        S[n][k] = solve(n, k - 1);
        return S[n][k];
    }
}
 
int main(){
    int input;
    while(cin >> input){
        for (int i = 0; i < MAX; i++)
            for (int j = 0; j < MAX; j++)
                S[i][j] = 0;
        
        cout << solve(input, log2(input)) << endl;   
    }

    return 0;
}