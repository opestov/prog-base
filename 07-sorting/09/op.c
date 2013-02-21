#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAXN 100000

int x[MAXN], y[MAXN], a1[MAXN], a2[MAXN], b[MAXN];

int before(int i, int j) {
  int v = x[i] * y[j] - y[i] * x[j];
  if (v > 0) return 1;
  if (v < 0) return 0;
  return x[i] * x[i] + y[i] * y[i] < x[j] * x[j] + y[j] * y[j];
}

int main () {
  int n;
  scanf("%d", &n);

  for (int i = 0; i < n; ++i)
    scanf("%d%d", &x[i], &y[i]);

  int k1 = 0, k2 = 0;
  for (int i = 0; i < n; ++i)
    if (y[i] > 0 || (y[i] == 0 && x[i] > 0))
      a1[k1++] = i;
    else
      a2[k2++] = i;

  for (int size = 1, k = 0; size < k1; size *= 2, k = 0) {
    for (int p = size; p < k1; p += 2 * size)
      for (int i = p - size, j = p, q = p + size; i < p || (j < q && j < k1); )
        b[k++] = i >= p || (j < q && j < k1 && before(a1[j], a1[i])) ? a1[j++] : a1[i++];          
    memcpy(a1, b, k * sizeof(int));
  }
  for (int size = 1, k = 0; size < k2; size *= 2, k = 0) {
    for (int p = size; p < k2; p += 2 * size)
      for (int i = p - size, j = p, q = p + size; i < p || (j < q && j < k2); )
        b[k++] = i >= p || (j < q && j < k2 && before(a2[j], a2[i])) ? a2[j++] : a2[i++];          
    memcpy(a2, b, k * sizeof(int));
  }

  for (int i = 0; i < k1; ++i)
    if (i == 0 || x[a1[i - 1]] * y[a1[i]] != y[a1[i - 1]] * x[a1[i]])
      printf("%d ", a1[i] + 1);
  for (int i = 0; i < k2; ++i)
    if (i == 0 || x[a2[i - 1]] * y[a2[i]] != y[a2[i - 1]] * x[a2[i]])
      printf("%d ", a2[i] + 1);
  printf("\n");

  return 0;
}
