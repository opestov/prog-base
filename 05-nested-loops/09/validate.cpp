#include "testlib.h"

using namespace std;

int main()
{
    registerValidation();
    
    inf.readInt(2, 1000000000, "n");
    inf.readEoln();
    inf.readEof();

    return 0;
}
