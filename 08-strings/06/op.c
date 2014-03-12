#include <stdio.h>
#include <string.h>

#define MAX 257

int main() {    
    char s[MAX];
    int n;

    fgets(s, MAX, stdin);
    scanf("%d", &n);
    for (int i = 0; s[i] && s[i] != '\n'; ++i)
        s[i] = 'a'+(s[i]-'a'+26-n)%26;
    printf("%s", s);
    return 0;
}
