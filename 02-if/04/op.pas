var a, b, c : integer;
begin
  read(a, b, c);
  if (a + b > c) and (a + c > b) and (b + c > a) then
    writeln('Yes')
  else
    writeln('No');
end.