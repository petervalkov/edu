#include <iostream>

#define MAX 1000000

int a[MAX], b[MAX], c[2 * MAX];
unsigned m, n;

void merge() {
    unsigned i, j, k;
    for (i = 0, j = 0, k = 0; i < m && j < n; k++)
        if (a[i] <= b[j])
            c[k] = a[i++];
        else
            c[k] = b[j++];
    if (i == m)
        for (i = j; i < n; i++)
            c[k++] = b[i];
    else
        for (j = i; j < m; j++)
            c[k++] = a[j];     
}

int main() {
    std::cin >> m >> n;

    for (unsigned i = 0; i < m; i++)
        std::cin >> a[i];

    for (unsigned i = 0; i < n; i++)
        std::cin >> b[i];

    merge();

    for (unsigned i = 0; i < m + n; i++)
        std::cout << c[i] << " ";    

    return 0;
}
