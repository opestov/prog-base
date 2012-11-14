var i, s : integer;
begin
  read(i);
  s := 0;
  while i > 0 do
  begin
    s := s + (i mod 10);
    i := i div 10;
  end;
  writeln(s);  
end.