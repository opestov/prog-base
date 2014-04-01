#include <stdio.h>

int main( void )
{
  int a, b;
  scanf("%d%d", &a, &b);
  if (a > b)
    printf("1\n");
  else if (a < b)
    printf("2\n");
  else
    printf("0\n");
  return 0;
}
