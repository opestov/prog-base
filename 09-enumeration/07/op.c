#include <stdio.h>

int main()
{
  int n, k, i, z;
  scanf("%d", &n);
  
  int a[n];
  for (i = 0; i < n; ++i)
    a[i] = 1;
  k = n;
 
  while (1) {
    for (i = 0; i < k; ++i) {
      if (i) printf("+");
      printf("%d", a[i]);
    }
    printf("\n");
    
    if (k == 1)
      break;

    z = a[k - 2] + 1;
    a[k - 2] += a[k - 1];
    --k;

    while (a[k - 1] >= 2 * z) {
      ++k;
      a[k - 1] = a[k - 2] - z;
      a[k - 2] = z;
    }
  }

  return 0;
}
