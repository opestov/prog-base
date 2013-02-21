#include <stdio.h>

int main() {
  int n, x;
  scanf("%d", &n);
  
  int c[n], a[n], p[n];
  for (int i = 0; i < n; ++i) {
    scanf("%d%d", &c[i], &a[i]);
    p[i] = i;
  }
  for (int i = 0; i < n; ++i)
    for (int j = i+1; j < n; ++j)
      if (c[p[j]] < c[p[i]] || ((c[p[j]] == c[p[i]]) && (a[p[j]] > a[p[i]])))
        x = p[i], p[i] = p[j], p[j] = x;

  for (int i = 0; i < n; ++i)
    printf("%d %d %d\n", c[p[i]], a[p[i]], p[i]+1);

  return 0;
}