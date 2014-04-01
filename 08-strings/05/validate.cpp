#include "testlib.h"

using namespace std;

int main()
{
  registerValidation();

  string a;
  for (int i = 0; i < 2; ++i) {
    a = inf.readLine();
    ensure(a.length() <= 255);
    for (int i = 0; i < a.length(); ++i)
      ensure(a[i] >= 'a' && a[i] <= 'z');
  }
  inf.readEof();

  return 0;
}
