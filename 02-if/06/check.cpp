#include "testlib.h"
#include <stdio.h>

int main(int argc, char * argv[])
{
    registerTestlibCmd(argc, argv);

    int R = inf.readInt();
    int C = inf.readInt();
    int i = inf.readInt();
    int j = inf.readInt();

    int e = 0;
    if (j > 1) e += 1;
    if (j < C) e += 2;
    if (i > 1) e += 4;
    if (i < R) e += 8;

    int a = 0;
    while (!ouf.seekEof()) 
    {
      int r = ouf.readInt();
      int c = ouf.readInt();

      if (r < 1 || r > R || c < 1 || c > C)
        quitf(_wa, "cell (%d, %d) lays outside", r, c);

      int z = -1;
      if (r == i && c == j - 1) z = 1;
      if (r == i && c == j + 1) z = 2;
      if (c == j && r == i - 1) z = 4;
      if (c == j && r == i + 1) z = 8;

      if (z == -1)
        quitf(_wa, "cell (%d, %d) is not neighbor of cell original cell (%d, %d)", r, c, i, j);

      a += z;
    }

    if (a != e)
      quit(_wa, "some neighbor cells are missing");
    quit(_ok, "correct");
}
