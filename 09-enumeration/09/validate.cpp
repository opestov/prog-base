#include "testlib.h"

using namespace std;

int main()
{
    registerValidation();

    int n = inf.readInt(1, 20); inf.readSpace();
    int k = inf.readInt(1, 20); inf.readEoln();
    inf.readEof();

    for (int i = 0, z = 1; i < n; ++i) {
      z *= k;
      ensure(z <= 10000);
    }

    return 0;
}
