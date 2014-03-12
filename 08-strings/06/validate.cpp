#include "testlib.h"

using namespace std;

int main()
{
  registerValidation();

  string a = inf.readLine();

  ensure(a.length() <= 255);
  for (int i = 0; i < a.length(); ++i)
    ensure(a[i] >= 'a' && a[i] <= 'z');

  inf.readInt(1, 10);
  inf.readEoln();  
  inf.readEof();

  return 0;
}
