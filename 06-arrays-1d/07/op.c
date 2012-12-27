#include <stdio.h>

int a[10239];

int main() {
  int i, t, n;

  scanf("%d", &n);
  for (i = 0; i < n; ++i)
    scanf("%d", &a[i]);
  for (i = 0; 2 * i < n; ++i)
    t = a[i], a[i] = a[n - i - 1], a[n - i - 1] = t;

  for (i = 0; a[i] == 9; ++i)
    a[i] = 0;
  a[i]++;
  
  if (i >= n)
    n++;
  for (i = n - 1; i >= 0; --i)
    printf("%d", a[i]);
  printf("\n");

  return 0;
}
