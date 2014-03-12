#include <stdio.h>

#define MAX 257

int main() {
  char s[MAX];
  fgets(s, MAX, stdin);

  int n = 0;
  for (; s[n] && s[n] != '\n'; ++n)
    ;

  int ok = 1;
  for (int i = 0, j = n - 1; ok && (i < j);) {
    while (s[i] == ' ') ++i;
    while (j >= 0 && s[j] == ' ') --j;
    if (s[i++] != s[j--])
      ok = 0;
  }

  if (ok)
      printf("YES\n");
  else
      printf("NO\n");

  return 0;
}
