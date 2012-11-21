let n = System.Console.ReadLine() |> int

{1..n}
|> Seq.iter (fun i -> if n%i = 0 then printf "%d\n" i)

