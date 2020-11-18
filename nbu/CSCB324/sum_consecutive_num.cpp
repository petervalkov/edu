/* https://www.hackerrank.com/contests/nbu-october-2019-programming-contest/challenges/challenge-2206
Find the largest sum of 3 consecutive numbers
Constraints: -1000 <= number <= 1000
Input:
[numbers count]
[numbers]
4
12 10 22 11
3
-20 20 -30
Output:
44
-30 */

#include <iostream>
#include <string>

using namespace std;

int main()
{
    int valuesCount, last, mid, first, currentVal, currentSum, bestSum = 0;
    while (cin >> valuesCount)
    {
        for (int i = 0; i < valuesCount; i++)
        {
            cin >> currentVal;

            if(i==0){
                last = currentVal;
                currentSum = currentVal;
            }else if(i == 1){
                mid = currentVal;
                currentSum += currentVal;
            }else if(i == 2){
                first = currentVal;
                currentSum += currentVal;
                bestSum = currentSum;
            }else{
                currentSum = currentSum - last + currentVal;
                if (currentSum > bestSum)
                {
                    bestSum = currentSum;
                }

                last = mid;
                mid = first;
                first = currentVal;
            }
        }

        cout << bestSum << endl;
    }

    return 0;
}