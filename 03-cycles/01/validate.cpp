#include "testlib.h"

using namespace std;

int main() {
    registerValidation();

    int a = inf.readInt(-10000, 10000); inf.readSpace();
    int b = inf.readInt(-10000, 10000); inf.readEoln();
    inf.readEof();

    ensure(a <= b);

    return 0;
}
