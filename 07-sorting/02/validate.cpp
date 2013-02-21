#include "testlib.h"

using namespace std;

int main()
{
    registerValidation();

    int n = inf.readInt(1, 100);
    inf.readEoln();

    for (int i = 0; i < n; i++) {
      inf.readInt(1, 32000);
      inf.readEoln();
    }

    inf.readEof();

    return 0;
}
