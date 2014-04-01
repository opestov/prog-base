#include "testlib.h"

using namespace std;

int main()
{
    registerValidation();

    string a = inf.readLine();
    ensure(a.length() <= 100);
    for (int i = 0; i < a.length(); ++i) {
        ensure(static_cast<int>(a[i]) >= 32);
        ensure(static_cast<int>(a[i]) <= 126);
    }
    inf.readEof();

    return 0;
}
