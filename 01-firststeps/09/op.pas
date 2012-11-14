var a, b, c, n : integer;
begin
  read(a, b, n);
  c := (a * 100 + b) * n;
  writeln(c div 100, ' ', c mod 100);
end.