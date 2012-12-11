System.Console.ReadLine() |> ignore
let (cur, best) =
    (System.Console.ReadLine() + " 1").Split(' ')
    |> Array.map int
    |> Seq.fold (
        fun (cur, best) i ->
            if i = 0 then (cur+1, best)
            elif cur > best then (0, cur)
            else (0, best)) (0, 0)

printf "%d\n" best

