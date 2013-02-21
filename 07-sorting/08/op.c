#include <stdio.h>
#include <stdlib.h>
#include <string.h>


int main() {
  int n;
  scanf("%d", &n);

  int* a = malloc(n * sizeof(int));
  int* b = malloc(n * sizeof(int));

  for (int i = 0; i < n; ++i)
    scanf("%d", &a[i]);

  for (int size=1; size < n; size*=2) {
    int si = 0, ti = size, sj = size, tj = 2*size > n ? n : 2*size;
    for (int i = 0; i < n; ++i) {
      if (sj >= tj || (si < ti && a[si] < a[sj]))
        b[i] = a[si++];
      else
        b[i] = a[sj++];

      if (si >= ti && sj >= tj) {
        si += size; ti += 2*size; if (ti > n) ti = n;
        sj += size; tj += 2*size; if (tj > n) tj = n;
      }
    }
    memcpy(a, b, n*sizeof(int));
  }

  int k = 1;
  for (int i = 1, j = 0; i < n; ++i)
    if (a[i] != a[j]) {
      j = i;
      k++;
    }
  printf("%d\n", k);

  free(a);
  free(b);

  return 0;
}