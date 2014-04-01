#include <stdio.h>

void solve(char *s)
{
  int n = 0;
  for (n = 0; s[n] != 0 && s[n] != '\n'; ++n)
    ;
  if (s[n] == '\n')
    s[n] = 0;

  int i, j;
  for (i = n - 2; i >= 0 && s[i] <= s[i + 1]; --i)
    ;

  if (i < 0) {
    printf("-1\n");
    return;
  }

  for (j = i + 1; j < n && s[j] < s[i]; ++j)
    ;
  --j;

  char c;

  c = s[i]; s[i] = s[j]; s[j] = c;
  if (i == 0 && s[i] == '0') {
    printf("-1\n");
    return;    
  }

  for (++i, j = n - 1; i < j; ++i, --j) {
    c = s[i]; s[i] = s[j]; s[j] = c;
  }
  printf("%s\n", s);
}

int main()
{
  const int LEN = 100;
  char s[LEN];
  while (fgets(s, LEN, stdin))
    solve(s);
  return 0;
}
