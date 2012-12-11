#include "testlib.h"

using namespace std;

int main()
{
    registerValidation();
    
    inf.readInt(1, 100, "n");
    inf.readEoln();
    inf.readEof();

    return 0;
}
