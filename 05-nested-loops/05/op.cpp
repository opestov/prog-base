#include <cstdio>

int main() {
    int n, s;
    scanf("%d", &n);
    for (int i = 1; i < n; i++) {
        s = 0;
        for (int j = 1; j < i; j++)
            if (i % j == 0)
                s += j;
        if (i == s)
            printf("%d\n", i);
    }

    return 0;
}
