#include <stdio.h>

int main()
{
  int n, k, i;
  scanf("%d%d", &n, &k);
  
  int a[k + 1];
  for (i = 0; i < k; ++i)
    a[i] = i;
  a[k] = n;

  while (1) {
    for (i = 0; i < k; ++i) {
      if (i) printf(" ");
      printf("%d", a[i] + 1);
    }
    printf("\n");

    for (i = k - 1; i >= 0 && a[i] + 1 == a[i + 1]; --i)
      ;
    if (i < 0)
      break;

    ++a[i];
    for (++i; i < k; ++i)
      a[i] = a[i - 1] + 1;
  }

  return 0;
}
