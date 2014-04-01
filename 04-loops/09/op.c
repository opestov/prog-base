#include <stdio.h>

int days[] = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

int IsLeap(int y) {
  return (y % 4 == 0 && y % 100 != 0) || y % 400 == 0;
}

int DaysInMonth(int m, int y) {
  return m != 1 ? days[m] : days[m] + IsLeap(y);
}

int main() {
  int d, m, y, d2, m2, y2;
  int k = 0; 

  scanf("%d%d%d", &d, &m, &y);
  scanf("%d%d%d", &d2, &m2, &y2);

  while (d != d2 || m != m2 || y != y2) {
    k++;

    d++;
    if (d > DaysInMonth(m - 1, y)) {
      d = 1;
      m++;
    } 
    if (m > 12) {
      m = 1;
      y++;
    }
  }

  printf("%d\n", k);

  return 0;
}
