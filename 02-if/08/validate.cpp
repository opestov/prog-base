#include "testlib.h"

using namespace std;

int main() {
    registerValidation();

    int x1 = inf.readInt(-10000, 10000); inf.readSpace();
    int y1 = inf.readInt(-10000, 10000); inf.readSpace();
    int x2 = inf.readInt(-10000, 10000); inf.readSpace();
    int y2 = inf.readInt(-10000, 10000); inf.readSpace();
    int xp = inf.readInt(-10000, 10000); inf.readSpace();
    int yp = inf.readInt(-10000, 10000); inf.readEoln();
    inf.readEof();

    ensure(x1 < x2);
    ensure(y1 > y2);
    
    return 0;
}
