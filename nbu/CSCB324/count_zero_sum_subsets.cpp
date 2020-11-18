/* https://www.hackerrank.com/contests/nbu-october-2019-programming-contest/challenges/1-186
Count subsets with zero sum
Constraints: 0 <= n <= 20 
Input:
[inputs count]
[set elements count]
[...set]
2
5
10 -5 0 5 2
2
-10 -8
Output:
3 -> {0}, {-5, 5} и {0, -5, 5}
0 */

#include<iostream>
#include<string>
#include<vector>

using namespace std; 

void solve(int index, int start, vector<int> &subset, int &sum, int &size, int &counter) {
    if(index >= size) {
        if(sum == 0) {
            counter++;
        }
    }else{
        for(size_t i = start; i < subset.size(); i++) {
            sum += subset[i];
            solve(index + 1, i + 1, subset, sum, size, counter);
            sum -= subset[i];
        }
    }
}

int main() {
    int inputsCount;
    cin >> inputsCount;

    while (inputsCount--)
    {
        int counter = 0;
        int subsetCount;
        cin >> subsetCount;
        vector<int> subset(subsetCount);

        for (int i = 0; i < subsetCount; i++)
        {
            cin >> subset[i];
        }

        for (int i = 1; i <= subsetCount; i++)
        {
            int sum = 0;
            solve(0, 0, subset, sum, i, counter);
        }

        cout << counter << endl;
    }

    return 0;
}