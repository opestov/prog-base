#include "testlib.h"
#include <algorithm>

using namespace std;

int main()
{
  registerValidation();

  int n = inf.readInt(1, 100000);
  inf.readEoln();

  int x[n], y[n], a[n];

  for (int i = 0; i < n; ++i) {
    x[i] = inf.readInt(-10000, 10000); inf.readSpace();
    y[i] = inf.readInt(-10000, 10000); inf.readEoln();
    a[i] = (y[i] + 10000) * 20001 + x[i] + 10000;
    ensure(x[i] || y[i]);
  }

  sort(a, a + n);
  for (int i = 1; i < n; ++i)
    ensure(a[i] != a[i - 1]);

  inf.readEof();

  return 0;
}
