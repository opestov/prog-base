#include <stdio.h>
#include <inttypes.h>

int main() {
  int64_t r, x, t = 0, b = 0, a = 0;

  scanf("%" PRId64, &r);
  for (x = -r; x <= r; ++x) {
    while (x*x+t*t <= r*r) ++t;
    while (x*x+b*b <= r*r) --b;
    while (x*x+t*t > r*r) --t;
    while (x*x+b*b > r*r) ++b;
    a += t-b+1;
  }
  printf("%" PRId64 "\n", a);

  return 0;
}
