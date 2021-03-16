/*Input:
1 3 4 [coins...]
8 10  [sums...]
5 6
9 10
Output:
6 8
0 1
*/

#include <bits/stdc++.h>

#define MAXCOINS 101
#define MAXSUM 100001

using namespace std;

vector<int> coins;
unsigned char exist[MAXSUM];
unsigned long solution[MAXSUM][MAXCOINS];

void reset(unsigned sum, unsigned n){
    for (unsigned i = 0; i < MAXSUM; i++)
        for (unsigned j = 0; j < MAXCOINS; j++) 
            solution[i][j] = 0;
  
    for (unsigned i = 0; i <= sum; i++) 
        exist[i] = 0;
    for (unsigned i = 0; i < n; i++) 
        exist[coins[i]] = 1;
}

unsigned long count(unsigned sum, unsigned max){
    if (sum <= 0) return 0;
    if (solution[sum][max] > 0) return solution[sum][max];
    else {
        if (sum < max) max = sum;
        if (sum == max && exist[sum]) solution[sum][max] = 1;
   
        for (unsigned long i = max; i > 0; i--)
            if (exist[i]) solution[sum][max] += count(sum - i, i);
    }

    return solution[sum][max];
}

int main(){
    string input;
    while (getline(cin, input)){
        int coin_value, target_sum;

        coins.clear();
        istringstream iss_coins(input);
        while(iss_coins >> coin_value)
            coins.push_back(coin_value);

        getline(cin, input);
        istringstream iss_sums(input);

        while(iss_sums >> target_sum){
            sort(coins.begin(), coins.end());
            reset(target_sum, coins.size());

            cout << count(target_sum, coins[coins.size() - 1]) << " ";
        }

        cout << endl;
    }
        
    return 0;
}