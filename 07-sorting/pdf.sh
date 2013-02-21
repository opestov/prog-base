#!/bin/sh

pandoc \
  -o content.tex \
  01/statement/rus.md \
  02/statement/rus.md \
  03/statement/rus.md \
  04/statement/rus.md \
  05/statement/rus.md \
  06/statement/rus.md \
  07/statement/rus.md \
  08/statement/rus.md \
  09/statement/rus.md \
  10/statement/rus.md

perl -i -0pe 's/\\ctable\[(.*)\]{(.*)}$/\\ctable[pos=H, botcap]{\2}/mg' content.tex
perl -i -0pe 's/\\ctable\[pos=H, botcap\]{([^|])}$/\\ctable[pos=H, botcap]{|\1|}/mg' content.tex
perl -i -0pe 's/\\ctable\[pos=H, botcap\]{([^|])([^|])}$/\\ctable[pos=H, botcap]{|\1|\2|}/mg' content.tex
perl -i -0pe 's/\\ctable\[pos=H, botcap\]{([^|])([^|])([^|])}$/\\ctable[pos=H, botcap]{|\1|\2|\3|}/mg' content.tex
perl -i -0pe 's/\\ctable\[pos=H, botcap\]{([^|])([^|])([^|])([^|])}$/\\ctable[pos=H, botcap]{|\1|\2|\3|\4|}/mg' content.tex
perl -i -0pe 's/\\\\\\noalign{\\medskip}/\\ML/mg' content.tex
perl -i -0pe 's/\\FL/\\hline/mg' content.tex
perl -i -0pe 's/\\ML/\\\\\\hline/mg' content.tex
perl -i -0pe 's/\\LL/\\\\\\hline/mg' content.tex
perl -i -0pe 's/} & \\parbox/\\smallskip} & \\parbox/mg' content.tex
perl -i -0pe 's/}\r?\n\\\\\\hline\r?/\\smallskip}\n\\\\\\hline/mg' content.tex
perl -i -0pe 's/parbox\[b\]\{/parbox\[t\]\{/mg' content.tex

pdflatex statements.tex
pdflatex statements.tex
rm content.tex
rm *.aux
rm *.log
