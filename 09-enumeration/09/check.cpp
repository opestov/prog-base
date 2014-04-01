#include "testlib.h"

int used[100000];

int main(int argc, char ** argv)
{
  registerTestlibCmd(argc, argv);

  int n = inf.readInt();
  int k = inf.readInt();

  int z = 1;
  for (int i = 0; i < n; ++i)
    z *= k;

  int p[2][n];
  for (int i = 0; i < z; ++i) {
    int q = 0;
    for (int j = 0; j < n; ++j) {
      p[i & 1][j] = ouf.readInt(1, k);
      q = q * k + (p[i & 1][j] - 1);
    }

    if (used[q])
      quitf(_wa, "same sequences in lines %d and %d", used[q], i + 1);
    used[q] = i + 1;

    if (i) {
      q = 0;
      for (int j = 0; j < n; ++j)
        if (p[0][j] != p[1][j]) {
          ++q;
          if (q > 1)
            quitf(_wa, "sequence %d differs from the previous one in at least two positions", i + 1);
          if (p[0][j] - p[1][j] != 1 && p[1][j] - p[0][j] != 1)
            quitf(_wa, "sequence %d differs from the previous one in position %d by more than one", i + 1, j + 1);
        }
    }
  }

  quit(_ok, "");

  return 0;
}