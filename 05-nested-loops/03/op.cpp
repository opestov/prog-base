#include <cstdio>

int main() {
    int n;
    scanf("%d", &n);
    for (int i = 1; i <= n; i++) {
        printf("%d", i);
        for (int j = 1; j <= i; j++)
            if (i % j == 0)
                printf("+");
        printf("\n");
    }

    return 0;
}
