System.Console.ReadLine()
|> Seq.sumBy(fun c -> int(c)-int('0'))
|> printf "%d\n"

