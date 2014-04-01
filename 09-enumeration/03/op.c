#include <stdio.h>

int main() {
  int n;
  scanf("%d", &n);
  
  int a[n], i, j, z = n - 1, t;
  for (i = 0; i < n; ++i)
    a[i] = i + 1;
  
  while (z >= 0) {
    for (i = n - 1; a[i] < a[z]; --i)
      ;
    t = a[i], a[i] = a[z], a[z] = t;
    for (i = z + 1, j = n - 1; i < j; ++i, --j)
      t = a[i], a[i] = a[j], a[j] = t;    
      
    for (z = n - 2; z >= 0 && a[z] > a[z + 1]; --z)
      ;

    for (i = 0; i < n; ++i) {
      if (i) printf(" ");
      printf("%d", a[i]);
    }
    printf("\n");
  }

  return 0;
}
