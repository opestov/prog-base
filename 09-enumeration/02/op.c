#include <stdio.h>

int main() {
  int n;
  scanf("%d", &n);
  
  int a[n], z = 0;

  a[0] = 0;
  while (z >= 0) {
    a[z]++;
    for (int i = z + 1; i < n; ++i)
      a[i] = 1;

    int m = 0;
    for (int i = 0; i < n; ++i)
      if (a[i] == 2)
        ++m;
    if (m) {
      printf("%d", m);
      for (int i = 0; i < n; ++i)
        if (a[i] == 2)
          printf(" %d", i + 1);
      printf("\n");
    }
    
    for (z = n - 1; z >= 0 && a[z] == 2; --z)
      ;
  }

  return 0;
}
