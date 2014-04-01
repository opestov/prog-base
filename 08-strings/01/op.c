#include <stdio.h>

int main() {
    char c;

    scanf("%c", &c);
    for (int i = 0; i < 10; ++i)
      printf("%c", c + i + 1);
    printf("\n");

    return 0;
}
