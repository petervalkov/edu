#include <iostream>

#define MAX 1000000

int F[MAX];

void merge(unsigned start, unsigned mid, unsigned end) {
    unsigned left_sz = mid - start + 1; 
    unsigned left_arr[left_sz];

    unsigned right_sz = end - mid;
    unsigned right_arr[right_sz];

    unsigned i, j, k;
    for(i = 0; i<left_sz; i++)
        left_arr[i] = F[start + i];
    for(j = 0; j<right_sz; j++)
        right_arr[j] = F[mid + 1 + j];

    i = 0; j = 0; k = start;
    while(i < left_sz && j < right_sz) {
        if(left_arr[i] <= right_arr[j])
            F[k] = left_arr[i++];
        else
            F[k] = right_arr[j++];
        k++;
    }

    while(i < left_sz)
        F[k++] = left_arr[i++];

    while(j < right_sz)
        F[k++] = right_arr[j++];
}

void mergeSort(int start, int end) {
    if(start >= end) return;

    int mid = start + (end - start) / 2;
    mergeSort(start, mid);
    mergeSort(mid + 1, end);
    merge(start, mid, end);
}

int main() {
    unsigned n, i;
    std::cin >> n;

    for (i = 0; i < n; i++)
        std::cin >> F[i];

    mergeSort(0, n-1);
    
    for (i = 0; i < n; i++)
        std::cout << F[i] << " ";

    return 0;
}