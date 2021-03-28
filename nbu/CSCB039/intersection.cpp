#include <iostream>

#define MAX 100000

int a[MAX], b[MAX];
unsigned m, n;

void print_intrersection() {
    unsigned i, j, k;
    for (i = 0, j = 0, k = 0; i < m && j < n; k++)
        if (a[i] == b[j])
            std::cout << a[i++] << " ", j++;
        else if (a[i] < b[j]) 
            i++;
        else 
            j++;  
}

int main() {
    std::cin >> m >> n;

    for (unsigned i = 0; i < m; i++)
        std::cin >> a[i];

    for (unsigned i = 0; i < n; i++)
        std::cin >> b[i];

    print_intrersection();

    return 0;
}
