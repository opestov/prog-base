#include <stdio.h>

int main() {
  int n, i;
  scanf("%d", &n);
  
  int a[2 * n], b[2 * n];
  for (i = 0; i < n; ++i) {
    a[i] = -1;
    a[i + n] = 1;
  }
  b[0] = a[0];
  for (i = 1; i < 2 * n; ++i)
    b[i] = b[i - 1] + a[i];

  while (1) {
    for (i = 0; i < 2 * n; ++i)
      printf(a[i] == -1 ? "(" : ")");
    printf("\n");

    for (i = 2 * n - 1; i >= 1 && (a[i] == 1 || b[i - 1] == 0); --i)
      ;
    if (i == 0)
      break;

    a[i] = 1;
    b[i] = b[i - 1] + a[i];
    ++i;
    int o = (2 * n - i + b[i - 1]) / 2;
    int c = o - b[i - 1];
    for (; o > 0; ++i, --o)
      a[i] = -1, b[i] = b[i - 1] + a[i];
    for (; c > 0; ++i, --c)
      a[i] = 1, b[i] = b[i - 1] + a[i];  
  }

  return 0;
}
