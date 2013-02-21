#include <stdio.h>

int main() {
  int k, n;
  scanf("%d", &n);

  int a[n];
  for (int i = 0; i < n; ++i)
    scanf("%d", &a[i]);

  for (int i = 0; i < n; ++i)
    for (int j = i+1; j < n; ++j)
      if (a[j]%10 < a[i]%10 || (a[j]%10 == a[i]%10 && a[j] < a[i]))
        k = a[i], a[i] = a[j], a[j] = k;

  for (int i = 0; i < n; ++i) {
    if (i) printf(" ");
    printf("%d", a[i]);
  }
  printf("\n");

  return 0;
}
