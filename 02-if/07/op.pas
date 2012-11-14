var i1, j1, i2, j2 : integer;
begin
  read(i1, j1, i2, j2);
  if (i1 + j1) mod 2 = (i2 + j2) mod 2 then
    writeln('Yes')
  else
    writeln('No');
end.