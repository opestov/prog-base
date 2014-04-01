#include "testlib.h"

using namespace std;

int main()
{
  registerValidation();

  string a = inf.readLine();
  ensure(a.length() <= 100);
  ensure(a[0] != '0');
  for (int i = 0; i < a.length(); ++i) {
    ensure(a[i] >= '0');
    ensure(a[i] <= '9');
  }
  inf.readEof();

  return 0;
}
