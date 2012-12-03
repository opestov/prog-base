var i, k, n : integer;
begin
  read(n);
  i := 1;
  k := 0;
  while (i < n) do
  begin
    i := 2 * i;
    k := k + 1;
  end;
  writeln(k);
end.
