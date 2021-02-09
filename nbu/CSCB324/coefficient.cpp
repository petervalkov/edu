#include <iostream>
#include <sstream>
#include <vector>
#include <cmath> 

using namespace std;

long long binomialCoefficient(int n, int k){ 
    long long coefficient = 1;
    if (k > n - k) k = n - k;
    for (int i = 0; i < k; ++i) { 
        coefficient *= (n - i); 
        coefficient /= (i + 1); 
    }
    return coefficient; 
} 

int main()
{
    string input;
    while(getline(cin, input)){
        int n, m, k;
        istringstream iss(input);
        iss >> n >> m >> k;

        vector<long long> firstExpr, secondExpr, result(n + m + 1, 0);
        
        for (int i = 0; i < n + 1; i++){
            int sign = n % 2 == 0 ? 1 : -1;
            firstExpr.push_back(binomialCoefficient(n, i) * pow(-1, i) * sign);
        }

        for (int i = 0; i < m + 1; i++){
            secondExpr.push_back(binomialCoefficient(m, i));
        }

        for (int i = 0; i <= n; i++){
            for (int j = 0; j <= m; j++){
                result[i + j] += firstExpr[i] * secondExpr[j];
            }
        }
        
        cout << result[k] << endl;
    }

    return 0;
}