var n, i, s, x : integer;
begin
  read(n);

  s := 0;
  for i := 1 to n do
  begin
    read(x);
    s := s + x;
  end;

  writeln(s);
end.