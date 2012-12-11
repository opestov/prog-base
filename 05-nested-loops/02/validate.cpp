#include "testlib.h"

using namespace std;

int main()
{
    registerValidation();
    
    inf.readInt(0, 9);
    inf.readEoln();
    inf.readEof();

    return 0;
}
