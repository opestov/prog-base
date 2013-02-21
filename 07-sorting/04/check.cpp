#include "testlib.h"

int main(int argc, char ** argv)
{
  registerTestlibCmd(argc, argv);

  int n = inf.readInt();
  int c[n], b[n], u[n];
  for (int i = 0; i < n; ++i) {
    c[i] = inf.readInt();
    b[i] = inf.readInt();
    u[i] = 0;
  }

  int pb = 801;
  int pc = 0;
  for (int i = 0; i < n; ++i) {
    int xc = ouf.readInt(1, 11);
    int xb = ouf.readInt(0, 800);
    int j = ouf.readInt(1, n)-1;
    ensure(c[j] == xc);
    ensure(b[j] == xb);
    ensure(u[j] == 0);
    ensure((pc < xc) || ((pc == xc) && (pb >= xb)));
    u[j] = 1;
    pb = xb;
    pc = xc;
  }

  quit(_ok, "");

  return 0;
}