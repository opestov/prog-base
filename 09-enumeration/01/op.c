#include <stdio.h>

int main() {
  int n, k;
  scanf("%d%d", &n, &k);
  
  int a[n], z = 0;

  a[0] = 0;
  while (z >= 0) {
    a[z]++;
    for (int i = z + 1; i < n; ++i)
      a[i] = 1;

    for (int i = 0; i < n; ++i) {
      if (i) printf(" ");
      printf("%d", a[i]);
    }
    printf("\n");
    
    for (z = n - 1; z >= 0 && a[z] == k; --z)
      ;
  }

  return 0;
}
