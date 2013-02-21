#include "testlib.h"

int main(int argc, char ** argv)
{
  registerTestlibCmd(argc, argv);

  int n = inf.readInt();
  int a[n], u[n];
  for (int i = 0; i < n; ++i) {
    a[i] = inf.readInt();
    u[i] = 0;
  }

  int x = 801;
  for (int i = 0; i < n; ++i) {
    int j = ouf.readInt(1, n)-1;
    int v = ouf.readInt(0, 800);
    ensure(u[j] == 0);
    ensure(a[j] == v);
    ensure(v <= x);
    u[j] = 1;
    x = v;
  }

  quit(_ok, "");

  return 0;
}