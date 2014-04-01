#include "testlib.h"

int used[100000];

int main(int argc, char ** argv)
{
  registerTestlibCmd(argc, argv);

  int n = inf.readInt();
  int m = 1;
  for (int i = 1; i <= n; ++i)
    m *= i;

  int p[2][n];
  for (int i = 0; i < m; ++i) {
    int q = 0;
    int mask = 0;
    for (int j = 0; j < n; ++j) {
      p[i & 1][j] = ouf.readInt(1, n);
      mask |= 1 << (p[i & 1][j] - 1);

      int s = p[i & 1][j] - 1;
      for (int z = 0; z < j; ++ z)
        if (p[i & 1][z] < p[i & 1][j])
          --s;
      q = q * (n - j + 1) + s;
    }

    if (mask + 1 != 1 << n)
      quitf(_wa, "the sequence #%d is not a permutation", i + 1);

    if (used[q])
      quitf(_wa, "same sequences in lines #%d and #%d", used[q], i + 1);
    used[q] = i + 1;

    if (i) {
      int j;
      for (j = 0; j < n && p[0][j] == p[1][j]; ++j)
        ;
      if (j == n)
        quitf(_wa, "sequence #%d is the same as the previous one", i + 1);
      if (j == n - 1)
        quitf(_wa, "sequence #%d couldn't be produced from #%d by one transposition", i + 1, i);
      if (p[0][j] != p[1][j + 1] || p[0][j + 1] != p[1][j])
        quitf(_wa, "sequence #%d couldn't be produced from #%d by one transposition", i + 1, i);

      for (j = j + 2; j < n && p[0][j] == p[1][j]; ++j)
        ;
      if (j < n)
        quitf(_wa, "sequence #%d couldn't be produced from #%d by one transposition", i + 1, i);
    }
  }

  quit(_ok, "");

  return 0;
}