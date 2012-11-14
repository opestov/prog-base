#include "testlib.h"

using namespace std;

int main() {
    registerValidation();

    inf.readInt(1, 31); inf.readSpace();
    inf.readInt(1, 12); inf.readSpace();
    inf.readInt(1, 100000); inf.readEoln();
    inf.readInt(1, 31); inf.readSpace();
    inf.readInt(1, 12); inf.readSpace();
    inf.readInt(1, 100000); inf.readEoln();
    inf.readEof();
   
    return 0;
}
