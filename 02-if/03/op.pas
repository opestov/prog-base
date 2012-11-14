var i, m : integer;
begin
  read(m);
  read(i);
  if i > m then m := i;
  read(i);
  if i > m then m := i;
  writeln(m);
end.