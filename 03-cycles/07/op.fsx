System.Console.ReadLine() |> ignore
System.Console.ReadLine().Split(' ')
|> Array.map int
|> Seq.filter (fun i -> i = 0)
|> Seq.length
|> printf "%d\n"

