#include "testlib.h"

using namespace std;

int main()
{
    registerValidation();

    string a = inf.readLine();
    ensure(a.length() <= 100);
    for (int i = 0; i < a.length(); ++i) {
        ensure(a[i] >= static_cast<int>('a'));
        ensure(a[i] <= static_cast<int>('z'));
    }
    inf.readEof();

    return 0;
}
