#include "testlib.h"
#include <stdio.h>
#include <string.h>

int main(int argc, char * argv[])
{
  registerTestlibCmd(argc, argv);

  int n = inf.readInt();
  int a[n], b[n];
  for (int i = 0; i < n; ++i)
    a[i] = inf.readInt();
  for (int i = 0; i < n; ++i)
    b[i] = inf.readInt();

  int uj[n], up[n];
  memset(uj, 0, n*sizeof(int));
  memset(up, 0, n*sizeof(int));

  int js = 0, ps = 0, z = 0;
  for (int i = 0; i < n; ++i) {
    z = ans.readInt(1,n)-1;
    if (uj[z])
      quitf(_fail, "Incorrect jury answer: car %d appears more than once.", z+1);
    uj[z] = 1;
    js += a[i]*b[z];
  }
  for (int i = 0; i < n; ++i) {
    z = ouf.readInt(1,n)-1;
    if (up[z])
      quitf(_wa, "Incorrect answer: car %d appears more than once.", z+1);
    up[z] = 1;
    ps += a[i]*b[z];
  }

  if (ps < js)
    quitf(_fail, "Participant answer %d is better than jury answer %d", ps, js);
  if (js < ps)
    quitf(_wa, "Non-optimal distribution. Expected total cost is %d, but %d was found.", js, ps);
  quit(_ok, "");

  return 0;
}
