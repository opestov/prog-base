var a, b, c : integer;
begin
  read(a, b, c);
  if (a = b) and (b = c) then
    writeln(3)
  else if (a = b) or (a = c) or (b = c) then
    writeln(2)
  else
    writeln(0);
end.