#include "testlib.h"

using namespace std;

bool u[101];

int main() {
    registerValidation();

    int n = inf.readInt(1, 100); inf.readEoln();
    for (int i = 0; i < n; ++i)
        u[i] = false;

    for (int i = 0; i < n-1; ++i) {
        if (i > 0)
            inf.readSpace();

        int x = inf.readInt(1, 100);
        ensure(!u[x]);
        u[x] = true;
    }
    inf.readEoln();
    inf.readEof();

    return 0;
}
