#include <iostream>
#include <sstream>
#include <algorithm>

using namespace std;

int main()
{
    string input;

    while(getline(cin, input)){
        istringstream iss(input);
        string number;
        int k;
        iss >> number >> k;

        int n = number.length();
        int* arr = new int[n];
        for (int i = 0; i < n; i++) {
            arr[i] = (int)(number[i] - 48);
        }

        sort(arr, arr + n);

        long long counter = 0;
        do {
            counter++;
            if(counter == k){
                bool leadingZero = true;
                for(int i = 0; i < n; i++){
                    if(arr[i] == 0){
                        if(leadingZero) continue;
                        else cout << arr[i];
                    }else{
                        leadingZero = false;
                        cout << arr[i];
                    }
                }

                cout << " ";
            }
        } while (next_permutation(arr, arr + n));

        cout << counter << endl;
    }
   
  return 0;
}