var n, p, m : integer;
begin
  p := 1;
  read(n);
  m := 0;
  while (n <> 0) or (p <> 0) do
  begin
    m := m + n;
    p := n;
    read(n);
  end;
  writeln(m);
end.