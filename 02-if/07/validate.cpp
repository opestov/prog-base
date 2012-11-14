#include "testlib.h"

using namespace std;

int main() {
    registerValidation();

    inf.readInt(1, 8); inf.readSpace();
    inf.readInt(1, 8); inf.readSpace();
    inf.readInt(1, 8); inf.readSpace();
    inf.readInt(1, 8); inf.readEoln();
    inf.readEof();
    
    return 0;
}
