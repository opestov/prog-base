#include <stdio.h>

int days[] = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

int main()
{
	int d, m, y;

	scanf("%d%d%d", &d, &m, &y);

	d += 2;

	if (y % 4 == 0 && y % 100 != 0 || y % 400 == 0)
		days[1] = 29;

	if (d > days[m - 1])
	{
		d %= days[m - 1];
		m++;
	}
	
	if (m > 12)
	{
		m %= 12;
		y++;
	}

	printf("%d %d %d\n", d, m, y);

	return 0;
}
