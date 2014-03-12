#include "testlib.h"

using namespace std;

int main()
{
    registerValidation();

    char c = inf.readChar();
    inf.readEoln();

    ensure(c >= 32);
    ensure(c <= 116);

    return 0;
}
