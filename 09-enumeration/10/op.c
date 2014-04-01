#include <stdio.h>

int main() {
  int n, i;
  scanf("%d", &n);
  
  int a[n], d[n], t[n];

  for (i = 0; i < n; ++i) {
    a[i] = 0;
    d[i] = 1;
  }

  while (1) {
    for (i = 0; i < n; ++i)
      t[i] = 0;
    for (i = n - 1; i >= 0; --i) {
      int j, k;
      for (j = 0, k = a[i]; t[j] > 0 || k > 0; ++j)
        if (t[j] == 0)
          --k;       
      t[j] = i + 1;
    }
    for (i = 0; i < n; ++i) {      
      if (i) printf(" ");
      printf("%d", t[i]);
    }
    printf("\n");

    for (i = n - 1; i >= 0 && (a[i] + d[i] < 0 || a[i] + d[i] > i); --i)
      ;
    if (i < 0)
      break;

    a[i] += d[i];
    for (++i; i < n; ++i)
      d[i] = -d[i];
  }

  return 0;
}
