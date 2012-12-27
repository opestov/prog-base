#include <stdio.h>

int a[1000];

int main() {
  int n;

  scanf("%d", &n);
  for (int i = 0; i < n; ++i)
    scanf("%d", &a[i]);

  int k = 0;
  for (int i = 0; i < n; ++i)
    for (int j = 1; j < n; ++j)
      if (a[i] > a[j])
        k++;

  printf("%d\n", k);

  return 0;
}
