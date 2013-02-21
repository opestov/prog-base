#include <stdio.h>

int main() {
  int n, x;
  scanf("%d", &n);
  
  int a[n], p[n];
  for (int i = 0; i < n; ++i) {
    scanf("%d", &a[i]);
    p[i] = i;
  }
  for (int i = 0; i < n; ++i)
    for (int j = i+1; j < n; ++j)
      if (a[p[j]] > a[p[i]])
        x = p[i], p[i] = p[j], p[j] = x;

  for (int i = 0; i < n; ++i)
    printf("%d %d\n", p[i]+1, a[p[i]]);

  return 0;
}