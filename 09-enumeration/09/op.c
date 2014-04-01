#include <stdio.h>

int main()
{
  int n, k, i;
  scanf("%d%d", &n, &k);
  
  int a[n], d[n];

  for (i = 0; i < n; ++i) {
    a[i] = 1;
    d[i] = 1;
  }

  while (1) {
    for (int i = 0; i < n; ++i) {
      if (i) printf(" ");
      printf("%d", a[i]);
    }
    printf("\n");

    for (i = n - 1; i >= 0 && (a[i] + d[i] < 1 || a[i] + d[i] > k); --i)
      ;
    if (i < 0)
      break;

    a[i] += d[i];
    for (++i; i < n; ++i)
      d[i] = -d[i];
  }

  return 0;
}
