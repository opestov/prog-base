var r, c, i, j : integer;
begin
  read(r, c, i, j);
  if i < r then writeln(i + 1, ' ', j);
  if i > 1 then writeln(i - 1, ' ', j);
  if j < c then writeln(i, ' ', j + 1);
  if j > 1 then writeln(i, ' ', j - 1);
end.