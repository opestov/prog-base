#include "testlib.h"

using namespace std;

int main()
{
    registerValidation();
    
    inf.readInt(1, 1000000, "n");
    inf.readEoln();
    inf.readEof();

    return 0;
}
