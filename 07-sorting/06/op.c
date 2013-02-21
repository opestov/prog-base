#include <stdio.h>

int main() {
  int n, k;
  scanf("%d", &n);

  int a[n], pa[n];
  for (int i = 0; i < n; ++i)
    scanf("%d", &a[i]);
  for (int i = 0; i < n; ++i)
    pa[i] = i;
  for (int i = 0; i < n; ++i)
    for (int j = i+1; j < n; ++j)
      if (a[pa[j]] > a[pa[i]]) 
        k = pa[i], pa[i] = pa[j], pa[j] = k;

  int b[n], pb[n];
  for (int i = 0; i < n; ++i)
    scanf("%d", &b[i]);
  for (int i = 0; i < n; ++i)
    pb[i] = i;
  for (int i = 0; i < n; ++i)
    for (int j = i+1; j < n; ++j)
      if (b[pb[j]] < b[pb[i]]) 
        k = pb[i], pb[i] = pb[j], pb[j] = k;


  int r[n];
  for (int i = 0; i < n; ++i)
    r[pa[i]] = pb[i];
  for (int i = 0; i < n; ++i) {
    if (i) printf(" ");
    printf("%d", r[i]+1);
  }
  printf("\n");

  return 0;
}