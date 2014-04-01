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
    for (i = k - 2, z = a[k - 1]; i > 0 && a[i] == a[i - 1]; --i)
      z += a[i];
    ++a[i];

    k = i + z;
    for (++i; i < k; ++i)
      a[i] = 1;
  }

  return 0;
}
