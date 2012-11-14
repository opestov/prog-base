#include "testlib.h"

using namespace std;

int main() {
    registerValidation();

    inf.readInt(0, 99); inf.readSpace();
    inf.readInt(0, 99); inf.readSpace();
    inf.readInt(0, 99); inf.readEoln();
    inf.readEof();
    
    return 0;
}
