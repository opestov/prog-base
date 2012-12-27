#include "testlib.h"

using namespace std;

int main()
{
    registerValidation();
    
    int n = inf.readInt(3, 100000, "n"); inf.readEoln();
    for (int i = 0; i < n; ++i) {
      if (i) inf.readSpace();
      inf.readInt(1, 1000);
    }
    inf.readEoln();
    inf.readEof();

    return 0;
}
