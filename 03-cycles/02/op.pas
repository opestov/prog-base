var i, s, n : integer;
begin
  read(n);
  s := 1;
  for i := 1 to n do
    s := 2 * s;
  writeln(s);
end.