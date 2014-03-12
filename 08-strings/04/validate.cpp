#include "testlib.h"

using namespace std;

int main()
{
    registerValidation();

    string a = inf.readLine();
    ensure(a.length() <= 255);
    for (int i = 0; i < a.length(); ++i)
        ensure(a[i] == ' ' || (a[i] >= 'a' && a[i] <= 'z') || (a[i] >= 'A' && a[i] <= 'Z'));
    inf.readEof();

    return 0;
}
