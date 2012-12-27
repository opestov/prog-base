const MAXN = 100000;
var a : array[1..MAXN] of integer;
    i, j, p, r, n : integer;

begin
  read(n);
  for i := 1 to n do
    read(a[i]);

  j := 1;
  for i := 2 to n do
    if a[i] > a[j] then
      j := i;

  p := 0;
  for i := j + 1 to n - 1 do
    if (a[i] mod 10 = 5) and (a[i] > a[i + 1]) and (a[i] > p) then
      p := a[i];

  r := 0;
  for i := 1 to n do
    if a[i] > p then
      r := r + 1;
  if p = 0 then
    writeln(0)
  else
  writeln(r + 1);
end.
