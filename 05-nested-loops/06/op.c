#include <stdio.h>

int main() {
    int n;
    scanf("%d", &n);

    for (int a = 1; a <= n; ++a) {
      int b=a;
      for (int c = a; c <= n; ++c) {
        while (a*a+b*b < c*c)
          ++b;
        if (a*a+b*b==c*c)
          printf("%d %d %d\n", a, b, c);
      }
    }

    return 0;
}
