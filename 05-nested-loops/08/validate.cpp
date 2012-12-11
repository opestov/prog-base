#include "testlib.h"

using namespace std;

int main()
{
    int a, b;

    registerValidation();
    
    a = inf.readInt(2, 100000, "a");
    inf.readSpace();
    b = inf.readInt(2, 100000, "b");
    ensure(a <= b);
    inf.readEoln();
    inf.readEof();

    return 0;
}
