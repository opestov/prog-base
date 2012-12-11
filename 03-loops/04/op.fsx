let n = System.Console.ReadLine() |> int

{1..n-1}
|> Seq.filter (fun i -> i%2 = 1)
|> Seq.sum
|> printf "%d\n"

