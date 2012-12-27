#include <stdio.h>

int main() {
  int n, a, b, c, d, k;
  scanf("%d%d%d%d%d", &n, &a, &b, &c, &d);

  int x[n];
  for (int i = 0; i < n; ++i)
    x[i] = i+1;
  for (int i=a-1, j=b-1; i <= j; ++i, --j)
    k = x[i], x[i] = x[j], x[j] = k;
  for (int i=c-1, j=d-1; i <= j; ++i, --j)
    k = x[i], x[i] = x[j], x[j] = k;
  for (int i = 0; i < n; ++i) {
    if (i) printf(" ");
    printf("%d", x[i]);
  }
  printf("\n");

  return 0;
}