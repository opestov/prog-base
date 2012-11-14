var x1, y1, x2, y2, xp, yp : integer;
begin
  read(x1, y1, x2, y2, xp, yp);
  if (x1 <= xp) and (xp <= x2) and (y1 >= yp) and (yp >= y2) then
    writeln('Yes')
  else
    writeln('No');
end.