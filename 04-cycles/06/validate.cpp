#include "testlib.h"

using namespace std;

int main() {
    registerValidation();


    int n = inf.readInt(-1000, 1000);
    bool zero = n == 0;

    while (!inf.eoln()) {
      inf.readSpace();
      int n = inf.readInt(-1000, 1000);
      zero = zero || (n == 0);
    }
    inf.readEof();

    ensure(zero);

    return 0;
}
