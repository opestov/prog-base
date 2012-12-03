#include "testlib.h"

using namespace std;

int main() {
    registerValidation();

    inf.readInt(0, 1000000000);
    inf.readEoln();
    inf.readEof();

    return 0;
}
