#include <stdio.h>
#include <string.h>

#define MAX 102
char s[MAX];

int main() {
    fgets(s, MAX, stdin);

    char r;
    char c = s[0];
    int b = 0, k = 1;
    for (int i = 1; s[i]; ++i) {
        if (s[i] == c) {
            ++k;
        }
        else {
            if (k > b) {
                b = k;
                r = c;
            }
            c = s[i];
            k = 1;
        }
    }
    for (int i = 0; i < b; ++i)
        printf("%c", r);
    printf("\n");

    return 0;
}
