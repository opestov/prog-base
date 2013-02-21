#include <stdio.h>

int main() {
  int n;
  scanf("%d", &n);
  
  int a[n];
  for (int i = 0; i < n; ++i)
    scanf("%d", &a[i]);

  for (int i = 0; i < n; ++i) {
    if (i) printf(" ");
    int k = 0;
    for (int j = 0; j < n; ++j)
      if (a[j] > a[i])
        k++;
    printf("%d", k+1);
  }
  printf("\n");

  return 0;
}