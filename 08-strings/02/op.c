#include <stdio.h>

#define MAX 101

int main() {
  char s[MAX];
  fgets(s, MAX, stdin);

  char c = 'a';
  int ok = 1;
  for (int i = 0; ok && s[i] >= 'a' && s[i] <= 'z'; ++i) {
      if (s[i] != c) 
          ok = 0;
      ++c;
  }

  if (ok)
      printf("YES\n");
  else
      printf("NO\n");

  return 0;
}
