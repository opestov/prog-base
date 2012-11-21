#include "testlib.h"

using namespace std;

int main() {
    registerValidation();

    for (int i = 0; i < 10; ++i) {
      inf.readInt(-1000, 1000);
      if (i < 9)
        inf.readSpace();
      else
        inf.readEoln();
    }
    inf.readEof();

    return 0;
}
