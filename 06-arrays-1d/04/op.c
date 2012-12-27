#include <stdio.h>

#define K 3

int a[K];

int main() {
  int i, j, x, n;
  
  scanf("%d", &n);
  for (i = 0; i < n; ++i) {
    scanf("%d", &x);
    a[x] += 1;
  }
  for (i = 0; i < K; ++i)
    for (j = 0; j < a[i]; ++j)
      printf("%d ", i);

  return 0;
}
