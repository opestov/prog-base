var i : integer;
begin
  read(i);
  if i mod 400 = 0 then
    writeln('Yes')
  else if i mod 4 <> 0 then
    writeln('No')
  else if i mod 100 = 0 then
    writeln('No')
  else
    writeln('Yes');
end.