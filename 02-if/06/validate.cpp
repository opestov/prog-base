#include "testlib.h"

using namespace std;

int main() {
    registerValidation();

    int r = inf.readInt(1, 1000000000); inf.readSpace();
    int c = inf.readInt(1, 1000000000); inf.readSpace();
    int i = inf.readInt(1, 1000000000); inf.readSpace();
    int j = inf.readInt(1, 1000000000); inf.readEoln();
    inf.readEof();

    ensure(i <= r);
    ensure(j <= c);
    
    return 0;
}
