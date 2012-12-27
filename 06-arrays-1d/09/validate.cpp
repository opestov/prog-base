#include "testlib.h"

using namespace std;

int main()
{
    registerValidation();
    
    int n = inf.readInt(1, 1000, "n"); inf.readSpace();
    int a = inf.readInt(1, n, "a"); inf.readSpace();
    int b = inf.readInt(1, n, "b"); inf.readSpace();
    int c = inf.readInt(1, n, "c"); inf.readSpace();
    int d = inf.readInt(1, n, "d"); inf.readEoln();
    inf.readEof();

    ensure(a <= b);
    ensure(c <= d);

    return 0;
}
