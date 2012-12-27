#include "testlib.h"

using namespace std;

int main()
{
    registerValidation();

    int n = inf.readInt(1, 10000);
    inf.readEoln();

    for (int i = 0; i < n; i++) {
        if (i > 0)
            inf.readSpace();
        inf.readInt(-1000000000, 1000000000);
    }

    inf.readEoln();
    inf.readEof();

    return 0;
}
