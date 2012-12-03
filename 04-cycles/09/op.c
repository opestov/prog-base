#include <stdio.h>

int days[] = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

int main() {
  int d, m, y, d2, m2, y2;
  scanf("%d%d%d", &d, &m, &y);
  scanf("%d%d%d", &d2, &m2, &y2);

  if (y % 4 == 0 && y % 100 != 0 || y % 400 == 0)
    days[1] = 29;

  int k = 0; 
  while (d != d2 || m != m2 || y != y2) {
    k++;

    d++;
    if (d > days[m-1]) {
      d = 1;
      m++;
    } 
    if (m > 12) {
      m = 1;
      y++;
      if (y % 4 == 0 && y % 100 != 0 || y % 400 == 0)
        days[1] = 29;
    }
  }

  printf("%d\n", k);

  return 0;
}
