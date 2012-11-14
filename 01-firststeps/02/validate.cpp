#include "testlib.h"

using namespace std;

int main() {
    registerValidation();

    inf.readInt(10, 99);
    inf.readEoln();
    inf.readEof();
    
    return 0;
}
