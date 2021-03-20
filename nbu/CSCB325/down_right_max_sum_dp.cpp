/*Input:
2 
3 
0 1 1 
0 4 2 
1 1 1 
5 
1 1 1 1 1 
0 0 3 4 3 
0 1 2 0 1 
1 1 1 0 1 
2 4 0 4 0
Output:
8
15
*/

#include <bits/stdc++.h>

using namespace std;

#define MAX 110

int F[MAX][MAX];
int S[MAX][MAX];

int main(){
    int input_count;
    cin >> input_count;

    for (int i = 0; i < input_count; i++){
        int size;
        cin >> size;

        for (int row = 0; row < size; row++)
            for (int col = 0; col < size; col++)
                cin >> F[row][col];

        S[0][0] = F[0][0];
        for (int i = 1; i < size; i++)
            S[0][i] = S[0][i-1] + F[0][i];

        for (int row = 1; row < size; row++){
            S[i][0] = S[i-1][0] + F[i][0];
            for (int col = 1; col < size; col++)
                S[row][col] = max(F[row][col] + S[row-1][col], F[row][col] + S[row][col-1]);
        }

        cout << S[size - 1][size - 1] << endl;
    }
        
    return 0;
}