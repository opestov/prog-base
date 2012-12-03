var i, n : integer;
begin
  read(n);
  i := 1;
  while (i * i <= n) do
  begin
    writeln(i * i);
    i := i + 1;
  end;
end.
