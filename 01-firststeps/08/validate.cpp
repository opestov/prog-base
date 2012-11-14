#include "testlib.h"

using namespace std;

int main() {
    registerValidation();

    inf.readInt(100, 999); inf.readEoln();
    inf.readEof();
    
    return 0;
}
