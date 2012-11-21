var i, s, x : integer;
begin
  s := 0;
  for i := 1 to 10 do
  begin
    read(x);
    s := s + x;
  end;
  writeln(s);
end.