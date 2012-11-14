var i : integer;
begin
  read(i);
  writeln(i + i mod 2 + 2 * (1 - i mod 2));
end.