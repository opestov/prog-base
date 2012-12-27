#include <stdio.h>

int a[1001];

int main() {
  int i, j, x, n;
  
  scanf("%d", &n);
  for (i = 0; i < n; ++i) {
    scanf("%d", &x);
    a[x] += 1;
  }
  x = 0;
  for (i = 0; i <= 1000; ++i)
    if (a[i])
      x++;
  printf("%d\n", x);

  return 0;
}
