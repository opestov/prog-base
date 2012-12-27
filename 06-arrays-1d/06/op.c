#include <stdio.h>

#define K 2001
#define D 1000

int a[K];

int main() {
  int i, j, x, n;
  
  scanf("%d", &n);
  for (i = 0; i < n; ++i) {
    scanf("%d", &x);
    a[x+D] += 1;
  }
  int f = 0;
  for (i = 0; i < K; ++i)
    for (j = 0; j < a[i]; ++j) {
      if (f) printf(" ");
      printf("%d", i-D);
      f = 1;
    }

  return 0;
}
