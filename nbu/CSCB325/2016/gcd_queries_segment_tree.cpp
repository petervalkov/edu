#include <bits/stdc++.h>

using namespace std;

#define MAX 100000
#define MAX_TREE_SIZE 300000
//segment tree height = ceil(log2(n))
//max segment tree size = 2 * pow(2, x) - 1

int arr[MAX];
int seg_tree[MAX_TREE_SIZE];

int get_value(int seg_start, int seg_end, int query_from, int query_to, int node_index){
    if (query_from <= seg_start && query_to >= seg_end)
        return seg_tree[node_index];
  
    if (seg_end < query_from || seg_start > query_to)
        return 0;

    int mid = (seg_start + (seg_end - seg_start) / 2);
    int left_child = get_value(seg_start, mid, query_from, query_to, 2 * node_index + 1);
    int right_child = get_value(mid + 1, seg_end, query_from, query_to, 2 * node_index + 2);

    return __gcd(left_child, right_child);
}

void update_value(int start, int end, int element_index, int new_value, int node_index){
    if (element_index < start || element_index > end)
        return;

    if (end == start)
        seg_tree[node_index] = new_value;
    else {
        int mid = (start + (end - start) / 2);
        update_value(start, mid, element_index, new_value, 2 * node_index + 1);
        update_value(mid + 1, end, element_index, new_value, 2 * node_index + 2);
        seg_tree[node_index] = __gcd(seg_tree[2 * node_index + 1], seg_tree[2 * node_index + 2]);
    }
}

int build_tree(int start, int end, int index){
    if (start == end) {
        seg_tree[index] = arr[start];
        return arr[start];
    }

    int mid = (start + (end - start) / 2);
    int left_child = build_tree(start, mid, index * 2 + 1);
    int right_child = build_tree(mid + 1, end, index * 2 + 2);

    seg_tree[index] = __gcd(left_child, right_child);

    return seg_tree[index];
}

int main() {
    ios_base::sync_with_stdio(false);

    int n; 
    while (cin >> n) {
        if(n == 0) continue;

        for (int i = 0; i < n; i++)
            cin >> arr[i];

        build_tree(0, n - 1, 0);

        int query;
        cin >> query;
        while (query != 3){
            if (query == 1){
                int index, value;
                cin >> index >> value;
                arr[index - 1] = value;
    
                update_value(0, n - 1, index - 1, value, 0);
            } else if (query == 2){
                int start, end;
                cin >> start >> end;
                
                cout << get_value(0, n - 1, start - 1, end - 1, 0) << endl;
            }

            cin >> query;
        }
    }

    return 0;
}