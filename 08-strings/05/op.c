#include <stdio.h>
#include <string.h>

#define MAX 257

int main() {    
    int c[256];
    memset(c, 0, sizeof(int) * 256);

    char s[MAX];

    fgets(s, MAX, stdin);
    for (int i = 0; s[i] && s[i] != '\n'; ++i)
        c[s[i]]++;

    fgets(s, MAX, stdin);
    for (int i = 0; s[i] && s[i] != '\n'; ++i)
        c[s[i]]--;
    
    int ok = 1;
    for (int i = 0; i < 256; ++i)
        if (c[i])
            ok = 0;
    if (ok)
        printf("YES\n");
    else
        printf("NO\n");

    return 0;
}
