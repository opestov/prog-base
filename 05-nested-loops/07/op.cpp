#include <cstdio>

int main() {
    int n;
    scanf("%d", &n);

    for (int i = 1; i * i <= n; i++)
        for (int j = i; j * j <= n - i * i; j++)
            for (int k = j; k * k <= n - i * i - j * j; k++)
                if (i * i + j * j + k * k == n)
                    printf("%d %d %d\n", i, j, k);

    return 0;
}
