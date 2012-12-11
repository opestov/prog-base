var n, m : integer;
begin
  read(n);
  m := 0;
  while n <> 0 do
  begin
    m := m + n;
    read(n);
  end;
  writeln(m);
end.