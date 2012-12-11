#include <cstdio>

int main() {
    int n, k, s = 0;
    scanf("%d", &n);
    for (int i = 1; i <= n; i++) {
        k = 1;
        for (int j = 0; j < i; j++)
            k *= i;
        s += k;
    }
    printf("%d\n", s);
}
