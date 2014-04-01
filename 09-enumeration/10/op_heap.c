// minimal changes but not adjancent
// https://en.wikipedia.org/wiki/Heap%27s_algorithm

#include <stdio.h>

void rec(int k, int n, int *a)
{
  if (k == 1) {
    for (int i = 0; i < n; ++i) {
      if (i) printf(" ");
      printf("%d", a[i]);
    }
    printf("\n");
  }
  else
    for (int c = 0; c < k; ++c) {
      rec(k - 1, n, a);
      int p = (k & 1) ? 0 : c;
      int z = a[p];
      a[p] = a[k - 1];
      a[k - 1] = z;
    }
}

int main() {
  int n;
  scanf("%d", &n);
  
  int a[n];
  for (int i = 0; i < n; ++i)
    a[i] = i + 1;
  rec(n, n, a);

  return 0;
}
