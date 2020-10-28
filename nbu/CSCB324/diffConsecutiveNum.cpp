/* https://www.hackerrank.com/cscb324-2021
Find the largest difference between two consecutive numbers.
Constraints: 2 <= numbers count <= 1000; -1000 <= number <= 1000].
Input:
[numbers count]
[...numbers]
4
12 10 22 11
3
-20 20 -30
Output:
12
40 */

#include<iostream>

using namespace std; 

int main() {
    int nCount, currentNum, prevNum, currentDiff, currentBest = 0;

    while (cin >> nCount)
    {
        cin >> currentNum;
        prevNum = currentNum;

        while (--nCount)
        {
            cin >> currentNum;
            currentDiff = currentNum - prevNum;
            currentBest = currentDiff > currentBest ? currentDiff : currentBest;
            prevNum = currentNum;
        }
        
        cout << currentBest << endl;
        currentBest = 0;
    }

    return 0;
}