#include "testlib.h"

using namespace std;

int main() {
    registerValidation();


    int p = 1;
    int n = inf.readInt(-1000, 1000);
    bool zero = false;

    while (!inf.eoln()) {
      inf.readSpace();
      p = n;
      n = inf.readInt(-1000, 1000);
      zero = zero || (p == 0 && n == 0);
    }
    inf.readEof();

    ensure(zero);

    return 0;
}
