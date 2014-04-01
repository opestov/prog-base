#include <stdio.h>
#include <string.h>

#define MAX 102
char s[MAX], t[MAX];

int main() {
    fgets(s, MAX, stdin);
    fgets(t, MAX, stdin);

    int i, j, k, b = 0;
    for (i = 0; s[i] && s[i] != '\n'; ++i)
        for (j = 0; t[j] && t[j] != '\n'; ++j) {
            k = 0;
            while (s[i + k] && s[i + k] != '\n' && s[i + k] == t[j + k])
                ++k;

            if (k > b)
                b = k;
        }

    printf("%d\n", b);

    return 0;
}
