let [|a; b|] = System.Console.ReadLine().Split(' ') |> Array.map int

let check i =
    let rec rev i j =
        if i = 0 then j
        else rev (i/10) (j*10+i%10)
    i = rev i 0

{a..b}
|> Seq.filter check
|> Seq.iter (fun i -> printf "%d\n" i)

