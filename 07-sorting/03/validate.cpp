#include "testlib.h"

using namespace std;

int main()
{
    registerValidation();

    int n = inf.readInt(1, 200);
    inf.readEoln();

    for (int i = 0; i < n; i++) {
        inf.readInt(0, 800);
        inf.readEoln();
    }

    inf.readEof();

    return 0;
}
