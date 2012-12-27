#include <algorithm>
#include "testlib.h"

using namespace std;

int a[1000];

int main()
{
    registerValidation();

    int n = inf.readInt(1, 1000);
    inf.readEoln();

    int a[n];
    for (int i = 0; i < n; ++i) {
      if (i) inf.readSpace();
      a[i] = inf.readInt(1, n);
    }
    inf.readEoln();
    inf.readEof();

    sort(a, a+n);
    for (int i = 0; i < n; ++i)
      ensure(a[i] == (i+1));

    return 0;
}
