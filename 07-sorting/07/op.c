#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main () {
  int n;
  scanf("%d", &n);

  int a[n], b[n]; 
  for (int i = 0; i < n; ++i)
    scanf("%d", &a[i]);

  // merge sort
  for (int size = 1, k = 0; size < n; size *= 2, k = 0) {
    for (int p = size; p < n; p += 2 * size)
      for (int i = p - size, j = p, q = p + size; i < p || (j < q && j < n);)
        b[k++] = i >= p || (j < q && j < n && a[j] < a[i]) ? a[j++] : a[i++];
    memcpy(a, b, k * sizeof(int));
  }        

  for (int i = 0; i < n; ++i) {
    if (i) printf(" ");
    printf("%d", a[i]);
  }
  printf("\n");

  return 0;
}