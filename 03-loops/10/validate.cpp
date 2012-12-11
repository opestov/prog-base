#include "testlib.h"

using namespace std;

int main() {
    registerValidation();

    int a = inf.readInt(1000, 9999); inf.readSpace();
    int b = inf.readInt(1000, 9999); inf.readEoln();
    ensure(a <= b);
    inf.readEof();

    return 0;
}
