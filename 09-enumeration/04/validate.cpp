#include "testlib.h"

using namespace std;

int main()
{
    registerValidation();

    int n = inf.readInt(1, 16); inf.readSpace();
    int k = inf.readInt(1, 16); inf.readEoln();
    inf.readEof();

    ensure(k <= n);

    return 0;
}
