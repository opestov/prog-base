#include "testlib.h"

using namespace std;

int main() {
    registerValidation();

    inf.readInt(-1000000, 1000000); inf.readEoln();
    inf.readEof();
    
    return 0;
}
