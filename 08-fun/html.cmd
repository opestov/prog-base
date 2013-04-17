pandoc -S -s -t html5 --section-divs ^
  --mathjax ^
  -c ../media/css/normalize.css -c ../media/css/style-statements.css ^
  -o statements.html ^
  01\statement\rus.md ^
  02\statement\rus.md ^
  03\statement\rus.md ^
  04\statement\rus.md ^
  05\statement\rus.md 
