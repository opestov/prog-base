#include "testlib.h"
#include <sstream>

int a[10], c[1024];

int main(int argc, char * argv[])
{
  registerTestlibCmd(argc, argv);

  int n = inf.readInt();
  while (!ouf.seekEof()) {
    int k = ouf.readInt(1, n);
    
    for (int i = 0; i < n; ++i)
      a[i] = 0;
    for (int i = 0; i < k; ++i) {
      int j = ouf.readInt(1, n) - 1;
      a[j]++;
    }
    
    int x = 0;
    for (int i = 0; i < n; ++i) {
      if (a[i] > 1)
        quit(_wa, "Same student appears more than once");
      x = x * 2 + a[i];
    }
    c[x]++;
  }

  for (int i = 1; i < (1 << n); ++i) {
    if (c[i] == 0)
      quitf(_wa, "Subset #%d not found", i);
    if (c[i] > 1)
      quitf(_wa, "Subset #%d appears more than once", i);
  }

  quit(_ok, "");
}


