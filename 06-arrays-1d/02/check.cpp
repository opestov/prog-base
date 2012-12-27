#include "testlib.h"
#include <algorithm>
#include <sstream>

using namespace std;

int main(int argc, char * argv[])
{
  registerTestlibCmd(argc, argv);

  int n = inf.readInt();
  int a[n];
  for (int i = 0; i < n; ++i)
    a[i] = inf.readInt();

  int j = 0;
  for (int i = 1; i < n; ++i)
    if (a[i] < a[j])
      j = i;

  int k = a[0];
  a[0] = a[j];
  a[j] = k;
  sort(a+1, a+n);

  int b[n];
  for (int i = 0; i < n; ++i)
    b[i] = ouf.readInt();
  sort(b+1, b+n);
  
  for (int i = 0; i < n; ++i)
    if (a[i] != b[i])
      quitf(_wa, "");

  quitf(_ok, "%d numbers", n);

  return 0;
}
