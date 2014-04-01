#include "testlib.h"

int used[100000];

int main(int argc, char ** argv)
{
  registerTestlibCmd(argc, argv);

  int n = inf.readInt();
  int c[n + 1];
  c[0] = 1;
  c[1] = 1;
  for (int i = 2; i <= n; ++i) {
    c[i] = 0;
    for (int j = 0; j <= i - 1; ++j)
      c[i] += c[j] * c[i - 1 - j];
  }
    
  int p[2][2*n];
  for (int i = 0; i < c[n]; ++i) {
    int b = 0;
    for (int j = 0; j < 2 * n; ++j) {
      char c = ouf.readChar();
      if (c != '(' && c != ')')
        quitf(_wa, "incorrect character in line #%d", i + 1);

      p[i & 1][j] = c == '(' ? -1 : 1;
      b += p[i & 1][j];
      if (b > 0)
        quitf(_wa, "sequence #%d is not balanced", i + 1);        
    }
    if (b != 0)
      quitf(_wa, "sequence #%d is not balanced", i + 1);        

    if (i) {
      int j;
      for (j = 0; j < 2 * n && p[0][j] == p[1][j]; ++j)
        ;
      if (j == 2 * n)
        quitf(_wa, "sequence #%d is the same as the sequence #%d", i + 1, i);

      if (p[i & 1][j] < p[1 - (i & 1)][j])
        quitf(_wa, "sequence #%d is less than the sequence #%d", i + 1, i);
    }
    ouf.nextLine();
  }

  quit(_ok, "");

  return 0;
}