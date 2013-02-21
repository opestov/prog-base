#include <stdio.h>

int main() {
  int n, x;
  scanf("%d", &n);
  
  int a[n], b[n], p[n];
  for (int i = 0; i < n; ++i) {
    scanf("%d", &a[i]);
    p[i] = i;
  }
  for (int i = 0; i < n; ++i)
    for (int j = i+1; j < n; ++j)
      if (a[p[j]] > a[p[i]])
        x = p[i], p[i] = p[j], p[j] = x;
  b[p[0]] = 1;
  for (int i = 1; i < n; ++i)
    if (a[p[i]] == a[p[i-1]])
      b[p[i]] = b[p[i-1]];
    else
      b[p[i]] = i+1;

  for (int i = 0; i < n; ++i) {
    if (i) printf(" ");
    printf("%d", b[i]);
  }
  printf("\n");

  return 0;
}