var a, d1, m1, y1, d2, m2, y2 : integer;
begin
  read(d1, m1, y1, d2, m2, y2);
  a := y2 - y1;
  if m1 > m2 then
    a := a - 1;
  if (m1 = m2) and (d1 > d2) then
    a := a - 1;
  
  writeln(a);
end.