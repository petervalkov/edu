#include <iostream>

#define MAX 1000000

int F[MAX];

int binary_search(int start, int end, int value){
    if (end >= start){
        int mid = start + (end - start) / 2;

        if (F[mid] == value) 
            return mid;

        if (F[mid] > value) 
            return binary_search(start, mid - 1, value);
        
        return binary_search(mid + 1, end, value);
    }

    return -1;
}

int main() {
    unsigned n, i, x;
    std::cin >> n;
    
    for (i = 0; i < n; i++)
        std::cin >> F[i];

    while (std::cin >> x) 
        std::cout << binary_search(0, n-1, x) << " ";
}