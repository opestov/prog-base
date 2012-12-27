#include <stdio.h>

#define K 10000

int a[K];

int main() {
  int k, n;

  scanf("%d", &n);
  for (int i = 0; i < n; ++i)
    scanf("%d", &a[i]);

  int j = 0;
  for (int i = 1; i < n; ++i)
    if (a[i] < a[j])
      j = i;

  k = a[0], a[0] = a[j], a[j] = k;
  for (int i = 0; i < n; ++i) {
    if (i) printf(" ");
    printf("%d", a[i]);
  }
  printf("\n");

  return 0;
}
