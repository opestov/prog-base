#include <stdio.h>

int x[1000], y[1000], r[1000];

int main() {
  int n;

  scanf("%d", &n);
  for (int i = 0; i < n; ++i)
    scanf("%d%d%d", &x[i], &y[i], &r[i]);
           
  int flag = 1;
  for (int i = 0; flag && (i < n); ++i)
    for (int j = i+1; flag && (j < n); ++j)
      if ((x[i]-x[j])*(x[i]-x[j])+(y[i]-y[j])*(y[i]-y[j]) <= (r[i]+r[j])*(r[i]+r[j]))
        flag = 0;

  if (flag)
    printf("NO\n");
  else
    printf("YES\n");

  return 0;
}
