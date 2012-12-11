let [|a; b|] = System.Console.ReadLine().Split(' ') |> Array.map int

let check n =
    let rec check n i d k =
        if i = 5 then k = 3
        elif n%10 = d then check (n/10) (i+1) d (k+1)
        else check (n/10) (i+1) d k
    {0..9}
    |> Seq.exists (fun x -> check n 1 x 0)

{a..b}
|> Seq.filter check
|> Seq.iter (fun i -> printf "%d\n" i)

