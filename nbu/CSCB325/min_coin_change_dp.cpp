/*Input:
3 1 3 4   coins_count [coins...]
2 8 10    sums_count [sums...]
2 5 6
2 9 10
Output:
2 3
0 2
*/

#include <bits/stdc++.h>

using namespace std;

#define N 1000001
#define MAX_COIN_COUNT 101

bool visited[N];
int solution[N];
int coins[MAX_COIN_COUNT];
int sums_count, coins_count;

int solve(int x) {
    if (x < 0) return N;
    if (x == 0) return 0;
    if (visited[x]) return solution[x];
    int best = N;

    for (int i = 0; i < coins_count; i++){
        best = min(best, solve(x - coins[i]) + 1);
    }

    solution[x] = best;
    visited[x] = true;
    return solution[x];
}

int main(){
    while(cin >> coins_count){
        memset(coins, -1 , sizeof(coins));
        for (int i = 0; i < coins_count; i++){
            cin >> coins[i];
        }

        cin >> sums_count;

        for (int i = 0; i < sums_count; i++){
            memset(visited, 0 , sizeof(visited));

            int current_sum;
            cin >> current_sum;
            int result = solve(current_sum);

            if(result == N)
                cout << 0;
            else
                cout << result;
            cout << " ";
        }

        cout << endl;
    }

    return 0;
}