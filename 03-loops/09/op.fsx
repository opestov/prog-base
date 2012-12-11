let n = System.Console.ReadLine() |> int
if n = 1 then
    printfn "%d\n" 1
else
    let a = System.Console.ReadLine().Split(' ') |> Array.map int
    printfn "%d\n" (n*(n+1)/2-Seq.sum(a))

